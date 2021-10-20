using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using YurtdisiTebligat.General;

namespace YurtdisiTebligat.Database
{
    public class HareketYoklama
    {
        private VeriTabanıBaglantisi veriTabaniBaglantisi = new VeriTabanıBaglantisi();

        private long[] tcArray = new long[10000];
        private string[] tarihArray = new string[10000];

        #region Fields
        private decimal _TCKimlikNo;
        private string _TahsisNo;
        private string _CikisTarihi;
        private string _GirisTarihi;
        private string _Kapsam;
        private string _DosyaYeri;
        private DateTime _YoklamaBelgetarihi;
        private string _CiktiAlinmaTarihi;
        private string _Ad;
        private string _Soyad;
        private string _Soyad2;
        private DateTime _AylikAcilmaTarihi;
        private string _AylikDurumu;
        private string _AylikTuru;
        private string _KullaniciId;
        private DateTime _IslemZamani;
        private string _KullaniciIP;
        private string _TerminalID;
        private string _IslemKodu;
        private long _Id;
        private long _HamveriId;
        private int _MaasDurumuKodu;
        private DateTime _MaasDegisiklikTarihi;
        #endregion

        #region Properties
        public decimal TCKimlikNo
        {
            get { return _TCKimlikNo; }
            set { _TCKimlikNo = value; }
        }

        public string TahsisNo
        {
            get { return _TahsisNo; }
            set { _TahsisNo = value; }
        }

        public string CikisTarihi
        {
            get { return _CikisTarihi; }
            set { _CikisTarihi = value; }
        }

        public string GirisTarihi
        {
            get { return _GirisTarihi; }
            set { _GirisTarihi = value; }
        }

        public string Kapsam
        {
            get { return _Kapsam; }
            set { _Kapsam = value; }
        }

        public string DosyaYeri
        {
            get { return _DosyaYeri; }
            set { _DosyaYeri = value; }
        }

        public DateTime YoklamaBelgetarihi
        {
            get { return _YoklamaBelgetarihi; }
            set { _YoklamaBelgetarihi = value; }
        }

