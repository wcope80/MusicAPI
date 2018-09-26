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
        public List<Artist> Artists()
        {           
            return ArtistList;
        }
    }
}