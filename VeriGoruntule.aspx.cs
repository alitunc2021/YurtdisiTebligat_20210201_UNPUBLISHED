using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using YurtdisiTebligat.Database;

namespace YurtdisiTebligat
{
    public partial class VeriGoruntule : System.Web.UI.Page
    {

        Genel genel = new Genel();
        List<Genel> genelListe = new List<Genel>();
        string adresMahalle;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != "true")
                Response.Redirect("login.aspx");

            baslangicDegeri = Request.QueryString["prameter1"];
            bitisDegeri = Request.QueryString["prameter2"];
            Kapsam = Request.QueryString["prameter3"];



            if (Kapsam == "4A")
                genelListe = genel.setGenelValues(Convert.ToInt32(baslangicDegeri), Convert.ToInt32(bitisDegeri));
            else if (Kapsam == "4B")
                genelListe = genel.setGenelValues4B(Convert.ToInt32(baslangicDegeri), Convert.ToInt32(bitisDegeri), null, null);
            else

                genelListe = genel.setGenelValues4C(Convert.ToInt32(baslangicDegeri), Convert.ToInt32(bitisDegeri));

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8] { new DataColumn("Id", typeof(int)),
                                                    new DataColumn("Adı Soyadı", typeof(string)),
                                                    new DataColumn("Tahsis Numarası",typeof(string)),
                                                    new DataColumn("Kapsamı",typeof(string)),
                                                    new DataColumn("Dosya Yeri",typeof(string)),
                                                    new DataColumn("Adres",typeof(string)),
                                                    new DataColumn("İşlem Durumu",typeof(string)),
                                                    new DataColumn("İşlem Tarihi",typeof(string))});

            for (int i = 0; i < genelListe.Count; i++)
            {
                String adresIlIlce = "";

                if (genelListe[i].TahsisNo != null)
                {
                    if (genelListe[i].CiktiAlinmaTarihi == null || genelListe[i].CiktiAlinmaTarihi == "")
                    {
                        genelListe[i].CiktiAlinmaTarihi = "1111-01-01";
                    }

                    string islemDurumu;
                    if (genelListe[i].CiktiAlinmaTarihi.CompareTo("1.01.1111 00:00:00") == 0 || genelListe[i].CiktiAlinmaTarihi.CompareTo("01.01.1111 00:00:00") == 0 || genelListe[i].CiktiAlinmaTarihi.CompareTo("1111-01-01") == 0)
                        islemDurumu = "";
                    else
                        islemDurumu = "ÇIKTI ALINDI";


                    //***************************************afdaf

                    //  *********************    AÇIK ADRES   NULL DAN FARKLI İSE ;

                    if (genelListe[i].acikadres != null && genelListe[i].acikadres.Trim() != "")
                    {
                        Regex exp = new Regex(@"\s{2,}");
                        string odemeAdres = genelListe[i].acikadres.ToString().Trim();
                        int karakterSayisi = odemeAdres.Length;

                        foreach (Match match in exp.Matches(odemeAdres))
                        {
                            int ciftBoslukPozisyonu = match.Index;
                            adresMahalle = odemeAdres.Substring(0, ciftBoslukPozisyonu);
                            adresIlIlce = odemeAdres.Substring(ciftBoslukPozisyonu + 1, odemeAdres.Length - (ciftBoslukPozisyonu + 1)).Trim();
                            break;
                        }

                        if (karakterSayisi > 40 && !exp.IsMatch(odemeAdres))
                        {
                            adresMahalle = odemeAdres.Substring(0, 40);
                            adresIlIlce = odemeAdres.Substring(40, odemeAdres.Length - 40).Trim();
                        }
                        else if (karakterSayisi < 40 && !exp.IsMatch(odemeAdres))
                        {
                            adresMahalle = odemeAdres.ToString();
                        }
                    }

                    //   acikadres =  NULL ise VE IcKapiNo YADA DisKapiNo NULL DAN FARKLI İSE ;

                    else if ((genelListe[i].IcKapiNo != null && genelListe[i].IcKapiNo.Trim() != "") || (genelListe[i].DisKapiNo != null && genelListe[i].DisKapiNo.Trim() != ""))
                    {
                        adresMahalle = genelListe[i].Mahalle.ToString().Trim();
                        adresMahalle += genelListe[i].CSBM.ToString().Trim();
                        adresMahalle += genelListe[i].DisKapiNo.ToString().Trim() + "/";
                        adresMahalle += genelListe[i].IcKapiNo.ToString().Trim();
                        adresIlIlce = genelListe[i].Ilce.ToString().Trim() + "/";
                        adresIlIlce += genelListe[i].Il.ToString().Trim();
                    }

                    //   acikadres =  NULL ise VE IcKapiNo YADA DisKapiNo NULL İSE   ve  ÖDEME ADRES  NULL DAN FARKLI İSE ;

                    else if (genelListe[i].odemeAdres != null && genelListe[i].odemeAdres != "")
                    {
                        Regex exp = new Regex(@"\s{2,}");
                        string odemeAdres = genelListe[i].odemeAdres.ToString().Trim();
                        int karakterSayisi = odemeAdres.Length;

                        foreach (Match match in exp.Matches(odemeAdres))
                        {
                            int ciftBoslukPozisyonu = match.Index;
                            adresMahalle = odemeAdres.Substring(0, ciftBoslukPozisyonu);
                            adresIlIlce = odemeAdres.Substring(ciftBoslukPozisyonu + 1, odemeAdres.Length - (ciftBoslukPozisyonu + 1)).Trim();
                            break;
                        }

                        if (karakterSayisi > 40 && !exp.IsMatch(odemeAdres))
                        {

                            //                                   adresMahalle = genelListe[i].odemeAdres.Trim();


                            adresMahalle = odemeAdres.Substring(0, 40);
                            adresIlIlce = odemeAdres.Substring(40, odemeAdres.Length - 40).Trim();
                        }
                        else if (karakterSayisi < 40 && !exp.IsMatch(odemeAdres))
                        {
                            adresMahalle = odemeAdres.ToString();
                        }

                        //   adresIlIlce = genelListe[i].UlkeSehir.ToString().Trim();
                        //    adresIlIlce += "/";
                        //  adresIlIlce += genelListe[i].Ulke.ToString().Trim();
                    }


                    //   acikadres =  NULL ise VE IcKapiNo YADA DisKapiNo NULL İSE   ve  ÖDEME ADRES  NULL İSE VE UlkeAcikAdres NULL DAN FARKLI İSE ;

                    else if (genelListe[i].AdresTipi.Trim().Equals("4") && genelListe[i].UlkeAcikAdres != null && genelListe[i].UlkeAcikAdres.Trim() != "")
                    {

                        //  if (genelListe[i].UlkeAcikAdres.IndexOf('0') > 0 ||
                        //     genelListe[i].UlkeAcikAdres.IndexOf('1') > 0 ||
                        //     genelListe[i].UlkeAcikAdres.IndexOf('2') > 0 ||
                        //     genelListe[i].UlkeAcikAdres.IndexOf('3') > 0 ||
                        //     genelListe[i].UlkeAcikAdres.IndexOf('4') > 0 ||
                        //     genelListe[i].UlkeAcikAdres.IndexOf('5') > 0 ||
                        //     genelListe[i].UlkeAcikAdres.IndexOf('6') > 0 ||
                        //     genelListe[i].UlkeAcikAdres.IndexOf('7') > 0 ||
                        //     genelListe[i].UlkeAcikAdres.IndexOf('8') > 0 ||
                        //     genelListe[i].UlkeAcikAdres.IndexOf('9') > 0 ) 
                        // { 
                        adresMahalle = genelListe[i].UlkeAcikAdres.ToString().Trim();
                        adresIlIlce = genelListe[i].UlkeSehir.ToString().Trim();
                        adresIlIlce += "/";
                        adresIlIlce += genelListe[i].Ulke.ToString().Trim();
                        // }
                        // else
                        // {

                        //  adresIlIlce = genelListe[i].UlkeSehir.ToString().Trim();
                        //adresIlIlce += "/";
                        //  adresIlIlce += genelListe[i].Ulke.ToString().Trim();
                        //  }
                    }




                    //*************************************adfadf






                    //if (genelListe[i].AdresTipi != null && genelListe[i].AdresTipi.Trim().Equals("4") && genelListe[i].UlkeAcikAdres != null && genelListe[i].UlkeAcikAdres.Trim() != "")
                    //{
                    //    adresMahalle = genelListe[i].UlkeAcikAdres.ToString().Trim();
                    //}
                    //else if (genelListe[i].AdresTipi != null && genelListe[i].AdresTipi.Trim().Equals("4") && (genelListe[i].UlkeAcikAdres == null || genelListe[i].UlkeAcikAdres.ToString().Trim().Equals("")))
                    //{
                    //    adresMahalle = genelListe[i].odemeAdres.ToString().Trim();
                    //}
                    //else
                    //{
                    //    if (genelListe[i].acikadres != null && genelListe[i].acikadres.Trim() != "")
                    //    {
                    //        adresMahalle = genelListe[i].acikadres.ToString().Trim();
                    //    }
                    //    else if ((genelListe[i].IcKapiNo != null && genelListe[i].IcKapiNo.Trim() != "") || (genelListe[i].DisKapiNo != null && genelListe[i].DisKapiNo.Trim() != ""))
                    //    {
                    //        adresMahalle = genelListe[i].Mahalle.ToString().Trim();
                    //        adresMahalle += genelListe[i].CSBM.ToString().Trim();
                    //        adresMahalle += genelListe[i].DisKapiNo.ToString().Trim() + "/";
                    //        adresMahalle += genelListe[i].IcKapiNo.ToString().Trim();
                    //    }
                    //    else
                    //    {
                    //        adresMahalle = genelListe[i].odemeAdres.ToString().Trim();
                    //    }
                    //}




                    if (genelListe[i].DosyaYeri != null && genelListe[i].DosyaYeri.Trim() == "K")
                        genelListe[i].DosyaYeri = "KAMU GÖREVLİLERİ ÖDEMELER DAİRE BAŞKANLIĞI";
                    dt.Rows.Add((i + 1), (genelListe[i].Ad + " " + genelListe[i].Soyad), genelListe[i].TahsisNo, genelListe[i].Kapsam, genelListe[i].DosyaYeri, adresMahalle + " " + adresIlIlce, islemDurumu, (Convert.ToDateTime(genelListe[i].CiktiAlinmaTarihi) == Convert.ToDateTime("1111-01-01")) ? "" : genelListe[i].CiktiAlinmaTarihi.Substring(0, 10));
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private String baslangicDegeri;
        private String bitisDegeri;
        private String Kapsam;
        private string AylikTuru;
    }
}
