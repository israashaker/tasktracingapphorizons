using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TaskTrackingApp.Models;

namespace TaskTrackingApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class TaskController : ApiController
    {
        private DBModels db = new DBModels();

        // GET: api/Task
        public IQueryable<myTask> GetmyTasks()
        {
            return db.myTasks;
        }
        // POST api/Task
        [ResponseType(typeof(myTask))]
        public IHttpActionResult PostTask(myTask task)
        {
            db.myTasks.Add(task);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = task.taskId }, task);
        }
        // PUT api/Task/5
        public IHttpActionResult PutTask(int id,myTask task)
        {
            db.Entry(task).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!myTaskExists(id))
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

        

        // DELETE api/Task/5
        [ResponseType(typeof(myTask))]
        public IHttpActionResult DeleteTask(int id)
        {
            myTask task = db.myTasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            db.myTasks.Remove(task);
            db.SaveChanges();
            return Ok(task);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool myTaskExists(int id)
        {
            return db.myTasks.Count(e => e.taskId == id) > 0;
        }
    }
}