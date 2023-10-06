using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Enums
{
    public enum AdisyonStatus
    {
        [Description("Açık")]
        Acik,
        [Description("Kapalı")]
        Kapali,
        [Description("İptal")]
        Iptal
    }
}
