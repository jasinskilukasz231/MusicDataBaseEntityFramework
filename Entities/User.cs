using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.DataBase.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginEmail { get; set; }
        public string Password { get; set; }

        public List<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}
