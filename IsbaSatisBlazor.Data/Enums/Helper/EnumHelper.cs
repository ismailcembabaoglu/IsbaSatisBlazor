using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Enums.Helper
{
    public static class EnumHelper
    {
        public static string GetEnumDescription<T>(T enumValue)
        {
            string enumDescription = "";
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    enumDescription = ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumDescription;
        }
    }
}
