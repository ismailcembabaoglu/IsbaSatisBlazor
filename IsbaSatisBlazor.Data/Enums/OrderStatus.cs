using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Enums
{
    public enum OrderStatus
    {
        [Description("Hazırlanıyor")]
        Hazirlaniyor,
        [Description("Servise Hazır")]
        ServiseHazir,
        [Description("Servis Edildi")]
        ServisEdildi
    }
}
