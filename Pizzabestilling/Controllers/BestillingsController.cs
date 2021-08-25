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
    }
}