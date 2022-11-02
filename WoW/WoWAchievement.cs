using System.Text.Json.Serialization;

namespace BNETAPI.WoW;

public record Description(
    [property: JsonPropertyName("en_US")] string EnUS,
    [property: JsonPropertyName("es_MX")] string EsMX,
    [property: JsonPropertyName("pt_BR")] string PtBR,
    [property: JsonPropertyName("de_DE")] string DeDE,
    [property: JsonPropertyName("en_GB")] string EnGB,
    [property: JsonPropertyName("es_ES")] string EsES,
    [property: JsonPropertyName("fr_FR")] string FrFR,
    [property: JsonPropertyName("it_IT")] string ItIT,
    [property: JsonPropertyName("ru_RU")] string RuRU,
    [property: JsonPropertyName("ko_KR")] string KoKR,
    [property: JsonPropertyName("zh_TW")] string ZhTW,
    [property: JsonPropertyName("zh_CN")] string ZhCN
);

public record Media(
    [property: JsonPropertyName("key")] Key Key,
    [property: JsonPropertyName("id")] int Id
);

public record RewardDescription(
    [property: JsonPropertyName("en_US")] string EnUS,
    [property: JsonPropertyName("es_MX")] string EsMX,
    [property: JsonPropertyName("pt_BR")] string PtBR,
    [property: JsonPropertyName("de_DE")] string DeDE,
    [property: JsonPropertyName("en_GB")] string EnGB,
    [property: JsonPropertyName("es_ES")] string EsES,
    [property: JsonPropertyName("fr_FR")] string FrFR,
    [property: JsonPropertyName("it_IT")] string ItIT,
    [property: JsonPropertyName("ru_RU")] string RuRU,
    [property: JsonPropertyName("ko_KR")] string KoKR,
    [property: JsonPropertyName("zh_TW")] string ZhTW,
    [property: JsonPropertyName("zh_CN")] string ZhCN
);

public record WoWAchievementRoot(
    [property: JsonPropertyName("_links")] Links Links,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("category")] Category Category,
    [property: JsonPropertyName("name")] Name Name,
    [property: JsonPropertyName("description")] Description Description,
    [property: JsonPropertyName("points")] int Points,
    [property: JsonPropertyName("is_account_wide")] bool IsAccountWide,
    [property: JsonPropertyName("reward_description")] RewardDescription RewardDescription,
    [property: JsonPropertyName("media")] Media Media,
    [property: JsonPropertyName("display_order")] int DisplayOrder
);