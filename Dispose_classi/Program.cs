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

            Console.WriteLine("Inserire valore stringa: ");
            esempio.Stringa = Console.ReadLine();

            Console.WriteLine("Inserire valore numero: ");
            esempio.Numero = int.Parse(Console.ReadLine());


            Console.WriteLine("\n\nvalore stringa: " + esempio.Stringa);
            Console.WriteLine("valore numero: " + esempio.Numero);
            GC.Collect();

            Console.WriteLine("\n\n\nChiamiamo la funzione dispose...");
            esempio.Dispose();

            Console.WriteLine("\n\nChiamiamo nuovamente la funzione dispose...");
            esempio.Dispose();

            
        }
    }


    class Esempio : IDisposable
    {
        //classe esempio, string e double..? get e set, costruttori distruttore, writeline in dispose
        //attributi
        private string stringa;
        private int numero;
        private bool disposed;


        //costruttore con paramentri
        public Esempio(int valore1, string string1)
        {
            numero = valore1;
            stringa = string1;
            disposed = false;
        }

        //costruttore senza parametri
        public Esempio()
        {
            numero = 0;
            stringa = "vuoto";
            disposed = false;
        }


        //set e get stringa
        public string Stringa
        {
            get { return stringa; }
            set { stringa = value; }
        }


        //set e get double
        public int Numero
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
            Console.WriteLine("dispose");
        }
    }

    class EsempioEsteso : Esempio
    {
        double decimale;
        private bool disposed;

        public EsempioEsteso()
        {
            decimale = 0;
        }
        public EsempioEsteso(double val)
        {
            decimale = val;
        }

        public double Decimale
        {
            get { return decimale; }
            set { decimale = value; }
        }


        //aree virtuali
        protected virtual void DisposeEsteso(bool disposing)
        {
            if (disposed)
            {
                Console.WriteLine("EX: la risorsa è già stata cancellata...");
                return;
            }


            if (disposing)
            {
                // rilascia le risorse gestite qui (qual'ora ci fossero)
                Console.WriteLine("EX: sta cancellando...");
            }
            // rilascia le risorse non gestite qui (qual'ora ci fossero)

            disposed = true;
        }

        //Distruttore (generalmente non è necessario/usato in C#)
        ~EsempioEsteso()
        {
            DisposeEsteso(false);
            Console.WriteLine("EX: dispose");
        }
    }
}
