using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Common
{
    public static class CommonMethod
    {
        public static string ComputeSha512Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA512 shaM = new SHA512Managed())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = shaM.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }



        }
    }
}
