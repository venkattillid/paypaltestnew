using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LepiPele.PayPal.com.paypal.sandbox.www;

namespace LepiPele.PayPal.API
{
    public partial class ExpressCheckoutSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string token = Request.QueryString["token"];

                // build getdetails request
                GetExpressCheckoutDetailsReq req = new GetExpressCheckoutDetailsReq()
                {
                    GetExpressCheckoutDetailsRequest = new GetExpressCheckoutDetailsRequestType()
                    {
                        Version = UtilPayPalAPI.Version,
                        Token = token
                    }
                };

                // query PayPal for transaction details
                GetExpressCheckoutDetailsResponseType resp =
                    UtilPayPalAPI.BuildPayPalWebservice().GetExpressCheckoutDetails(req);
                UtilPayPalAPI.HandleError(resp);

                GetExpressCheckoutDetailsResponseDetailsType respDetails = resp.GetExpressCheckoutDetailsResponseDetails;


                // setup UI and save transaction details to session
                Label1.Text = string.Format(
                    "Dear {0} {1}, everything is set for {2} {3} transaction to take place. Click on button below to commit transaction",
                    respDetails.PayerInfo.PayerName.FirstName,
                    respDetails.PayerInfo.PayerName.LastName,
                    respDetails.PaymentDetails.OrderTotal.Value,
                    respDetails.PaymentDetails.OrderTotal.currencyID
                );

                Session["CheckoutDetails"] = resp;
            }
        }

        protected void finishTransactionButton_Click(object sender, EventArgs e)
        {
            // get transaction details
            GetExpressCheckoutDetailsResponseType resp = Session["CheckoutDetails"] as GetExpressCheckoutDetailsResponseType;

            // prepare for commiting transaction
            DoExpressCheckoutPaymentReq payReq = new DoExpressCheckoutPaymentReq()
            {
                DoExpressCheckoutPaymentRequest = new DoExpressCheckoutPaymentRequestType()
                {
                    Version = UtilPayPalAPI.Version,
                    DoExpressCheckoutPaymentRequestDetails = new DoExpressCheckoutPaymentRequestDetailsType()
                    {
                        Token = resp.GetExpressCheckoutDetailsResponseDetails.Token,
                        PaymentAction = PaymentActionCodeType.Sale,
                        PayerID = resp.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerID,
                        PaymentDetails = new PaymentDetailsType()
                        {
                            OrderTotal = new BasicAmountType()
                            {
                                currencyID = CurrencyCodeType.USD,
                                Value = "10.00"
                            }
                        },
                    }
                }
            };

            // commit transaction and display results to user
            DoExpressCheckoutPaymentResponseType doResponse =
                UtilPayPalAPI.BuildPayPalWebservice().DoExpressCheckoutPayment(payReq);
            UtilPayPalAPI.HandleError(doResponse);

            Label1.Text = "Payment was successfully processed!";
            finishTransactionButton.Visible = false;
        }
    }
}
