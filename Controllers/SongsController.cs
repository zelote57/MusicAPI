using Microsoft.AspNetCore.Mvc;
using MusicAPI.Data;
using MusicAPI.DTO;
using MusicAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ApiDbContext dbContext;

        public SongsController(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<SongsController>
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return dbContext.Songs;
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public Song Get(int id)
        {
            return dbContext.Songs.Find(id);
        }

        // POST api/<SongsController>
        [HttpPost]
        public ActionResult Post([FromBody] SongDto newSong)
        {
            var song = new Song
            {
                Title = newSong.Title,
                Language = newSong.Language,
            };

            dbContext.Songs.Add(song);
            dbContext.SaveChanges();

            return Ok();
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Song updatedSong)
        {
            var song = dbContext.Songs.Find(id);

            song.Title = updatedSong.Title;
            song.Language = updatedSong.Language;

            dbContext.SaveChanges();

            return Ok();
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var songToDelete = dbContext.Songs.Find(id);
            if (songToDelete != null)
            {
                dbContext.Songs.Remove(songToDelete);
                dbContext.SaveChanges();
            }
            return Ok();
        }
    }
}
