using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Handle.HandleGenerate
{
    public class GenerateCode
    {
        public static string GenerateBillCode()
        {
            string timeCode = DateTime.Now.ToString("yyyyMMddHHmmss");
            Random random = new Random();
            string result = random.Next(100000, 999999).ToString();
            string billCode = "MyBugs_" + timeCode + result;
            return billCode;
        }
    }
}
