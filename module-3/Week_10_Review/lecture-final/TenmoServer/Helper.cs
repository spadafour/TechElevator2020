using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TenmoServer
{
    public static class Helper
    {
        public static int? GetUserID(this ClaimsPrincipal user)
        {
            string userId = user.FindFirst("sub")?.Value;
            if (string.IsNullOrWhiteSpace(userId)) return null;
            int.TryParse(userId, out int userIdInt);
            return userIdInt;

        }
    }
}
