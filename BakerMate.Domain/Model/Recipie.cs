﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.Domain.Model
{
    public class Recipie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseIngredientId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
