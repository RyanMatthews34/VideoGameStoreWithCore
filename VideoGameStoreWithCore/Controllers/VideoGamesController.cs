using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//reference themodel
using VideoGameStoreWithCore.Model;

namespace VideoGameStoreWithCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private VideoGameStoreModel db;

        //constructor - connect to db as soon as this controller is instantiated
        public VideoGamesController()
        {
            this.db = db;
        }

        //get
        [HttpGet]
        public IEnumerable<VideoGames>Get()
        {
            return db.videoGames.OrderBy(a => a.VideoGameName).ToList();
        }

        // GET: api/albums/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            VideoGames album = db.videoGames.Find(id);

            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        // POST: api/albums
        [HttpPost]
        public ActionResult Post([FromBody] VideoGames videoGames)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.videoGames.Add(videoGames);
            db.SaveChanges();
            return CreatedAtAction("Post", videoGames);
        }

        // PUT: api/albums/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] VideoGames videoGames)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(videoGames).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        // DELETE: api/albums/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            VideoGames videoGames = db.videoGames.Find(id);

            if (videoGames == null)
            {
                return NotFound();
            }

            db.videoGames.Remove(videoGames);
            db.SaveChanges();
            return Ok();
        }
    }
}