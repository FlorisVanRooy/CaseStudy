using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisApplicatie
{
    public class Vlucht
    {
        public string name { get; set; }
        public double price { get; set; }

        public Vlucht() 
        {
            
        }

        public Vlucht(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public override string ToString()
        {
            return $"{this.name} - {this.price: € #,##0.00}";
        }
    }
}
