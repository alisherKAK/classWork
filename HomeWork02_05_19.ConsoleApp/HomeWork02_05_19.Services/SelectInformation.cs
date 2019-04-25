using HomeWork02_05_19.DataAccess;
using HomeWork02_05_19.Models;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork02_05_19.Services
{
    public static class SelectInformation
    {
        public static List<Music> SelectAllMusic()
        {
            using (var context = new MusicContext())
            {
                var musics = context.Musics.ToList();
                return musics;
            }
        }

        public static List<Band> SelectAllBand()
        {
            using (var context = new MusicContext())
            {
                return context.Bands.ToList();
            }
        }

        public static Band SelectBandByIndex(int index)
        {
            return SelectAllBand()[index];
        }

        public static Music SelectMusicByIndex(int index)
        {
            return SelectAllMusic()[index];
        }

        public static List<Music> SelectMusicsByBandName(string bandName)
        {
            using(var context = new MusicContext())
            {
                var searchedBand = context.Bands.Where(band => band.Name == bandName).SingleOrDefault();
                return context.Musics.Where(music => music.Band.Id == searchedBand.Id).ToList();
            }
        }

        public static Music SelectMusicsByName(string musicName, Band band)
        {
            using(var context = new MusicContext())
            {
                var mus = context.Musics.Where(music => music.Name == musicName).SingleOrDefault();
                band = mus.Band;
                return mus;
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
