using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlobalModal
{
    public partial class Default : System.Web.UI.Page
    {
        string msg = "Messaggio Messaggio Messaggio.";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string btnName = Request["__EVENTTARGET"]; // btnSave
            string parameter = Request["__EVENTARGUMENT"]; // parameter
            switch (btnName)
            {
                case "btnShowAlertError":
                    btnShowAlertError_click(this, EventArgs.Empty);
                    break;
                case "btnShowAlertInfo":
                    btnShowAlertInfo_click(this, EventArgs.Empty);
                    break;
                case "btnShowAlertSuccess":
                    btnShowAlertSuccess_click(this, EventArgs.Empty);
                    break;
                case "btnShowAlertWarning":
                    btnShowAlertWarning_click(this, EventArgs.Empty);
                    break;
                case "btnHideAlert":
                    btnHideAlert_click(this, EventArgs.Empty);
                    break;
            }
        }


        protected void btnShowAlertError_click(object sender, EventArgs e)
        {
            string hdr = "Errore Server!";
            this.Master.AlertShowError(hdr, msg);
        }
        protected void btnShowAlertErrorClient_click(object sender, EventArgs e)
        {
            string hdr = "Errore Server (Chiamando JS)!";
            this.Master.AlertShowErrorClient(hdr, msg);
        }
        protected void btnShowAlertInfo_click(object sender, EventArgs e)
        {
            string hdr = "Info Server!";
            this.Master.AlertShowInfo(hdr, msg);
        }
        protected void btnShowAlertInfoClient_click(object sender, EventArgs e)
        {
            string hdr = "Info Server (Chiamando JS)!";
            this.Master.AlertShowInfoClient(hdr, msg);
        }
        protected void btnShowAlertSuccess_click(object sender, EventArgs e)
        {
            string hdr = "Success Server!";
            this.Master.AlertShowSuccess(hdr, msg);
        }
        protected void btnShowAlertSuccessClient_click(object sender, EventArgs e)
        {
            string hdr = "Success Server (Chiamando JS)!";
            this.Master.AlertShowSuccessClient(hdr, msg);
        }
        protected void btnShowAlertWarning_click(object sender, EventArgs e)
        {
            string hdr = "Warning Server!";
            this.Master.AlertShowWarning(hdr, msg);
        }
        protected void btnShowAlertWarningClient_click(object sender, EventArgs e)
        {
            string hdr = "Warning Server (Chiamando JS)!";
            this.Master.AlertShowWarningClient(hdr, msg);
        }
        protected void btnHideAlert_click(object sender, EventArgs e)
        {
            this.Master.AlertResetAndHide();
        }
        protected void btnHideAlertClient_click(object sender, EventArgs e)
        {
            this.Master.AlertResetAndHideClient();
        }
    }
}