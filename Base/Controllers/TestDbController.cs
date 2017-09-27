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
using Base.Model.Model;
using Base.Model.Model.Test;

namespace Base.Controllers
{
    public class TestDbController : ApiController
    {
        private PracaDorywczaDbContext db = new PracaDorywczaDbContext();

        // GET: api/TestDb
        [Authorize]
        public IQueryable<TestDb> GetTest()
        {
            return db.Test;
        }

        // GET: api/TestDb/5
        [ResponseType(typeof(TestDb))]
        public IHttpActionResult GetTestDb(int id)
        {
            TestDb testDb = db.Test.Find(id);
            if (testDb == null)
            {
                return NotFound();
            }

            return Ok(testDb);
        }

        // PUT: api/TestDb/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestDb(int id, TestDb testDb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testDb.Id)
            {
                return BadRequest();
            }

            db.Entry(testDb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestDbExists(id))
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

        // POST: api/TestDb
        [ResponseType(typeof(TestDb))]
        public IHttpActionResult PostTestDb(TestDb testDb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Test.Add(testDb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = testDb.Id }, testDb);
        }

        // DELETE: api/TestDb/5
        [ResponseType(typeof(TestDb))]
        public IHttpActionResult DeleteTestDb(int id)
        {
            TestDb testDb = db.Test.Find(id);
            if (testDb == null)
            {
                return NotFound();
            }

            db.Test.Remove(testDb);
            db.SaveChanges();

            return Ok(testDb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestDbExists(int id)
        {
            return db.Test.Count(e => e.Id == id) > 0;
        }
    }
}