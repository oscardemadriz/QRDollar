using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using QRDollar.Models;

namespace QRDollar.Controllers
{
    public class QRsController : ApiController
    {
        private QRDollarModel db = new QRDollarModel();

        // GET: api/QRs
        public IQueryable<QR> GetQRs()
        {
            return db.QRs;
        }

        // GET: api/QRs/5
        [ResponseType(typeof(QR))]
        public IHttpActionResult GetQR(int id)
        {
            QR qR = db.QRs.Find(id);
            if (qR == null)
            {
                return NotFound();
            }

            return Ok(qR);
        }

        // PUT: api/QRs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQR(int id, QR qR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != qR.Id)
            {
                return BadRequest();
            }

            db.Entry(qR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QRExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/QRs
        [ResponseType(typeof(QR))]
        public IHttpActionResult PostQR(QR qR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QRs.Add(qR);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QRExists(qR.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = qR.Id }, qR);
        }

        // DELETE: api/QRs/5
        [ResponseType(typeof(QR))]
        public IHttpActionResult DeleteQR(int id)
        {
            QR qR = db.QRs.Find(id);
            if (qR == null)
            {
                return NotFound();
            }

            db.QRs.Remove(qR);
            db.SaveChanges();

            return Ok(qR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QRExists(int id)
        {
            return db.QRs.Count(e => e.Id == id) > 0;
        }
    }
}