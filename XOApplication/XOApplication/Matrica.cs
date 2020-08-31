using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace XOApplication
{
    //Pokusao sam da u formi imam matricu labela i matricu buttona, pa sam uporedjivao
    //ta 2, zbog cega mi je bila potrebna enkapsulacija preko apstraktne klasa matrica koja moze da bude 
    //matrica labela ili matrica buttona
    abstract class Matrica
    {
        public int dimenzija;   //dimenzija matrica(ako se igra menja)
        public bool partijautoku = false;   //provera da li je unos partije u toku (dugme Pocni)
        public bool analiza = false;
        public string PRAZNOPOLJE = "";
        public int MAXDUZINA = 5;  //duzina niza simbola potrebna za pobedu
        public int brojPraznihPolja;
        public bool X = true;    //odredjuje ko je na potezu
        public Partija partija = new Partija(); //trenutna partija na tabli
        public List<Partija> lista=new List<Partija>();
        public BindingList<Partija> bindingpartije = new BindingList<Partija>();
        public List<MyTuple<int, int>> listx=new List<MyTuple<int, int>>(); //pozicije x-eva na tabli
        public List<MyTuple<int, int>> listo=new List<MyTuple<int, int>>(); //pozicije o-eva na tabli

        public Matrica(int dim)
        {
            dimenzija = dim;
            brojPraznihPolja = dimenzija * dimenzija;
        }

        public abstract void tabla_click(object sender, EventArgs e); //klik na tablu
        public abstract bool provera(string znak,int i, int j);  //proverava da li je postignut niz od 5 simbola
        public abstract bool proveraglavnadijagonala(string znak, int i, int j); //podfunjcija prethodne funkcije
        public abstract bool proverasporednadijagonala(string znak, int i, int j); // -||-
        public abstract bool proveravrsta(string znak, int i, int j); //-||-
        public abstract bool proverakolona(string znak, int i, int j); // -||-
        public abstract void postaviZnak(string znak, int i, int j);
        public abstract string znak(int i, int j);
        public abstract void inicijalizuj(); //inicijalizacuje formu
        public abstract void ispraznitablu();
        
    }
}
