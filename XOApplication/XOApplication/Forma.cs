using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace XOApplication
{
    public partial class Forma : Form
    {
        private static readonly int dimenzija = 10;
        private ButtonMatrica tabla = new ButtonMatrica(dimenzija);

        private Partija trenutna;
        private int potez = 0;
        private bool X;
        private static readonly string PRAZNOPOLJE = "";
        private int pocetnaDuzinaForme;
        private int pocetnaVisinaForme;
        private Dictionary<Control, Tuple<int, int>> kontroledimenzije = new Dictionary<Control, Tuple<int, int>>();
        private Dictionary<Control, Tuple<int, int>> kontrolelokacija = new Dictionary<Control, Tuple<int, int>>();
        string statusnova="Partija u toku";
        string statusPregledPartije = "Pregled partije";
        string statusAnaliza = "Analiza";
        string statusPretragaPoPoziciji = "Pretraga po poziciji";
        string statusPretragaPoIgracu = "Pretraga po igracu";
        string regime = "^[a-zA-Z]+$"; //pri unosu partija imena igraca se moraju sastojati od slova i bez razmaka
        List<TextBox> novapartijaimena = new List<TextBox>();

        //podesavanja oko izgleda i funkcije forme
        public Forma()
        {
            
            InitializeComponent();
            tablaForma.Controls.Clear();
            tablaForma.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tabla.inicijalizuj();
            for (int i = 0; i < tabla.dimenzija; i++)
            {
                for (int j = 0; j < tabla.dimenzija; j++)
                {
                    tabla[i, j].Click += new System.EventHandler(tabla.tabla_click);
                    tablaForma.Controls.Add(tabla[i, j], j, i);
                }
            }

            citajpartije();
            listBoxPartije.DataSource = tabla.bindingpartije;
            
            foreach (Control c in Controls)
            {
                c.Anchor = AnchorStyles.None;
                kontroledimenzije.Add(c, new Tuple<int, int>(c.Width, c.Height));
                kontrolelokacija.Add(c, new Tuple<int, int>(c.Location.X, c.Location.Y));
            }
            pocetnaDuzinaForme = Width;
            pocetnaVisinaForme = Height;
            Resize += new System.EventHandler(promenaVelicine);
            buttonObrisi_Click(new Object(), new EventArgs());

            novapartijaimena.Add(textBoxImeX);
            novapartijaimena.Add(textBoxPrezimeX);
            novapartijaimena.Add(textBoxImeO);
            novapartijaimena.Add(textBoxPrezimeO);
        }


        public void promenaVelicine(object sender, EventArgs e)
        {

            double a1 = Width * 1.0 / pocetnaDuzinaForme;
            double b1 = Height * 1.0 / pocetnaVisinaForme;

            foreach (Control c in Controls)
            {
                c.Location = new Point(Convert.ToInt16(a1 * kontrolelokacija[c].Item1),Convert.ToInt16(b1 * kontrolelokacija[c].Item2));
                //c.Width =Convert.ToInt16(a1* c.Width ); //-- menjanje velicine na ovaj nacin je izuzetno sporo
                //c.Height = Convert.ToInt16(b1 * c.Height);
            }

        }

        //citanje partija iz fajla pri startovanju forme
        //redovi u fajlu se dele na 3 slucaja-potez, ishod i imena igraca 
        public void citajpartije()
        {
            try
            {
                XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Partija>));
                StreamReader file = new StreamReader("partije.xml");
                tabla.lista = (List<Partija>)reader.Deserialize(file);
                file.Close();
            }
            catch(SerializationException e)
            {
                MessageBox.Show("Neuspesna serijalizacija\n",e.Source);
                throw;
            }
            

            foreach (Partija p in tabla.lista)
            {
                if (p.Rezultat != "1:0" && p.Rezultat != "0:1" && p.Rezultat != "1/2:1/2") throw new InvalidDataException("Nekorektno uneta partija");
                else if (p.Rezultat == "1:0" && p.BrojPoteza % 2 == 0) throw new InvalidDataException("Nekorektno uneta partija");
                else if (p.Rezultat == "0:1" && p.BrojPoteza % 2 == 1) throw new InvalidDataException("Nekorektno uneta partija");
                else if (p.Rezultat == "1/2:1/2" && p.BrojPoteza != dimenzija * dimenzija) throw new InvalidDataException("Nekorektno uneta partija");
                tabla.bindingpartije.Add(p);
            }
                
        }

        //klik na dugme Pocni
        private void buttonPocni_Click(object sender, EventArgs e)
        {
            
            foreach (TextBox t in novapartijaimena)
            {
                if (!Regex.IsMatch(t.Text, regime))
                {
                    MessageBox.Show("Imena i prezimena mogu sadrzati samo slova\nPokusajte ponovo");
                    buttonObrisi_Click(new object(),new EventArgs());
                    return;
                }
            }
            tabla.partija = new Partija(textBoxImeX.Text,textBoxPrezimeX.Text,textBoxImeO.Text,textBoxPrezimeO.Text);
            tabla.ispraznitablu();
            Statuslabel.Text= statusnova;
            tabla.partijautoku = true;
            buttonAnaliza.Enabled = false;
            buttonPretragaPoPoziciji.Enabled = false;
            buttonPretraga.Enabled = false;
            
        }


        //klik na dugme << za vracanje poteza
        private void buttonNazad_Click(object sender, EventArgs e)
        {
            if (Statuslabel.Text==statusAnaliza || Statuslabel.Text==statusPregledPartije)
            {
                if (Statuslabel.Text==statusPregledPartije)//ako se pregleda partija iz listboxa
                {
                    if (potez > 0)
                    {
                        potez--;
                        int i = trenutna[potez].Item1;
                        int j = trenutna[potez].Item2;
                        tabla[i, j].Text = PRAZNOPOLJE;
                    }
                }
                else if(Statuslabel.Text==statusAnaliza)//ako se analizira partija
                {
                    int n = tabla.listx.Count + tabla.listo.Count;
                    if (n > 0)//ako je broj poteza>0
                    {
                        int i = -1, j = -1;
                        if(n%2==1)//brise poslednji x potez
                        {
                            i = tabla.listx[(n-1) / 2 ].Item1;
                            j = tabla.listx[(n-1) / 2 ].Item2;
                            tabla.listx.RemoveAt((n-1)/2);
                           
                        }
                        else//brise poslednji o potez
                        {
                            i = tabla.listo[(n-2) / 2 ].Item1;
                            j = tabla.listo[(n-2) / 2 ].Item2;
                            tabla.listo.RemoveAt((n-2)/2);
                        }
                        tabla[i, j].Text = PRAZNOPOLJE;
                        tabla.X = !tabla.X;//sledeci simbol je razlicit
                    }
                }
                /*else if(tabla.partijautoku && tabla.partija.BrojPoteza>0) -moze se doraditi i za ovaj rezim
                {
                    int i = tabla.partija.Potezi[tabla.partija.BrojPoteza - 1].Item1;
                    int j = tabla.partija.Potezi[tabla.partija.BrojPoteza - 1].Item2;
                    tabla.partija.Potezi.RemoveAt(tabla.partija.BrojPoteza - 1);
                    tabla[i, j].Text = PRAZNOPOLJE;
                    tabla.X = !tabla.X;
                }*/
            }
        }

        //klik na dugme >> za sledeci potez
        private void buttonNapred_Click(object sender, EventArgs e)
        {
            if ( Statuslabel.Text==statusPregledPartije && trenutna.BrojPoteza >potez)
            {
                int i = trenutna[potez].Item1;
                int j = trenutna[potez].Item2;
                if (potez % 2 == 0) X = true;
                else X = false;
                if (X) tabla[i, j].Text = "X";
                else tabla[i, j].Text = "O";
                X = !X;
                potez++;
            }
        }

        //promena partije koja se pregleda-klik na item u listboxu
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //MessageBox.Show("Selektovana Partija" + listBox1.SelectedIndex + listBox1.Items.Count);
           
            if (listBoxPartije.SelectedIndex >= 0)
            {
                
                Statuslabel.Text = statusPregledPartije;
                tabla.partijautoku = false;
                X = true;
                trenutna = tabla.bindingpartije[listBoxPartije.SelectedIndex];
                textBoxImeX.Text = trenutna.imeX;
                textBoxPrezimeX.Text = trenutna.prezimeX;
                textBoxImeO.Text = trenutna.imeO;
                textBoxPrezimeO.Text = trenutna.prezimeO;
                tabla.ispraznitablu();
                potez = 0;
            }
        }

        //klik na dugme obrisi-vraca sve promenljive na njihovu pocetnu vrednost
        private void buttonObrisi_Click(object sender, EventArgs e)
        {
            if (tabla.partijautoku)
                tabla.partijautoku = false;
            Statuslabel.Text = "";
            buttonAnaliza.Enabled = true;
            buttonPocni.Enabled = true;
            buttonPretraga.Enabled = true;
            buttonPretragaPoPoziciji.Enabled = false;
            tabla.analiza = false;
            tabla.ispraznitablu();
            tabla.X = true;
            textBoxImeO.Text = "";
            textBoxImeX.Text = "";
            textBoxPrezimeO.Text = "";
            textBoxPrezimeX.Text = "";
            foreach (Partija p in tabla.lista)
            {
                if (!listBoxPartije.Items.Contains(p))
                {
                    tabla.bindingpartije.Add(p);
                }
            }
            tabla.listx.Clear();
            tabla.listo.Clear();
        }

        //klik na dugme Pretraga, pretrazuje partije po igracima
        private void buttonPretraga_Click(object sender, EventArgs e)
        {
            string ime = textBoxImePretraga.Text;
            string prezime = textBoxPrezimePretraga.Text;
            string regimepretraga = "^[a-zA-Z]*$";

            if (!Regex.IsMatch(ime,regimepretraga) || !Regex.IsMatch(prezime,regimepretraga))
            {
                MessageBox.Show("Imena i prezimena mogu sadrzati samo slova\nPokusajte ponovo");
                return;
            }
            Statuslabel.Text =statusPretragaPoIgracu;
            tabla.bindingpartije.Clear();
            tabla.partijautoku = false;
            tabla.analiza=false;
            buttonPretragaPoPoziciji.Enabled = false;
            buttonAnaliza.Enabled = false;
            buttonPocni.Enabled = false;
         
            foreach (Partija p in tabla.lista)
            {
                if ((p.imeX.StartsWith(ime) && p.prezimeX.StartsWith( prezime))
                || (p.imeO.StartsWith( ime) && p.prezimeO.StartsWith(prezime)))
                {
                    tabla.bindingpartije.Add(p);
                }
            }
        }

        //klik na dugme pretraga po poziciji, trazi partije sa trenutnom pozicijom u analizi
        private void buttonPretragaPoPoziciji_Click(object sender, EventArgs e)
        {
            if(tabla.analiza)
            {
                Statuslabel.Text = statusPretragaPoPoziciji;
                tabla.bindingpartije.Clear();
                
                foreach(Partija p in tabla.lista)
                {
                    if (istapozicija(p))
                    {
                        tabla.bindingpartije.Add(p);
                    }
                }
            }
        }

        //proverava da li je u partiji p doslo do pozicije koja je trenutno na tabli
        private bool istapozicija (Partija p)
        {
            int n = tabla.listx.Count + tabla.listo.Count;
            for (int i=0;i<n;i++)
            {
                bool f = false;
                if(i%2==0)
                    for(int j=0;j<tabla.listx.Count;j++)
                    {
                        if (tabla.listx[j].Item1 == p[i].Item1 && tabla.listx[j].Item2 == p[i].Item2) f = true;
                     
                    }
                else
                    for (int j = 0; j < tabla.listo.Count; j++)
                    {
                        if (tabla.listo[j].Item1 == p[i].Item1 && tabla.listo[j].Item2 == p[i].Item2) f = true;
                       
                    }
                if (!f) return false;

            }
            return true;
        }

        //klik na dugme analiza-ulazi u rezim za analiziranje
        private void buttonAnaliza_Click(object sender, EventArgs e)
        {
            
            Statuslabel.Text= statusAnaliza;
            buttonPocni.Enabled = false;
            buttonPretraga.Enabled = false;
            buttonPretragaPoPoziciji.Enabled = true;
            tabla.listx = new List<MyTuple<int, int>>();
            tabla.listo = new List<MyTuple<int, int>>();
            tabla.analiza= true;
            

        }

        private void savetoolStripButton_Click(object sender, EventArgs e)
        {
            /*if (Statuslabel.Text != statusUToku)
                return;
            saveFileDialog.FileName ="partije.xml";
            saveFileDialog.Filter = "xml files (.xml) | *.xml";
            DialogResult res = saveFileDialog.ShowDialog();
            if (res != DialogResult.OK)
                return;*/
            try
            {
                var writer = new XmlSerializer(typeof(List<Partija>));
                var wfile = new StreamWriter("partije.xml");
                writer.Serialize(wfile, tabla.lista);
                wfile.Close();
                MessageBox.Show("Nove partije su dodate");
            }
            catch(SerializationException u)
            {
                MessageBox.Show("Neuspesna serijalizacija",u.Source);
            }

        }

        private void opentoolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void saveFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void NewSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {


        }

        
    }
}
