using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzabestilling.Models;

namespace Pizzabestilling.Controllers
{
    [Route("api/Bestilling")]
    public class BestillingsController:ControllerBase
    {
        private readonly MyDBContext _db;

        public BestillingsController(MyDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public List<Bestilling> HentListe()
        {
            return _db.Bestillinger.ToList();
        }

        [HttpPost]
        public bool CreateBestilling([FromBody]Bestilling bestillingen)
        {
            Console.WriteLine(bestillingen);
            try
            {
                var dbKunde = _db.Kunder.FirstOrDefault(kunde => kunde.Navn == bestillingen.Kunde.Navn);
                if (dbKunde == null)
                {
                    var returKunde = _db.Kunder.Add(bestillingen.Kunde);
                    bestillingen.Kunde = returKunde.Entity;
                }
                else
                {
                    dbKunde.Adresse = bestillingen.Kunde.Adresse;
                    dbKunde.Telefon = bestillingen.Kunde.Telefon;
                    bestillingen.Kunde = dbKunde;
                }

                _db.Bestillinger.Add(bestillingen);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut("{id}")]
        public bool RemoveBestilling(int id)
        {
            try
            {
                var bestilling = _db.Bestillinger.Find(id);
                _db.Bestillinger.Remove(bestilling);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        [HttpGet("kunde/{navn}")]
        public Kunde getKundeByNavn(string navn)
        {
            try
            {
                var DbKunde = _db.Kunder.FirstOrDefault(kunde => kunde.Navn == navn);
                return DbKunde;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}