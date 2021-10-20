using System;
using System.Web.UI;

namespace YurtdisiTebligat
{
    public partial class footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblFooter.Text = lblFooter.Text.Insert(lblFooter.Text.Length, " " + Convert.ToChar(169) + " " + DateTime.Now.Year.ToString());
            }
        }
    }
}