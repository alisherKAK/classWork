using HomeWork02_05_19.Models;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork02_05_19.Services
{
    public static class SortingService
    {
        public static List<Music> SortMusicDescendingRating(List<Music> musics)
        {
            return musics.OrderByDescending(music => music.Rating).ToList();
        }

        public static List<Music> SortMusicAscendingRating(List<Music> musics)
        {
            return musics.OrderBy(music => music.Rating).ToList();
        }

        public static List<Music> SortMusicDescendingName(List<Music> musics)
        {
            return musics.OrderByDescending(music => music.Name).ToList();
        }

        public static List<Music> SortMusicAscendingName(List<Music> musics)
        {
            return musics.OrderBy(music => music.Name).ToList();
        }

        public static List<Band> SortBandDescendingName(List<Band> bands)
        {
            return bands.OrderByDescending(band => band.Name).ToList();
        }

        public static List<Band> SortBandAscendingName(List<Band> bands)
        {
            return bands.OrderBy(band => band.Name).ToList();
        }
    }
}
