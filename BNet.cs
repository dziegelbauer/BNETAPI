using System.Text;
using System.Text.Json;
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
        static string ClientID = "4c129af2795342f283e3d3f98dfe406f";// String.Empty;
        static string ClientSecret = "RjHozaAXDLSAJdghW1LWDNWNbcxiONRh"; // String.Empty;
        static string APIToken = String.Empty;
        static DateTime? APITokenExpiration = null;

        public static void Initialize(string clientid, string secret)
        {
            ClientID = clientid;
            ClientSecret = secret;
        }

        internal static async Task<string> CallAPI(string endpoint)
        {
            if (ClientID == String.Empty || ClientSecret == String.Empty)
                throw new Exception("Client not initialized");

            HttpResponseMessage response;

            using (HttpClient client = new())
            {
                if (APIToken == String.Empty || APITokenExpiration is null || DateTime.Now.CompareTo(APITokenExpiration) > 0)
                {
                    client.BaseAddress = new Uri(BNet.GetOAuthEndpoint(Region.US));
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{BNet.ClientID}:{BNet.ClientSecret}")));
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    });
                    content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded");

                    response = await client.PostAsync("oauth/token", content);

                    var TokenReply = await response.Content.ReadAsStringAsync();
                    var OAuthToken = JsonSerializer.Deserialize<OAuth2Token>(TokenReply);

                    APIToken = OAuthToken?.access_token;
                    APITokenExpiration = DateTime.Now.AddSeconds(OAuthToken.expires_in);
                }
            }

            using (HttpClient client = new())
            {
                client.BaseAddress = new Uri(BNet.GetAPIEndpoint(Region.US));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", APIToken);

                response = await client.GetAsync($"{endpoint}&access_token={APIToken}");

                return await response.Content.ReadAsStringAsync();
            }
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

        internal static string GetOAuthEndpoint(Region rg)
        {
            return rg switch
            {
                Region.US => "https://us.battle.net/",
                Region.EU => "https://eu.battle.net/",
                Region.KR => "https://kr.battle.net/",
                Region.TW => "https://tw.battle.net/",
                Region.CN => "https://gateway.battlenet.com.cn/",
                _ => throw new Exception("Invalid Region")
            };
        }
    }
}