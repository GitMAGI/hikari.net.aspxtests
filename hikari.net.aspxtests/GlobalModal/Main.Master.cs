using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlobalModal
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public string projectFullName = WebConfigurationManager.AppSettings["projectFullName"];
        public string projectDisplayName = WebConfigurationManager.AppSettings["projectDisplayName"];
        public string projectShortName = WebConfigurationManager.AppSettings["projectShortName"];
        public string projectDescriptionName = WebConfigurationManager.AppSettings["projectDescriptionName"];
        public string projectVersion = WebConfigurationManager.AppSettings["projectVersion"];
        public string devCompanyName = WebConfigurationManager.AppSettings["devCompanyName"];
        public string devCompanyWebSiteURL = WebConfigurationManager.AppSettings["devCompanyWebSiteURL"];
        public string devYear = WebConfigurationManager.AppSettings["devYear"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string GetCalssIfActive(string url)
        {
            if (Request.RawUrl.Contains(url))
                return "active";
            else
                return "";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect(FormsAuthentication.LoginUrl);
        }


        public void AlertResetAndHide()
        {
            string styles = "display:none";
            alertMain.Attributes.Remove("style");
            alertMain.Attributes.Add("style", styles);
        }
        public void AlertResetAndHideClient()
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "AlertResetAndHideID", "AlertResetAndHide();", true);
        }
        public void AlertShow(string className, string msgHeader, string msgBody)
        {
            string styles = "display:block";
            alertMain.Attributes.Remove("style");
            alertMain.Attributes.Add("style", styles);
            string classes = alertMain.Attributes["class"];
            classes = classes.Replace("alert-info", "");
            classes = classes.Replace("alert-success", "");
            classes = classes.Replace("alert-warning", "");
            classes = classes.Replace("alert-danger", "");
            classes += className;
            alertMain.Attributes["class"] = classes;

            alertMainHeader.InnerText = msgHeader;
            alertMainBody.InnerText = msgBody;
        }
        public void AlertShowError(string msgHeader, string msgBody)
        {
            AlertShow("alert-danger", msgHeader, msgBody);
        }
        public void AlertShowInfo(string msgHeader, string msgBody)
        {
            AlertShow("alert-info", msgHeader, msgBody);
        }
        public void AlertShowSuccess(string msgHeader, string msgBody)
        {
            AlertShow("alert-success", msgHeader, msgBody);
        }
        public void AlertShowWarning(string msgHeader, string msgBody)
        {
            AlertShow("alert-warning", msgHeader, msgBody);
        }
        public void AlertShowErrorClient(string msgHeader, string msgBody)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "AlertShowErrorID", "AlertShowError('" + msgHeader + "', '" + msgBody + "');", true);
        }
        public void AlertShowInfoClient(string msgHeader, string msgBody)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "AlertShowInfoID", "AlertShowInfo('" + msgHeader + "', '" + msgBody + "');", true);
        }
        public void AlertShowSuccessClient(string msgHeader, string msgBody)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "AlertShowSuccessID", "AlertShowSuccess('" + msgHeader + "', '" + msgBody + "');", true);
        }
        public void AlertShowWarningClient(string msgHeader, string msgBody)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "AlertShowWarningID", "AlertShowWarning('" + msgHeader + "', '" + msgBody + "');", true);
        }
    }
}