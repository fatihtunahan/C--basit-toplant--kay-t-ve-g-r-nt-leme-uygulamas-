using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToplantıUygulamasi
{
    public partial class AnaEkran : Form
    {
        private int dogruCevap;
        private int soruSayisi = 0;
        private int hataliCevapSayisi = 0;
        private const int maksHataSayisi = 3; // Kullanıcının üç hata hakkı var.


        public AnaEkran()
        {
            InitializeComponent();
            YeniSoruOlustur();
        }
        private void YeniSoruOlustur()
        {
            Random random = new Random();
            int sayi1 = random.Next(1, 11);
            int sayi2 = random.Next(1, 11);
            int islem = random.Next(1, 5);

            switch (islem)
            {
                case 1:
                    dogruCevap = sayi1 + sayi2;
                    labelSoru.Text = $"{sayi1} + {sayi2} = ?";
                    break;
                case 2:
                    dogruCevap = sayi1 - sayi2;
                    labelSoru.Text = $"{sayi1} - {sayi2} = ?";
                    break;
                case 3:
                    dogruCevap = sayi1 * sayi2;
                    labelSoru.Text = $"{sayi1} * {sayi2} = ?";
                    break;
                case 4:
                    dogruCevap = sayi1 / sayi2;
                    labelSoru.Text = $"{sayi1} / {sayi2} = ?";
                    break;
            }
        }
        private void AnaEkran_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MAALESEF EMEK YOKSA EKMEK DE YOK SORUYU BİL ÖYLE GİRİŞ YAP :)");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nickname = textBox1.Text;
            string Kullanici1 = "Ali";
            string Kullanici2 = "Ayşe";
            string Kullanici3 = "Mehmet";
            string Kullanici4 = "Merve";


            if (nickname.Equals(Kullanici1) || nickname.Equals(Kullanici2) || nickname.Equals(Kullanici3) || nickname.Equals(Kullanici4))
            { if (textBoxCevap.Text != "")
            {
                int kullaniciCevap = Convert.ToInt32(textBoxCevap.Text);

                    if (kullaniciCevap == dogruCevap)
                    {

                        soruSayisi++;
                        hataliCevapSayisi = 0; // Kullanıcı doğru cevap verdiğinde hatalı cevap sayısını sıfırla
                        YeniSoruOlustur();
                    }
                    else
                    {
                        MessageBox.Show("Yanlış cevap, tekrar deneyin.");

                        hataliCevapSayisi++;

                        if (hataliCevapSayisi >= maksHataSayisi)
                        {
                            MessageBox.Show($"Üzgünüz! {maksHataSayisi} hatalı cevap yaptınız. Oyun yeniden başlatılıyor.");
                            YenidenBaslat();
                        }
                    }
                    
                }
                textBoxCevap.Clear();

                if (soruSayisi == 1)
                {
                    Form1 form1 =new Form1();
                    form1.Show();
                    this.Hide();
                }
            }
                
            else
            {
                MessageBox.Show("Kayitli Kullanicilar Erisebilir");
            }
        
            
           
      
        }
        private void YenidenBaslat()
        {
            soruSayisi = 0;
            hataliCevapSayisi = 0;
            YeniSoruOlustur();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            YeniSoruOlustur();
            textBoxCevap.Clear();
        }

        private void textBoxCevap_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelSoru_Click(object sender, EventArgs e)
        {

        }
    }
}
