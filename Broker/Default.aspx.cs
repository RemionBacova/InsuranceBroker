using System;
using System.Data;

namespace Broker
{
    public partial class Default : System.Web.UI.Page
    {
        Broker.Requirenments z = new Requirenments();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string unicode = Request.ServerVariables["REMOTE_ADDR"] + "|" + Request.ServerVariables["REMOTE_HOST"] + "|" + Request.ServerVariables["REMOTE_USER"] + "|" + Request.ServerVariables["HTTP_USER_AGENT"];
                string ip = Request.ServerVariables["REMOTE_ADDR"];
                z.spI_tbl_logs(unicode, ip, "Page Open", "default.aspx");
                Session.Add(AppConstants.Counters.TotalRequests, 0);
                Session.Add(AppConstants.Counters.TplRequests, 0);
                Session.Add(AppConstants.Counters.KartonRequests, 0);
                Session.Add(AppConstants.Counters.KufitareRequests, 0);
            }
            else
            {
                Session[AppConstants.Counters.TotalRequests] = (int.Parse( Session[AppConstants.Counters.TotalRequests].ToString()) + 1).ToString();
            }
        }

        protected void tplButton_Click(object sender, EventArgs e)
        {
            string unicode = Request.ServerVariables["REMOTE_ADDR"] + "|" + Request.ServerVariables["REMOTE_HOST"] + "|" + Request.ServerVariables["REMOTE_USER"] + "|" + Request.ServerVariables["HTTP_USER_AGENT"];
            string ip = Request.ServerVariables["REMOTE_ADDR"];
            z.spI_tbl_logs(unicode, ip, "Page Redirect tpl.aspx", "default.aspx");
            Session[AppConstants.Counters.TplRequests] = (int.Parse(Session[AppConstants.Counters.TplRequests].ToString()) + 1).ToString();
            Response.Redirect("tpl.aspx");
        }

        protected void kartonButton_Click(object sender, EventArgs e)
        {

            string unicode = Request.ServerVariables["REMOTE_ADDR"] + "|" + Request.ServerVariables["REMOTE_HOST"] + "|" + Request.ServerVariables["REMOTE_USER"] + "|" + Request.ServerVariables["HTTP_USER_AGENT"];
            string ip = Request.ServerVariables["REMOTE_ADDR"];
            z.spI_tbl_logs(unicode, ip, "Page Redirect karton.aspx", "default.aspx");
            Session[AppConstants.Counters.KartonRequests] = (int.Parse(Session[AppConstants.Counters.KartonRequests].ToString()) + 1).ToString();
            Response.Redirect("karton.aspx");
        }

        protected void kufitareButton_Click(object sender, EventArgs e)
        {

            string unicode = Request.ServerVariables["REMOTE_ADDR"] + "|" + Request.ServerVariables["REMOTE_HOST"] + "|" + Request.ServerVariables["REMOTE_USER"] + "|" + Request.ServerVariables["HTTP_USER_AGENT"];
            string ip = Request.ServerVariables["REMOTE_ADDR"];
            z.spI_tbl_logs(unicode, ip, "Page Redirect  kufitare.aspx", "default.aspx");
            Session[AppConstants.Counters.KufitareRequests] = (int.Parse(Session[AppConstants.Counters.KufitareRequests].ToString()) + 1).ToString();
            Response.Redirect("kufitare.aspx");
        }

      
    }
}