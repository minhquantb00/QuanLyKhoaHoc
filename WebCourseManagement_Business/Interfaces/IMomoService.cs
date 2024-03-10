using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.ResponseModels;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IMomoService
    {
        Task CreatePaymentAsync(int hoaDonId);
        MomoExcuteResponseModel PaymentExcuteAsync(IQueryCollection collection);
    }
}
