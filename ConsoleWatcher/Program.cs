using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViagoWatcher.Model.Connector;
using ViagoWatcher.Model.Connector.Dto;

namespace ConsoleWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = @"http://www.viagogo.fr/";
            string pathToWatch = @"/psg/Billets-de-sport/Football/Ligue-1/Paris-Saint-Germain-Billets/E-751483";
            string mailTo = "etienne.pierrot@gmail.com;clement@leetchi.com;endika@leetchi.com";

            string login = "ep.mail.sender.viagogo";
            string password = "viagogowatch123%";
            var viagogoConnector = new ViagogoConnector();

            IList<string> urlSended = new List<string>();

            while (true)
            {
                IEnumerable<ProductDto> products = viagogoConnector.GetProduct(baseUrl + pathToWatch);
                ProductDto productLowerPrice = products.Aggregate((x, y) => x.RawPrice < y.RawPrice ? x : y);

                if (productLowerPrice.RawPrice < 70)
                {
                    if (!urlSended.Contains(productLowerPrice.BuyUrl))
                    {
                        SendMail(login, mailTo, productLowerPrice, password);
                        urlSended.Add(productLowerPrice.BuyUrl);
                    }
                }


                Thread.Sleep(60000);

            }

            
        }

        private static void SendMail(string login, string mailTo, ProductDto productLowerPrice, string password)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(login + "@gmail.com");

            foreach (string s in mailTo.Split(';'))
            {
                mail.To.Add(s);
            }

            
            mail.Subject = "Alert Viagogo : PSG - Chelsea";
            mail.Body = productLowerPrice.BuyUrl;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(login, password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}
