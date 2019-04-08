using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class PayPalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        static PayPalConfiguration()
        {
            var config = GetConfig();
            ClientId = "AeLN8KAkkwGxPp3ZFXkrZmbHLFfRNuJW8L7VIeqNFWOrafnnJyHY04Ykvx8VQ7flRsOkbv-04Q8Ac21e";
            ClientSecret = "ELyTJKfLYc-UqzbPHoy1pbpqkRJWt8w782h5hD-xSzdr14pgCJmkt4mx_IZr44FG3vbo-DP9Y5pSN1BT";
        }

        public static Dictionary<string, string> GetConfig()
        {
            var config = ConfigManager.Instance.GetProperties();
            return config;
        }

        //Create access token
        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }

        //This will return APIContext 
        public static APIContext GetAPIContext()
        {
            var apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }
}