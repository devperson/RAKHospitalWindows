using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookDemo.Models
{
    public class TextBook : Book
    {
        public int GradeLevel { get; set; }

        public override double Price
        {
            get
            {
                return base.Price;
            }
            set
            {
                if (value >= 20 && value <= 80)
                    base.Price = value;
                //else
                //    throw new Exception("Price should be between $20.00 and $80.00");
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
