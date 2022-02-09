using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.General
{
    /// <summary>
    /// Example : (IRepository)HttpContext.Current.RequestServices.GetService(typeof(IRepository));
    /// </summary>
    public static class HttpContextStatic
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static Microsoft.AspNetCore.Http.HttpContext Current
        {
            get { return _httpContextAccessor.HttpContext; }
        }

        internal static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
