using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ViagoWatcher.Model
{
    public class ParserHelper
    {
        public long GetLowerPrice(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            string priceStr = doc.GetElementbyId("clientgrid_listings")
                .Descendants("tr").ToArray()[1]
                .Descendants("strong").First().InnerText;
            return long.Parse(priceStr, NumberStyles.Currency);
        }
    }
}
