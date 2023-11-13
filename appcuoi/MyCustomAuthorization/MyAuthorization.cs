using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace appcuoi.MyCustomAuthorization
{
    public class MyAuthorization : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            
        }
    }
}
