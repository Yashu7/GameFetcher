using DesktopUI_Logic.Models;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
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

        public string StartCrawlingAsync(string _title)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--ignore-certificate-errors");
          
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--nogpu");
            chromeOptions.AddArgument("--disable-extensions");
            chromeOptions.AddArgument("--window-size=1920,1080");
       
            chromeOptions.AddArgument("--allow-running-insecure-content");
            chromeOptions.AddArgument("--allow-insecure-localhost");
            chromeOptions.AddAdditionalCapability("CapabilityType.AcceptSslCertificates",true, true);
            chromeOptions.AddAdditionalCapability("CapabilityType.AcceptInsecureCerts", true,true);
            
           
           


            List<Game> titles = new List<Game>();

            var browser = new ChromeDriver(chromeOptions);
            
               string allGamesUrl = "https://www.nintendo.co.uk/Search/Search-299117.html?f=147394-5-81";
            string discountedGamesUrl = "https://www.nintendo.co.uk/Search/Search-299117.html?f=147394-5-81-6956";
            browser.Url = discountedGamesUrl;
            

           
           
            browser.FindElementByXPath("//a[@class='pla-btn pla-btn--region-store pla-btn--block plo-cookie-overlay__accept-btn']").Click();




            var goodList = browser.FindElementsByXPath("//div[@class='search-result-txt col-xs-9 col-sm-10']//p[@class='page-title']");
            int count = 1;
            do
            {
                
                goodList = browser.FindElementsByXPath("//div[@class='search-result-txt col-xs-9 col-sm-10']");
                foreach (var l in goodList)
                {


                    var _name = l.FindElement(By.XPath(".//p[@class='page-title']"));
                    var _originalPrice = l.FindElement(By.XPath(".//span[@class='original-price']"));
                    var _discountedPrice = l.FindElement(By.XPath(".//span[@class='discount']"));
                    titles.Add(new Game
                    {
                        Title = _name.Text,
                        OriginalPrice = _originalPrice.Text,
                        DiscountPrice = _discountedPrice.Text

                    });
                    if (titles.Last().Title.Contains(_title)) return titles.Last().ReturnGame();



                }

               var buttons = browser.FindElementsByXPath("//button[@class='btn btn-primary']");
               buttons[buttons.Count() - 1].Click();
                Thread.Sleep(2000);
               
            } while (browser.FindElementsByXPath("//div[@class='search-result-txt col-xs-9 col-sm-10']").Count() > 2);


            return "No Games";
            }
        public class Game
        {
            public string Title { get; set; }
            public string OriginalPrice { get; set; }
            public string DiscountPrice { get; set; }

            public string ReturnGame()
            {
                return Title + " original price is " + OriginalPrice + " and discounted is " + DiscountPrice;
            }
        }

    }
}
