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
        Admin =0,
        [Description("Ürün")]
        Ürün =1,
        [Description("Kullanıcı")]
        Kullanıcı =2,
        [Description("Porsiyon")]
        Porsiyon =3,
        [Description("Ürün Notları")]
        ÜrünNot =4,
        [Description("Ek Malzeme hareket")]
        EkMalzemeHareket =5,
        [Description("Ürün Grup")]
        ÜrünGrup =6,
        [Description("Ürün Birimleri")]
        Birimler = 7,
    }
}
