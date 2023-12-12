using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisApplicatie
{
    // public declareren om te kunnen gebruiken
    public class Vlucht
    {
        // twee eigenschappen: naam en prijs delcareren
        public string name { get; set; }
        public double price { get; set; }

        // basis constructor (niet echt nodig)
        public Vlucht() 
        {
            
        }

        // constructor met naam en prijs parameters
        public Vlucht(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        // toString overschrijven om in het juiste formaat te tonen in de listbox
        public override string ToString()
        {
            // geeft de naam en dan de prijs met juiste scheidingsteken en decimalen
            return $"{this.name} - {this.price: € #,##0.00}";
        }
    }
}
