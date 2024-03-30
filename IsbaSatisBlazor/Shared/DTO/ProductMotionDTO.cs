using IsbaSatisBlazor.Data.Enums;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Shared.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.DTO
{
    public class ProductMotionDTO : ModelBaseDTO
    {
        public ProductMotionType ProductMotionType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SupplementaryMaterialPrice { get; set; }
        public decimal SupplementaryMaterialUnitPrice { get { return UnitPrice + SupplementaryMaterialPrice; } }
        public decimal Sale { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return (Amount * SupplementaryMaterialUnitPrice) - ((Amount * SupplementaryMaterialUnitPrice) / 100 * Sale);
            }
        }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }

        public Guid PortionId { get; set; }
        public string PortionName { get; set; }
        public decimal PortionPrice { get; set; }
        public String? UnitName { get; set; }

        public Guid AdisyonId { get; set; }
        public string? CustomerName { get; set; }
        public string? DeskName { get; set; }


    }
}
