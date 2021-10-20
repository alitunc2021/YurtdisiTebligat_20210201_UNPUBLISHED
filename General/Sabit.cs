using System;

namespace YurtdisiTebligat.General
{
    public class Sabit
    {
        private string adana = "Adana";
        private string adiyaman = "Adıyaman";
        private string afyon = "Afyon";
        private string agri = "Ağrı";
        private string amasya = "Amasya";
        private string ankara = "Ankara";
        private string antalya = "Antalya";
        private string artvin = "Artvin";
        private string aydin = "Aydın";
        private string balikesir = "Balıkesir";
        private string bilecik = "Bilecik";
        private string bingol = "Bingöl";
        private string bitlis = "Bitlis";
        private string bolu = "Bolu";
        private string burdur = "Burdur";
        private string bursa = "Bursa";
        private string canakkale = "Çanakkale";
        private string cankiri = "Çankırı";
        private string corum = "Çorum";
        private string denizli = "Denizli";
        private string diyarbakir = "Diyarbakır";
        private string edirne = "Edirne";
        private string elazig = "Elazığ";
        private string erzincan = "Erzincan";
        private string erzurum = "Erzurum";
        private string eskisehir = "Eskişehir";
        private string gaziantep = "Gaziantep";
        private string giresun = "Giresun";
        private string gumushane = "Gümüşhane";
        private string hakkari = "Hakkari";
        private string hatay = "Hatay";
        private string isparta = "Isparta";
        private string icel = "İçel";
        private string istanbul = "İstanbul";
        private string izmir = "İzmir";
        private string kars = "Kars";
        private string kastamonu = "Kastamonu";
        private string kayseri = "Kayseri";
        private string kirklareli = "Kırklareli";
        private string kirsehir = "Kırşehir";
        private string kocaeli = "Kocaeli";
        private string konya = "Konya";
        private string kutahya = "Kütahya";
        private string malatya = "Malatya";
        private string manisa = "Manisa";
        private string kahramanmaras = "Kahramanmaraş";
        private string mardin = "Mardin";
        private string mugla = "Muğla";
        private string mus = "Muş";
        private string nevsehir = "Nevşehir";
        private string nigde = "Niğde";
        private string ordu = "Ordu";
        private string rize = "Rize";
        private string sakarya = "Sakarya";
        private string samsun = "Samsun";
        private string siirt = "Siirt";
        private string sinop = "Sinop";
        private string sivas = "Sivas";
        private string tekirdag = "Tekirdağ";
        private string tokat = "Tokat";
        private string trabzon = "Trabzon";
        private string tunceli = "Tunceli";
        private string sanliurfa = "Şanlıurfa";
        private string usak = "Uşak";
        private string van = "Van";
        private string yozgat = "Yozgat";
        private string zonguldak = "Zonguldak";
        private string aksaray = "Aksaray";
        private string bayburt = "Bayburt";
        private string karaman = "Karaman";
        private string kirikkale = "Kırıkkale";
        private string batman = "Batman";
        private string sirnak = "Şırnak";
        private string bartin = "Bartın";
        private string ardahan = "Ardahan";
        private string igdir = "Iğdır";
        private string yalova = "Yalova";
        private string karabuk = "Karabük";
        private string kilis = "Kilis";
        private string osmaniye = "Osmaniye";
        private string duzce = "Düzce";

        public string ilDondur(String str)
        {
            String il = "";

            switch (str)
            {
                case "01": il = adana; break;
                case "02": il = adiyaman; break;
                case "03": il = afyon; break;
                case "04": il = agri; break;
                case "05": il = amasya; break;
                case "06": il = ankara; break;
                case "07": il = antalya; break;
                case "08": il = artvin; break;
                case "09": il = aydin; break;
                case "10": il = balikesir; break;
                case "11": il = bilecik; break;
                case "12": il = bingol; break;
                case "13": il = bitlis; break;
                case "14": il = bolu; break;
                case "15": il = burdur; break;
                case "16": il = bursa; break;
                case "17": il = canakkale; break;
                case "18": il = cankiri; break;
                case "19": il = corum; break;
                case "20": il = denizli; break;
                case "21": il = diyarbakir; break;
                case "22": il = edirne; break;
                case "23": il = elazig; break;
                case "24": il = erzincan; break;
                case "25": il = erzurum; break;
                case "26": il = eskisehir; break;
                case "27": il = gaziantep; break;
                case "28": il = giresun; break;
                case "29": il = gumushane; break;
                case "30": il = hakkari; break;
                case "31": il = hatay; break;
                case "32": il = isparta; break;
                case "33": il = icel; break;
                case "34": il = istanbul; break;
                case "35": il = izmir; break;
                case "36": il = kars; break;
                case "37": il = kastamonu; break;
                case "38": il = kayseri; break;
                case "39": il = kirklareli; break;
                case "40": il = kirsehir; break;
                case "41": il = kocaeli; break;
                case "42": il = konya; break;
                case "43": il = kutahya; break;
                case "44": il = malatya; break;
                case "45": il = manisa; break;
                case "46": il = kahramanmaras; break;
                case "47": il = mardin; break;
                case "48": il = mugla; break;
                case "49": il = mus; break;
                case "50": il = nevsehir; break;
                case "51": il = nigde; break;
                case "52": il = ordu; break;
                case "53": il = rize; break;
                case "54": il = sakarya; break;
                case "55": il = samsun; break;
                case "56": il = siirt; break;
                case "57": il = sinop; break;
                case "58": il = sivas; break;
                case "59": il = tekirdag; break;
                case "60": il = tokat; break;
                case "61": il = trabzon; break;
                case "62": il = tunceli; break;
                case "63": il = sanliurfa; break;
                case "64": il = usak; break;
                case "65": il = van; break;
                case "66": il = yozgat; break;
                case "67": il = zonguldak; break;
                case "68": il = aksaray; break;
                case "69": il = bayburt; break;
                case "70": il = karaman; break;
                case "71": il = kirikkale; break;
                case "72": il = batman; break;
                case "73": il = sirnak; break;
                case "74": il = bartin; break;
                case "75": il = ardahan; break;
                case "76": il = igdir; break;
                case "77": il = yalova; break;
                case "78": il = karabuk; break;
                case "79": il = kilis; break;
                case "80": il = osmaniye; break;
                case "81": il = duzce; break;
            }

            return il;

        }


    }
}