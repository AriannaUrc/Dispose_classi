using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispose_classi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Esempio esempio = new Esempio();

            Console.WriteLine("valore stringa: " + esempio.Stringa);
            Console.WriteLine("valore numero: " + esempio.Numero);

            Console.WriteLine("\nChiamiamo la funzione dispose...");
            esempio.Dispose();


            Console.WriteLine("\nChiamiamo nuovamente la funzione dispose...");
            esempio.Dispose();
        }
    }


    class Esempio
    {
        //classe esempio, string e double..? get e set, costruttori distruttore, writeline in dispose
        //attributi
        private string stringa;
        private double numero;
        private bool disposed = false;


        //costruttore con paramentri
        public Esempio(double valore1, string string1)
        {
            numero = valore1;
            stringa = string1;
        }

        //costruttore senza parametri
        public Esempio()
        {
            numero = 0;
            stringa = "vuoto";
        }


        //set e get stringa
        public string Stringa
        {
            get { return stringa; }
            set { stringa = value; }
        }


        //set e get double
        public double Numero
        {
            get { return numero; }
            set { numero = value; }
        }


        //metodo Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        //aree virtuali
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                Console.WriteLine("la risorsa è già stata cancellata...");
                return;
            }
                

            if (disposing)
            {
                // rilascia le risorse gestite qui (qual'ora ci fossero)
                Console.WriteLine("sta cancellando...");
            }
            // rilascia le risorse non gestite qui (qual'ora ci fossero)

            disposed = true;
        }

        //Distruttore (generalmente non è necessario/usato in C#)
        ~Esempio()
        {
            Dispose(false);
        }
    }
}
