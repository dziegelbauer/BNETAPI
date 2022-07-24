using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNETAPI.WoW
{
    public static class WoW
    {
        public static async Task<Dictionary<int,string>> GetAchievementCategoryIndex()
        {
            Dictionary<int, string> result = new();

            var response = await BNet.CallAPI("data/wow/achievement-category/index?namespace=static-us");

            throw new NotImplementedException();
        }

        public static async Task<string> GetAchievementCategory(string id)
        {
            var response = await BNet.CallAPI($"data/wow/achievement-category/{id}?namespace=static-us");

            return response;
        }

        public static async Task<string> GetAchievementCategory(int id)
        {
            return await GetAchievementCategory(id.ToString());
        }

        public static async Task<string> GetAchievementIndex()
        {
            var response = await BNet.CallAPI("data/wow/achievement/index?namespace=static-us");

            return response;
        }

        public static async Task<string> GetAchievement(string id)
        {
            var response = await BNet.CallAPI($"data/wow/achievement/{id}?namespace=static-us");

            return response;
        }

        public static async Task<string> GetAchievement(int id)
        {
            return await GetAchievement(id.ToString());
        }

        public static async Task<string> GetAchievementMedia(string id)
        {
            var response = await BNet.CallAPI($"data/wow/media/achievement/{id}?namespace=static-us");

            return response;
        }

        public static async Task<string> GetAchievementMedia(int id)
        {
            return await GetAchievementMedia(id.ToString());
        }
    }
}
