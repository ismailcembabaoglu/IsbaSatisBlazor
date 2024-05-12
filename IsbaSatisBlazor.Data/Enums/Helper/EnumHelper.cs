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
        public static List<KeyValuePair<string, int>> GetEnumDescriptionAndValues<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T is not Enum");

            var result = new List<KeyValuePair<string, int>>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                var field = e.GetType().GetField(e.ToString());
                var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

                result.Add(new KeyValuePair<string, int>((attributes.Length > 0) ? attributes[0].Description : e.ToString(), (int)e));
            }

            return result;
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
