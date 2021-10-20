using System;

/*Anasayfa sınıfında kullanılan constantların tutulduğu sınıf*/

namespace YurtdisiTebligat
{
    public class Globals
    {

        public static String ortam = "SHSTBT01";

        private const String TC = "TC";
        private const String SOSYAL_GUVENLIK_KURUMU = "SOSYAL GÜVENLİK KURUMU BAŞKANLIĞI";
        private const String GENEL_MUDURLUK = "Emeklilik Hizmetleri Genel Müdürlüğü";
        private String daireBaskanligi;
        private String sayiTarih = "";
        private const String KONU = "Konu : Yoklama İşlemleri\n";
        private String adSoyad = "";
        private const String ILK_PARAGRAF = "\n       06/11/2008 tarihli 27046 sayılı Resmi Gazetede yayımlanan Yurtdışında Geçen Sürelerin Borçlandırılması ve Değerlendirilmesine İlişkin Yönetmeliğin 14 üncü maddesi gereğince 3201 sayılı Yurtdışında Bulunan Türk Vatandaşlarının Yurtdışında Geçen Sürelerinin Sosyal Güvenlikleri Bakımından Değerlendirilmesi Hakkında Kanuna göre borçlandıkları süreler dikkate alınarak malullük, yaşlılık ve emekli aylığı bağlananlardan ";
        private const String ILK_PARAGRAF2 = "altı aydan daha uzun süre";
        private const String ILK_PARAGRAF3 = " yurt dışında bulunmuş olanlar, yurt dışında çalışıp çalışmadıklarını ve ikamete dayalı bir sosyal sigorta ya da sosyal yardım ödeneği alıp almadıklarını gösterir belgeleri, 3201 sayılı Kanuna Göre Aylık Alanlara Mahsus Yoklama Belgesi ile birlikte söz konusu altı aylık sürenin dolduğu tarihten sonra üç ay içinde Kuruma vermek zorundadırlar.";
        private String ikinciParagraf;
        private String ucuncuParagraf;
        private const String ARA_PARAGRAF = " ";
        private const String DORDUNCU_PARAGRAF = "       Aylık başlangıç tarihinden itibaren yurt dışında çalışmış ya da halen çalışıyor iseniz veya ikamete dayalı bir sosyal sigorta ya da sosyal yardım ödeneği almış ya da halen alıyor iseniz bu süreleri gösterir ";
        private const String DORDUNCU_PARAGRAF2 = "ekteki açıklamalarda 'Hizmet Belgeleri' başlığı altında belirtilen durumunuza uygun belgelerden birini yoklama belgesine eklemeniz şarttır.";
        private const String BESINCI_PARAGRAF = "       Yoklama belgesini {0}/{1}/{2} tarihine kadar Kuruma vermediğiniz takdirde bildirim yapılmaksızın ";
        private const String BESINCI_PARAGRAF2 = "aylığınız durdurulacaktır";
        private const String BESINCI_PARAGRAF3 = ".";
        private const String ALTINCI_PARAGRAF = "       Bundan sonra da yurt dışında bulunacağınız altı aydan daha uzun süreler için ";
        private const String ALTINCI_PARAGRAF2 = "http://www.sgk.gov.tr/wps/portal/sgk/tr/emekli/form_ve_dilekceler/formlar";
        private const String ALTINCI_PARAGRAF3 = " adresinden ulaşabileceğiniz yoklama belgesini düzenli olarak her yıl Kuruma göndermenizi rica ederim.";
        private const String EKLER = @"EKLER :
1- Yoklama Belgesi (1 sayfa)
2- 3201 sayılı Kanunun uygulanmasına dair bilgiler (1 sayfa) 
Kanunun uygulanmasına dair bilgiler ile yapacağınız işlemlere ait ekteki açıklamaları dikkatle okuyunuz!";
        private const String CIZGI = "________________________________________________________________________________________________________________________";

        private const String ILETISIM = @"Adres	:  Mithatpaşa Cad. No:7 06437 Sıhhiye/Ankara                         	
Telefon	:  (+90 312)  444 32 01                                                                                                                             Faks:   (+90 312)  432 12 45
e-posta  :  yurtdisimevzuat@sgk.gov.tr                                                                                                              Elektronik Ağ : www.sgk.gov.tr";

