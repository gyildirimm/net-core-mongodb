using Core.Utilities.Helpers.General;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.Auth
{
    public class SharedIdentityHelper : ISharedIdentityHelper
    {
        private IHttpContextAccessor _httpContextAccessor;

        public SharedIdentityHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("NameIdentifier").Value;

        public List<string> GetUserRoles => _httpContextAccessor.HttpContext.User.FindAll("Roles").Select(s => s.Value).ToList();
    }
}
