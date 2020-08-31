using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace XOApplication
{
    [Serializable]
    public class Partija
    {
        public List<MyTuple<int, int>> Potezi;
        public string imeX, prezimeX, imeO, prezimeO;
        public string Rezultat;
       
        public Partija()
        {
            Potezi = new List<MyTuple<int, int>>();
        }

        public Partija(List<MyTuple<int,int>> l)
        {
            Potezi = l;
        }

        public Partija(string imeX, string prezimeX, string imeO, string prezimeO)
        {
            this.imeX = imeX;
            this.prezimeX = prezimeX;
            this.imeO = imeO;
            this.prezimeO = prezimeO;
            Potezi = new List<MyTuple<int, int>>();
        }

        public Partija (string Xigrac, string Oigrac)
        {
            string[] niz1 = Xigrac.Split(' ');
            string[] niz2 = Oigrac.Split(' ');
            imeX = niz1[0];
            prezimeX = niz1[1];
            prezimeO = niz2[1];
            imeO = niz2[0];
            Potezi = new List<MyTuple<int, int>>();
        }

       public Partija(Partija p)
        {
            imeX = p.imeX;
            imeO = p.imeO;
            prezimeO = p.prezimeO;
            prezimeX = p.prezimeX;
            Rezultat = p.Rezultat;
            Potezi = p.Potezi;
        }

        

        public MyTuple<int, int> this[int i]
        {
            get
            {
                return Potezi[i];
            }
        }
        public int BrojPoteza
        {
            get
            {
                return Potezi.Count;
            }
        }

        public void dodajPotez(MyTuple<int, int> p)
        {
            Potezi.Add(p);
            
        }

        public void dodajPotez(int k1,int k2)
        {
            Potezi.Add(new MyTuple<int, int>(k1,k2));
        }

        public void dodajPotez(int x1, int x2, int o1, int o2)
        {
            dodajPotez(x1, x2);
            dodajPotez(o1,o2);
        }

        public  override string ToString()
        {
            return prezimeX + " " + imeX + " & " + prezimeO + " " + imeO;
        }
        
        public int brojPoteza()
        {
            return Potezi.Count;
        }
      
    }
}
