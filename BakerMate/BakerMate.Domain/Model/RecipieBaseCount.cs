using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.Domain.Model
{
    public class RecipieBaseCount
    {
        public int Id { get; set; }
        public int RecipieId { get; set; }
        public double BaseCount { get; set; }
        public int Size { get; set; }

    }
}
