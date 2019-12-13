using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Request
{
   public class OrderRequest
    {
        public string Token { get; set; }

        public int PaymentTypeId { get; set; } = 1;
        public DateTime CargoDate { get; set; } = DateTime.Now;
        public DateTime? CargoArriveDate { get; set; }
        public bool? CargoArrived { get; set; } = false;

    }
}
