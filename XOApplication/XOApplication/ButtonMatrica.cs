using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;

namespace XOApplication
{
    class ButtonMatrica:Matrica 
    {
        private System.Windows.Forms.Button[,] tabla; //matrica

        public ButtonMatrica(int dim):base(dim)
        {
            tabla = new System.Windows.Forms.Button[dimenzija, dimenzija];
        }

        public override void postaviZnak(string znak, int i, int j)
        {
            tabla[i,j].Text=znak;
        }

        public override string znak(int i, int j)
        {
            return tabla[i,j].Text;
        }

        public override void inicijalizuj() // izgled forme
        {
            tabla = new System.Windows.Forms.Button[dimenzija, dimenzija];
            for (int i = 0; i < dimenzija; i++)
            {
                for (int j = 0; j < dimenzija; j++)
                {
                    tabla[i, j] = new Button();
                    tabla[i, j].Text = PRAZNOPOLJE;
                    tabla[i, j].Width = 20;
                    tabla[i, j].Height = 30;
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
            Button kliknutaLabela = (Button)sender;
            string[] indeksi = kliknutaLabela.Name.Split(' ');

            int i = Convert.ToInt16(indeksi[0]);
            int j = Convert.ToInt16(indeksi[1]);
            // ako se unosi partija
            if (partijautoku)
            {
                if (kliknutaLabela.Text == PRAZNOPOLJE)
                {
                    brojPraznihPolja--;
                    if (X == true)
                    {
                        tabla[i, j].Text = "X";
                        partija.dodajPotez(i, j);
                        if (provera("X", i, j))
                        {
                            System.Windows.Forms.MessageBox.Show("X igrac je pobedio");
                            partijautoku = false;
                            partija.Rezultat = "1:0";
                            
                        }
                        else X = false;
                    }
                    else
                    {
                        tabla[i, j].Text = "O";
                        partija.dodajPotez(i, j);
                        if (provera("O", i, j))
                        {
                            System.Windows.Forms.MessageBox.Show("O igrac je pobedio");
                            partijautoku = false;
                            partija.Rezultat = "0:1";
                        }
                        else X = true;
                    }
                    if (brojPraznihPolja == 0 && partijautoku)
                    {
                        MessageBox.Show("Igra se zavrsila nereseno");
                        partijautoku = false;
                        partija.Rezultat = "1/2:1/2";
                    }
                    if (!partijautoku)
                    {
                        lista.Add(partija);
                        bindingpartije.Add(partija);
                        ispraznitablu();
                    }
                }
            }
            // ako korisnik analizira
            else if (analiza)
            { 
                if (kliknutaLabela.Text == PRAZNOPOLJE)
                {
                    brojPraznihPolja--;
                    if (X == true)
                    {
                        tabla[i, j].Text = "X";
                        listx.Add(new Tuple<int,int>(i, j));
                        //partija.dodajPotez(i, j);
                        if (provera("X", i, j))
                        {
                            System.Windows.Forms.MessageBox.Show("X igrac je pobedio");
                            analiza = false;
                        }
                        else X = false;
                    }
                    else
                    {
                        tabla[i, j].Text = "O";
                        listo.Add(new Tuple<int, int>(i,j));
                        //partija.dodajPotez(i, j);
                        if (provera("O", i, j))
                        {
                            System.Windows.Forms.MessageBox.Show("O igrac je pobedio");
                            analiza = false;
                        }
                        X = true;
                    }
                    if (brojPraznihPolja == 0 && analiza)
                    {
                        MessageBox.Show("Igra se zavrsila nereseno");
                        analiza = false;
                    }
                    if (!analiza)
                    {
                        //lista.Add(partija);
                        //bindingpartije.Add(partija);
                        //partija = new Partija();
                        ispraznitablu();
                    }
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
        //proverava da li je zavrsni niz postignut kroz niz polja u koje je ukljuceno polje poslednjeg poteza
        //dovoljno je da proverimo posle svakog odigranog poteza samo za okolinu poslednjeg polja
        public override bool provera(string znak, int i, int j) //moglo bi da se promeni da se sve radi u jednoj funkciji
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
            // System.Windows.Forms.MessageBox.Show("Glavna");
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
            //System.Windows.Forms.MessageBox.Show("Sporedna");
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

        public ref Button this[int i, int j]
        {
            get
            {
                return ref tabla[i, j];
            }
        }
    }
}
