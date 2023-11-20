using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.Domain.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public string CustomerNumber { get; set; }
        public string OrderDescription { get; set; }
        public DateOnly OrderingDate { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public bool Delivered { get; set; }
        public double Price { get; set; }
        public double Revenue { get; set; }
        public List<OrderRecipe> OrderRecipes { get; set; }

    }
}
