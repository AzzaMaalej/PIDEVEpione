using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers.Doctolib
{
    public class RssController : Controller
    {
        // GET: Rss
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RssReader()
        {
            return View(WebUI.Models.Doctolib.RssReader.GetRssFeed());
        }
       
    }
}