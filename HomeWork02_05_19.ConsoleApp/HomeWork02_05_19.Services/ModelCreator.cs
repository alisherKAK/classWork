using HomeWork02_05_19.Models;

namespace HomeWork02_05_19.Services
{
    public static class ModelCreator
    {
        public static Band CreateBand()
        {
            Band newBand = new Band()
            {
                Name = SetInformation.SetBandName()
            };

            return newBand;
        }

        public static Music CreateMusic(Band band)
        {
            Music newMusic = new Music()
            {
                Name = SetInformation.SetMusicName(),
                BandId = band.Id,
                SongDurationInSeconds = SetInformation.SetMusicDuration(),
                Lyrics = SetInformation.SetMusicLyrics(),
                Rating = SetInformation.SetMusicRating()
            };

            return newMusic;
        }
    }
}
