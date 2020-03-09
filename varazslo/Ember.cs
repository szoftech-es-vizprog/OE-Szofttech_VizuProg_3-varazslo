using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varazslo
{
    class Ember
    {
        string nev;
        int elet = 100;
        int ero;
        int varazsero;

        public Ember( string nev, int ero, int varazsero = 0) {
            this.Ero = ero;
            this.Nev = nev;
            this.Varazsero = varazsero;
        }

        public int MaxEro {
            get => this.Varazsero + this.Ero;
        }

        public void Sebzodott(int sebzes) {
            this.Elet = this.Elet - sebzes;
        }

        public string Nev { get => nev; set => nev = value; }
        public int Elet { get => elet; set => elet = value; }
        public int Ero { get => ero; set => ero = value; }
        public int Varazsero { get => varazsero; set => varazsero = value; }
    }
    
    class Varazslo : Ember
    {

        int varazsero;

        public Varazslo(Ember ember, int varazsero) : base(ember.Nev, ember.Ero)
        {
            this.Varazsero = varazsero;
        } 

        public int Varazsero { get => varazsero; set => varazsero = value; }
    }
    
}
