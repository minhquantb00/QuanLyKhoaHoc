using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.RequestModels.BannerRequest
{
    public class Request_TaoBanner
    {
        public IFormFile AnhBanner { get; set; }
    }
}
