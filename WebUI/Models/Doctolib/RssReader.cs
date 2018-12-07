using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Text.RegularExpressions;


namespace WebUI.Models.Doctolib
{
    public class RssReader
    {
       
       private static string _blogURL = "http://www.castries.fr/index.php/outils/rss?idpage=23&idmetacontenu=";

        public static IEnumerable<Rss> GetRssFeed()
        {
            XDocument feedXml = XDocument.Load(_blogURL);
            var feeds = from feed in feedXml.Descendants("item")
                        select new Rss
                        {
                            Title = feed.Element("title").Value,
                            Link = feed.Element("link").Value,
                            Description = Regex.Match(feed.Element("description").Value, @"^.{1,180}\b(?<!\s)").Value,
                            
                        };
            return feeds;
        }
    }
}