using DesktopUI_Logic.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DesktopUI_Logic
{
    public class SalesChecker
    {
        public string[] CheckSteamSale(GameDetailsModel game)
        {
           
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var html = "https://store.steampowered.com/search/?filter=topsellers&specials=1&ignore_preferences=1";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);


            var title = htmlDoc.DocumentNode.SelectNodes("//a").ToList();

            foreach (var a in title)
            {
                if (a.InnerHtml.ToUpper().Contains(game.Name.ToUpper()))
                {

                    var price = a.Descendants(); //("//div[@class='col search_price discounted responsive_secondrow']");
                    string outputPrice = "";
                    foreach (var p in price)
                    {
                        if (p.OuterHtml.Contains("div class=\"col search_price_discount_combined responsive_secondrow\""))
                        {
                            outputPrice = p.InnerText;
                        }
                    }
                    
                    
                   
                    
                    string[] bothPrices = outputPrice.Split('ł');
                    return bothPrices;


                }
            }
            
            return new string[] {""};

        } 
    }
}
