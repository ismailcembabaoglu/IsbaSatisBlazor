﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Utils
{
    public class PasswordEncrypter
    {
        public static String Encrypt(String Password)
        {
            // Kendi algoritmanızı kullanabilirsiniz.
            // Ben Base64 olarak kullanıyorum


            var plainTextBytes = Encoding.UTF8.GetBytes(Password);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
