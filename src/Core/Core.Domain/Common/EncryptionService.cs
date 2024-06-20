using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
//using Org.BouncyCastle.Utilities.Encoders;
using System.Threading.Tasks;

namespace Core.Domain.Common
{
    public class EncryptionService
    {

        private readonly EncryptionSettings _encryptionSettings;


        public EncryptionService(IOptions<EncryptionSettings> encryptionSettings)
        {
            _encryptionSettings = encryptionSettings.Value;
        }

      
        public string Encryptword(string Encryptval)
        {
            var encodedStr = Base64UrlEncoder.Encode(Encryptval);
            return encodedStr;
            //  byte[] SrctArray;
            //va EnctArray = Base64UrlEncoder.Encode(Encryptval);
            //  SrctArray = UTF8Encoding.UTF8.GetBytes(_encryptionSettings.Key);
            //  TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();
            //  MD5CryptoServiceProvider objcrpt = new MD5CryptoServiceProvider();
            //  SrctArray = objcrpt.ComputeHash(UTF8Encoding.UTF8.GetBytes(_encryptionSettings.Key));
            //  objcrpt.Clear();
            //  objt.Key = SrctArray;
            //  objt.Mode = CipherMode.ECB;
            //  objt.Padding = PaddingMode.PKCS7;
            //  ICryptoTransform crptotrns = objt.CreateEncryptor();
            //  byte[] resArray = crptotrns.TransformFinalBlock(EnctArray, 0, EnctArray.Length);
            //  objt.Clear();
            //  var encodedStr = (StringToEncode);
            //  var decodedStr = Base64UrlEncoder.Decode(encodedStr);
            //  return Convert.ToBase64String(resArray, 0, resArray.Length);
        }
        public string Decryptword(string DecryptText)
        {
            var decodedStr = Base64UrlEncoder.Decode(DecryptText);
            return decodedStr;
            //byte[] SrctArray;
            //byte[] DrctArray = Convert.FromBase64String(DecryptText);
            //SrctArray = UTF8Encoding.UTF8.GetBytes(_encryptionSettings.Key);
            //TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();
            //MD5CryptoServiceProvider objmdcript = new MD5CryptoServiceProvider();
            //SrctArray = objmdcript.ComputeHash(UTF8Encoding.UTF8.GetBytes(_encryptionSettings.Key));
            //objmdcript.Clear();
            //objt.Key = SrctArray;
            //objt.Mode = CipherMode.ECB;
            //objt.Padding = PaddingMode.PKCS7;
            //ICryptoTransform crptotrns = objt.CreateDecryptor();
            //byte[] resArray = crptotrns.TransformFinalBlock(DrctArray, 0, DrctArray.Length);
            //objt.Clear();
            //return UTF8Encoding.UTF8.GetString(resArray);
        }
        public class EncryptionSettings
        {
            public string Key { get; set; }
            public string IV { get; set; }
        }
    }
}
