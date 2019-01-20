using System;
using System.Collections.Generic;
using System.Text;

namespace Giver.Tests.Model
{
    public class OrderLine
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}
