using System.Web.Configuration;

namespace YurtdisiTebligat.General
{
    public class VeriTabanıBaglantisi
    {

        private string _SSKDB2 = WebConfigurationManager.ConnectionStrings["SSKDB2T"].ConnectionString;


        public string SSKDB2
        {
            get { return _SSKDB2; }
            set { _SSKDB2 = value; }
        }

    }
}