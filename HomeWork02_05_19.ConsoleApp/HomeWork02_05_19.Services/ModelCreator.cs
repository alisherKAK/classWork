using HomeWork02_05_19.DataAccess;
using HomeWork02_05_19.Models;
using System;

namespace HomeWork02_05_19.Services
{
    public static class ModelCreator
    {
        public static void CreateAndSaveBand()
        {
            Band newBand = new Band()
            {
                Name = SetInformation.SetBandName()
            };

            using(var context = new MusicContext())
            {
                context.Bands.Add(newBand);
                context.SaveChanges();
            }
        }

        public static void CreateAndSaveMusic(Guid bandId)
        {
            string name = SetInformation.SetMusicName();
            int songDuration = SetInformation.SetMusicDuration();
            string lyrics = SetInformation.SetMusicLyrics();
            int rating = SetInformation.SetMusicRating();
            using (var context = new MusicContext())
            {
                Music newMusic = new Music()
                {
                    Name = name,
                    Band = context.Bands.Find(bandId),
                    SongDurationInSeconds = songDuration,
                    Lyrics = lyrics,
                    Rating = rating
                };
                context.Musics.Add(newMusic);
                context.SaveChanges();
            }
        }
    }
}
