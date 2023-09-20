using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using ExcelApp = Microsoft.Office.Interop.Excel;



namespace ExcelDosyaOkuma
{
    public partial class Form1 : Form
    {
        public List<Kisi> people = new List<Kisi>();
        public Form1()
        {
            people = new List<Kisi>();
            InitializeComponent();
        }


        private void DosyayiSec_Click(object sender, EventArgs e)
        {
            string DosyaYolu;
            string DosyaAdi;
            DataTable dt;
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Dosyası | *.xls; *.xlsx; *.xlsm  *.csv";
            if (file.ShowDialog() == DialogResult.OK)
            {
                DosyaYolu = file.FileName;// seçilen dosyanın tüm yolunu verir
                DosyaAdi = file.SafeFileName;// seçilen dosyanın adını verir.
                ExcelApp.Application excelApp = new ExcelApp.Application();
                if (excelApp == null)
                { //Excel Yüklümü Kontrolü Yapılmaktadır.
                    MessageBox.Show("Excel yüklü değil.");
                    return;
                }
                //Excel Dosyası Açılıyor.
                ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DosyaYolu);
                //Excel Dosyasının Sayfası Seçilir.
                ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                //Excel Dosyasının ne kadar satır ve sütun kaplıyorsa tüm alanları alır.
                ExcelApp.Range excelRange = excelSheet.UsedRange;
                int satirSayisi = excelRange.Rows.Count; //Sayfanın satır sayısını alır.
                int sutunSayisi = excelRange.Columns.Count;//Sayfanın sütun sayısını alır.
                dt = ToDataTable(excelRange, satirSayisi, sutunSayisi);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                //Okuduktan Sonra Excel Uygulamasını Kapatıyoruz.
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            else
            {
                MessageBox.Show("Dosya Seçilemedi.");
            }
        }
        public DataTable ToDataTable(ExcelApp.Range range, int rows, int cols)
        {
            DataTable table = new DataTable();
            for (int i = 1; i <= rows; i++)
            {
                if (i == 1)
                { // ilk satırı Sutun Adları olarak kullanıldığından
                  // bunları Sutün Adları Olarak Kaydediyoruz.
                    for (int j = 1; j <= cols; j++)
                    {
                        //Sütunların içeriği boş mu kontrolü yapılmaktadır.
                        if (range.Cells[i, j] != null && range.Cells[i, j].Value2 != null)
                        {
                            table.Columns.Add(range.Cells[i, j].Value2.ToString());
                            // people.Add(range.Cells[i, j].Value2.ToString());

                        }
                        else //Boş olduğunda Kaçınsı Sutünsa Adı veriliyor.
                            table.Columns.Add(j.ToString() + ".Sütun");
                    }
                    continue;
                }
                //Yukarıda Sütunlar eklendi
                // onun şemasına göre yeni bir satır oluşturuyoruz. 
                //Okunan verileri yan yana sıralamak için
                var yeniSatir = table.NewRow();
                for (int j = 1; j <= cols; j++)
                {
                    //Sütunların içeriği boş mu kontrolü yapılmaktadır.
                    if (range.Cells[i, j] != null && range.Cells[i, j].Value2 != null)
                    {
                        yeniSatir[j - 1] = range.Cells[i, j].Value2.ToString();
                        // people.Add(range.Cells[i, j].Value2.ToString());



                    }
                    else // İçeriği boş hücrede hata vermesini önlemek için
                        yeniSatir[j - 1] = String.Empty;
                }
                Kisi adam = new Kisi();
                String  es = "";
                String ksoyad = "";
                String meslek = "";
                adam.GetTc = range.Cells[i, 1].Value2.ToString() ?? "";
                adam.GetAd = range.Cells[i, 2].Value2.ToString() ?? "";
                adam.GetSoyad = range.Cells[i, 3].Value2.ToString() ?? "";
                adam.GetDogumTarihi = range.Cells[i, 4].Value2.ToString() ?? "";
                adam.GetAnneAdi = range.Cells[i, 6].Value2.ToString() ?? "";
                adam.GetBabaAdi = range.Cells[i, 7].Value2.ToString() ?? "";
                adam.GetKanGrubu = range.Cells[i, 8].Value2.ToString() ?? "";
                adam.GetCinsiyet = range.Cells[i, 12].Value2.ToString() ?? "";
                //String meslek = range.Cells[i, 9].Value2.ToString() ?? "";
                adam.GetMedeniHal = range.Cells[i, 10].Value2.ToString() ?? "";
                //String ksoyad = range.Cells[i, 11].Value2.ToString() ?? " ";
                /*if (range.Cells[i, 5].Value2.ToString().HasValue)
                {
                    
                    adam.GetEs = range.Cells[i, 5].Value2.ToString();
                }
                else
                {

                    adam.GetEs = string.Empty;
                }
                */

                people.Add(adam);
                table.Rows.Add(yeniSatir);
            }
            return table;
        }

