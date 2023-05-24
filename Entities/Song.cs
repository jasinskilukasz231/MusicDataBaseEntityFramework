using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.DataBase.Entities
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public Performer Performer { get; set; }
        public Guid PerformerId { get; set; }

        public double Time { get; set; }

        public Album Album { get; set; }
        public Guid AlbumId { get; set; }

        public List<Playlist> Playlists { get; set; }
    }
}
