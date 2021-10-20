using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using YurtdisiTebligat.Database;
using YurtdisiTebligat.General;

namespace YurtdisiTebligat
{

    public partial class Anasayfa : System.Web.UI.Page
    {

        private VeriTabanıBaglantisi veriTabaniBaglantisi = new VeriTabanıBaglantisi();
        Genel genel = new Genel();
        List<Genel> genelListe = new List<Genel>();
        Globals myGlobals = new Globals();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != "true")
                Response.Redirect("login.aspx");

            Label2.Text = getTumKisiSayisi4AB().ToString();
            Label6.Text = getTumVeriSayisi4AB().ToString();
            //Label4.Text = getTumVeriSayisi4C().ToString();
            Label4.Text = getTumKisiSayisi4C().ToString();
            Label8.Text = getTumVeriSayisi4C().ToString();
            Label11.Text = getTumKisiSayisi4B().ToString();
            Label13.Text = getTumVeriSayisi4B().ToString();
        }

        protected void BtnDokumAl_Click(object sender, EventArgs e)
        {

            try
            {
                Label9.Visible = false;

                int a = int.Parse(TextBox1.Text);
                int b = int.Parse(TextBox2.Text);

                if (a > 0 && b > 0 && b >= a && b < getTumVeriSayisi4AB() && b - a <= 200)
                    genelListe = genel.setGenelValues(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox2.Text));

                if ((b - a) <= 200)
                {
                    createPdf();
                }
                else
                {
                    Label9.Visible = true;

                    Label9.Text = "En fazla 200 adet kayıt alınabilir.";
                }


            }
            catch { }

        }

        protected void BtnDokumAl_Click4B(object sender, EventArgs e)
        {

            try
            {
                Label9.Visible = false;

                int a = int.Parse(TextBox1.Text);
                int b = int.Parse(TextBox2.Text);


                if (a > 0 && b > 0 && b >= a && b < getTumVeriSayisi4AB() && b - a <= 200)
                    genelListe = genel.setGenelValues4B(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox2.Text), null, null);

                if ((b - a) <= 200)
                {
                    createPdf();
                }
                else
                {
                    Label9.Visible = true;

                    Label9.Text = "En fazla 200 adet kayıt alınabilir.";
                }


            }
            catch { }

        }

        protected void BtnTekTC_Click(object sender, EventArgs e)
        {
            try
            {
                decimal parsedResult;
                decimal? tcResult;

                if (decimal.TryParse(TextBox3.Text, out parsedResult))
                    tcResult = Convert.ToDecimal(TextBox3.Text);
                else
                    throw new Exception("TC numarası hatalı");

                genelListe = genel.setGenelValues4B(null, null, tcResult, null);
                createPdf();
            }
            catch (Exception ex)
            {
                Label9.Visible = true;

                Label9.Text = ex.Message;
            }


        }
        protected void BtnTekTahsis_Click(object sender, EventArgs e)
        {
            try
            {
                decimal parsedResult;
                decimal? tahsisResult;

                if (decimal.TryParse(TextBox4.Text, out parsedResult))
                    tahsisResult = Convert.ToDecimal(TextBox4.Text);
                else
                    throw new Exception("Tahsis numarası hatalı");

                genelListe = genel.setGenelValues4B(null, null, null, tahsisResult);
                createPdf();
            }
            catch (Exception ex)
            {
                Label9.Visible = true;

                Label9.Text = ex.Message;
            }
        }
        protected void BtnDokumAl4C0_Click(object sender, EventArgs e)
        {
            try
            {
                Label9.Visible = false;

                int a = int.Parse(TextBox1.Text);
                int b = int.Parse(TextBox2.Text);

                if (a > 0 && b > 0 && b >= a && b < getTumVeriSayisi4C() && b - a <= 200)
                    genelListe = genel.setGenelValues4C(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox2.Text));

                if ((b - a) <= 200)
                {
                    createPdf();
                }
                else
                {
                    Label9.Visible = true;
                    Label9.Text = "En fazla 200 adet kayıt alınabilir.";
                }

            }
            catch { }

        }

        protected void BtnVeriGoruntule_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(TextBox1.Text);
                int b = int.Parse(TextBox2.Text);

                //         if (a > 0 && b > 0 && b >= a && b < getTumVeriSayisi4AB())
                if (a > 0 && b > 0 && b >= a && b < getTumVeriSayisi4AB() && b - a <= 900)

                    Response.Redirect("VeriGoruntule.aspx?prameter1=" + TextBox1.Text + "&prameter2=" + TextBox2.Text + "&prameter3=" + "4A");
                else
                {
                    Label9.Visible = true;
                    Label9.Text = "En fazla 900 adet kayıt görüntülebilir.";
                }

            }
            catch { }
        }


        protected void BtnVeriGoruntule_Click4B(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(TextBox1.Text);
                int b = int.Parse(TextBox2.Text);

                if (a > 0 && b > 0 && b >= a && b < getTumVeriSayisi4B() && b - a <= 900)
                    Response.Redirect("VeriGoruntule.aspx?prameter1=" + TextBox1.Text + "&prameter2=" + TextBox2.Text + "&prameter3=" + "4B");
                else
                {
                    Label9.Visible = true;
                    Label9.Text = "En fazla 900 adet kayıt görüntülebilir.";
                }

            }
            catch { }
        }
        protected void BtnTumVerileriGoruntule_Click(object sender, EventArgs e)
        {
            try
            {

                int a = int.Parse(TextBox1.Text);
                int b = int.Parse(TextBox2.Text);

                if (a > 0 && b > 0 && b >= a && b < getTumVeriSayisi4C() && b - a <= 900)
                    Response.Redirect("VeriGoruntule.aspx?prameter1=" + TextBox1.Text + "&prameter2=" + TextBox2.Text + "&prameter3=" + "4C");
                else
                {
                    Label9.Visible = true;
                    Label9.Text = "En fazla 900 adet kayıt görüntülebilir.";
                }

            }
            catch { }
        }

        public void createPdf()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition",
             "attachment;filename=tebligat.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            StringReader sr = new StringReader(sw.ToString());
            Document doc = new Document();
            HTMLWorker htmlparser = new HTMLWorker(doc);
            string path = Server.MapPath(".");
            PdfWriter.GetInstance(doc, Response.OutputStream);
            String baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            doc.Open();
            htmlparser.Parse(sr);
            BaseFont customfont = BaseFont.CreateFont(baseUrl + "Images/ARIALUNI.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font fontBuyuk = new Font(customfont, 11);
            Font fontKucuk = new Font(customfont, 8);

            try
            {
                for (int i = 0; i < genelListe.Count; i++)
                {
                    if (genelListe[i].TahsisNo != null)
                    {
                        String sayi;

                        if (genelListe[i].Kapsam.CompareTo("4A") == 0)
                            sayi = "40825013";
                        else if (genelListe[i].Kapsam.CompareTo("4B") == 0)
                            sayi = "40825013";
                        else
                            sayi = "12151965";

                        myGlobals.setSayiTarih(genelListe[i].TahsisNo, myGlobals.getDate(DateTime.Now), sayi);
                        myGlobals.setAdSoyad((genelListe[i].Ad + " " + genelListe[i].Soyad).ToString());
                        String adresMahalle = "";
                        String adresIlIlce = "";

                        //// ************************************************************************************************************************************************************

                        //  *********************    AÇIK ADRES   NULL DAN FARKLI İSE ;


                        //           if (genelListe[i].acikadres != null) || genelListe[i].acikadres.Trim() != "")
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

                            //    adresIlIlce = genelListe[i].UlkeSehir.ToString().Trim();
                            //  adresIlIlce += "/";
                            //      adresIlIlce += genelListe[i].Ulke.ToString().Trim();
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




                        //// ************************************************************************************************************************************************************
                        myGlobals.setAdresMahalle(adresMahalle.Replace("\n", " "));
                        myGlobals.setAdresIlIlce(adresIlIlce);

                        if (genelListe[i].Kapsam.Equals("4A") || genelListe[i].Kapsam.Equals("4B"))
                        {
                            myGlobals.setDaireBaskanligi("Yurtdışı Sözleşmeler ve Emeklilik Daire Başkanlığı");
                            myGlobals.setUcuncuParagraf(genelListe[i].SGMAdi);
                            myGlobals.setImagePath(baseUrl + "Images/zalif.png");

                            if (genelListe[i].GirisTarihi != null && genelListe[i].GirisTarihi != "")
                            {
                                myGlobals.setIkinciParagraf("       Emniyet Genel Müdürlüğünden alınan kayıtlar incelendiğinde son olarak " + genelListe[i].CikisTarihi.Substring(0, 10) + " - " + genelListe[i].GirisTarihi.Substring(0, 10) + " tarihleri arasında altı aydan fazla yurt dışında bulunduğunuz tespit edilmiştir.");
                            }
                            else
                            {
                                myGlobals.setIkinciParagraf("       Emniyet Genel Müdürlüğünden alınan kayıtlar incelendiğinde son olarak " + genelListe[i].CikisTarihi.Substring(0, 10) + " tarihinden itibaren altı aydan fazla yurt dışında bulunduğunuz tespit edilmiştir. ");
                            }
                        }
                        else if (genelListe[i].Kapsam.Equals("4C"))
                        {
                            myGlobals.setImagePath(baseUrl + "Images/ozan2.png");
                            myGlobals.setDaireBaskanligi("Kamu Görevlileri Ödemeler Daire Başkanlığı");
                            myGlobals.setUcuncuParagraf("Kamu Görevlileri Ödemeler Daire Başkanlığı'na");

                            if (genelListe[i].GirisTarihi != null && genelListe[i].GirisTarihi != "")
                            {
                                myGlobals.setIkinciParagraf("       Emniyet Genel Müdürlüğünden alınan kayıtlar incelendiğinde son olarak " + genelListe[i].GirisTarihi.Substring(0, 10) + " - " + genelListe[i].CikisTarihi.Substring(0, 10) + " tarihleri arasında altı aydan fazla yurt dışında bulunduğunuz tespit edilmiştir.");
                            }
                            else
                            {
                                myGlobals.setIkinciParagraf("       Emniyet Genel Müdürlüğünden alınan kayıtlar incelendiğinde son olarak " + genelListe[i].CikisTarihi.Substring(0, 10) + " tarihinden itibaren altı aydan fazla yurt dışında bulunduğunuz tespit edilmiştir. ");
                            }
                        }
                        paragrafEkle(ref doc, fontBuyuk, fontKucuk, genelListe[i].Kapsam);

                        doc.NewPage();
                    }
                }
                guncelleCiktiAlinmaTarihi();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            try
            {
                doc.Close();
                Response.Write(doc);
                Response.End();
            }
            catch (Exception e)
            {
            }

        }

        private void paragraf(ref Document doc, String str, String str2, String str3, Font font, int i)
        {
            Paragraph myParagraph = new Paragraph(str, font);
            if (i == 1) myParagraph.Alignment = Element.ALIGN_LEFT;
            else if (i == 2) myParagraph.Alignment = Element.ALIGN_CENTER;
            else if (i == 3) myParagraph.Alignment = Element.ALIGN_JUSTIFIED;


            if (str2 != null)
            {
                myParagraph.Add(underlineChunk(str2));
            }

            if (str3 != null)
            {
                myParagraph.Add(str3);
            }

            doc.Add(myParagraph);
        }

        private Chunk underlineChunk(String str)
        {
            Chunk underlinedText = new Chunk(str);
            underlinedText.SetUnderline(0.1f, -2f);
            return underlinedText;
        }

        //private void paragraf2(ref Document doc, String str, String str2, Font font, int i)
        //{
        //    Paragraph myParagraph = new Paragraph(str, font);
        //    if (i == 1) myParagraph.Alignment = Element.ALIGN_LEFT;
        //    else if (i == 2) myParagraph.Alignment = Element.ALIGN_CENTER;
        //    else if (i == 3) myParagraph.Alignment = Element.ALIGN_JUSTIFIED;

        //    Chunk sigUnderline = new Chunk(str2);
        //    sigUnderline.SetUnderline(0.1f, -2f);

        //    myParagraph.Add(sigUnderline);
        //    doc.Add(myParagraph);
        //}

        private void paragrafEkle(ref Document doc, Font fontBuyuk, Font fontKucuk, String kapsam)
        {
            paragraf(ref doc, myGlobals.getTC(), null, null, fontBuyuk, 2);
            paragraf(ref doc, myGlobals.getSosyalGuvenlikKurumu(), null, null, fontBuyuk, 2);
            paragraf(ref doc, myGlobals.getGenelMudurluk(), null, null, fontBuyuk, 2);
            paragraf(ref doc, myGlobals.getDaireBaskanligi(), null, null, fontBuyuk, 2);
            paragraf(ref doc, " ", null, null, fontKucuk, 2);
            paragraf(ref doc, " ", null, null, fontKucuk, 2);
            paragraf(ref doc, myGlobals.getSayiTarih(), null, null, fontBuyuk, 1);
            paragraf(ref doc, myGlobals.getKonu(), null, null, fontBuyuk, 1);
            paragraf(ref doc, " ", null, null, fontKucuk, 3);
            paragraf(ref doc, myGlobals.getAdSoyad(), null, null, fontBuyuk, 2);
            paragraf(ref doc, myGlobals.getAdresMahalle(), null, null, fontBuyuk, 2);
            paragraf(ref doc, myGlobals.getAdresIlIlce(), null, null, fontBuyuk, 2);
            paragraf(ref doc, myGlobals.getIlkParagraf(), myGlobals.getIlkParagraf2(), myGlobals.getIlkParagraf3(), fontBuyuk, 3);
            paragraf(ref doc, myGlobals.getIkinciParagraf(), null, null, fontBuyuk, 3);
            paragraf(ref doc, myGlobals.getUcuncuParagraf(), null, null, fontBuyuk, 3);
            paragraf(ref doc, myGlobals.getDorduncuParagraf(), myGlobals.getDorduncuParagraf2(), null, fontBuyuk, 3);
            paragraf(ref doc, String.Format(myGlobals.getBesinciParagraf(), DateTime.Now.AddDays(90).Day.ToString(), DateTime.Now.AddDays(90).Month.ToString(), DateTime.Now.AddDays(90).Year.ToString()), myGlobals.getBesinciParagraf2(), myGlobals.getBesinciParagraf3(), fontBuyuk, 3);
            paragraf(ref doc, myGlobals.getAltinciParagraf(), myGlobals.getAltinciParagraf2(), myGlobals.getAltinciParagraf3(), fontBuyuk, 3);
            paragraf(ref doc, " ", null, null, fontKucuk, 3);
            paragraf(ref doc, " ", null, null, fontKucuk, 3);
            paragraf(ref doc, " ", null, null, fontKucuk, 3);
            paragraf(ref doc, " ", null, null, fontKucuk, 3);
            paragraf(ref doc, " ", null, null, fontKucuk, 3);
            paragraf(ref doc, " ", null, null, fontKucuk, 3);
            paragraf(ref doc, " ", null, null, fontKucuk, 3);
            paragraf(ref doc, myGlobals.getEkler(), null, null, fontKucuk, 3);
            paragraf(ref doc, myGlobals.getCizgi(), null, null, fontKucuk, 3);

            if (kapsam.CompareTo("4A") == 0 || kapsam.CompareTo("4B") == 0)
            {
                paragraf(ref doc, myGlobals.getIletisim(), null, null, fontKucuk, 3);

            }

            else
                paragraf(ref doc, myGlobals.getIletisim2(), null, null, fontKucuk, 3);

            try
            {
                String baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                //String baseUrl = "http://netintratest.sgk.intra/YurtDisiYoklamaTebligat/";
                string imageURL = baseUrl + "Images/sgk.jpg";
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
                jpg.ScaleToFit(80f, 80f);
                jpg.SpacingBefore = 10f;
                jpg.SpacingAfter = 1f;
                jpg.SetAbsolutePosition(30, 720);
                jpg.Alignment = Element.ALIGN_LEFT;
                doc.Add(jpg);
            }
            catch { }

            try
            {
                string imageURL1 = myGlobals.getImagePath();
                iTextSharp.text.Image jpg1 = iTextSharp.text.Image.GetInstance(imageURL1);
                jpg1.ScaleToFit(135f, 135f);
                jpg1.SpacingBefore = 10f;
                jpg1.SpacingAfter = 1f;
                jpg1.SetAbsolutePosition(435, 165);
                doc.Add(jpg1);
            }
            catch { }
        }

        private void guncelleCiktiAlinmaTarihi()
        {
            try
            {

                String kullanici = Globals.kullanici;
                String ipAdres = Globals.ipAdres;

                for (int i = 0; i < genelListe.Count; i++)
                {
                    if ((genelListe[i].CiktiAlinmaTarihi == null || genelListe[i].CiktiAlinmaTarihi == "" || Convert.ToDateTime(genelListe[i].CiktiAlinmaTarihi) == Convert.ToDateTime("1111-01-01")) && genelListe[i].TahsisNo != null)
                    {
                        OleDbConnection con = new OleDbConnection(veriTabaniBaglantisi.SSKDB2);
                        string query = "update " + Globals.ortam + ".HAREKET_YOKLAMA set CIKTI_ALINMA_TARIHI = '" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "', KULLANICI_ID='" + kullanici + "', KULLANICI_IP='" + ipAdres + "' where TCKIMLIKNO = ? "; //XXX AND CIKIS_TARIHI=?
                        OleDbCommand cmd = new OleDbCommand(query, con);
                        con.Open();
                        cmd.Parameters.Add("TCKIMLIKNO", OleDbType.Decimal).Value = genelListe[i].TCKimlikNo;
                        //cmd.Parameters.Add("CIKIS_TARIHI", OleDbType.Date).Value = genelListe[i].CikisTarihi;      

                        cmd.ExecuteNonQuery();
                        con.Dispose();
                        con.Close();
                    }
                }
            }
            catch { }
        }


        private int getTumKisiSayisi4AB()
        {
            int veriSayisi = 0;
            OleDbConnection con = new OleDbConnection(veriTabaniBaglantisi.SSKDB2);
            try
            {
                //    string query = "select count(distinct h.TCKIMLIKNO) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM != '4C' ";
                //  string query = "select count(distinct h.TCKIMLIKNO) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM = '4A' and (AYLIK_TURU='B'  or AYLIK_TURU='P')  ";
                string query = "select count(distinct h.TCKIMLIKNO) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM = '4A' and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B'  ";

                //  query += " select distinct h.TCKIMLIKNO from   " + Globals.ortam + ".HAREKET_YOKLAMA h,  " + Globals.ortam + ".NUFUS n  where KAPSAM = '4A' and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B'  and n.TCKIMLIKNO = h.TCKIMLIKNO order by h.TCKIMLIKNO ";

                OleDbCommand cmd = new OleDbCommand(query, con);
                con.Open();
                veriSayisi = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch { }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return veriSayisi;
        }

        private int getTumVeriSayisi4AB()
        {
            int veriSayisi = 0;
            OleDbConnection con = new OleDbConnection(veriTabaniBaglantisi.SSKDB2);
            try
            {
                //    string query = "select count(*) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM != '4C' ";
                //  string query = "select count(*) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM = '4A' and (AYLIK_TURU='B' or AYLIK_TURU='P') ";
                string query = "select count(*) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM = '4A' and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B' ";

                OleDbCommand cmd = new OleDbCommand(query, con);
                con.Open();
                veriSayisi = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch { }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return veriSayisi;
        }


        private int getTumKisiSayisi4B()
        {
            int veriSayisi = 0;
            OleDbConnection con = new OleDbConnection(veriTabaniBaglantisi.SSKDB2);
            try
            {
                //    string query = "select count(distinct h.TCKIMLIKNO) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM != '4C' ";
                //  string query = "select count(distinct h.TCKIMLIKNO) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM = '4B' and (AYLIK_TURU='B'  or AYLIK_TURU='P')  ";
                string query = "select count(distinct h.TCKIMLIKNO) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM = '4B' and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B' ";

                OleDbCommand cmd = new OleDbCommand(query, con);
                con.Open();
                veriSayisi = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch { }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return veriSayisi;
        }

        private int getTumVeriSayisi4B()
        {
            int veriSayisi = 0;
            OleDbConnection con = new OleDbConnection(veriTabaniBaglantisi.SSKDB2);
            try
            {
                //    string query = "select count(*) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM != '4C' ";
                //   string query = "select count(*) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM = '4B' and (AYLIK_TURU='B' or AYLIK_TURU='P') ";
                string query = "select count(*) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM = '4B' and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B' ";

                OleDbCommand cmd = new OleDbCommand(query, con);
                con.Open();
                veriSayisi = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch { }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return veriSayisi;
        }



        private int getTumKisiSayisi4C()
        {
            int veriSayisi = 0;
            OleDbConnection con = new OleDbConnection(veriTabaniBaglantisi.SSKDB2);
            try
            {
                //  string query = "select count(distinct h.TCKIMLIKNO) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM = '4C'";
                //  string query = "select count(distinct h.TCKIMLIKNO) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM = '4C' and (AYLIK_TURU='B' or AYLIK_TURU='P')   ";
                string query = "select count(distinct h.TCKIMLIKNO) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM = '4C' and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B' ";

                OleDbCommand cmd = new OleDbCommand(query, con);
                con.Open();
                veriSayisi = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch { }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return veriSayisi;
        }

        private int getTumVeriSayisi4C()
        {
            int veriSayisi = 0;
            OleDbConnection con = new OleDbConnection(veriTabaniBaglantisi.SSKDB2);
            try
            {
                // string query = "select count(*) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM = '4C' and (AYLIK_TURU='B' or AYLIK_TURU='P') ";
                string query = "select count(*) from " + Globals.ortam + ".HAREKET_YOKLAMA h, " + Globals.ortam + ".NUFUS n where h.TCKIMLIKNO = n.TCKIMLIKNO and h.KAPSAM = '4C' and (h.AYLIK_DURUMU='A' or h.AYLIK_DURUMU='P') AND h.AYLIK_TURU='B' ";

                OleDbCommand cmd = new OleDbCommand(query, con);
                con.Open();
                veriSayisi = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch { }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return veriSayisi;
        }

    }
}