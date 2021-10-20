using System;
using System.Collections.Generic;

namespace YurtdisiTebligat.Database
{
    public class Genel
    {

        Nufus nufus = new Nufus();
        YDYOK_YDSUBELERCROSS yDYOK_YDSUBELERCROSS = new YDYOK_YDSUBELERCROSS();
        HareketYoklama hareketYoklama = new HareketYoklama();
        List<Nufus> nufusList = new List<Nufus>();
        List<HareketYoklama> hareketYoklamaList = new List<HareketYoklama>();

        #region Fields
        private decimal _TCKimlikNo;
        private string _TahsisNo;
        private string _CikisTarihi;
        private string _GirisTarihi;
        private string _Kapsam;
        private string _CiktiAlinmaTarihi;
        private string _Ad;
        private string _Soyad;
        private string _Soyad2;
        private string _AdresTipi;
        private string _Il;
        private string _Ilce;
        private string _Mahalle;
        private string _CSBM;
        private string _DisKapiNo;
        private string _IcKapiNo;
        private string _Ulke;
        private string _UlkeSehir;
        private string _UlkeAcikAdres;
        private string _DosyaYeri;
        private string _SGMAdi;

        #endregion

        #region Properties
        public decimal TCKimlikNo
        {
            get
            {
                return _TCKimlikNo;
            }

            set
            {
                _TCKimlikNo = value;
            }
        }

        public string TahsisNo
        {
            get
            {
                return _TahsisNo;
            }

            set
            {
                _TahsisNo = value;
            }
        }

        public string CikisTarihi
        {
            get
            {
                return _CikisTarihi;
            }

            set
            {
                _CikisTarihi = value;
            }
        }

        public string GirisTarihi
        {
            get
            {
                return _GirisTarihi;
            }

            set
            {
                _GirisTarihi = value;
            }
        }

        public string Kapsam
        {
            get
            {
                return _Kapsam;
            }

            set
            {
                _Kapsam = value;
            }
        }

        public string CiktiAlinmaTarihi
        {
            get
            {
                return _CiktiAlinmaTarihi;
            }

            set
            {
                _CiktiAlinmaTarihi = value;
            }
        }

        public string Ad
        {
            get
            {
                return _Ad;
            }

            set
            {
                _Ad = value;
            }
        }

        public string Soyad
        {
            get
            {
                return _Soyad;
            }

            set
            {
                _Soyad = value;
            }
        }

        public string Soyad2
        {
            get
            {
                return _Soyad2;
            }

            set
            {
                _Soyad2 = value;
            }
        }

        public string AdresTipi
        {
            get
            {
                return _AdresTipi;
            }

            set
            {
                _AdresTipi = value;
            }
        }

        public string Il
        {
            get
            {
                return _Il;
            }

            set
            {
                _Il = value;
            }
        }

        public string Ilce
        {
            get
            {
                return _Ilce;
            }

            set
            {
                _Ilce = value;
            }
        }

        public string Mahalle
        {
            get
            {
                return _Mahalle;
            }

            set
            {
                _Mahalle = value;
            }
        }

        public string CSBM
        {
            get
            {
                return _CSBM;
            }

            set
            {
                _CSBM = value;
            }
        }

        public string DisKapiNo
        {
            get
            {
                return _DisKapiNo;
            }

            set
            {
                _DisKapiNo = value;
            }
        }

        public string IcKapiNo
        {
            get
            {
                return _IcKapiNo;
            }

            set
            {
                _IcKapiNo = value;
            }
        }

        public string Ulke
        {
            get
            {
                return _Ulke;
            }

            set
            {
                _Ulke = value;
            }
        }

        public string UlkeSehir
        {
            get
            {
                return _UlkeSehir;
            }

            set
            {
                _UlkeSehir = value;
            }
        }

        public string UlkeAcikAdres
        {
            get
            {
                return _UlkeAcikAdres;
            }

            set
            {
                _UlkeAcikAdres = value;
            }
        }

        public string DosyaYeri
        {
            get
            {
                return _DosyaYeri;
            }

            set
            {
                _DosyaYeri = value;
            }
        }

        public string SGMAdi
        {
            get
            {
                return _SGMAdi;
            }

            set
            {
                _SGMAdi = value;
            }
        }

        public string odemeAdres { get; internal set; }
        public string acikadres { get; internal set; }
        public string AylıkTuru { get; private set; }
        public string AylikTuru { get; private set; }
        #endregion

