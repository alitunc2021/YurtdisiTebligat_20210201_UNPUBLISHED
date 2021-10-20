using System;

namespace YurtdisiTebligat
{

    public partial class login : System.Web.UI.Page
    {

        protected static string YetkiUserName;
        protected static string YetkiUserPassword;
        private Database.Login yetki = new Database.Login();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["yetki"] != null && Request.QueryString["yetki"] == "false")
            {

                lblHata.Text = "Yekilendirme sayfasýna eriþim yetkiniz yok!";
            }

            if (Request.QueryString["logout"] != null && Request.QueryString["logout"] == "true")
            {

                Session["user"] = null;
                lblHata.Text = "Oturumunuz kapatýldý!";

                lblHata.Text = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Boolean check = yetki.yetkiKontrol(txtKulAd.Text, txtSifre.Text);

            if (check)
            {

                Session["user"] = "true";
                Response.Redirect("Anasayfa.aspx");
            }
            else
            {

                lblHata.Text = "Hatalý Kullanýcý Adý/Þifre!";
            }
        }


    }
}
