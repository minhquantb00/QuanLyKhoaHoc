using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataThucHanh;

namespace WebCourseManagement_Models.Converters
{
    public class ThucHanhConverter
    {
        public DataResponseThucHanh EntityToDTO(ThucHanh thucHanh)
        {
            return new DataResponseThucHanh
            {
                CallTestCode = thucHanh.CallTestCode,
                ChiTietDeBai = thucHanh.ChiTietDeBai,
                CodeDauVao = thucHanh.CodeDauVao,
                CodeKhoiDau = thucHanh.CodeKhoiDau,
                DeBai = thucHanh.DeBai,
                GiaiThich = thucHanh.DeBai,
                GoiY = thucHanh.GoiY,
                MongDoiDauRa = thucHanh.MongDoiDauRa
            };
        }
    }
}
