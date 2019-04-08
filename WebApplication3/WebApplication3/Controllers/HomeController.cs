using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

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

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId,
            };
            payment = new Payment() { id = paymentId };
            return payment.Execute(apiContext, paymentExecution);
        }

        public ActionResult PaymentWithPaypal()
        {
            APIContext apiContext = PayPalConfiguration.GetAPIContext();

            try
            {
                string payerId = Request.Params["PayerId"];
                if (string.IsNullOrEmpty(payerId))
                {
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createPayment = CreatePayment(apiContext, "http://localhost:64366/Home/GetPayerId?guid=" + guid);
                    string paypalREdirectUrl = string.Empty;
                    var links = createPayment.links.GetEnumerator();

                    while (links.MoveNext())
                    {
                        Links link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalREdirectUrl = link.href;
                        }
                    }
                    Session.Add(guid, createPayment.id);
                    return Redirect(paypalREdirectUrl);
                }
                else
                {
                    var guid = Request.Params["guid"];
                    var executePayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    if(executePayment.state.ToLower() == "approved")
                    {
                        Console.WriteLine("EEE");
                    }
                    return Redirect("https://google.com");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return View();
            }
        }
        public string GetPayerId(string guid, string paymentId, string token, string PayerID)
        {
            APIContext apiContext = PayPalConfiguration.GetAPIContext();
            var executePayment = ExecutePayment(apiContext, PayerID, paymentId);
            return PayerID;
        }
    }
}