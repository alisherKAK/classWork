using HomeWork02_05_19.DataAccess;
using HomeWork02_05_19.Models;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork02_05_19.Services
{
    public static class SelectInformation
    {
        public static List<Music> SelectMusicsByBandName(string bandName)
        {
            using(var context = new MusicContext())
            {
                return context.Bands.Where(band => band.Name == bandName).SingleOrDefault().Musics as List<Music>;
            }
        }

        public static List<Music> SelectMusicsByName(string musicName)
        {
            using(var context = new MusicContext())
            {
                return context.Musics.Where(music => music.Name == musicName).ToList();
            }
        }

        public static List<Band> SelectBandsByBandName(string bandName)
        {
            using (var context = new MusicContext())
            {
                return context.Bands.Where(band => band.Name == bandName).ToList();
            }
        }
    }
}
