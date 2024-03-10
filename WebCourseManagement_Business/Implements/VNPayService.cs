using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Repositories;
using WebCourseManagement_Repositories.HandleVNPayPayment;

namespace WebCourseManagement_Business.Implements
{
    public class VNPayService : IVNPayService
    {
        private readonly AppDbContext _context;
        private readonly VNPayLibrary pay;
        private readonly IConfiguration _configuration;
        private readonly AuthService _authService;
        public VNPayService(AppDbContext context, VNPayLibrary pay, IConfiguration configuration, AuthService authService)
        {
            _context = context;
            this.pay = pay;
            _configuration = configuration;
            _authService = authService;
        }
        public async Task<string> TaoDuongDanThanhToan(int hoaDonId, HttpContext httpContext, int id)
        {
            var hoaDon = await _context.hoaDonDangKies.SingleOrDefaultAsync(x => x.Id == hoaDonId);
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == id);
            if (nguoiDung.Id == hoaDon.NguoiDungId)
            {
                if (hoaDon.TrangThaiHoaDonId == 2)
                {
                    return "Hóa đơn đã được thanh toán trước đó";
                }
                if (hoaDon.TrangThaiHoaDonId == 1 && hoaDon.TongTien != 0 && hoaDon.TongTien != null)
                {
                    pay.AddRequestData("vnp_Version", "2.1.0");
                    pay.AddRequestData("vnp_Command", "pay");
                    pay.AddRequestData("vnp_TmnCode", "YIK14C5R");
                    pay.AddRequestData("vnp_Amount", (hoaDon.TongTien * 1000).ToString());
                    pay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
                    pay.AddRequestData("vnp_CurrCode", "VND");
                    pay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(httpContext));
                    pay.AddRequestData("vnp_Locale", "vn");
                    pay.AddRequestData("vnp_OrderInfo", $"Thanh toán hóa đơn: {hoaDonId}");
                    pay.AddRequestData("vnp_OrderType", "other");
                    pay.AddRequestData("vnp_ReturnUrl", _configuration.GetSection("VnPay:vnp_ReturnUrl").Value);
                    pay.AddRequestData("vnp_TxnRef", hoaDonId.ToString());

                    string duongDanThanhToan = pay.CreateRequestUrl(_configuration.GetSection("VnPay:vnp_Url").Value, _configuration.GetSection("VnPay:vnp_HashSecret").Value);
                    return duongDanThanhToan;
                }

                return "Vui lòng kiểm tra lại hóa đơn";
            }
            return "Vui lòng kiểm tra lại thông tin người thanh toán";
        }

        public async Task<string> VNPayReturn(IQueryCollection vnpayData)
        {
            string vnp_TmnCode = _configuration.GetSection("VnPay:vnp_TmnCode").Value;
            string vnp_HashSecret = _configuration.GetSection("VnPay:vnp_HashSecret").Value;

            VNPayLibrary vnPayLibrary = new VNPayLibrary();
            foreach (var (key, value) in vnpayData)
            {
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    vnPayLibrary.AddResponseData(key, value);
                }
            }

            string hoaDonId = vnPayLibrary.GetResponseData("vnp_TxnRef");
            string vnp_ResponseCode = vnPayLibrary.GetResponseData("vnp_ResponseCode");
            string vnp_TransactionStatus = vnPayLibrary.GetResponseData("vnp_TransactionStatus");
            string vnp_SecureHash = vnPayLibrary.GetResponseData("vnp_SecureHash");
            double vnp_Amount = Convert.ToDouble(vnPayLibrary.GetResponseData("vnp_Amount"));
            bool check = vnPayLibrary.ValidateSignature(vnp_SecureHash, vnp_HashSecret);

            if (check)
            {
                if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                {
                    var hoaDon = await _context.hoaDonDangKies.FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(hoaDonId));

                    if (hoaDon == null)
                    {
                        return "Không tìm thấy hóa đơn";
                    }

                    hoaDon.TrangThaiHoaDonId = 2;
                    hoaDon.ThoiGianTao = DateTime.Now;

                    var user = _context.nguoiDungs.FirstOrDefault(x => x.Id == hoaDon.NguoiDungId);
                    if (user != null)
                    {
                        string email = user.Email;
                        string mss = _authService.SendEmail(new EmailTo
                        {
                            To = email,
                            Subject = $"Thanh Toán đơn hàng: {hoaDon.Id}",
                            Content = "Bạn đã mua khóa học thành công! Từ bây giờ bạn có thể học tập tại đây"
                        });
                    }
                    KhoaHocCuaNguoiDung khoaHocCuaNguoiDung = new KhoaHocCuaNguoiDung
                    {
                        DaHoanThanh = false,
                        KhoaHocId = hoaDon.KhoaHocId,
                        PhanTramHoanThanh = 0,
                        ThoiGianDangKy = DateTime.Now,
                        NguoiDungId = hoaDon.NguoiDungId,
                    };
                    _context.khoaHocCuaNguoiDungs.Add(khoaHocCuaNguoiDung);
                    _context.SaveChanges();
                    return "Giao dịch thành công đơn hàng " + hoaDon.Id;
                }
                else
                {
                    return $"Lỗi trong khi thực hiện giao dịch. Mã lỗi: {vnp_ResponseCode}";
                }
            }
            else
            {
                return "Có lỗi trong quá trình xử lý";
            }
        }
    }
}
