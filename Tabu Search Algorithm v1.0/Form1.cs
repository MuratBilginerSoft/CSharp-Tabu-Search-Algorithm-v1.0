using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Tabu_Search_Algorithm_v1._0
{
    public partial class Form1 : Form
    {
        #region Değişkenler

        public static int tabusayısı;
        public static int iterasyonsayısı;

        string harfsırala;
        string sayısıralama;
        string stoplam; // Sözel toplama işlemini göstermek için
        int itoplam; // Değerlerin sayısal toplamı için.
        int eniyiçözüm;

        int x, y, z, t; // Makineden gelen değerler.

        int x1;

        int m = 0, n = 1; // dizi değerleri değişimini sağlamak için.

        int seçimsayısı = 0;

        #endregion

        #region Metodlar

        #endregion

        #region Tanımlamalar

        string[] makineisimleri = { "", "A", "B", "C", "D" };
        public static int[] makine1 = new int[4];
        public static int[] makine2 = new int[4];
        public static int[] makine3 = new int[4];
        public static int[] makine4 = new int[4];

        public static int[] dizi1 = new int[4]; // İlk işlemde rasgele seçimin sayısal değerlerini tutacak.

        ArrayList seçimlistesi = new ArrayList();
        ArrayList eniyiçözümlist1 = new ArrayList();
        ArrayList eniyiçözümlist2 = new ArrayList();

        ArrayList ilkseçim = new ArrayList();
        ArrayList seçimyenile = new ArrayList();

        Random r = new Random();


        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Makine Değerlerini Al

            makine1[0] = int.Parse(textBox1.Text);
            makine1[1] = int.Parse(textBox2.Text);
            makine1[2] = int.Parse(textBox3.Text);
            makine1[3] = int.Parse(textBox4.Text);
            makine2[0] = int.Parse(textBox5.Text);
            makine2[1] = int.Parse(textBox6.Text);
            makine2[2] = int.Parse(textBox7.Text);
            makine2[3] = int.Parse(textBox8.Text);
            makine3[0] = int.Parse(textBox9.Text);
            makine3[1] = int.Parse(textBox10.Text);
            makine3[2] = int.Parse(textBox11.Text);
            makine3[3] = int.Parse(textBox12.Text);
            makine4[0] = int.Parse(textBox13.Text);
            makine4[1] = int.Parse(textBox14.Text);
            makine4[2] = int.Parse(textBox15.Text);
            makine4[3] = int.Parse(textBox16.Text);

            iterasyonsayısı = int.Parse(textBox17.Text);
            tabusayısı = int.Parse(textBox18.Text);
            #endregion

            #region İlk İşlem

            for (int i = 0; i < 4; i++)
            {
                do
                {
                    x1 = r.Next(1, 5);
                } while (Array.IndexOf(dizi1, x1) != -1);
                dizi1[i] = x1;
                seçimlistesi.Add(makineisimleri[x1]);
                ilkseçim.Add(makineisimleri[x1]);

                harfsırala += makineisimleri[x1] + ",";
                sayısıralama += dizi1[i] + ",";
            }

            sayısıralama = sayısıralama.Substring(0, 7);
            harfsırala = harfsırala.Substring(0, 7);
            
            listBox2.Items.Add(sayısıralama);
            listBox3.Items.Add(harfsırala);

            #endregion

            #region İlk Değer Alma

            for (int i = 0; i < 4; i++)
            {
                switch (dizi1[i])
                {

                    case 1:
                        x = makine1[i]; stoplam += x + "+"; break;
                    case 2:
                        y = makine2[i]; stoplam += y + "+"; break;
                    case 3:
                        z = makine3[i]; stoplam += z + "+"; break;
                    case 4:
                        t = makine4[i]; stoplam += t + "+"; break;
                }
            }

            seçimsayısı++;
            listBox1.Items.Add(seçimsayısı);
            stoplam = stoplam.Substring(0, stoplam.Length - 1);
            listBox4.Items.Add(stoplam);

            itoplam = x + y + z + t;
            eniyiçözüm = x + y + z + t;
            listBox5.Items.Add(itoplam);
            listBox6.Items.Add(eniyiçözüm);

            foreach (var items in seçimlistesi)
            {
                eniyiçözümlist1.Add(items);
                eniyiçözümlist2.Add(items);
                ilkseçim.Add(items);
            }

            #endregion

            #region Tabu Döngüsü

            for (int i = 0; i < iterasyonsayısı; i++)
            {
                for (int z1 = 0; z1 < 3; z1++)
                {
                    seçimyenile.Clear();
          
                    #region Komşuluk Bulma

                    if (z1==0)
                    {
                        seçimyenile.Add(ilkseçim[n]);
                        seçimyenile.Add(ilkseçim[m]);
                        seçimyenile.Add(ilkseçim[n + 1]);
                        seçimyenile.Add(ilkseçim[n + 2]);
                    }

                    else if (z1==1)
                    {
                        seçimyenile.Add(ilkseçim[n+1]);
                        seçimyenile.Add(ilkseçim[n]);
                        seçimyenile.Add(ilkseçim[m]);
                        seçimyenile.Add(ilkseçim[n + 2]);
                    }

                    else if (z1 == 2)
                    {
                        seçimyenile.Add(ilkseçim[n + 2]);
                        seçimyenile.Add(ilkseçim[n]);
                        seçimyenile.Add(ilkseçim[n+1]);
                        seçimyenile.Add(ilkseçim[m]);
                    }

                    ilkseçim.Clear();
                    harfsırala = "";
                    sayısıralama = "";

                    #endregion

                    #region Yeni Yer Seçimi

                    for (int j = 0; j < 4; j++)
                    {
                        if (seçimyenile[j] == "A")
                        {
                            dizi1[j] = 1;
                            seçimlistesi.Add(makineisimleri[1]);
                            ilkseçim.Add(makineisimleri[1]);
                            harfsırala += makineisimleri[1] + ",";
                            sayısıralama += dizi1[j] + ",";

                            
                        }

                        else if (seçimyenile[j] == "B")
                        {
                            dizi1[j] = 2;
                            seçimlistesi.Add(makineisimleri[2]);
                            ilkseçim.Add(makineisimleri[2]);
                            harfsırala += makineisimleri[2] + ",";
                            sayısıralama += dizi1[j] + ",";


                        }

                        else if (seçimyenile[j] == "C")
                        {
                            dizi1[j] = 3;
                            seçimlistesi.Add(makineisimleri[3]);
                            ilkseçim.Add(makineisimleri[3]);
                            harfsırala += makineisimleri[3] + ",";
                            sayısıralama += dizi1[j] + ",";
                        }

                        else if (seçimyenile[j] == "D")
                        {
                            dizi1[j] = 4;
                            seçimlistesi.Add(makineisimleri[4]);
                            ilkseçim.Add(makineisimleri[4]);
                            harfsırala += makineisimleri[4] + ",";
                            sayısıralama += dizi1[j] + ",";
                        }
                    }

                    sayısıralama = sayısıralama.Substring(0, 7);
                    harfsırala = harfsırala.Substring(0, 7);

                    listBox2.Items.Add(sayısıralama);
                    listBox3.Items.Add(harfsırala);
                    stoplam = "";

                    for (int z2 = 0; z2 < 4; z2++)
                    {
                        switch (dizi1[z2])
                        {

                            case 1:
                                x = makine1[z2]; stoplam += x + "+"; break;
                            case 2:
                                y = makine2[z2]; stoplam += y + "+"; break;
                            case 3:
                                z = makine3[z2]; stoplam += z + "+"; break;
                            case 4:
                                t = makine4[z2]; stoplam += t + "+"; break;
                        }
                    }

                    seçimsayısı++;
                    listBox1.Items.Add(seçimsayısı);
                    stoplam = stoplam.Substring(0, stoplam.Length - 1);
                    listBox4.Items.Add(stoplam);

                    itoplam = x + y + z + t;
                    if (itoplam<eniyiçözüm)
                    {
                        eniyiçözüm = itoplam;
                        listBox6.Items.Add(eniyiçözüm);
                    }

                    listBox5.Items.Add(itoplam);
                    listBox6.Items.Add("-");
                    

                    #endregion
                }
                
            }


            #endregion


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
