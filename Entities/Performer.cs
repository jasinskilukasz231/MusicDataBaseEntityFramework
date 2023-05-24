using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.DataBase.Entities
{
    public class Performer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PerformerType { get; set; }

        public List<Album> Albums { get; set; } = new List<Album>();
        public List<Song> Songs { get; set; } = new List<Song>();

    }
}
