using Bogus;
using Microsoft.EntityFrameworkCore;
using MusicDataBaseEntityFramework.Entities;
using SpotifyClone.Core.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpotifyClone.Core.DataBase.Resources.Resources;

namespace SpotifyClone.Core.DataBase
{
    public class DataGenerator
    {
        public static void GenerateData(MyMusicDbContext db)
        {
            List<string> performerTypes = new List<string>();
            foreach (var i in Enum.GetValues(typeof(Resources.Resources.PerformerType)))
            {
                performerTypes.Add(i.ToString());
            }

            if (!db.Performers.Any())
            {
                for (int i = 0; i < 50; i++)
                {
                    //single perfomer 
                    var performerGenerator = new Faker<Performer>().RuleFor(x => x.Name, y => y.Music.Random.Words(2))
                        .RuleFor(x => x.PerformerType, y => performerTypes.RandomElement());

                    var performer = performerGenerator.Generate();

                    var albumsPerPerformer = new Random().Next(1, 5);
                    for (int j = 0; j < albumsPerPerformer; j++)
                    {
                        var albumGenerator = new Faker<Album>().RuleFor(x => x.Name, y => y.Random.Words(2))
                                .RuleFor(x => x.ReleaseDate, y => y.Date.Between(new DateTime(1980, 1, 1), DateTime.Now))
                                .RuleFor(x => x.Performer, y => performer);

                        var album = albumGenerator.Generate();

                        int songsPerAlbum = new Random().Next(7, 15);
                        for (int k = 0; k < songsPerAlbum; k++)
                        {
                            var songGenerator = new Faker<Song>().RuleFor(x => x.Title, y => y.Music.Random.Words(2))
                                    .RuleFor(x => x.Performer, y => performer)
                                    .RuleFor(x => x.Time, y => Double.Parse(new Random().Next(1, 4).ToString() + ',' + new Random().Next(1, 59).ToString()))
                                    .RuleFor(x => x.Album, y => album);

                            db.Songs.Add(songGenerator.Generate());
                        }
                    }
                }
            }

            if(!db.Users.Any())
            {
                for (int i = 0; i < 40; i++)
                {
                    var userGenerator = new Faker<User>().RuleFor(x => x.FirstName, b => b.Person.FirstName)
                    .RuleFor(x => x.LastName, b => b.Person.LastName)
                    .RuleFor(x => x.LoginEmail, b => b.Person.Email)
                    .RuleFor(x => x.Password, b => b.Random.Words(2) + b.Random.Number(1, 100).ToString());
                    var user = userGenerator.Generate();

                    var playlistPerUser = new Random().Next(1, 5);

                    for (int j = 0; j < playlistPerUser; j++)
                    {
                        var playlistGenerator = new Faker<Playlist>()
                       .RuleFor(x => x.Title, b => b.Random.Words(2) + " playlist")
                       .RuleFor(x => x.User, b => user);

                        db.Add(playlistGenerator.Generate());
                    }
                }
            }

            db.SaveChanges();
        }
    }
    
    //for choosing random string from a list
    internal static class CollectionExtension
    {
        private static Random rng = new Random();

        public static T RandomElement<T>(this IList<T> list)
        {
            return list[rng.Next(list.Count)];
        }

        public static T RandomElement<T>(this T[] array)
        {
            return array[rng.Next(array.Length)];
        }
    }
}
