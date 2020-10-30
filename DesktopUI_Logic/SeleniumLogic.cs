using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Xml;
using DesktopUI_Logic.Models;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace DesktopUI_Logic
{
    public class SeleniumLogic
    {
        public void SetUpSelenium(GameDetailsModel game)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var html = "https://store.steampowered.com/search/?filter=topsellers&specials=1&ignore_preferences=1";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var node = htmlDoc.DocumentNode.SelectNodes("//span[@class='title']").ToList();
            
            foreach(var i in node)
            {
                if (i.InnerText.ToUpper().Contains(game.Name.ToUpper()))
                {
                    MessageBox.Show(game.Name + " " + i.InnerText);
                    var title = htmlDoc.DocumentNode.SelectNodes("//a").ToList();
                    List<string> link = new List<string>();
                    foreach(var a in title)
                    {
                        link.Add(a.InnerText);
                    }
                    
                   // var innerNode = htmlDoc.DocumentNode.SelectNodes("//span[@class='col search_price discounted responsive_secondrow']").ToList();
                }

            }


        }
       
    }
}
