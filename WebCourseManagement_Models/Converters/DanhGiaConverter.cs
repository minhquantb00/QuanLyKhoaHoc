using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataDanhGia;

namespace WebCourseManagement_Models.Converters
{
    public class DanhGiaConverter
    {
        public DataResponseDanhGia EntityToDTO(DanhGia danhGia)
        {
            return new DataResponseDanhGia
            {
                Id = danhGia.Id,
                SoSao = danhGia.SoSao
            };
        }
    }
}
