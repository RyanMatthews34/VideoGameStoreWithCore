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
        public VideoGamesController(VideoGameStoreModel db)
        {
            this.db = db;
        }

        //get
        [HttpGet]
        public IEnumerable<VideoGames>Get()
        {
            return db.VideoGameInfo;
        }

        // GET: api/VideoGames
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            VideoGames album = db.VideoGameInfo.Find(id);

            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        // POST: api/VideoGames
        [HttpPost]
        public ActionResult Post([FromBody] VideoGames videoGames)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VideoGameInfo.Add(videoGames);
            db.SaveChanges();
            return CreatedAtAction("Post", videoGames);
        }

        // PUT: api/VideoGames
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

        // DELETE: api/VideoGames
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            VideoGames videoGames = db.VideoGameInfo.Find(id);

            if (videoGames == null)
            {
                return NotFound();
            }
            db.VideoGameInfo.Remove(videoGames);
            db.SaveChanges();
            return Ok();
        }
    }
}