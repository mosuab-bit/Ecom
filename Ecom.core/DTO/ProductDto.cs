using Ecom.core.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecom.core.DTO
{
    public record ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PhotoDto> Photos { get; set; } = new List<PhotoDto>();
        public decimal PriceTotal { get; set; }
        public string CategoryName { get; set; }
    }

    public record PhotoDto
    {
        public string ImageName { get; set; }
        public int ProductId { get; set; }
    }
}
