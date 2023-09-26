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
        }
    }


    class Esempio
    {
        //classe esempio, string e double..? get e set, costruttori distruttore, writeline in dispose
        //attributi
        private string es_string;
        private double es_double;
        private bool disposed = false;


        //costruttore con paramentri
        public Esempio(double valore1, string string1)
        {
            es_double = valore1;
            es_string = string1;
        }

        //costruttore senza parametri
        public Esempio()
        {
            es_double = 0;
            es_string = "vuoto";
        }


        //set e get stringa
        public string Es_string
        {
            get { return es_string; }
            set { es_string = value; }
        }


        //set e get double
        public string Es_double
        {
            get { return es_string; }
            set { es_string = value; }
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
                return;

            if (disposing)
            {
                // rilascia le risorse gestite qui (qual'ora ci fossero)
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
