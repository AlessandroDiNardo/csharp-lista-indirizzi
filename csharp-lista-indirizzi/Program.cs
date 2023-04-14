using System.Diagnostics.Metrics;
using System.Net;

namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Indirizzo> indirizzi = new List<Indirizzo>();

                //Utilizzo di using per fare in modo che capisca in autonomia quando chiudere il file
                using (StreamReader inputstream = File.OpenText("addresses.csv"))
                {
                    // Leggi la prima riga che contiene i nomi dei campi
                    string primaRiga = inputstream.ReadLine();

                    // Leggi le righe successive contenenti gli indirizzi
                    while (!inputstream.EndOfStream)
                    {
                        string riga = inputstream.ReadLine();

                        // Dividi la riga in un array di valori
                        string[] valori = riga.Split(',');

                        // Verifica se ci sono informazioni mancanti sull'indirizzo e avverte l'utente all'inizio dell'esecuzione
                        if (valori.Length < 6)
                        {
                            Console.WriteLine("Attenzione: controllare l'output per vedere quali campi sono mancanti.");
                            continue;
                        }

                        // Verifica se ci sono valori mancanti e in caso vengono sostituiti con una stringa predefinita
                        string name = string.IsNullOrWhiteSpace(valori[0]) ? "[Nome-mancante]" : valori[0];
                        string cognome = string.IsNullOrWhiteSpace(valori[1]) ? "[Cognome-mancante]" : valori[1];
                        string street = string.IsNullOrWhiteSpace(valori[2]) ? "[Indirizzo-mancante]" : valori[2];
                        string city = string.IsNullOrWhiteSpace(valori[3]) ? "[Città-mancante]" : valori[3];
                        string province = string.IsNullOrWhiteSpace(valori[4]) ? "[Provincia-mancante]" : valori[4];
                        string zip = string.IsNullOrWhiteSpace(valori[5]) ? "[CAP-mancante]" : valori[5];

                        // Creazione lista con tutte le varie parti
                        Indirizzo indirizzo = new Indirizzo(name, cognome, street, city, province, zip);
                        indirizzi.Add(indirizzo);
                    }
                }

                // Stampa gli indirizzi nella lista
                int counter = 1;
                foreach (Indirizzo indirizzo in indirizzi)
                {
                    Console.WriteLine("" +
                        $"User {counter++} - " +
                        $"{indirizzo.Name}, " +
                        $"{indirizzo.Surname}, " +
                        $"{indirizzo.Street}, " +
                        $"{indirizzo.City}, " +
                        $"{indirizzo.Province}, " +
                        $"{indirizzo.ZIP}.");
                }
            }
            //messaggio di errore in caso ci sia un problema con il try
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}