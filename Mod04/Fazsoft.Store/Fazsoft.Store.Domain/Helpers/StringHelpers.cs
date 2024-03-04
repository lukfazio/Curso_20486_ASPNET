using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.Domain.Helpers
{
    public static class StringHelpers
    {
        public static string Encrypt(this string senha)
        {
            var salt = "BEF544A2-D627-494E-A01E-A380AA606093";
            var password = Encoding.UTF8.GetBytes(senha + salt);

            using (var sha = SHA512.Create())
            {
                password = sha.ComputeHash(password);
            }
            return Convert.ToBase64String(password);
        }
    }
}
