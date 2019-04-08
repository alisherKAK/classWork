using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Web.Mvc;

namespace Hotel.Sevices
{
    public class PayPalPayment
    {
        private Payment payment;

        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var itemList = new ItemList() { items = new List<Item>() };

            itemList.items.Add(new Item()
            {
                name = "Test",
                currency = "AUD",
                price = "100",
                quantity = "1",
                sku = "sku"
            });

            var payer = new Payer() { payment_method = "paypal" };

            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };

            var details = new Details()
            {
                tax = "1",
                shipping = "2",
                subtotal = "100"
            };

            var amount = new Amount()
            {
                currency = "AUD",
                total = "103",
                details = details
            };

            var trasactionList = new List<Transaction>();
            trasactionList.Add(new Transaction()
            {
                description = "Test trans",
                amount = amount,
                item_list = itemList,
                invoice_number = Convert.ToString((new Random()).Next(100000))
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = trasactionList,
                redirect_urls = redirUrls
            };

            return payment.Create(apiContext);
        }

        private Payment ExecutePayment(APIContext apiContext, string payerId, string payerSecret)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId,
            };
            payment = new Payment() { id = payment.id };
            return payment.Execute(apiContext, paymentExecution);
        }

        public void PaymentWithPaypal()
        {
            APIContext apiContext = PayPalConfiguration.GetAPIContext();

            try
            {
                string payerId = "";
                var guid = Convert.ToString((new Random()).Next(100000));
                if (string.IsNullOrEmpty(payerId))
                {
                    var createPayment = CreatePayment(apiContext, "https://google.com");
                    var links = createPayment.links.GetEnumerator();
                    string paypalREdirectUrl = string.Empty;

                    while (links.MoveNext())
                    {
                        Links link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalREdirectUrl = link.href;
                        }
                    }
                    var url = "http://sms.horisen.info:12000/bulk/send?type=text&user=xxx&password=xxx&sender=Bulk+Test&receiver=%2b123456789&dcs=UCS&text=Dies+ist+ein+Test!&dlr-mask=19";
                    var req = (HttpWebRequest)WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=EC-6WW05017EE8791010#/checkout/review");
                    var res = req.GetResponse();
                    var req2 = (HttpWebRequest)WebRequest.Create(res.ResponseUri.AbsoluteUri);
                    Process.Start(@"C:\Users\калабаева\source\repos\WebApplication3\WebApplication3\bin\WebApplication3.dll");
                }
                else
                {
                    
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
