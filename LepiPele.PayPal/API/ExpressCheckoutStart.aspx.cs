using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LepiPele.PayPal.com.paypal.sandbox.www;
using System.Configuration;

namespace LepiPele.PayPal.API
{
    public partial class ExpressCheckoutStart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void oneTimeButton_Click(object sender, EventArgs e)
        {
            // build request
            SetExpressCheckoutRequestDetailsType reqDetails = new SetExpressCheckoutRequestDetailsType();

            // TODO: Be sure to update hosting address in Web.Config!!
            string hostingOn = ConfigurationManager.AppSettings["HostingPrefix"];

            reqDetails.ReturnURL = hostingOn + "/API/ExpressCheckoutSuccess.aspx";
            reqDetails.CancelURL = hostingOn + "/API/ExpressCheckoutCancel.aspx";
            reqDetails.NoShipping = "1";
            reqDetails.OrderTotal = new BasicAmountType()
            {
                currencyID = CurrencyCodeType.USD,
                Value = "10.00"
            };

            SetExpressCheckoutReq req = new SetExpressCheckoutReq()
            {
                SetExpressCheckoutRequest = new SetExpressCheckoutRequestType()
                {
                    Version = UtilPayPalAPI.Version,
                    SetExpressCheckoutRequestDetails = reqDetails
                }
            };

            // query PayPal and get token
            SetExpressCheckoutResponseType resp = UtilPayPalAPI.BuildPayPalWebservice().SetExpressCheckout(req);
            UtilPayPalAPI.HandleError(resp);

            // redirect user to PayPal
            Response.Redirect(string.Format("{0}?cmd=_express-checkout&token={1}",
                ConfigurationManager.AppSettings["PayPalSubmitUrl"], resp.Token));
        }
    }
}
