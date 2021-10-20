using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using YurtdisiTebligat.General;

namespace YurtdisiTebligat.Database
{
    public class Nufus
    {

        private VeriTabanıBaglantisi veriTabaniBaglantisi = new VeriTabanıBaglantisi();

        #region Fields
        private decimal _TCKimlikNo;
        private string _Ad;
        private string _Soyad;
        private string _Soyad2;
        private string _BabaAd;
        private DateTime _DogumTarihi;
        private string _AdresTipi;
        private decimal _AdresNo;
        private string _Il;
        private int _IlKodu;
        private string _Ilce;
        private int _IlceKodu;
        private string _Bucak;
        private decimal _BucakKodu;
        private string _Koy;
        private decimal _KoyKodu;
        private decimal _KoyKayitKodu;
        private string _Mahalle;
        private decimal _MahalleKodu;
        private string _CSBM;
        private decimal _CSBMKodu;
        private string _DisKapiNo;
        private string _IcKapiNo;
        private string _Ulke;
        private string _UlkeSehir;
        private string _UlkeAcikAdres;
        private string _OdemeAdres;
        private string _AcikAdres;
        private string _KullaniciId;
        private DateTime _IslemZamani;
        private string _KullaniciIp;
        private string _TerminalId;
        private string _IslemKodu;
        #endregion

        #region Properties
        public decimal TCKimlikNo
        {
            get { return _TCKimlikNo; }
            set { _TCKimlikNo = value; }
        }

        public string Ad
        {
            get { return _Ad; }
            set { _Ad = value; }
        }

        public string Soyad
        {
            get { return _Soyad; }
            set { _Soyad = value; }
        }

        public string Soyad2
        {
            get { return _Soyad2; }
            set { _Soyad2 = value; }
        }

        public string BabaAd
        {
            get { return _BabaAd; }
            set { _BabaAd = value; }
        }

        public DateTime DogumTarihi
        {
            get { return _DogumTarihi; }
            set { _DogumTarihi = value; }
        }

        public string AdresTipi
        {
            get { return _AdresTipi; }
            set { _AdresTipi = value; }
        }

        public decimal AdresNo
        {
            get { return _AdresNo; }
            set { _AdresNo = value; }
        }

        public string Il
        {
            get { return _Il; }
            set { _Il = value; }
        }

        public int IlKodu
        {
            get { return _IlKodu; }
            set { _IlKodu = value; }
        }

        public string Ilce
        {
            get { return _Ilce; }
            set { _Ilce = value; }
        }

        public int IlceKodu
        {
            get { return _IlceKodu; }
            set { _IlceKodu = value; }
        }

        public string Bucak
        {
            get { return _Bucak; }
            set { _Bucak = value; }
        }

        public decimal BucakKodu
        {
            get { return _BucakKodu; }
            set { _BucakKodu = value; }
        }

        public string Koy
        {
            get { return _Koy; }
            set { _Koy = value; }
        }

        public decimal KoyKodu
        {
            get { return _KoyKodu; }
            set { _KoyKodu = value; }
        }

        public decimal KoyKayitKodu
        {
            get { return _KoyKayitKodu; }
            set { _KoyKayitKodu = value; }
        }

        public string Mahalle
        {
            get { return _Mahalle; }
            set { _Mahalle = value; }
        }

        public decimal MahalleKodu
        {
            get { return _MahalleKodu; }
            set { _MahalleKodu = value; }
        }

        public string CSBM
        {
            get { return _CSBM; }
            set { _CSBM = value; }
        }

        public decimal CSBMKodu
        {
            get { return _CSBMKodu; }
            set { _CSBMKodu = value; }
        }

        public string DisKapiNo
        {
            get { return _DisKapiNo; }
            set { _DisKapiNo = value; }
        }

        public string IcKapiNo
        {
            get { return _IcKapiNo; }
            set { _IcKapiNo = value; }
        }

        public string Ulke
        {
            get { return _Ulke; }
            set { _Ulke = value; }
        }

        public string UlkeSehir
        {
            get { return _UlkeSehir; }
            set { _UlkeSehir = value; }
        }

        public string UlkeAcikAdres
        {
            get { return _UlkeAcikAdres; }
            set { _UlkeAcikAdres = value; }
        }

