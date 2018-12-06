﻿using System;
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
    public class PlayerInfoController : ControllerBase
    {
        private VideoGameStoreModel db;

        //constructor - connect to db as soon as this controller is instantiated
        public PlayerInfoController()
        {
            this.db = db;
        }

        //get
        [HttpGet]
        public IEnumerable<PlayerInfo> Get()
        {
            return db.playerInfo.OrderBy(a => a.PlayerName).ToList();
        }

        // GET: api/Players
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            PlayerInfo player = db.playerInfo.Find(id);

            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        // POST: api/Players
        [HttpPost]
        public ActionResult Post([FromBody] PlayerInfo playerInfos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.playerInfo.Add(playerInfos);
            db.SaveChanges();
            return CreatedAtAction("Post", playerInfos);
        }

        // PUT: api/Players/
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PlayerInfo playerInfos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(playerInfos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Players
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            PlayerInfo playerInfos = db.playerInfo.Find(id);

            if (playerInfos == null)
            {
                return NotFound();
            }

            db.playerInfo.Remove(playerInfos);
            db.SaveChanges();
            return Ok();
        }
    }
}