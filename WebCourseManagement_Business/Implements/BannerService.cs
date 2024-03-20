using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.Converters;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.RequestModels.BannerRequest;
using WebCourseManagement_Models.ResponseModels.DataBanner;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandleImage;

namespace WebCourseManagement_Business.Implements
{
    public class BannerService : IBannerService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseBanner> _responseObject;
        private readonly BannerConverter _converter;
        public BannerService(AppDbContext context, ResponseObject<DataResponseBanner> responseObject, BannerConverter converter)
        {
            _context = context;
            _responseObject = responseObject;
            _converter = converter;
        }

        public async Task<ResponseObject<DataResponseBanner>> TaoBanner(Request_TaoBanner request)
        {
            if(request.AnhBanner == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng chọn ảnh banner", null);
            }
            Banner banner = new Banner
            {
                AnhBanner = await HandleUploadImage.Upfile(request.AnhBanner)
            };
            _context.banners.Add(banner);
            _context.SaveChanges();
            return _responseObject.ResponseSuccess("Tạo banner thành công", _converter.EntityToDTO(banner));
        }
    }
}
