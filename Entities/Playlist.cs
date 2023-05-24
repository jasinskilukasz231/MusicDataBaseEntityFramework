using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.DataBase.Entities
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public List<Song> Songs { get; set; }
    }
}
