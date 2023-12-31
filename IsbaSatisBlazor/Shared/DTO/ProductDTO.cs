﻿using IsbaSatisBlazor.Shared.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.DTO
{
    public class ProductDTO:ModelBaseDTO
    {
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string? Photo { get; set; }
        public Guid ProductGroupId { get; set; }
        public string? GroupName { get; set; }
    }
}
