using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Broker
{
    public partial class Karton : System.Web.UI.Page
    {
        AmfCommunicator com = new AmfCommunicator();
        Broker.Requirenments z = new Requirenments();
        private string nrrendor = "7923F940-6B19-4D7D-8B1F-5BB8F7A21848";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string unicode = Request.ServerVariables["REMOTE_ADDR"] + "|" + Request.ServerVariables["REMOTE_HOST"] + "|" + Request.ServerVariables["REMOTE_USER"] + "|" + Request.ServerVariables["HTTP_USER_AGENT"];
                string ip = Request.ServerVariables["REMOTE_ADDR"];
                z.spI_tbl_logs(unicode, ip, "Page Open", "tpl.aspx");
            }
            if (!com.checkService())
            {
                //paraqit tekst gabimi
                //dizable buton
            }
        }

        protected void kontrolloBTN_Click(object sender, EventArgs e)
        {
            string xmlReturn = com.gedCarData(targaTXT.Text);
            string kubikazhi = com.ekstraktKubikazhi(xmlReturn);
            string kategoria = com.llogaritKategorineKarton(kubikazhi);
            DataTable Cmimet = com.merCmimet(nrrendor, kategoria);
            MbushZgjedhjet(Cmimet);
        }

        private void MbushZgjedhjet(DataTable Cmimet)
        {
            for (int i = 0; i < 8; i++)
            {

                BtnKompaniCmim ac = (BtnKompaniCmim)Page.LoadControl("BtnKompaniCmim.ascx");
                ac.v1 = i.ToString();
                ac.v2 = "test";
                Panel1.Controls.Add(ac);
                Panel1.Controls.Add(new LiteralControl("<BR>"));

            }

        }

    }
}