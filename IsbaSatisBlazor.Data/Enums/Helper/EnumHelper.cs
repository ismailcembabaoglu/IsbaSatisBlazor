using IsbaSatisBlazor.Data.Models;
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
        public static string GetDescription<T>(this T enumValue)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }


        //public static List<NameValue> EnumToList<T>()
        //{
        //    var array = (T[])(Enum.GetValues(typeof(T)).Cast<T>());
        //    var array2 = Enum.GetNames(typeof(T)).ToArray<string>();
            
        //    List<NameValue> lst = null;
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (lst == null)
        //            lst = new List<NameValue>();
        //        string name = array2[i];
        //        T value = array[i];
        //        lst.Add(new NameValue { Name = name, Id = Convert.ToInt32(value) });
        //    }
        //    return lst;
        //}
    }
}
