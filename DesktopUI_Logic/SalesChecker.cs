using DesktopUI_Logic.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace DesktopUI_Logic
{
    public class SalesChecker
    {
        public string CheckSteamSale(IGameDetailsModel game)
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



                    
                  
                    string pattern = "ł";
                    string sentence = outputPrice;
                    List<int> indexes = new List<int>();
                    foreach(Match match in Regex.Matches(sentence,pattern))
                    {
                        indexes.Add(match.Index);
                           
                    }

                    
                    string discountPrice = outputPrice.Substring((indexes[0]+1),((indexes[1] - indexes[0])+1));



                   
                    return discountPrice;


                }
            }

            return "No sale";

        } 
    }
}
