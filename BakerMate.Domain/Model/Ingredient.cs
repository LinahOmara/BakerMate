using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.Domain.Model
{
    public  class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string PurchaseLocation { get; set; }
        public int UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public bool IsDeleted { get; set; }

    }
}