        private void btnSoyagaci_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(people);
            form.Show();

        }

        private void BtnDosyayiSec_Click(object sender, EventArgs e)
        {
            string DosyaYolu;
            string DosyaAdi;
            DataTable dt;
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Dosyası | *.xls; *.xlsx; *.xlsm; *.csv";
            if (file.ShowDialog() == DialogResult.OK)
            {
                DosyaYolu = file.FileName;// seçilen dosyanın tüm yolunu verir
                DosyaAdi = file.SafeFileName;// seçilen dosyanın adını verir.
                ExcelApp.Application excelApp = new ExcelApp.Application();
                if (excelApp == null)
                { //Excel Yüklümü Kontrolü Yapılmaktadır.
                    MessageBox.Show("Excel yüklü değil.");
                    return;
                }
                //Excel Dosyası Açılıyor.
                ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DosyaYolu);
                //Excel Dosyasının Sayfası Seçilir.
                ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                //Excel Dosyasının ne kadar satır ve sütun kaplıyorsa tüm alanları alır.
                ExcelApp.Range excelRange = excelSheet.UsedRange;
                int satirSayisi = excelRange.Rows.Count; //Sayfanın satır sayısını alır.
                int sutunSayisi = excelRange.Columns.Count;//Sayfanın sütun sayısını alır.
                dt = ToDataTable(excelRange, satirSayisi, sutunSayisi);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                //Okuduktan Sonra Excel Uygulamasını Kapatıyoruz.
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            else
            {
                MessageBox.Show("Dosya Seçilemedi.");
            }

        }

        private void btnDosyaSec_Click(object sender, EventArgs e)
        {

            string DosyaYolu;
            string DosyaAdi;
            DataTable dt;
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Dosyası | *.xls; *.xlsx; *.xlsm; *.csv";
            if (file.ShowDialog() == DialogResult.OK)
            {
                DosyaYolu = file.FileName;// seçilen dosyanın tüm yolunu verir
                DosyaAdi = file.SafeFileName;// seçilen dosyanın adını verir.
                ExcelApp.Application excelApp = new ExcelApp.Application();
                if (excelApp == null)
                { //Excel Yüklümü Kontrolü Yapılmaktadır.
                    MessageBox.Show("Excel yüklü değil.");
                    return;
                }
                //Excel Dosyası Açılıyor.
                ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DosyaYolu);
                //Excel Dosyasının Sayfası Seçilir.
                ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                //Excel Dosyasının ne kadar satır ve sütun kaplıyorsa tüm alanları alır.
                ExcelApp.Range excelRange = excelSheet.UsedRange;
                int satirSayisi = excelRange.Rows.Count; //Sayfanın satır sayısını alır.
                int sutunSayisi = excelRange.Columns.Count;//Sayfanın sütun sayısını alır.
                dt = ToDataTable(excelRange, satirSayisi, sutunSayisi);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                //Okuduktan Sonra Excel Uygulamasını Kapatıyoruz.
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            else
            {
                MessageBox.Show("Dosya Seçilemedi.");
            }

        }

