﻿using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using IdeaStorm.Models;

namespace IdeaStorm.Controllers
{
    public class IdeaController : ApiController
    {
        private IRepository _repository;

        public IdeaController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Ideas
        public IQueryable<Idea> GetIdeas()
        {
            return _repository.GetAllIdeas();
        }

        // GET: api/Ideas/5
        [ResponseType(typeof(Idea))]
        public IHttpActionResult GetIdea(int id)
        {
            Idea idea = _repository.GetIdea(id);
            if (idea == null)
            {
                return NotFound();
            }

            return Ok(idea);
        }

        // PUT: api/Ideas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIdea(int id, Idea idea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != idea.Id)
            {
                return BadRequest();
            }

            //db.Entry(idea).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!IdeaExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ideas
        [ResponseType(typeof(Idea))]
        public IHttpActionResult PostIdea(Idea idea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Ideas.Add(idea);
            //db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = idea.Id }, idea);
        }

        // DELETE: api/Ideas/5
        [ResponseType(typeof(Idea))]
        public IHttpActionResult DeleteIdea(int id)
        {
            //Idea idea = db.Ideas.Find(id);
            //if (idea == null)
            //{
            //    return NotFound();
            //}

            //db.Ideas.Remove(idea);
            //db.SaveChanges();

            //return Ok(idea);
            return Ok();
        }

        //private bool IdeaExists(int id)
        //{
        //    return db.Ideas.Count(e => e.Id == id) > 0;
        //}
    }
}