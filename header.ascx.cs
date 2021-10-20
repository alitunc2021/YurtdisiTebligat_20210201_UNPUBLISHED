using System;

namespace YurtdisiTebligat
{
    public partial class header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null && Session["user"].ToString() == "true")
            {
                linkBtnCikis.Visible = true;
            }
            else
            {
                linkBtnCikis.Visible = false;
            }
        }
    }
}