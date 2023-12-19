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

namespace ToplantıUygulamasi
{
    public partial class Form1 : Form
    {
#pragma warning disable CS0169 // The field 'Form1.selectedDate' is never used
        private object selectedDate;
        private string filePath;
#pragma warning restore CS0169 // The field 'Form1.selectedDate' is never used

        public Form1()
        {
            InitializeComponent();
        }

        private void Toplanti_Id_Olustur_Click(object sender, EventArgs e)
        {
            string[] sembol1 = { "A", "Z", "K", "P", "R", "Y", "I", "Q", "E", "O" };  //Güvenlik kodundaki sembol ve sayıların değerini giriyoruz
            string[] sembol2 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string[] sembol3 = { "a", "z", "k", "p", "r", "y", "i", "q", "r", "o" };

            Random r = new Random();   // Rastgele değer çekmesi için Random sınıfını kullanıyoruz
            int s1, s2, s3, s4, s5;
            s1 = r.Next(0, sembol1.Length);
            s2 = r.Next(0, sembol2.Length);
            s3 = r.Next(0, sembol3.Length);
            s4 = r.Next(0, 10);
            s5 = r.Next(0, 10);
            Toplanti_Id.Text = sembol1[s1].ToString() + sembol2[s2].ToString() + sembol3[s3].ToString() + s4.ToString() + s5.ToString();
            string fileName = Toplanti_Id.Text;
            label2.Text = fileName;


            // Dosya adı boş veya geçersiz karakter içeriyorsa hata mesajı göster
            if (string.IsNullOrWhiteSpace(fileName) || fileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {
                MessageBox.Show("Geçersiz dosya adı. Lütfen geçerli bir dosya adı girin.");
                return;
            }

            // Dosyayı oluştur
            try
            {
                File.Create(fileName + ".txt").Close(); // ".txt" uzantısını ekledik
                MessageBox.Show("Dosya oluşturuldu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya oluşturma hatası: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "*";
            saveFileDialog1.Filter = "Yazı Dosyaları (*txt)|*.txt";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.ShowDialog();

            StreamWriter yazmaislemi=new StreamWriter(saveFileDialog1.FileName);
            yazmaislemi.WriteLine(textBox2.Text);
            yazmaislemi.WriteLine(monthCalendar2.SelectionStart.ToString("d"));

            yazmaislemi.Close();

        }

        private void WriteDateToFile(DateTime selectedDate)
        {
            throw new NotImplementedException();
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Dosya seçme iletişim kutusunu oluştur
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Sadece TXT dosyalarını filtrele
            openFileDialog.Filter = "Text Files|*.txt";

            // Kullanıcı dosyayı seçtiyse
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosyanın adını al
                string selectedFileName = openFileDialog.FileName;

                // Dosyanın içeriğini RichTextBox kontrolüne yaz
                LoadFileContent(selectedFileName);
            }
        }
        private void LoadFileContent(string filePath)
        {
            // Dosyanın içeriğini StreamReader ile oku
            using (StreamReader reader = new StreamReader(filePath))
            {
                richTextBox1.Text = reader.ReadToEnd();
            }

            MessageBox.Show("Dosya içeriği başarıyla yüklendi.");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
   

       
    }

