using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicAPI.Models;
namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    public class AlbumsController : Controller
    {
        List<Album> AlbumList = new List<Album>();
        
        public AlbumsController()
        {
            AlbumList.Add(new Album{Album_ID = 1, Artist_ID = 1, Artist ="Post Malone", Name = "Stoney", SongCount = 12, ReleaseDate = DateTime.Parse("12/09/2016")});
            AlbumList.Add(new Album{Album_ID = 2, Artist_ID = 1, Artist ="Post Malone", Name = "Stoney", SongCount = 12, ReleaseDate = DateTime.Parse("12/09/2016")});

            AlbumList.Add(new Album{Album_ID = 3, Artist_ID = 2, Artist ="Tool", Name = "Stoney", SongCount = 12, ReleaseDate = DateTime.Parse("12/09/2016")});
            AlbumList.Add(new Album{Album_ID = 4, Artist_ID = 2, Artist ="Tool", Name = "Stoney", SongCount = 12, ReleaseDate = DateTime.Parse("12/09/2016")});

            AlbumList.Add(new Album{Album_ID = 5, Artist_ID = 3, Artist ="Wu-Tang Clan", Name = "Stoney", SongCount = 12, ReleaseDate = DateTime.Parse("12/09/2016")});
            AlbumList.Add(new Album{Album_ID = 6, Artist_ID = 3, Artist ="Wu-Tang Clan", Name = "Stoney", SongCount = 12, ReleaseDate = DateTime.Parse("12/09/2016")});



        }

        [HttpGet]
        public ActionResult Albums()
        {
             return Ok(AlbumList);           
        }

        [HttpGet("{id}")]
        public ActionResult Albums(int Id)
        {
            return Ok(AlbumList.Where(a => a.Album_ID == Id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Albums([FromBody]Album album)
        {
            album.Album_ID = AlbumList.OrderByDescending(a => a.Album_ID).Select(a => a.Album_ID).FirstOrDefault() + 1;
            AlbumList.Add(album);
            return Ok(album);
        }

        [HttpPut]
        public ActionResult Albums(int album_id, [FromBody]Album album)
        {
            Album oldAlbum = AlbumList.Where(a => a.Album_ID == album.Album_ID).FirstOrDefault();
           if(oldAlbum != null)
           {
               oldAlbum.Artist = album.Artist;
               oldAlbum.Name = album.Name;
               oldAlbum.ReleaseDate = album.ReleaseDate;
               oldAlbum.SongCount = album.SongCount;
               return Ok(oldAlbum);
           }
           return NotFound();
        }

    }

}