        public List<Genel> setGenelValues(int baslangic, int bitis)
        {
            List<Genel> genelListe = new List<Genel>();
            hareketYoklamaList = hareketYoklama.selectDistinctTCKimlikNoFromHareketYoklama(baslangic, bitis);

            for (int i = 0; i < hareketYoklamaList.Count; i++)
            {
                Genel genel = new Genel();
                genelListe.Add(genel);
                genelListe[i].TCKimlikNo = hareketYoklamaList[i].TCKimlikNo;
                genelListe[i].TahsisNo = hareketYoklamaList[i].TahsisNo;
                genelListe[i].CikisTarihi = hareketYoklamaList[i].CikisTarihi;
                genelListe[i].GirisTarihi = hareketYoklamaList[i].GirisTarihi;
                genelListe[i].Kapsam = hareketYoklamaList[i].Kapsam;
                genelListe[i].CiktiAlinmaTarihi = hareketYoklamaList[i].CiktiAlinmaTarihi;
                genelListe[i].Ad = hareketYoklamaList[i].Ad;
                genelListe[i].Soyad = hareketYoklamaList[i].Soyad;
                genelListe[i].Soyad2 = hareketYoklamaList[i].Soyad2;
                genelListe[i].DosyaYeri = hareketYoklamaList[i].DosyaYeri;
                genelListe[i].AylikTuru = hareketYoklamaList[i].AylikTuru;
            }

            nufus.selectAdresFromNufus(ref genelListe);
            yDYOK_YDSUBELERCROSS.selectDosyaYeri(ref genelListe);

            return genelListe;
        }


        public List<Genel> setGenelValues4B(int? baslangic, int? bitis, decimal? tcKimlikNo, decimal? tahsisNo)
        {
            List<Genel> genelListe = new List<Genel>();

            if (tcKimlikNo == null && tahsisNo == null)
            {
                hareketYoklamaList = hareketYoklama.selectDistinctTCKimlikNoFromHareketYoklama4B(baslangic, bitis);
            }
            else
            {
                try
                {
                    if (tahsisNo == null)
                        hareketYoklamaList = hareketYoklama.selectTekTc(tcKimlikNo, null);
                    else
                        hareketYoklamaList = hareketYoklama.selectTekTc(null, tahsisNo);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }

            for (int i = 0; i < hareketYoklamaList.Count; i++)
            {
                Genel genel = new Genel();
                genelListe.Add(genel);
                genelListe[i].TCKimlikNo = hareketYoklamaList[i].TCKimlikNo;
                genelListe[i].TahsisNo = hareketYoklamaList[i].TahsisNo;
                genelListe[i].CikisTarihi = hareketYoklamaList[i].CikisTarihi;
                genelListe[i].GirisTarihi = hareketYoklamaList[i].GirisTarihi;
                genelListe[i].Kapsam = hareketYoklamaList[i].Kapsam;
                genelListe[i].CiktiAlinmaTarihi = hareketYoklamaList[i].CiktiAlinmaTarihi;
                genelListe[i].Ad = hareketYoklamaList[i].Ad;
                genelListe[i].Soyad = hareketYoklamaList[i].Soyad;
                genelListe[i].Soyad2 = hareketYoklamaList[i].Soyad2;
                genelListe[i].DosyaYeri = hareketYoklamaList[i].DosyaYeri;
                genelListe[i].AylikTuru = hareketYoklamaList[i].AylikTuru;
            }

            nufus.selectAdresFromNufus(ref genelListe);
            yDYOK_YDSUBELERCROSS.selectDosyaYeri(ref genelListe);

            return genelListe;
        }

        public List<Genel> setGenelValues4C(int baslangic, int bitis)
        {
            List<Genel> genelListe = new List<Genel>();
            hareketYoklamaList = hareketYoklama.selectDistinctTCKimlikNoFromHareketYoklama4C(baslangic, bitis);

            for (int i = 0; i < hareketYoklamaList.Count; i++)
            {
                Genel genel = new Genel();
                genelListe.Add(genel);
                genelListe[i].TCKimlikNo = hareketYoklamaList[i].TCKimlikNo;
                genelListe[i].TahsisNo = hareketYoklamaList[i].TahsisNo;
                genelListe[i].CikisTarihi = hareketYoklamaList[i].CikisTarihi;
                genelListe[i].GirisTarihi = hareketYoklamaList[i].GirisTarihi;
                genelListe[i].Kapsam = hareketYoklamaList[i].Kapsam;
                genelListe[i].CiktiAlinmaTarihi = hareketYoklamaList[i].CiktiAlinmaTarihi;
                genelListe[i].Ad = hareketYoklamaList[i].Ad;
                genelListe[i].Soyad = hareketYoklamaList[i].Soyad;
                genelListe[i].Soyad2 = hareketYoklamaList[i].Soyad2;
                genelListe[i].DosyaYeri = hareketYoklamaList[i].DosyaYeri;
                genelListe[i].AylikTuru = hareketYoklamaList[i].AylikTuru;
            }

            nufus.selectAdresFromNufus(ref genelListe);
            yDYOK_YDSUBELERCROSS.selectDosyaYeri(ref genelListe);

            return genelListe;
        }


    }
}