using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelDosyaOkuma
{
   
   public class Kisi
    {
       private string Tc;
        private string Ad;
        private string Soyad;
        private string DogumTarihi;
        private string AnneAdi;
        private string BabaAdi;
        private string KanGrubu;
        private string Cinsiyet;
        private string Meslek;
        private string MedeniHal;
        private string KızlıkSoyadı;
        private string Es;
       
           public Kisi ( string Tc,string Ad,string Soyad,string DogumTarihi,string Es,string AnneAdi,string BabaAdi,string KanGrubu,string Meslek, string MedeniHal, string KızlıkSoyadı, string Cinsiyet)
            {
            this.Tc = Tc;
            this.Ad = Ad;
            this.Soyad = Soyad;
            this.DogumTarihi = DogumTarihi;
            this.Es = Es;
            this.AnneAdi = AnneAdi;
            this.BabaAdi = BabaAdi;
            this.KanGrubu = KanGrubu;
            this.Cinsiyet = Cinsiyet;
            this.Meslek = Meslek;
            this.MedeniHal = MedeniHal;
            this.KızlıkSoyadı = KızlıkSoyadı;
            }
        public Kisi()
        {

        }
        public string GetTc
        {
            get { return Tc; }
            set { Tc = value; }
        }
        public String GetMedeniHal { get; set; }
        public String GetEs { get; set; }
        public String GetAd { get; set; }
        public String GetSoyad { get; set; }
        public String GetDogumTarihi { get; set; }
        public String GetAnneAdi { get; set; }
        public String GetBabaAdi { get; set; }
        public String GetKanGrubu { get; set; }
        public String GetCinsiyet { get; set; }
        public String GetMeslek { get; set; }
        public String GetKızlıkSoyadı { get; set; }
    }

}
