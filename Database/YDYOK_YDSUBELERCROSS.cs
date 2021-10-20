using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using YurtdisiTebligat.General;


namespace YurtdisiTebligat.Database
{
    public class YDYOK_YDSUBELERCROSS
    {
        private VeriTabanıBaglantisi veriTabaniBaglantisi = new VeriTabanıBaglantisi();
        Sabit sabit = new Sabit();

        #region Fields
        private string _SSK;
        private decimal _Bagkur;
        private decimal _Meyes;
        private string _SGMAdi;
        private string _KullaniciId;
        private DateTime _IslemZamani;
        private string _KullaniciIP;
        private string _TerminalId;
        private string _IslemKodu;
        #endregion

        #region Properties
        public string SSK
        {
            get
            {
                return _SSK;
            }

            set
            {
                _SSK = value;
            }
        }

        public decimal Bagkur
        {
            get
            {
                return _Bagkur;
            }

            set
            {
                _Bagkur = value;
            }
        }

        public decimal Meyes
        {
            get
            {
                return _Meyes;
            }

            set
            {
                _Meyes = value;
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

        public string KullaniciId
        {
            get
            {
                return _KullaniciId;
            }

            set
            {
                _KullaniciId = value;
            }
        }

        public DateTime IslemZamani
        {
            get
            {
                return _IslemZamani;
            }

            set
            {
                _IslemZamani = value;
            }
        }

        public string KullaniciIP
        {
            get
            {
                return _KullaniciIP;
            }

            set
            {
                _KullaniciIP = value;
            }
        }

        public string TerminalId
        {
            get
            {
                return _TerminalId;
            }

            set
            {
                _TerminalId = value;
            }
        }

        public string IslemKodu
        {
            get
            {
                return _IslemKodu;
            }

            set
            {
                _IslemKodu = value;
            }
        }
        #endregion

        public void selectDosyaYeri(ref List<Genel> genelListe)
        {

            OleDbConnection con = new OleDbConnection(veriTabaniBaglantisi.SSKDB2);

            string query = "";

            try
            {
                for (int i = 0; i < genelListe.Count; i++)
                {
                    if (genelListe[i].Kapsam == "4C")
                        continue;

                    if (genelListe[i].Kapsam == "4A")
                    {
                        //query = "Select SGM_ADI from SHSTBT01.YDYOK_YDSUBELERCROSS where SSK = ? with ur";
                        if (genelListe[i].DosyaYeri == "")
                            genelListe[i].SGMAdi = "";
                        else
                            genelListe[i].SGMAdi = sabit.ilDondur(genelListe[i].DosyaYeri.Substring(0, 2)).ToUpper() + " SOSYAL GÜVENLİK İL MÜDÜRLÜĞÜ'ne";
                        continue;
                    }
                    else if (genelListe[i].Kapsam == "4B")
                        query = "Select SGM_ADI from  " + Globals.ortam + ".YDYOK_YDSUBELERCROSS where BAGKUR = ? with ur";


                    OleDbCommand cmd = new OleDbCommand(query, con);
                    if (genelListe[i].Kapsam == "4A")
                        cmd.Parameters.Add("SSK", OleDbType.VarChar).Value = genelListe[i].DosyaYeri;
                    else if (genelListe[i].Kapsam == "4B")
                        cmd.Parameters.Add("BAGKUR", OleDbType.Decimal).Value = Convert.ToDecimal(genelListe[i].DosyaYeri);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    OleDbDataReader dr = null;
                    dr = cmd.ExecuteReader();


                    if (dr.Read())
                    {
                        YDYOK_YDSUBELERCROSS yDYOK_YDSUBELERCROSS = new YDYOK_YDSUBELERCROSS();
                        genelListe[i].SGMAdi = dr["SGM_ADI"].ToString().Trim().ToUpper() + "'ne";

                    }
                    else
                    {
                        genelListe[i].SGMAdi = "";

                    }
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