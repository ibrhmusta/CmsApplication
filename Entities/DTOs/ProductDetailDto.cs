using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductDetailDto
    {
        public Product Product { get; set; }
        public string CategoryName { get; set; }
    }
}