        public string CiktiAlinmaTarihi
        {
            get { return _CiktiAlinmaTarihi; }
            set { _CiktiAlinmaTarihi = value; }
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

        public DateTime AylikAcilmaTarihi
        {
            get { return _AylikAcilmaTarihi; }
            set { _AylikAcilmaTarihi = value; }
        }

        public string AylikDurumu
        {
            get { return _AylikDurumu; }
            set { _AylikDurumu = value; }
        }

        public string AylikTuru
        {
            get { return _AylikTuru; }
            set { _AylikTuru = value; }
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

        public string KullaniciIP
        {
            get { return _KullaniciIP; }
            set { _KullaniciIP = value; }
        }

        public string TerminalID
        {
            get { return _TerminalID; }
            set { _TerminalID = value; }
        }

        public string IslemKodu
        {
            get { return _IslemKodu; }
            set { _IslemKodu = value; }
        }

        public long Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public long HamveriId
        {
            get { return _HamveriId; }
            set { _HamveriId = value; }
        }

        public int MaasDurumuKodu
        {
            get { return _MaasDurumuKodu; }
            set { _MaasDurumuKodu = value; }
        }

        public DateTime MaasDegisiklikTarihi
        {
            get { return _MaasDegisiklikTarihi; }
            set { _MaasDegisiklikTarihi = value; }
        }
        #endregion

        public List<HareketYoklama> selectDistinctTCKimlikNoFromHareketYoklama(int baslangic, int bitis)
        {
            List<HareketYoklama> list = new List<HareketYoklama>();
            OleDbConnection con = new OleDbConnection(veriTabaniBaglantisi.SSKDB2);

            //TEST AMAÇLI
            //  string query = "select TCKIMLIKNO, max(CIKIS_TARIHI) as a from " + Globals.ortam + ".HAREKET_YOKLAMA where KAPSAM != '4C' and TCKIMLIKNO='11006335010' group by TCKIMLIKNO";

            string query = " select h.TCKIMLIKNO, max(CIKIS_TARIHI) as a from  " + Globals.ortam + ".HAREKET_YOKLAMA h,  " + Globals.ortam + ".NUFUS n ";
            query += " where h.TCKIMLIKNO >=  ";
            query += " ( ";
            query += " select max(TCKIMLIKNO) from ( ";
            query += " select  distinct TCKIMLIKNO from ( ";
            //  query += " select distinct h.TCKIMLIKNO from   " + Globals.ortam + ".HAREKET_YOKLAMA h,  " + Globals.ortam + ".NUFUS n  where KAPSAM != '4C' and n.TCKIMLIKNO = h.TCKIMLIKNO order by h.TCKIMLIKNO ";   (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B'
            query += " select distinct h.TCKIMLIKNO from   " + Globals.ortam + ".HAREKET_YOKLAMA h,  " + Globals.ortam + ".NUFUS n  where KAPSAM = '4A' and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B'  and n.TCKIMLIKNO = h.TCKIMLIKNO order by h.TCKIMLIKNO ";
            //     query += " ) ";
            query += " fetch first " + baslangic.ToString() + " rows only ";
            query += " ) ";
            query += " ) ";
            query += " ) ";
            query += " and h.TCKIMLIKNO <=  ";
            query += " ( ";
            query += " select max(TCKIMLIKNO) from ( ";
            query += " select  distinct TCKIMLIKNO from ( ";
            //  query += " select distinct h.TCKIMLIKNO from   " + Globals.ortam + ".HAREKET_YOKLAMA h,  " + Globals.ortam + ".NUFUS n where KAPSAM != '4C' and n.TCKIMLIKNO = h.TCKIMLIKNO order by h.TCKIMLIKNO ";
            query += " select distinct h.TCKIMLIKNO from   " + Globals.ortam + ".HAREKET_YOKLAMA h,  " + Globals.ortam + ".NUFUS n where KAPSAM = '4A' and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B'  and n.TCKIMLIKNO = h.TCKIMLIKNO order by h.TCKIMLIKNO ";
            //      query += " ) ";
            query += " fetch first " + bitis.ToString() + " rows only ";
            query += " ) ";
            query += " ) ";
            query += " ) ";
            query += " and KAPSAM = '4A' and n.TCKIMLIKNO = h.TCKIMLIKNO and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B' ";
            query += " group by h.TCKIMLIKNO ";



            //string  query  = " select TCKIMLIKNO, max(CIKIS_TARIHI) as a from " + Globals.ortam + ".HAREKET_YOKLAMA ";
            //        query += " where TCKIMLIKNO >=  ";
            //        query += " ( ";
            //        query += " select max(TCKIMLIKNO) from ( ";
            //        query += " select  distinct TCKIMLIKNO from ( ";
            //        query += " select distinct TCKIMLIKNO from  " + Globals.ortam + ".HAREKET_YOKLAMA where KAPSAM != '4C' order by TCKIMLIKNO ";
            //        query += " ) ";
            //        query += " fetch first " + baslangic.ToString() + " rows only ";
            //        query += " ) ";
            //        query += " ) ";
            //        query += " and TCKIMLIKNO <=  ";
            //        query += " ( ";
            //        query += " select max(TCKIMLIKNO) from ( ";
            //        query += " select  distinct TCKIMLIKNO from ( ";
            //        query += " select distinct TCKIMLIKNO from  " + Globals.ortam + ".HAREKET_YOKLAMA where KAPSAM != '4C' order by TCKIMLIKNO ";
            //        query += " ) ";
            //        query += " fetch first " + bitis.ToString() + " rows only ";
            //        query += " ) ";
            //        query += " ) ";
            //        query += " and KAPSAM != '4C' ";
            //        query += " group by TCKIMLIKNO ";



            //string query = "select TCKIMLIKNO, max(CIKIS_TARIHI) as a from "+Globals.ortam+ ".HAREKET_YOKLAMA where KAPSAM != '4C' and TCKIMLIKNO in (Select distinct TCKIMLIKNO from  " + Globals.ortam + ".HAREKET_YOKLAMA where TCKIMLIKNO >= (select max(TCKIMLIKNO) from  " + Globals.ortam + ".HAREKET_YOKLAMA where TCKIMLIKNO in (SELECT TCKIMLIKNO from  " + Globals.ortam + ".HAREKET_YOKLAMA FETCH first " + baslangic.ToString() + " rows only)) and TCKIMLIKNO <= (select max(TCKIMLIKNO) from  " + Globals.ortam + ".HAREKET_YOKLAMA where TCKIMLIKNO in (SELECT TCKIMLIKNO from  " + Globals.ortam + ".HAREKET_YOKLAMA FETCH first " + bitis.ToString() + " rows only))order by TCKIMLIKNO ASC) group by TCKIMLIKNO with ur";
            //string query = "select TCKIMLIKNO, max(CIKIS_TARIHI) as a from SHSTBT01.HAREKET_YOKLAMA where kapsam!= '4C' and TCKIMLIKNO in (Select distinct TCKIMLIKNO from SHSTBT01.HAREKET_YOKLAMA where id >=  " + (baslangic + 29145).ToString() + "  and id <= " + (bitis + 29145).ToString() + " order by TCKIMLIKNO ASC) group by TCKIMLIKNO with ur";

            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    HareketYoklama pHareketYoklama = new HareketYoklama();
                    pHareketYoklama.TCKimlikNo = Convert.ToInt64(dr["TCKIMLIKNO"].ToString());
                    pHareketYoklama.CikisTarihi = dr["a"].ToString();
                    selectAllFromHareketYoklama(con, ref pHareketYoklama);
                    list.Add(pHareketYoklama);
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

            return list;
        }

        public List<HareketYoklama> selectDistinctTCKimlikNoFromHareketYoklama4B(int? baslangic, int? bitis)
        {
            List<HareketYoklama> list = new List<HareketYoklama>();
            OleDbConnection con = new OleDbConnection(veriTabaniBaglantisi.SSKDB2);

            //TEST AMAÇLI
            //  string query = "select TCKIMLIKNO, max(CIKIS_TARIHI) as a from " + Globals.ortam + ".HAREKET_YOKLAMA where KAPSAM != '4C' and TCKIMLIKNO='11006335010' group by TCKIMLIKNO";

            string query = " select h.TCKIMLIKNO, max(CIKIS_TARIHI) as a from  " + Globals.ortam + ".HAREKET_YOKLAMA h,  " + Globals.ortam + ".NUFUS n ";
            query += " where h.TCKIMLIKNO >=  ";
            query += " ( ";
            query += " select max(TCKIMLIKNO) from ( ";
            query += " select  distinct TCKIMLIKNO from ( ";
            //  query += " select distinct h.TCKIMLIKNO from   " + Globals.ortam + ".HAREKET_YOKLAMA h,  " + Globals.ortam + ".NUFUS n  where KAPSAM != '4C' and n.TCKIMLIKNO = h.TCKIMLIKNO order by h.TCKIMLIKNO ";
            query += " select distinct h.TCKIMLIKNO from   " + Globals.ortam + ".HAREKET_YOKLAMA h,  " + Globals.ortam + ".NUFUS n  where KAPSAM = '4B' and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B'  and n.TCKIMLIKNO = h.TCKIMLIKNO order by h.TCKIMLIKNO ";
            //      query += " ) ";
            query += " fetch first " + baslangic.ToString() + " rows only ";
            query += " ) ";
            query += " ) ";
            query += " ) ";
            query += " and h.TCKIMLIKNO <=  ";
            query += " ( ";
            query += " select max(TCKIMLIKNO) from ( ";
            query += " select  distinct TCKIMLIKNO from ( ";
            //  query += " select distinct h.TCKIMLIKNO from   " + Globals.ortam + ".HAREKET_YOKLAMA h,  " + Globals.ortam + ".NUFUS n where KAPSAM != '4C' and n.TCKIMLIKNO = h.TCKIMLIKNO order by h.TCKIMLIKNO ";
            query += " select distinct h.TCKIMLIKNO from   " + Globals.ortam + ".HAREKET_YOKLAMA h,  " + Globals.ortam + ".NUFUS n where KAPSAM = '4B' and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B'  and n.TCKIMLIKNO = h.TCKIMLIKNO order by h.TCKIMLIKNO ";
            //      query += " ) ";
            query += " fetch first " + bitis.ToString() + " rows only ";
            query += " ) ";
            query += " ) ";
            query += " ) ";
            query += " and KAPSAM = '4B' and n.TCKIMLIKNO = h.TCKIMLIKNO and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B' ";
            query += " group by h.TCKIMLIKNO ";



            //string  query  = " select TCKIMLIKNO, max(CIKIS_TARIHI) as a from " + Globals.ortam + ".HAREKET_YOKLAMA ";
            //        query += " where TCKIMLIKNO >=  ";
            //        query += " ( ";
            //        query += " select max(TCKIMLIKNO) from ( ";
            //        query += " select  distinct TCKIMLIKNO from ( ";
            //        query += " select distinct TCKIMLIKNO from  " + Globals.ortam + ".HAREKET_YOKLAMA where KAPSAM != '4C' order by TCKIMLIKNO ";
            //        query += " ) ";
            //        query += " fetch first " + baslangic.ToString() + " rows only ";
            //        query += " ) ";
            //        query += " ) ";
            //        query += " and TCKIMLIKNO <=  ";
            //        query += " ( ";
            //        query += " select max(TCKIMLIKNO) from ( ";
            //        query += " select  distinct TCKIMLIKNO from ( ";
            //        query += " select distinct TCKIMLIKNO from  " + Globals.ortam + ".HAREKET_YOKLAMA where KAPSAM != '4C' order by TCKIMLIKNO ";
            //        query += " ) ";
            //        query += " fetch first " + bitis.ToString() + " rows only ";
            //        query += " ) ";
            //        query += " ) ";
            //        query += " and KAPSAM != '4C' ";
            //        query += " group by TCKIMLIKNO ";



            //string query = "select TCKIMLIKNO, max(CIKIS_TARIHI) as a from "+Globals.ortam+ ".HAREKET_YOKLAMA where KAPSAM != '4C' and TCKIMLIKNO in (Select distinct TCKIMLIKNO from  " + Globals.ortam + ".HAREKET_YOKLAMA where TCKIMLIKNO >= (select max(TCKIMLIKNO) from  " + Globals.ortam + ".HAREKET_YOKLAMA where TCKIMLIKNO in (SELECT TCKIMLIKNO from  " + Globals.ortam + ".HAREKET_YOKLAMA FETCH first " + baslangic.ToString() + " rows only)) and TCKIMLIKNO <= (select max(TCKIMLIKNO) from  " + Globals.ortam + ".HAREKET_YOKLAMA where TCKIMLIKNO in (SELECT TCKIMLIKNO from  " + Globals.ortam + ".HAREKET_YOKLAMA FETCH first " + bitis.ToString() + " rows only))order by TCKIMLIKNO ASC) group by TCKIMLIKNO with ur";
            //string query = "select TCKIMLIKNO, max(CIKIS_TARIHI) as a from SHSTBT01.HAREKET_YOKLAMA where kapsam!= '4C' and TCKIMLIKNO in (Select distinct TCKIMLIKNO from SHSTBT01.HAREKET_YOKLAMA where id >=  " + (baslangic + 29145).ToString() + "  and id <= " + (bitis + 29145).ToString() + " order by TCKIMLIKNO ASC) group by TCKIMLIKNO with ur";

            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    HareketYoklama pHareketYoklama = new HareketYoklama();
                    pHareketYoklama.TCKimlikNo = Convert.ToInt64(dr["TCKIMLIKNO"].ToString());
                    pHareketYoklama.CikisTarihi = dr["a"].ToString();
                    selectAllFromHareketYoklama(con, ref pHareketYoklama);
                    list.Add(pHareketYoklama);
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

            return list;
        }






        public List<HareketYoklama> selectDistinctTCKimlikNoFromHareketYoklama4C(int baslangic, int bitis)
        {
            List<HareketYoklama> list = new List<HareketYoklama>();
            OleDbConnection con = new OleDbConnection(veriTabaniBaglantisi.SSKDB2);
            //TEST AMAÇLI
            //  string query = "select TCKIMLIKNO, max(CIKIS_TARIHI) as a from " + Globals.ortam + ".HAREKET_YOKLAMA where KAPSAM = '4C' and TCKIMLIKNO='15082669670' group by TCKIMLIKNO";


            string query = " select h.TCKIMLIKNO, max(CIKIS_TARIHI) as a from  " + Globals.ortam + ".HAREKET_YOKLAMA h,  " + Globals.ortam + ".NUFUS n ";
            query += " where h.TCKIMLIKNO >=  ";
            query += " ( ";
            query += " select max(TCKIMLIKNO) from ( ";
            query += " select  distinct TCKIMLIKNO from ( ";
            //          query += " select distinct h.TCKIMLIKNO from   " + Globals.ortam + ".HAREKET_YOKLAMA h,  " + Globals.ortam + ".NUFUS n  where KAPSAM = '4C' and n.TCKIMLIKNO = h.TCKIMLIKNO order by h.TCKIMLIKNO ";
            query += " select distinct h.TCKIMLIKNO from   " + Globals.ortam + ".HAREKET_YOKLAMA h,  " + Globals.ortam + ".NUFUS n  where KAPSAM = '4C' and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B'   and n.TCKIMLIKNO = h.TCKIMLIKNO order by h.TCKIMLIKNO ";
            //      query += " ) ";
            query += " fetch first " + baslangic.ToString() + " rows only ";
            query += " ) ";
            query += " ) ";
            query += " ) ";
            query += " and h.TCKIMLIKNO <=  ";
            query += " ( ";
            query += " select max(TCKIMLIKNO) from ( ";
            query += " select  distinct TCKIMLIKNO from ( ";
            //     query += " select distinct h.TCKIMLIKNO from   " + Globals.ortam + ".HAREKET_YOKLAMA h, "  + Globals.ortam + ".NUFUS n where KAPSAM = '4C' and n.TCKIMLIKNO = h.TCKIMLIKNO order by h.TCKIMLIKNO ";
            query += " select distinct h.TCKIMLIKNO from   " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where KAPSAM = '4C' and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B'  and n.TCKIMLIKNO = h.TCKIMLIKNO order by h.TCKIMLIKNO ";
            //      query += " ) ";
            query += " fetch first " + bitis.ToString() + " rows only ";
            query += " ) ";
            query += " ) ";
            query += " ) ";
            query += " and KAPSAM = '4C' and n.TCKIMLIKNO = h.TCKIMLIKNO and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B' ";
            query += " group by h.TCKIMLIKNO ";


            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    tcArray[count] = Convert.ToInt64(dr["TCKIMLIKNO"].ToString());
                    tarihArray[count] = dr["a"].ToString();
                    count++;
                }

                for (int i = 0; i < count; i++)
                {
                    HareketYoklama pHareketYoklama = new HareketYoklama();
                    pHareketYoklama.TCKimlikNo = tcArray[i];
                    pHareketYoklama.CikisTarihi = tarihArray[i];
                    selectAllFromHareketYoklama(con, ref pHareketYoklama);
                    list.Add(pHareketYoklama);
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

            return list;
        }

        public void selectAllFromHareketYoklama(OleDbConnection con, ref HareketYoklama pHareketYoklama)
        {
            string query = "Select * from  " + Globals.ortam + ".HAREKET_YOKLAMA where TCKIMLIKNO = ? and CIKIS_TARIHI = ? ";
            OleDbCommand cmd = new OleDbCommand(query, con);

            cmd.Parameters.Add("TCKIMLIKNO", OleDbType.Decimal).Value = pHareketYoklama.TCKimlikNo;
            cmd.Parameters.Add("CIKIS_TARIHI", OleDbType.DBDate).Value = pHareketYoklama.CikisTarihi.Substring(0, 10);

            OleDbDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();
                int a = 0;

                while (dr.Read())
                {

                    if (int.TryParse(dr["TAHSIS_NO"].ToString().Trim(), out a))
                        pHareketYoklama.TahsisNo = dr["TAHSIS_NO"].ToString();
                    else
                        pHareketYoklama.TahsisNo = nullTahsisNoDuzeltme(con, pHareketYoklama.TCKimlikNo);

                    pHareketYoklama.Kapsam = dr["KAPSAM"].ToString();
                    pHareketYoklama.Ad = dr["AD"].ToString().Trim();
                    pHareketYoklama.Soyad = dr["SOYAD"].ToString().Trim();
                    pHareketYoklama.CikisTarihi = dr["CIKIS_TARIHI"].ToString();
                    pHareketYoklama.GirisTarihi = dr["GIRIS_TARIHI"].ToString();
                    pHareketYoklama.CiktiAlinmaTarihi = dr["CIKTI_ALINMA_TARIHI"].ToString();
                    pHareketYoklama.DosyaYeri = dr["DOSYA_YERI"].ToString().Trim();
                    pHareketYoklama.AylikTuru = dr["AYLIK_TURU"].ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public string nullTahsisNoDuzeltme(OleDbConnection con, decimal tc)
        {

            string query = "select TAHSIS_NO from  " + Globals.ortam + ".HAREKET_YOKLAMA where TCKIMLIKNO = ? and TAHSIS_NO > 0  with ur";
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.Parameters.Add("TCKIMLIKNO", OleDbType.Decimal).Value = tc;
            OleDbDataReader dr = null;
            string tahsis = null;

            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tahsis = dr["TAHSIS_NO"].ToString();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }

            return tahsis;
        }

        //public String hataliDosyayeriDuzeltme(OleDbConnection con, decimal tc, String kapsam)
        //{
        //    string query = "";
        //    if (kapsam == "4A")
        //        query = "select DOSYA_YERI from SHSTBT01.HAREKET_YOKLAMA as a where a.TCKIMLIKNO = ? and a.DOSYA_YERI not like '%/%'  with ur";
        //    else
        //        query = "select DOSYA_YERI from SHSTBT01.HAREKET_YOKLAMA as a where a.TCKIMLIKNO = ? and a.DOSYA_YERI not like '%/%'  with ur";

        //    OleDbCommand cmd = new OleDbCommand(query, con);
        //    cmd.Parameters.Add("TCKIMLIKNO", OleDbType.Decimal).Value = tc;
        //    OleDbDataReader dr = null;
        //    string dosyaYeri = "";

        //    try
        //    {

        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }

        //        dr = cmd.ExecuteReader();

        //        if (dr.Read())
        //        {
        //            dosyaYeri = dr["DOSYA_YERI"].ToString().Trim();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw e;
        //    }
        //    if (dosyaYeri == null)
        //        dosyaYeri = "";
        //    return dosyaYeri;
        //}


        public List<HareketYoklama> selectTekTc(decimal? tcKimlikNo, decimal? tahsisNo)
        {
            List<HareketYoklama> list = new List<HareketYoklama>();
            OleDbConnection con = new OleDbConnection(veriTabaniBaglantisi.SSKDB2);

            string query = " select h.TCKIMLIKNO, max(CIKIS_TARIHI) as a from  SHSTBT01.HAREKET_YOKLAMA h,  SHSTBT01.NUFUS n ";
            if (tahsisNo == null)
                query += " where (h.AYLIK_TURU='B' or h.AYLIK_TURU='P') and n.TCKIMLIKNO = h.TCKIMLIKNO and h.TCKIMLIKNO=?  ";
            else
                query += " where (h.AYLIK_TURU='B' or h.AYLIK_TURU='P') and n.TCKIMLIKNO = h.TCKIMLIKNO and h.TAHSIS_NO=?  ";
            query += " group by h.TCKIMLIKNO ";



            OleDbCommand cmd = new OleDbCommand(query, con);
            if (tahsisNo == null)
                cmd.Parameters.Add("TCKIMLIKNO", OleDbType.Decimal).Value = tcKimlikNo;
            else
                cmd.Parameters.Add("TAHSIS_NO", OleDbType.Decimal).Value = tahsisNo;
            OleDbDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    HareketYoklama pHareketYoklama = new HareketYoklama();
                    pHareketYoklama.TCKimlikNo = Convert.ToInt64(dr["TCKIMLIKNO"].ToString());
                    pHareketYoklama.CikisTarihi = dr["a"].ToString();
                    selectAllFromHareketYoklama(con, ref pHareketYoklama);
                    list.Add(pHareketYoklama);
                }
                else
                {
                    throw new Exception("Kayıt Bulunamadı");
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

            return list;
        }










    }






}