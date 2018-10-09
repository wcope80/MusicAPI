using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicAPI.Models;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    public class ArtistsController : ControllerBase
    {
        List<Artist> ArtistList = new List<Artist>();
        public ArtistsController()
        {
            
            ArtistList.Add(new Artist{ Artist_ID = 1, Name = "Post Malone", Genre = "Hip Hop"});
            ArtistList.Add(new Artist{ Artist_ID = 2, Name = "Tool", Genre = "Heavy Metal"});
            ArtistList.Add(new Artist{ Artist_ID = 3, Name = "Wu-Tang Clan", Genre = "Rap"});

        }

        [HttpGet]
        public ActionResult Artists()
        {           
            return Ok(ArtistList);
        }

        [HttpGet("{Id}")]
        public ActionResult Artists(int Id)
        {
            Artist artist = ArtistList.FirstOrDefault(a => a.Artist_ID == Id);
            if(artist != null)
            {
                return Ok(artist);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Artists([FromBody]Artist artist)
        {
            artist.Artist_ID = ArtistList.OrderByDescending(a => a.Artist_ID).Select(a => a.Artist_ID).FirstOrDefault() + 1;
            ArtistList.Add(artist);
            return Ok(artist);
        }

        [HttpPut("{Id}")]
        public ActionResult Artists(int Id, [FromBody]Artist artist)
        {
            Artist oldArtist = ArtistList.FirstOrDefault(a => a.Artist_ID == Id);
            if(oldArtist != null)
            {
                oldArtist.Name = artist.Name ?? oldArtist.Name;
                oldArtist.Genre = artist.Genre ?? oldArtist.Genre;
                return Ok(oldArtist);
            }
            return NotFound();
        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteArtist(int Id)
        {
            Artist artist = ArtistList.FirstOrDefault(a => a.Artist_ID == Id);
            if(artist != null)
            {
                ArtistList.Remove(artist);
                return Ok();
            }
            return NotFound();
        }
    }
}