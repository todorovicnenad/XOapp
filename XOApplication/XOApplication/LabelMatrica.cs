using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace XOApplication
{
    class LabelMatrica : Matrica
    {
        private System.Windows.Forms.Label[,] tabla;


        public LabelMatrica(int dim):base(dim)
        {
            tabla = new System.Windows.Forms.Label[dimenzija, dimenzija];
        }


        public override void postaviZnak(string znak, int i, int j)
        {
            tabla[i, j].Text = znak;
        }

        public override string znak(int i, int j)
        {
            return tabla[i, j].Text;
        }

        public override void inicijalizuj()
        {

            for (int i = 0; i < dimenzija; i++)
            {
                for (int j = 0; j < dimenzija; j++)
                {
                    tabla[i, j] = new Label();
                    tabla[i, j].Text = PRAZNOPOLJE;
                    tabla[i, j].Width = 10;
                    tabla[i, j].Height = 10;
                    tabla[i, j].Name = $"{i} {j}";
                    tabla[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    tabla[i, j].Dock = DockStyle.Fill;
                    tabla[i, j].BackColor = Color.White;
                    tabla[i, j].Padding = new Padding(3, 3, 3, 3);  
                }
            }
        }

        public override void tabla_click(object sender, EventArgs e)
        {
            Label kliknutaLabela = (Label)sender;
            string[] indeksi = kliknutaLabela.Name.Split(' ');

            int i = Convert.ToInt16(indeksi[0]);
            int j = Convert.ToInt16(indeksi[1]);
            if (kliknutaLabela.Text == PRAZNOPOLJE)
            {
                brojPraznihPolja--;
                if (X == true)
                {
                    tabla[i, j].Text = "X";
                    System.IO.File.AppendAllText("partije.txt", $"[{i},{j}] - ");
                    partija.dodajPotez(i, j);
                    if (provera("X", i, j))
                    {
                        System.Windows.Forms.MessageBox.Show("X igrac je pobedio");
                        System.IO.File.AppendAllText("partije.txt", " 1:0\n");
                        lista.Add(partija);
                        partija = new Partija();
                        ispraznitablu();
                        return;
                    }
                    X = false;
                }
                else
                {
                    tabla[i, j].Text = "O";
                    System.IO.File.AppendAllText("partije.txt", $"[{i},{j}]\n");
                    partija.dodajPotez(i, j);
                    if (provera("O", i, j))
                    {
                        System.Windows.Forms.MessageBox.Show("O igrac je pobedio");
                        System.IO.File.AppendAllText("partije.txt", " 0:1\n");
                        lista.Add(partija);
                        partija = new Partija();
                        ispraznitablu();
                        return;
                    }
                    X = true;
                }
                if(brojPraznihPolja==0)
                {
                    System.Windows.Forms.MessageBox.Show("Igra je zavrsena nereseno");
                    System.IO.File.AppendAllText("partije.txt","1/2 : 1/2\n");
                    ispraznitablu();
                }
            }
        }

        public override void ispraznitablu()
        {
            for (int i = 0; i < dimenzija; i++)
            {
                for (int j = 0; j < dimenzija; j++)
                {
                    tabla[i, j].Text = PRAZNOPOLJE;
                }
            }
        }

        public ref Label kontrola(int i, int j)
        {
            return ref tabla[i, j];
        }

        public override bool provera(string znak, int i, int j)
        {
            if (proveraglavnadijagonala(znak, i, j) || proverasporednadijagonala(znak, i, j)
            || proveravrsta(znak, i, j) || proverakolona(znak, i, j)) return true;
            return false;
        }

        public override bool proveraglavnadijagonala(string znak, int i, int j)
        {
            int duzina = 0;

            int maxj = Math.Max(j - MAXDUZINA, 0);
            int maxi = Math.Max(i - MAXDUZINA, 0);
            int minj = Math.Min(j + MAXDUZINA, dimenzija - 1);
            int mini = Math.Min(i + MAXDUZINA, dimenzija - 1);
            int j1 = j;
            int i1 = i;
           
            while (i1 >= maxi && j1 >= maxj && tabla[i1, j1].Text == znak)
            {
                duzina++;
                i1--;
                j1--;
            }
           
            i1 = i + 1;
            j1 = j + 1;
            while (i1 <= mini && j1 <= minj && tabla[i1, j1].Text == znak)
            {
                duzina++;
                i1++;
                j1++;
            }
           
            if (duzina >= MAXDUZINA) return true;
            return false;
        }

        public override bool proverasporednadijagonala(string znak, int i, int j)
        {
            int duzina = 0;

            int maxj = Math.Max(j - MAXDUZINA + 1, 0);
            int maxi = Math.Max(i - MAXDUZINA + 1, 0);
            int minj = Math.Min(j + MAXDUZINA - 1, dimenzija - 1);
            int mini = Math.Min(i + MAXDUZINA - 1, dimenzija - 1);
            int j1 = j;
            int i1 = i;
         
            while (i1 <= mini && j1 >= maxj && tabla[i1, j1].Text == znak)
            {
                duzina++;
                i1++;
                j1--;
            }
            
            i1 = i - 1;
            j1 = j + 1;
            while (i1 >= maxi && j1 <= minj && tabla[i1, j1].Text == znak)
            {

                duzina++;
                i1--;
                j1++;
            }
           
            if (duzina >= MAXDUZINA) return true;
            return false;
        }

        public override bool proveravrsta(string znak, int i, int j)
        {
            int duzina = 0;
            int maxj = (Math.Max(j - MAXDUZINA + 1, 0));
            int minj = (Math.Min(j + MAXDUZINA - 1, dimenzija - 1));
            int j1 = j;
            //System.Windows.Forms.MessageBox.Show("Vrsta");
            while (j1 >= maxj && tabla[i, j1].Text == znak)
            {
                duzina++;
                j1--;
            }
            j1 = j + 1;
            while (j1 <= minj && tabla[i, j1].Text == znak)
            {
                duzina++;
                j1++;
            }
            if (duzina >= MAXDUZINA) return true;
            return false;
        }

        public override bool proverakolona(string znak, int i, int j)
        {
            int duzina = 0;
            int maxi = Math.Max(i - MAXDUZINA + 1, 0);
            int mini = Math.Min(i + MAXDUZINA - 1, dimenzija - 1);
            int i1 = i;
            //System.Windows.Forms.MessageBox.Show("Kolona");
            while (i1 >= maxi && tabla[i1, j].Text == znak)
            {
                duzina++;
                i1--;
            }
            i1 = i + 1;
            while (i1 <= mini && tabla[i1, j].Text == znak)
            {
                duzina++;
                i1++;
            }
            if (duzina >= MAXDUZINA) return true;
            return false;
        }

        public ref Label this[int i, int j]
        {
            get
            {
                return ref tabla[i, j];
            }
        }
    }
}