        private const String ILETISIM2 = @"Adres	:  Mithatpaşa Cad. No:7 06437 Sıhhiye/Ankara                         	
Telefon:  (+90 312)  458 70 00                                                                                                                             Faks:   (+90 312)  431 21 48
e-posta  :  kamuodeme@sgk.gov.tr                                                                                                              Elektronik Ağ : www.sgk.gov.tr";

        private String imagePath;
        private String adresMahalle;
        private String adresIlIlce;

        public static String kullanici;
        public static String ipAdres;


        public void setAdresMahalle(String str)
        {
            adresMahalle = str;
        }

        public String getAdresMahalle()
        {
            return adresMahalle;
        }

        public void setAdresIlIlce(String str)
        {
            adresIlIlce = str;
        }

        public String getAdresIlIlce()
        {
            return adresIlIlce;
        }

        public void setDaireBaskanligi(String str)
        {
            daireBaskanligi = str;
        }

        public String getDaireBaskanligi()
        {
            return daireBaskanligi;
        }

        public void setSayiTarih(String tahsisNumarasi, String date, String sayi)
        {
            sayiTarih = "Sayı   : " + sayi + "/" + tahsisNumarasi + "                                                                                                 " + date;
        }

        public String getSayiTarih()
        {
            return sayiTarih;
        }

        public void setAdSoyad(String adSoyad)
        {
            this.adSoyad = "Sayın " + adSoyad;
        }

        public String getAdSoyad()
        {
            return adSoyad;
        }

        public void setIkinciParagraf(String str)
        {
            ikinciParagraf = str;
        }

        public String getIkinciParagraf()
        {
            return ikinciParagraf;
        }



        public void setUcuncuParagraf(String str)
        {
            ucuncuParagraf = "       Yazımız eki 3201 sayılı Kanuna Göre Aylık Alanlara Mahsus Yoklama Belgesi'ni gerçeğe uygun ve eksiksiz doldurarak bu yazımızın Kurum kayıtlarından çıkış tarihinden itibaren üç aylık süre içerisinde dosyanızın bulunduğu " + str + " göndermeniz gerekmektedir. ";
        }

        public String getUcuncuParagraf()
        {
            return ucuncuParagraf;
        }

        public void setImagePath(String str)
        {
            imagePath = str;
        }

        public String getImagePath()
        {
            return imagePath;
        }

        public String getTC()
        {
            return TC;
        }

        public String getSosyalGuvenlikKurumu()
        {
            return SOSYAL_GUVENLIK_KURUMU;
        }

        public String getGenelMudurluk()
        {
            return GENEL_MUDURLUK;
        }

        public String getKonu()
        {
            return KONU;
        }

        public String getIlkParagraf()
        {
            return ILK_PARAGRAF;
        }
        public String getIlkParagraf2()
        {
            return ILK_PARAGRAF2;
        }
        public String getIlkParagraf3()
        {
            return ILK_PARAGRAF3;
        }

        public String getDorduncuParagraf()
        {
            return DORDUNCU_PARAGRAF;
        }

        public String getDorduncuParagraf2()
        {
            return DORDUNCU_PARAGRAF2;
        }

        public String getBesinciParagraf()
        {
            return BESINCI_PARAGRAF;
        }

        public String getBesinciParagraf2()
        {
            return BESINCI_PARAGRAF2;
        }
        public String getBesinciParagraf3()
        {
            return BESINCI_PARAGRAF3;
        }

        public String getAltinciParagraf()
        {
            return ALTINCI_PARAGRAF;
        }

        public String getAltinciParagraf2()
        {
            return ALTINCI_PARAGRAF2;
        }

        public String getAltinciParagraf3()
        {
            return ALTINCI_PARAGRAF3;
        }

        public String getEkler()
        {
            return EKLER;
        }

        public String getCizgi()
        {
            return CIZGI;
        }

        public String getIletisim()
        {
            return ILETISIM;
        }

        public String getIletisim2()
        {
            return ILETISIM2;
        }

        public String getDate(DateTime localDate)
        {
            String date = localDate.Day.ToString() + "/" + makeNDigit(localDate.Month.ToString()) + "/" + localDate.Year.ToString();
            return date;
        }

        public String makeNDigit(String str)
        {
            if (str.Trim().Length == 1)
            {
                return "0" + str.Trim();
            }
            else
            {
                return str.Trim();
            }
        }
    }
}