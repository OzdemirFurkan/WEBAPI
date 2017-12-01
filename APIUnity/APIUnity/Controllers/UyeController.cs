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


        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = db.uyeler.ToList();
            return Ok(result);

        }

        public Uyeler Get(int id)
        {
            return db.uyeler.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public HttpResponseMessage Post(Uyeler uye)
        {
            try
            {
                db.uyeler.Add(uye);

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

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Uyeler uye = db.uyeler.FirstOrDefault(e => e.Id == id);

                if (uye == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Uye ID : " + id);
                }
                else
                {

                    db.uyeler.Remove(uye);

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