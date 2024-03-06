using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.RequestModels.AuthRequests
{
    public class Request_RenewToken
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
