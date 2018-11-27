using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckPoint4.Models;
using CheckPoint4.DAL;
using System.Data.Entity;


//This project was made by Kyle Harrison with significant help from videos from the TAs, materials from
//Dr. Anderson, and Google. 11-15-2018
namespace CheckPoint4.Controllers
{
    public class HomeController : Controller
    {
        private CP4Context db = new CP4Context();


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

        public ActionResult Rentals()
        {
            return View(db.Instruments.ToList());
        }

        public ActionResult Create(int ID)
        {
            return View();
        }

        public ActionResult Password()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Password(string UName, string PWord)
        {
            if(UName == "whatever" && PWord == "WhateverPassword")
            {
                return View(confirmed)
            }
            else
            {
                return View(Denied)
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,FirstName,LastName,Address,City,State,Zip,Email,Phone")] Client client, int ID)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();

                Instrument instrument = db.Instruments.Find(ID);
                instrument.ClientID = client.ClientID;
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Summary", new { ClientID = client.ClientID, InstrumentID = instrument.InstrumentID });

            }

            return View(client);
        }

        public ActionResult Summary(int ClientID, int InstrumentID)
        {
            Client client = db.Clients.Find(ClientID);
            Instrument instrument = db.Instruments.Find(InstrumentID);

            ViewBag.Client = client;
            ViewBag.Instrument = instrument;

            return View();

        }
    }
}