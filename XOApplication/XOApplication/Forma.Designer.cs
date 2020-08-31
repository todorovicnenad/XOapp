namespace XOApplication
{
    partial class Forma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forma));
            this.tablaForma = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxPartije = new System.Windows.Forms.ListBox();
            this.textBoxImeX = new System.Windows.Forms.TextBox();
            this.textBoxPrezimeO = new System.Windows.Forms.TextBox();
            this.textBoxPrezimeX = new System.Windows.Forms.TextBox();
            this.textBoxImeO = new System.Windows.Forms.TextBox();
            this.buttonPocni = new System.Windows.Forms.Button();
            this.buttonNazad = new System.Windows.Forms.Button();
            this.buttonNapred = new System.Windows.Forms.Button();
            this.buttonObrisi = new System.Windows.Forms.Button();
            this.textBoxImePretraga = new System.Windows.Forms.TextBox();
            this.textBoxPrezimePretraga = new System.Windows.Forms.TextBox();
            this.buttonPretraga = new System.Windows.Forms.Button();
            this.labelIme = new System.Windows.Forms.Label();
            this.labelPrezime = new System.Windows.Forms.Label();
            this.labelXIme = new System.Windows.Forms.Label();
            this.labelPrezimeX = new System.Windows.Forms.Label();
            this.labelImeO = new System.Windows.Forms.Label();
            this.labelPrezimeO = new System.Windows.Forms.Label();
            this.buttonPretragaPoPoziciji = new System.Windows.Forms.Button();
            this.buttonAnaliza = new System.Windows.Forms.Button();
            this.Statuslabel = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.savetoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablaForma
            // 
            this.tablaForma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tablaForma.AutoSize = true;
            this.tablaForma.ColumnCount = 10;
            this.tablaForma.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.Location = new System.Drawing.Point(424, 63);
            this.tablaForma.Name = "tablaForma";
            this.tablaForma.RowCount = 10;
            this.tablaForma.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaForma.Size = new System.Drawing.Size(601, 330);
            this.tablaForma.TabIndex = 21;
            this.tablaForma.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // listBoxPartije
            // 
            this.listBoxPartije.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxPartije.FormattingEnabled = true;
            this.listBoxPartije.ItemHeight = 16;
            this.listBoxPartije.Location = new System.Drawing.Point(0, 145);
            this.listBoxPartije.Name = "listBoxPartije";
            this.listBoxPartije.Size = new System.Drawing.Size(256, 404);
            this.listBoxPartije.TabIndex = 12;
            this.listBoxPartije.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // textBoxImeX
            // 
            this.textBoxImeX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxImeX.Location = new System.Drawing.Point(1093, 41);
            this.textBoxImeX.Name = "textBoxImeX";
            this.textBoxImeX.Size = new System.Drawing.Size(100, 22);
            this.textBoxImeX.TabIndex = 0;
            // 
            // textBoxPrezimeO
            // 
            this.textBoxPrezimeO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrezimeO.Location = new System.Drawing.Point(1208, 131);
            this.textBoxPrezimeO.Name = "textBoxPrezimeO";
            this.textBoxPrezimeO.Size = new System.Drawing.Size(100, 22);
            this.textBoxPrezimeO.TabIndex = 3;
            // 
            // textBoxPrezimeX
            // 
            this.textBoxPrezimeX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrezimeX.Location = new System.Drawing.Point(1208, 41);
            this.textBoxPrezimeX.Name = "textBoxPrezimeX";
            this.textBoxPrezimeX.Size = new System.Drawing.Size(100, 22);
            this.textBoxPrezimeX.TabIndex = 1;
            // 
            // textBoxImeO
            // 
            this.textBoxImeO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxImeO.Location = new System.Drawing.Point(1093, 131);
            this.textBoxImeO.Name = "textBoxImeO";
            this.textBoxImeO.Size = new System.Drawing.Size(100, 22);
            this.textBoxImeO.TabIndex = 2;
            // 
            // buttonPocni
            // 
            this.buttonPocni.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPocni.Location = new System.Drawing.Point(1208, 190);
            this.buttonPocni.Name = "buttonPocni";
            this.buttonPocni.Size = new System.Drawing.Size(108, 55);
            this.buttonPocni.TabIndex = 4;
            this.buttonPocni.Text = "Pocni";
            this.buttonPocni.UseVisualStyleBackColor = true;
            this.buttonPocni.Click += new System.EventHandler(this.buttonPocni_Click);
            // 
            // buttonNazad
            // 
            this.buttonNazad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonNazad.Location = new System.Drawing.Point(306, 416);
            this.buttonNazad.Name = "buttonNazad";
            this.buttonNazad.Size = new System.Drawing.Size(52, 38);
            this.buttonNazad.TabIndex = 14;
            this.buttonNazad.Text = "<<";
            this.buttonNazad.UseVisualStyleBackColor = true;
            this.buttonNazad.Click += new System.EventHandler(this.buttonNazad_Click);
            // 
            // buttonNapred
            // 
            this.buttonNapred.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonNapred.Location = new System.Drawing.Point(1093, 416);
            this.buttonNapred.Name = "buttonNapred";
            this.buttonNapred.Size = new System.Drawing.Size(52, 38);
            this.buttonNapred.TabIndex = 15;
            this.buttonNapred.Text = ">>";
            this.buttonNapred.UseVisualStyleBackColor = true;
            this.buttonNapred.Click += new System.EventHandler(this.buttonNapred_Click);
            // 
            // buttonObrisi
            // 
            this.buttonObrisi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonObrisi.Location = new System.Drawing.Point(1208, 280);
            this.buttonObrisi.Name = "buttonObrisi";
            this.buttonObrisi.Size = new System.Drawing.Size(108, 55);
            this.buttonObrisi.TabIndex = 5;
            this.buttonObrisi.Text = "Obrisi";
            this.buttonObrisi.UseVisualStyleBackColor = true;
            this.buttonObrisi.Click += new System.EventHandler(this.buttonObrisi_Click);
            // 
            // textBoxImePretraga
            // 
            this.textBoxImePretraga.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxImePretraga.Location = new System.Drawing.Point(87, 38);
            this.textBoxImePretraga.Name = "textBoxImePretraga";
            this.textBoxImePretraga.Size = new System.Drawing.Size(100, 22);
            this.textBoxImePretraga.TabIndex = 9;
            // 
            // textBoxPrezimePretraga
            // 
            this.textBoxPrezimePretraga.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrezimePretraga.Location = new System.Drawing.Point(87, 93);
            this.textBoxPrezimePretraga.Name = "textBoxPrezimePretraga";
            this.textBoxPrezimePretraga.Size = new System.Drawing.Size(100, 22);
            this.textBoxPrezimePretraga.TabIndex = 10;
            // 
            // buttonPretraga
            // 
            this.buttonPretraga.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPretraga.Location = new System.Drawing.Point(248, 41);
            this.buttonPretraga.Name = "buttonPretraga";
            this.buttonPretraga.Size = new System.Drawing.Size(75, 59);
            this.buttonPretraga.TabIndex = 11;
            this.buttonPretraga.Text = "Pretraga po igracu";
            this.buttonPretraga.UseVisualStyleBackColor = true;
            this.buttonPretraga.Click += new System.EventHandler(this.buttonPretraga_Click);
            // 
            // labelIme
            // 
            this.labelIme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIme.AutoSize = true;
            this.labelIme.Location = new System.Drawing.Point(12, 38);
            this.labelIme.Name = "labelIme";
            this.labelIme.Size = new System.Drawing.Size(30, 17);
            this.labelIme.TabIndex = 7;
            this.labelIme.Text = "Ime";
            // 
            // labelPrezime
            // 
            this.labelPrezime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrezime.AutoSize = true;
            this.labelPrezime.Location = new System.Drawing.Point(12, 93);
            this.labelPrezime.Name = "labelPrezime";
            this.labelPrezime.Size = new System.Drawing.Size(59, 17);
            this.labelPrezime.TabIndex = 8;
            this.labelPrezime.Text = "Prezime";
            // 
            // labelXIme
            // 
            this.labelXIme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelXIme.AutoSize = true;
            this.labelXIme.Location = new System.Drawing.Point(1117, 15);
            this.labelXIme.Name = "labelXIme";
            this.labelXIme.Size = new System.Drawing.Size(39, 17);
            this.labelXIme.TabIndex = 17;
            this.labelXIme.Text = "ImeX";
            // 
            // labelPrezimeX
            // 
            this.labelPrezimeX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrezimeX.AutoSize = true;
            this.labelPrezimeX.Location = new System.Drawing.Point(1219, 15);
            this.labelPrezimeX.Name = "labelPrezimeX";
            this.labelPrezimeX.Size = new System.Drawing.Size(68, 17);
            this.labelPrezimeX.TabIndex = 18;
            this.labelPrezimeX.Text = "PrezimeX";
            // 
            // labelImeO
            // 
            this.labelImeO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelImeO.AutoSize = true;
            this.labelImeO.Location = new System.Drawing.Point(1117, 98);
            this.labelImeO.Name = "labelImeO";
            this.labelImeO.Size = new System.Drawing.Size(41, 17);
            this.labelImeO.TabIndex = 19;
            this.labelImeO.Text = "ImeO";
            // 
            // labelPrezimeO
            // 
            this.labelPrezimeO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrezimeO.AutoSize = true;
            this.labelPrezimeO.Location = new System.Drawing.Point(1217, 98);
            this.labelPrezimeO.Name = "labelPrezimeO";
            this.labelPrezimeO.Size = new System.Drawing.Size(70, 17);
            this.labelPrezimeO.TabIndex = 20;
            this.labelPrezimeO.Text = "PrezimeO";
            // 
            // buttonPretragaPoPoziciji
            // 
            this.buttonPretragaPoPoziciji.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPretragaPoPoziciji.Location = new System.Drawing.Point(287, 156);
            this.buttonPretragaPoPoziciji.Name = "buttonPretragaPoPoziciji";
            this.buttonPretragaPoPoziciji.Size = new System.Drawing.Size(85, 89);
            this.buttonPretragaPoPoziciji.TabIndex = 13;
            this.buttonPretragaPoPoziciji.Text = "Pretraga po poziciji";
            this.buttonPretragaPoPoziciji.UseVisualStyleBackColor = true;
            this.buttonPretragaPoPoziciji.Click += new System.EventHandler(this.buttonPretragaPoPoziciji_Click);
            // 
            // buttonAnaliza
            // 
            this.buttonAnaliza.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAnaliza.Location = new System.Drawing.Point(1208, 374);
            this.buttonAnaliza.Name = "buttonAnaliza";
            this.buttonAnaliza.Size = new System.Drawing.Size(108, 55);
            this.buttonAnaliza.TabIndex = 6;
            this.buttonAnaliza.Text = "Analiza";
            this.buttonAnaliza.UseVisualStyleBackColor = true;
            this.buttonAnaliza.Click += new System.EventHandler(this.buttonAnaliza_Click);
            // 
            // Statuslabel
            // 
            this.Statuslabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Statuslabel.AutoSize = true;
            this.Statuslabel.Location = new System.Drawing.Point(681, 15);
            this.Statuslabel.Name = "Statuslabel";
            this.Statuslabel.Size = new System.Drawing.Size(76, 17);
            this.Statuslabel.TabIndex = 16;
            this.Statuslabel.Text = "Status Igre";
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savetoolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1342, 27);
            this.toolStrip.TabIndex = 22;
            this.toolStrip.Text = "toolStrip1";
            // 
            // savetoolStripButton
            // 
            this.savetoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.savetoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("savetoolStripButton.Image")));
            this.savetoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.savetoolStripButton.Name = "savetoolStripButton";
            this.savetoolStripButton.Size = new System.Drawing.Size(44, 24);
            this.savetoolStripButton.Text = "Save";
            this.savetoolStripButton.Click += new System.EventHandler(this.savetoolStripButton_Click);
            // 
            // Forma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 550);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.Statuslabel);
            this.Controls.Add(this.buttonAnaliza);
            this.Controls.Add(this.buttonPretragaPoPoziciji);
            this.Controls.Add(this.labelPrezimeO);
            this.Controls.Add(this.labelImeO);
            this.Controls.Add(this.labelPrezimeX);
            this.Controls.Add(this.labelXIme);
            this.Controls.Add(this.labelPrezime);
            this.Controls.Add(this.labelIme);
            this.Controls.Add(this.buttonPretraga);
            this.Controls.Add(this.textBoxPrezimePretraga);
            this.Controls.Add(this.textBoxImePretraga);
            this.Controls.Add(this.buttonObrisi);
            this.Controls.Add(this.buttonNapred);
            this.Controls.Add(this.buttonNazad);
            this.Controls.Add(this.buttonPocni);
            this.Controls.Add(this.textBoxImeO);
            this.Controls.Add(this.textBoxPrezimeX);
            this.Controls.Add(this.textBoxPrezimeO);
            this.Controls.Add(this.textBoxImeX);
            this.Controls.Add(this.listBoxPartije);
            this.Controls.Add(this.tablaForma);
            this.MinimumSize = new System.Drawing.Size(1360, 597);
            this.Name = "Forma";
            this.Text = "Forma";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tablaForma;
        private System.Windows.Forms.ListBox listBoxPartije;
        private System.Windows.Forms.TextBox textBoxImeX;
        private System.Windows.Forms.TextBox textBoxPrezimeO;
        private System.Windows.Forms.TextBox textBoxPrezimeX;
        private System.Windows.Forms.TextBox textBoxImeO;
        private System.Windows.Forms.Button buttonPocni;
        private System.Windows.Forms.Button buttonNazad;
        private System.Windows.Forms.Button buttonNapred;
        private System.Windows.Forms.Button buttonObrisi;
        private System.Windows.Forms.TextBox textBoxImePretraga;
        private System.Windows.Forms.TextBox textBoxPrezimePretraga;
        private System.Windows.Forms.Button buttonPretraga;
        private System.Windows.Forms.Label labelIme;
        private System.Windows.Forms.Label labelPrezime;
        private System.Windows.Forms.Label labelXIme;
        private System.Windows.Forms.Label labelPrezimeX;
        private System.Windows.Forms.Label labelImeO;
        private System.Windows.Forms.Label labelPrezimeO;
        private System.Windows.Forms.Button buttonPretragaPoPoziciji;
        private System.Windows.Forms.Button buttonAnaliza;
        private System.Windows.Forms.Label Statuslabel;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton savetoolStripButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.OpenFileDialog saveFileDialog;
    }
}

