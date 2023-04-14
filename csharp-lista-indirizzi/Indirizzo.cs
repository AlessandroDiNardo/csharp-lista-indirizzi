using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    internal class Indirizzo
    {
        // Proprietà in solo lettura
        public string Name { get; }
        public string Surname { get; }
        public string Street { get; }
        public string City { get; }
        public string Province { get; }
        public string ZIP { get; }

        // Costruttore
        public Indirizzo(string name, string surname, string street, string city, string province, string zip)
        {
            // Assegna i valori delle proprietà con i parametri del costruttore
            Name = name;
            Surname = surname;
            Street = street;
            City = city;
            Province = province;
            ZIP = zip;
        }
    }
}
