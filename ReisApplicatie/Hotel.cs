using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisApplicatie
{
    // public definiëren om te kunnen gebruiken
    public class Hotel
    {
        // twee eigenschappen declareren, de naam en de prijs
        public string name { get; set; }
        public double price { get; set; }

        // basis constructor (hier niet echt nodig)
        public Hotel() 
        {
        
        }

        // constructor met naam en prijs parameters
        public Hotel(string name, double price) 
        {
            this.name = name;
            this.price = price;
        }

        // toString functie overschrijven
        public override string ToString()
        {
            // laat de naam zien en dan de prijs met het juiste scheidingsteken
            // voor de duizendtallen en met exact twee decimalen
            return $"{this.name} - {this.price: € #,##0.00}";
        }
    }
}
