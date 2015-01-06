using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookDemo.Models
{
    public class CoffeeTableBook : Book
    {
        public override double Price
        {
            get
            {
                return base.Price;
            }
            set
            {
                if (value >= 35 && value <= 100)
                    base.Price = value;
                //else
                //    throw new Exception("Price should be between $35.00 and $100.00");
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
