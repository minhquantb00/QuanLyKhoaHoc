using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBanner;

namespace WebCourseManagement_Models.Converters
{
    public class BannerConverter
    {
        public DataResponseBanner EntityToDTO(Banner banner)
        {
            return new DataResponseBanner
            {
                Id = banner.Id,
                AnhBanner = banner.AnhBanner
            };
        }
    }
}