        private void btnSoyagac_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(people);
            form2.Show();
        }

        private void btnCocuksuz_Click(object sender, EventArgs e)
        {

            List<Kisi> cocuksuz = new List<Kisi>();
            for (int i = 0; i < people.Count; i++)
            {
                int temp = 1;
                for (int j = 0; j < people.Count; j++)
                {
                    if (people[i].GetAd == people[j].GetAnneAdi || people[i].GetAd == people[j].GetBabaAdi)
                    {
                        if (people[i].GetSoyad == people[j].GetSoyad || people[i].GetKızlıkSoyadı == people[j].GetSoyad)
                        {
                            temp = 0;
                        }
                    }

                }
                if (temp == 1)
                {
                    cocuksuz.Add(people[i]);
                    temp = 0;
                }
            }
            dataGridView1.DataSource = cocuksuz;
            dataGridView1.Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String search = textBox.Text;
            List<String> temp = search.Split(' ').ToList();
            List<Kisi> list = new List<Kisi>();
            for (int i = 0; i < people.Count(); i++)
            {

                if (temp.Count > 1)
                {
                    if (people[i].GetSoyad.Contains(temp[1]) && people[i].GetAd.Contains(temp[0]))
                    {
                        list.Add(people[i]);

                    }
                }
                else if(temp.Count==1)
                {
                    if (people[i].GetAd.Contains(temp[0]))
                    {
                        list.Add(people[i]);
                    }
                }

            }
            dataGridView1.DataSource = list;
            dataGridView1.Refresh();
        }

        private void btnKanAra_Click(object sender, EventArgs e)
        {
            String search = textBox1.Text;
            String temp = "1";
            if (search.Equals("A"))
            {
                temp = "B";
            }
            else if (search.Equals("B"))
            {
                temp = "A";
            }
            List<Kisi> list = new List<Kisi>();
            for (int i = 0; i < people.Count(); i++)
            {
                if (people[i].GetKanGrubu.Contains(search) && !people[i].GetKanGrubu.Contains(temp))
                {
                    list.Add(people[i]);
                }

            }
            Kisi gecici;
            for (int i = 0; i <= list.Count - 1; i++)
            {
                for (int j = 1; j <= list.Count - 1; j++)
                {
                    if (Int32.Parse(list[j - 1].GetDogumTarihi) > Int32.Parse(list[j].GetDogumTarihi))
                    {
                        gecici = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = gecici;
                    }
                }

            }
            dataGridView1.DataSource = list;
            dataGridView1.Refresh();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<Kisi> uvey = new List<Kisi>();

            for (int i = 0; i < people.Count; i++)
            {
                int temp = 1;
                for (int j = 0; j < people.Count; j++)
                {
                    if (people[i].GetAnneAdi == people[j].GetAnneAdi && people[i].GetBabaAdi != people[j].GetBabaAdi)
                    {
                        if (Int32.Parse(uvey[j].GetDogumTarihi) - Int32.Parse(uvey[i].GetDogumTarihi) < 40)
                        {
                            temp = 0;
                        }
                    }

                    if (people[i].GetAnneAdi != people[j].GetAnneAdi && people[i].GetBabaAdi == people[j].GetBabaAdi)
                    {
                        int a = Int32.Parse(uvey[i].GetDogumTarihi);
                        int b = Int32.Parse(uvey[j].GetDogumTarihi);
                        if ( a-b < 40)
                        {
                            temp = 0;
                        }

                    }

                }
                if (temp == 0)
                {

                    uvey.Add(people[i]);
                    temp = 1;
                }
            }
            dataGridView1.DataSource = uvey;
            dataGridView1.Refresh();
        }
    }
    
}

