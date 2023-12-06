using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Enums
{
    public enum RoleType
    {
        [Description("Admin")]
        admin =0,
        [Description("Ürün")]
        product =1,
        [Description("Kullanıcı")]
        user =2,
        [Description("Porsiyon")]
        portion =3,
        [Description("Ürün Notları")]
        productNote =4,
        [Description("Ek Malzeme hareket")]
        supplementaryMeterial =5,
        [Description("Ürün Grup")]
        productGroup =6,

    }
}
