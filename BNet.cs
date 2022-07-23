using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BNETAPI
{
    public enum Region
    {
        US,
        EU,
        KR,
        TW,
        CN
    }

    public static class BNet
    {
        static string ClientID = String.Empty;
        static string ClientSecret = String.Empty;
        static string APIToken = String.Empty;

        public static void Initialize(string clientid, string secret)
        {
            ClientID = clientid;
            ClientSecret = secret;
        }

        internal static string CallAPI(string endpoint)
        {
            if (ClientID == String.Empty || ClientSecret == String.Empty)
                throw new Exception("Client not initialized");

            using (HttpClient client = new())
            {
                client.BaseAddress = new Uri(BNet.GetAPIEndpoint(Region.US));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("data/wow/achievement-category/index");
            }

            return String.Empty;
        }

        internal static string GetAPIEndpoint(Region rg)
        {
            return rg switch
            {
                Region.US => "https://us.api.blizzard.com/",
                Region.EU => "https://eu.api.blizzard.com/",
                Region.KR => "https://kr.api.blizzard.com/",
                Region.TW => "https://tw.api.blizzard.com/",
                Region.CN => "https://gateway.battlenet.com.cn/",
                _ => throw new Exception("Invalid Region")
            };
        }
    }
}