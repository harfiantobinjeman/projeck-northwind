using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Dto.Product
{
    public class OrderDetailForCreateDto
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public virtual OrderDto OrderDto { get; set; }

        public virtual ProductDto Product { get; set; }

        public virtual ICollection<ProductDto> Products { get; set; }
    }
}
