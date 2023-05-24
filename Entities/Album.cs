using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.DataBase.Entities
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<Song> Songs { get; set; } = new List<Song>();

        public Performer Performer { get; set; }
        public Guid PerformerId { get; set; }
    }
}
