using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAPI.Models;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    { 
        private static List<Song> _songs = new List<Song>
        {
            new Song{ 
                Id = 1, 
                Title = "Yeah", 
                Language = "English"
            },
            new Song
            {
                Id = 2,
                Title = "Still Waiting",
                Language = "English"
            },
            new Song
            {
                Id = 3,
                Title = "Entre Nosotros",
                Language = "Spanish"
            }
        };

        [HttpGet]
        public IEnumerable<Song> GetAllSongs()
        {
            return _songs;
        }

        //GET api/Songs/0
        [HttpGet("{id}")]
        public Song GetSongById(int id)
        {
            return _songs.Find(song => song.Id == id);
        }

        [HttpPost]
        public IActionResult SaveSong([FromBody] Song newSong)
        {
            _songs.Add(newSong);
            return Ok();
        }

        //PUT api/Songs/0/Abc
        [HttpPut("{id}/{newTitle}")]
        public IActionResult UpdateSongTitle(int id, string newTitle)
        {
            var song = _songs.Find(song => song.Id == id);
            song.Title = newTitle;

            return Ok();
        }

        //PUT api/Songs/2
        [HttpPut("{id}")]
        public IActionResult UpdateSong(int id,[FromBody] Song updatedSong)
        {
            var song = _songs.Find(song => song.Id == id);
            
            song.Title = updatedSong.Title;
            song.Language = updatedSong.Language;

            return Ok();
        }

        //DELETE api/Songs/1
        [HttpDelete("{id}")]
        public IActionResult DeleteSong(int id)
        {
            var song = _songs.Find(song => song.Id == id);
            _songs.Remove(song);
            return Ok();
        }
    }
}
