using System;

namespace MusicAPI.Models
{
    public class Album
    {
        public int Album_ID { get; set; }
        public int Artist_ID { get; set; }  
        public string Artist { get; set; } 
        public string Name { get; set; }        
        public int SongCount { get; set; }
        public DateTime ReleaseDate  { get; set; }  

    }

}
