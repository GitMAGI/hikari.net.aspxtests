using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlobalModal.pages
{
    public partial class Login : System.Web.UI.Page
    {
        public string projectFullName = WebConfigurationManager.AppSettings["projectFullName"];
        public string projectDisplayName = WebConfigurationManager.AppSettings["projectDisplayName"];
        public string projectShortName = WebConfigurationManager.AppSettings["projectShortName"];
        public string projectDescriptionName = WebConfigurationManager.AppSettings["projectDescriptionName"];
        public string projectVersion = WebConfigurationManager.AppSettings["projectVersion"];
        public string devCompanyName = WebConfigurationManager.AppSettings["devCompanyName"];
        public string devCompanyWebSiteURL = WebConfigurationManager.AppSettings["devCompanyWebSiteURL"];
        public string devYear = WebConfigurationManager.AppSettings["devYear"];

        private bool persistent = false;

        protected string usr = null;
        protected string pwd = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void OnLogginIn()
        {
            bool logged = (HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated;

            if (logged)
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
            }

            //AlertResetAndHide();
        }
        protected void OnLoginError(string errorHeader, string errorText)
        {
            AlertShowError(errorHeader, errorText);
        }
        protected void OnLoggedIn()
        {
            string usr = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            FormsAuthentication.RedirectFromLoginPage(usr, persistent);

            AlertResetAndHide();
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            this.OnLogginIn();
            
            string usr = !string.IsNullOrEmpty(UserName.Value) ? UserName.Value : null;
            string pwd = !string.IsNullOrEmpty(Password.Value) ? Password.Value : null;

            if (string.IsNullOrEmpty(usr) || string.IsNullOrEmpty(pwd))
            {
                return;
            }
            
            /*
            ReplyObject<bool> rsp = new ReplyObject<bool>(false);
            using (Business.BLL bll = new Business.BLL(0))
            {
                rsp = bll.IsAuthenticable(usr, pwd);
            }
            bool Authenticated = rsp.success ? rsp.data : false;
            */

            bool Authenticated = (usr == "test" && pwd == "test") ? true : false;

            if (Authenticated)
            {
                try
                {
                    FormsAuthentication.SetAuthCookie(usr, persistent);
                    classes.UserIdentity Identity = new classes.UserIdentity(usr, Authenticated);
                    string[] roles = new string[] { "", "", };
                    Context.User = new GenericPrincipal(Identity, roles);
                    this.OnLoggedIn();
                }
                catch (Exception ex)
                {
                    string hdr = "Errore Server!";
                    string err = null;
                    while (ex != null)
                    {
                        if (err == null)
                        {
                            err = ex.Message;
                        }
                        else
                        {
                            err += " - " + ex.Message;
                        }
                        ex = ex.InnerException;
                    }
                    OnLoginError(hdr, err);
                }
            }
            else
            {
                string hdr = "Login Fallito!";
                //string err = string.Join(" - ", rsp.GetExceptionStack());
                string err = "Messaggio debug di errore!";
                OnLoginError(hdr, err);
            }
        }

        public void AlertResetAndHideClient()
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "AlertResetAndHideID", "AlertResetAndHide();", true);
        }
        public void AlertResetAndHide()
        {
            string styles = "display:none";
            alertLogin.Attributes.Remove("style");
            alertLogin.Attributes.Add("style", styles);
        }
        public void AlertShow(string className, string msgHeader, string msgBody)
        {
            string styles = "display:block";
            alertLogin.Attributes.Remove("style");
            alertLogin.Attributes.Add("style", styles);
            string classes = alertLogin.Attributes["class"];
            classes = classes.Replace("alert-info", "");
            classes = classes.Replace("alert-success", "");
            classes = classes.Replace("alert-warning", "");
            classes = classes.Replace("alert-danger", "");
            classes += className;
            alertLogin.Attributes["class"] = classes;

            alertLoginHeader.InnerText = msgHeader;
            alertLoginBody.InnerText = msgBody;
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
            Page.ClientScript.RegisterStartupScript(GetType(), "AlertShowErrorID", "AlertShowError('"+ msgHeader + "', '"+ msgBody + "');", true);
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