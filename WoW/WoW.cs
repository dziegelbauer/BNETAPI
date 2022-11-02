using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BNETAPI.WoW
{
    public static class WoW
    {
        public static async Task<WoWAchievementCategoryIndexRoot> GetAchievementCategoryIndex()
        {
            var response = await BNet.CallAPI("data/wow/achievement-category/index?namespace=static-us");

            var result = JsonSerializer.Deserialize<WoWAchievementCategoryIndexRoot>(response);
            
            return result;
        }

        public static async Task<WoWAchievementCategoryRoot> GetAchievementCategory(string id)
        {
            var response = await BNet.CallAPI($"data/wow/achievement-category/{id}?namespace=static-us");

            var result = JsonSerializer.Deserialize<WoWAchievementCategoryRoot>(response);
            
            return result;
        }

        public static async Task<WoWAchievementCategoryRoot> GetAchievementCategory(int id)
        {
            return await GetAchievementCategory(id.ToString());
        }

        public static async Task<WoWAchievementIndexRoot> GetAchievementIndex()
        {
            var response = await BNet.CallAPI("data/wow/achievement/index?namespace=static-us");

            var result = JsonSerializer.Deserialize<WoWAchievementIndexRoot>(response);
            
            return result;
        }

        public static async Task<WoWAchievementRoot> GetAchievement(string id)
        {
            var response = await BNet.CallAPI($"data/wow/achievement/{id}?namespace=static-us");

            var result = JsonSerializer.Deserialize<WoWAchievementRoot>(response);
            
            return result;
        }

        public static async Task<WoWAchievementRoot> GetAchievement(int id)
        {
            return await GetAchievement(id.ToString());
        }

        public static async Task<WoWAchievementMediaRoot> GetAchievementMedia(string id)
        {
            var response = await BNet.CallAPI($"data/wow/media/achievement/{id}?namespace=static-us");

            var result = JsonSerializer.Deserialize<WoWAchievementMediaRoot>(response);
            
            return result;
        }

        public static async Task<WoWAchievementMediaRoot> GetAchievementMedia(int id)
        {
            return await GetAchievementMedia(id.ToString());
        }

        public static async Task<string> GetAuctions(string realmId)
        {
            var response = await BNet.CallAPI($"/data/wow/connected-realm/{realmId}/auctions");

            return response;
        }

        public static async Task<string> GetAuctions(int realmId)
        {
            var response = await GetAuctions(realmId.ToString());

            return response;
        }

        public static async Task<string> GetConnectRealmIndex()
        {
            var response = await BNet.CallAPI("/data/wow/connected-realm/index");

            return response;
        }

        public static async Task<string> GetConnectedRealm(string realmId)
        {
            var response = await BNet.CallAPI($"/data/wow/connected-realm/{realmId}");

            return response;
        }

        public static async Task<string> GetConnectedRealm(int realmId)
        {
            var response = await GetConnectedRealm(realmId.ToString());

            return response;
        }
    }
}
