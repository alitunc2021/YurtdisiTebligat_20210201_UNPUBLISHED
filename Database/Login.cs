using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using YurtdisiTebligat.General;

namespace YurtdisiTebligat.Database
{
    public class Login
    {
        private VeriTabanıBaglantisi veriTabaniBaglantisi = new VeriTabanıBaglantisi();

        #region Fields
        private String _Ad;
        private String _Soyad;
        private String _SicilNo;
        private String _KullaniciAdi;
        private String _Sifre;
        private String _YetkiTipi;
        
        #endregion

        #region Properties
        public String Ad
        {
            get { return _Ad; }
            set { _Ad = value; }
        }

        public String Soyad
        {
            get { return _Soyad; }
            set { _Soyad = value; }
        }

        public String SicilNo
        {
            get { return _SicilNo; }
            set { _SicilNo = value; }
        }

        public String KullaniciAdi
        {
            get { return _KullaniciAdi; }
            set { _KullaniciAdi = value; }
        }

        public String Sifre
        {
            get { return _Sifre; }
            set { _Sifre = value; }
        }

        public String YetkiTipi
        {
            get { return _YetkiTipi; }
            set { _YetkiTipi = value; }
        } 
        #endregion

        public Boolean yetkiKontrol(string kullaniciAdi, string sifre)
        {

            Globals.kullanici = kullaniciAdi;
            Globals.ipAdres = GetIPAddress();

            bool result = false;

            OleDbConnection con = new OleDbConnection(veriTabaniBaglantisi.SSKDB2);
            string query = "Select * from  " + Globals.ortam + ".LOGIN where KULLANICI_ADI = ? and SIFRE = ? with ur";
            

            OleDbCommand cmd = new OleDbCommand(query, con);

            cmd.Parameters.Add("KULLANICI_ADI", OleDbType.VarChar).Value = kullaniciAdi;
            cmd.Parameters.Add("SIFRE", OleDbType.VarChar).Value = sifre;
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
                    result = true;
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


            return result;
        }

        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }


    }
}