using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NetaisyklingiVeiksmaz
{
    public partial class Form1 : Form
    {
        const string CFd = "..//..//Zodziai.txt";
        List<Zodis> zodziai = new List<Zodis>(123);
        int im = -1, lygis = 1, kartas = 0;
        public Form1()
        {
            InitializeComponent();
            Tikrinti.Enabled = false;
            Isvalyti.Enabled = false;
            Uzuomina.Enabled = false;
        }

        private void Lygis1_Click(object sender, EventArgs e)
        {
            lygis = 1;
            if (im != -1)
            {
                Forma1.Text = zodziai[im].Forma1();
                Forma1.ReadOnly = true;
                Pasikeitimai.Text = "Keičiasi " + zodziai[im].Pasikeitimai() + " kartus(-ų)";
            }
        }

        private void Lygis2_Click(object sender, EventArgs e)
        {
            lygis = 2;
            if (im != -1)
            {
                Forma1.Clear();
                Forma1.ReadOnly = false;
                Pasikeitimai.Text = "";
            }
        }

        private void Isvalyti_Click(object sender, EventArgs e)
        {
            if (lygis == 2) Forma1.BackColor = SystemColors.Window;
            Forma2.BackColor = SystemColors.Window;
            Forma3.BackColor = SystemColors.Window;
        }

        private void Tikrinti_Click(object sender, EventArgs e)
        {
            if (lygis == 2)
            {
                if (Forma1.Text == zodziai[im].Forma1()) Forma1.BackColor = Color.LawnGreen;
                else Forma1.BackColor = Color.PaleVioletRed;
            }
            if (Forma2.Text == zodziai[im].Forma2()) Forma2.BackColor = Color.LawnGreen;
            else Forma2.BackColor = Color.PaleVioletRed;
            if (Forma3.Text == zodziai[im].Forma3()) Forma3.BackColor = Color.LawnGreen;
            else Forma3.BackColor = Color.PaleVioletRed;
        }

        private void Uzuomina_Click(object sender, EventArgs e)
        {
            if (lygis == 1)
            {
                Forma2.Text = zodziai[im].Forma2();
            }
            if (lygis == 2)
            {
                Pasikeitimai.Text = "Keičiasi " + zodziai[im].Pasikeitimai() + " kartus(-ų)";
            }
        }

        static void Skaityti(ref List<Zodis> zodziai)
        {
            string eilute;
            int keit;
            string liet, f1, f2, f3;
            Zodis z;
            using (StreamReader reader = new StreamReader(CFd))
            {
                while ((eilute = reader.ReadLine()) != null)
                {
                    string[] dalys = eilute.Split(new [] {'\t'},StringSplitOptions.RemoveEmptyEntries);
                    keit = int.Parse(dalys[0]);
                    liet = dalys[1];
                    f1 = dalys[2];
                    f2 = dalys[3];
                    f3 = dalys[4];
                    z = new Zodis(keit, liet, f1, f2, f3);
                    zodziai.Add(z);
                }
            }
        }

        private void NaujasZodis_Click(object sender, EventArgs e)
        {
            if (kartas == 0)
            {
                Skaityti(ref zodziai);
                kartas++;
                Tikrinti.Enabled = true;
                Isvalyti.Enabled = true;
                Uzuomina.Enabled = true;
            }
            Lietuviskas.BackColor = SystemColors.Window;
            Forma1.BackColor = SystemColors.Window;
            Forma2.BackColor = SystemColors.Window;
            Forma3.BackColor = SystemColors.Window;
            Random rnd = new Random();
            im = rnd.Next(0, zodziai.Count());
            if (lygis == 1)
            {
                Lietuviskas.Text = zodziai[im].Lietuviskas();
                Forma1.Text = zodziai[im].Forma1();
                Forma2.Clear();
                Forma3.Clear();
                Pasikeitimai.Text = "Keičiasi " + zodziai[im].Pasikeitimai() + " kartus(-ų)";
                Forma1.ReadOnly = true;
            }
            if (lygis == 2)
            {
                Lietuviskas.Text = zodziai[im].Lietuviskas();
                Forma1.Clear();
                Forma2.Clear();
                Forma3.Clear();
                Pasikeitimai.Text = "";
                Forma1.ReadOnly = false;
            }
        }
    }
}
