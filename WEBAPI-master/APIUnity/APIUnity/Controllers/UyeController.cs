using APIUnity.Context;
using APIUnity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIUnity.Controllers
{
    public class UyeController : ApiController
    {

        private DatabaseContext db = new DatabaseContext();

        // Butun uyeler ve skorlari
        [HttpGet]
        [Route("api/uye")]
        public IHttpActionResult Get()
        {
            var result = db.Users.Include("Scores").ToList();
            return Ok(result);

        }

        // Id ile uyeler ve skorlari
        [HttpGet]
        [Route("api/uye/{id}")]
        public Users Get(int id)
        {
            return db.Users.Include("Scores").FirstOrDefault(x => x.Id == id);
        }

        // Uye ekleme
        [HttpPost]
        [Route("api/uye")]
        public HttpResponseMessage Post(Users uye)
        {
            try
            {
                db.Users.Add(uye);

                if (db.SaveChanges() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, uye);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Ekleme islemi yapilamadi");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
           
        }

        // Skor ekleme
        [HttpPost]
        [Route("api/skor")]
        public IHttpActionResult Post(Scores skor)
        {
            db.Scores.Add(skor);
            db.SaveChanges();
            return Ok();
        }


        // Uye silme
        [Route("api/uye/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Users uye = db.Users.FirstOrDefault(e => e.Id == id);

                if (uye == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Uye ID : " + id);
                }
                else
                {

                    db.Users.Remove(uye);

                    if (db.SaveChanges() > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, uye);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Silme islemi yapilamadi");
                    }
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}