        public string OdemeAdres
        {
            get { return _OdemeAdres; }
            set { _OdemeAdres = value; }
        }

        public string AcikAdres
        {
            get { return _AcikAdres; }
            set { _AcikAdres = value; }
        }

        public string KullaniciId
        {
            get { return _KullaniciId; }
            set { _KullaniciId = value; }
        }

        public DateTime IslemZamani
        {
            get { return _IslemZamani; }
            set { _IslemZamani = value; }
        }

        public string KullaniciIp
        {
            get { return _KullaniciIp; }
            set { _KullaniciIp = value; }
        }

        public string TerminalId
        {
            get { return _TerminalId; }
            set { _TerminalId = value; }
        }

        public string IslemKodu
        {
            get { return _IslemKodu; }
            set { _IslemKodu = value; }
        }
        #endregion



        public void selectAdresFromNufus(ref List<Genel> genelListe)
        {

            OleDbConnection con = new OleDbConnection(veriTabaniBaglantisi.SSKDB2);

            string query = "";

            try
            {
                for (int i = 0; i < genelListe.Count; i++)
                {
                    query = "select ADRES_TIPI, IL, ILCE, MAHALLE, CSBM, DIS_KAPI_NO, IC_KAPI_NO, ULKE, ULKE_SEHIR, ULKE_ACIK_ADRES,ODEME_ADRES,ACIK_ADRES from  " + Globals.ortam + ".NUFUS where TCKIMLIKNO = ? with ur";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.Parameters.Add("TCKIMLIKNO", OleDbType.Decimal).Value = genelListe[i].TCKimlikNo;

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    OleDbDataReader dr = null;
                    dr = cmd.ExecuteReader();


                    if (dr.Read())
                    {
                        Nufus nufus = new Nufus();
                        genelListe[i].AdresTipi = dr["ADRES_TIPI"].ToString().Trim();
                        genelListe[i].Il = dr["IL"].ToString().Trim();
                        genelListe[i].Ilce = dr["ILCE"].ToString().Trim();
                        genelListe[i].Mahalle = dr["MAHALLE"].ToString().Trim();
                        genelListe[i].CSBM = dr["CSBM"].ToString().Trim();
                        genelListe[i].DisKapiNo = dr["DIS_KAPI_NO"].ToString().Trim();
                        genelListe[i].IcKapiNo = dr["IC_KAPI_NO"].ToString().Trim();
                        genelListe[i].Ulke = dr["ULKE"].ToString().Trim();
                        genelListe[i].UlkeSehir = dr["ULKE_SEHIR"].ToString().Trim();
                        genelListe[i].UlkeAcikAdres = dr["ULKE_ACIK_ADRES"].ToString().Trim();
                        genelListe[i].odemeAdres = dr["ODEME_ADRES"].ToString().Trim();
                        genelListe[i].acikadres = dr["ACIK_ADRES"].ToString().Trim();


                    }

                    /*  else
                    {
                        genelListe[i].AdresTipi = "";
                        genelListe[i].Il = "";
                        genelListe[i].Ilce = "";
                        genelListe[i].Mahalle = "";
                        genelListe[i].CSBM = "";
                        genelListe[i].DisKapiNo = "";
                        genelListe[i].IcKapiNo = "";
                        genelListe[i].Ulke = "";
                        genelListe[i].UlkeSehir = "";
                        genelListe[i].UlkeAcikAdres = "";

                    }
                    */
                    //if ( genelListe[i].AdresTipi.Trim().Equals("4"))
                    //{
                    // genelListe[i].UlkeAcikAdres.ToString().Trim();
                    //}
                    //else
                    //{
                    //   genelListe[i].odemeAdres.ToString().Trim();
                    //}

                    //if (genelListe[i].AdresTipi.Trim().Equals("3") && genelListe[i].DisKapiNo.Trim().Equals("") && genelListe[i].IcKapiNo.Trim().Equals(""))
                    //{
                    //    genelListe[i].acikadres.ToString().Trim();

                    //}
                    //else
                    //{
                    //    genelListe[i].odemeAdres.ToString().Trim();
                    //}


                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
        }


    }
}

