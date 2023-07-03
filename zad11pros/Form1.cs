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

namespace zad11pros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog otwarciepliku = new OpenFileDialog();
            otwarciepliku.Title = "Wybór pliku";
            otwarciepliku.DefaultExt = "txt";
            otwarciepliku.Filter = "Pliki txt (*.txt)|*.txt";
            otwarciepliku.CheckFileExists = true;
            otwarciepliku.CheckPathExists=true;
            if (otwarciepliku.ShowDialog() == DialogResult.OK)
            {
                string sciezka = otwarciepliku.FileName;
            }
            else
            {
                label1.Text = "Wystąpił błąd przy otwarciu pliku!";
            }
            try
            {
                var strumien = otwarciepliku.OpenFile();
                using (StreamReader czytnik = new StreamReader(strumien))
                {
                    string zawartosc = czytnik.ReadToEnd();
                    textBox1.Text = zawartosc;
                    label1.Text = "Zawartość pliku wyświetlona!";
                }
            }
            catch(Exception)
            {
                label1.Text = "Nie wybrano pliku!";
            }
            
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog zapis = new SaveFileDialog();
            zapis.Title = "Zapisz";
            zapis.DefaultExt = "txt";
            zapis.Filter = "Pliki txt (*.txt)|*.txt";
            if (zapis.ShowDialog() == DialogResult.OK)
            {
                string sciezka = zapis.FileName;
            }
            else
            {
                label1.Text = "Wystąpił błąd przy otwarciu pliku!";
            }
            try
            {
                var strumien = zapis.OpenFile();
                using (StreamWriter pisak = new StreamWriter(strumien))
                {
                    string zawartosc = textBox1.Text;
                    pisak.Write(zawartosc);
                    label1.Text = "Zapisano pomyślnie!!";
                }
            }
            catch (Exception)
            {
                label1.Text = "Anulowano zapis!";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!File.Exists("C:\\Users\\Siergiej\\Documents\\test.txt"))
            {
                File.Create("C:\\Users\\Siergiej\\Documents\\test.txt").Close();
                label1.Text = "Plik został utworzony pomyślnie!";
            }
            else
            {
                label1.Text = "Plik już istnieje!";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
