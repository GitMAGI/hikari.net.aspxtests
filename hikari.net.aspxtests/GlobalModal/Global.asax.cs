using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace hikari.net.aspxtests.GlobalModal
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            bool logged = (HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated;
            // Verifica che la pagina richiesta non sia la login, altrimenti looperemmo all'infinito redirezionando alla pagina di login
            bool loginReq = (Request.Url.AbsolutePath == FormsAuthentication.LoginUrl);
            if (!logged && !loginReq)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            bool logged = (HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated;

            if (HttpContext.Current.Session != null)
            {
                if (logged && HttpContext.Current.Session["profile"] == null)
                {
                    /* 
                    ReplyObject<ProfiloDTO> rsp = new ReplyObject<ProfiloDTO>(false);
                    using (Business.BLL bll = new Business.BLL(0))
                    {
                        string usr = HttpContext.Current.User.Identity.Name;
                        rsp = bll.GetProfileByUserName(usr);
                    }
                    if (!rsp.success)
                        throw new Exception("Fatal Error! Current User is Unauthorized to use the Application!");

                    ProfiloDTO Profilo = rsp.data;
                    */

                    //For Dev
                    // ------ begin ------ 
                    /*
                    ProfiloDTO Profilo = new ProfiloDTO();
                    Profilo.nome = "Marco";
                    Profilo.cognome = "Pietrangelo";
                    Profilo.username = "tst";
                    */
                    // ------ end ------

                    // Put Logged Profile into Session
                    //HttpContext.Current.Session["profile"] = Profilo;
                }
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}