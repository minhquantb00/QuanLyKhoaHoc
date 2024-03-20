using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBaiViet;

namespace WebCourseManagement_Models.Converters
{
    public class LoaiBaiVietConverter
    {
        public DataResponseLoaiBaiViet EntityToDTO(LoaiBaiViet loaiBaiViet)
        {
            return new DataResponseLoaiBaiViet
            {
                Id = loaiBaiViet.Id,
                TenLoaiBaiViet = loaiBaiViet.TenLoaiBaiViet
            };
        }
    }
}
