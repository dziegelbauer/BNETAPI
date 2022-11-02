using System.Text.Json.Serialization;

namespace BNETAPI.WoW;

public record Key(
    [property: JsonPropertyName("href")] string Href
);

public record Links(
    [property: JsonPropertyName("self")] Self Self
);

public record Name(
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

public record Self(
    [property: JsonPropertyName("href")] string Href
);

public record Achievement(
    [property: JsonPropertyName("key")] Key Key,
    [property: JsonPropertyName("name")] Name Name,
    [property: JsonPropertyName("id")] int Id
);

public record Category(
    [property: JsonPropertyName("key")] Key Key,
    [property: JsonPropertyName("name")] Name Name,
    [property: JsonPropertyName("id")] int Id
);