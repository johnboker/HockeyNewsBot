using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HockeyNewsBot
{
    public partial class NewsData
    {
        [JsonProperty("data")]
        public NewsArticle[] NewsArticles { get; set; }

        [JsonProperty("jsonapi")]
        public Jsonapi Jsonapi { get; set; }

        [JsonProperty("links")]
        public DataLinks Links { get; set; }

        [JsonProperty("included")]
        public Included[] Included { get; set; }
    }

    public partial class NewsArticle
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("attributes")]
        public DatumAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public DatumRelationships Relationships { get; set; }

        [JsonProperty("links")]
        public DatumLinks Links { get; set; }
    }

    public partial class DatumAttributes
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("changed")]
        public long Changed { get; set; }

        [JsonProperty("headline")]
        public string Headline { get; set; }

        [JsonProperty("news")]
        public Analysis News { get; set; }

        [JsonProperty("analysis")]
        public Analysis Analysis { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("source_url")]
        public Uri SourceUrl { get; set; }

        [JsonProperty("recap")]
        public object Recap { get; set; }

        [JsonProperty("injury")]
        public bool Injury { get; set; }

        [JsonProperty("transaction")]
        public bool Transaction { get; set; }

        [JsonProperty("rumor")]
        public object Rumor { get; set; }

        [JsonProperty("developmental")]
        public bool Developmental { get; set; }

        [JsonProperty("sport_headline")]
        public bool SportHeadline { get; set; }

        [JsonProperty("overall_headline")]
        public bool OverallHeadline { get; set; }

        [JsonProperty("metatag")]
        public object Metatag { get; set; }
    }

    public partial class Analysis
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("processed")]
        public string Processed { get; set; }
    }

    public partial class DatumLinks
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }
    }

    public partial class DatumRelationships
    {
        [JsonProperty("player")]
        public League Player { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("position")]
        public League Position { get; set; }

        [JsonProperty("team")]
        public League Team { get; set; }

        [JsonProperty("related_players")]
        public Related RelatedPlayers { get; set; }

        [JsonProperty("related_teams")]
        public Related RelatedTeams { get; set; }
    }

    public partial class League
    {
        [JsonProperty("data")]
        public PurpleData Data { get; set; }

        [JsonProperty("links")]
        public PurpleLinks Links { get; set; }
    }

    public partial class PurpleData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }
    }

    public partial class PurpleLinks
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("related")]
        public Uri Related { get; set; }
    }

    public partial class Related
    {
        [JsonProperty("data")]
        public object[] Data { get; set; }

        [JsonProperty("links")]
        public PurpleLinks Links { get; set; }
    }

    public partial class Included
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("attributes")]
        public IncludedAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public IncludedRelationships Relationships { get; set; }

        [JsonProperty("links")]
        public DatumLinks Links { get; set; }
    }

    public partial class IncludedAttributes
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("changed")]
        public long Changed { get; set; }

        [JsonProperty("player_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlayerId { get; set; }

        [JsonProperty("legacy_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? LegacyId { get; set; }

        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty("birth_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? BirthDate { get; set; }

        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public Path Path { get; set; }

        [JsonProperty("latest_player_news_uuid", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? LatestPlayerNewsUuid { get; set; }

        [JsonProperty("latest_player_news_timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long? LatestPlayerNewsTimestamp { get; set; }

        [JsonProperty("metatag")]
        public object Metatag { get; set; }

        [JsonProperty("birth_city", NullValueHandling = NullValueHandling.Ignore)]
        public string BirthCity { get; set; }

        [JsonProperty("birth_country", NullValueHandling = NullValueHandling.Ignore)]
        public string BirthCountry { get; set; }

        [JsonProperty("birth_state")]
        public string BirthState { get; set; }

        [JsonProperty("college")]
        public string College { get; set; }

        [JsonProperty("contract")]
        public string Contract { get; set; }

        [JsonProperty("debut_year", NullValueHandling = NullValueHandling.Ignore)]
        public long? DebutYear { get; set; }

        [JsonProperty("draft_pick_overall", NullValueHandling = NullValueHandling.Ignore)]
        public long? DraftPickOverall { get; set; }

        [JsonProperty("draft_pick_supp", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DraftPickSupp { get; set; }

        [JsonProperty("draft_round", NullValueHandling = NullValueHandling.Ignore)]
        public long? DraftRound { get; set; }

        [JsonProperty("draft_year", NullValueHandling = NullValueHandling.Ignore)]
        public long? DraftYear { get; set; }

        [JsonProperty("handedness", NullValueHandling = NullValueHandling.Ignore)]
        public string Handedness { get; set; }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public long? Height { get; set; }

        [JsonProperty("jersey", NullValueHandling = NullValueHandling.Ignore)]
        public long? Jersey { get; set; }

        [JsonProperty("profile")]
        public object Profile { get; set; }

        [JsonProperty("stats_global_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? StatsGlobalId { get; set; }

        [JsonProperty("stats_id")]
        public object StatsId { get; set; }

        [JsonProperty("field_player_type_metatags")]
        public object FieldPlayerTypeMetatags { get; set; }

        [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
        public long? Weight { get; set; }

        [JsonProperty("abbreviation", NullValueHandling = NullValueHandling.Ignore)]
        public string Abbreviation { get; set; }

        [JsonProperty("locale", NullValueHandling = NullValueHandling.Ignore)]
        public string Locale { get; set; }

        [JsonProperty("short", NullValueHandling = NullValueHandling.Ignore)]
        public string Short { get; set; }

        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? TeamId { get; set; }

        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }

        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Active { get; set; }

        [JsonProperty("tickets", NullValueHandling = NullValueHandling.Ignore)]
        public Shop Tickets { get; set; }

        [JsonProperty("shop", NullValueHandling = NullValueHandling.Ignore)]
        public Shop Shop { get; set; }

        [JsonProperty("last_season", NullValueHandling = NullValueHandling.Ignore)]
        public long? LastSeason { get; set; }

        [JsonProperty("field_team_type_metatags")]
        public object FieldTeamTypeMetatags { get; set; }

        [JsonProperty("venue_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? VenueId { get; set; }

        [JsonProperty("fid", NullValueHandling = NullValueHandling.Ignore)]
        public long? Fid { get; set; }

        [JsonProperty("langcode", NullValueHandling = NullValueHandling.Ignore)]
        public string Langcode { get; set; }

        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }

        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public UriClass Uri { get; set; }

        [JsonProperty("filemime", NullValueHandling = NullValueHandling.Ignore)]
        public string Filemime { get; set; }

        [JsonProperty("filesize", NullValueHandling = NullValueHandling.Ignore)]
        public long? Filesize { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Status { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
    }

    public partial class Path
    {
        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("pid")]
        public long Pid { get; set; }

        [JsonProperty("langcode")]
        public string Langcode { get; set; }
    }

    public partial class Shop
    {
        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("options")]
        public object[] Options { get; set; }
    }

    public partial class UriClass
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class IncludedRelationships
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public League Type { get; set; }

        [JsonProperty("team", NullValueHandling = NullValueHandling.Ignore)]
        public League Team { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public League Position { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public Image Image { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public League Status { get; set; }

        [JsonProperty("draft_team", NullValueHandling = NullValueHandling.Ignore)]
        public League DraftTeam { get; set; }

        [JsonProperty("sport", NullValueHandling = NullValueHandling.Ignore)]
        public League Sport { get; set; }

        [JsonProperty("league", NullValueHandling = NullValueHandling.Ignore)]
        public League League { get; set; }

        [JsonProperty("primary_logo", NullValueHandling = NullValueHandling.Ignore)]
        public Image PrimaryLogo { get; set; }

        [JsonProperty("secondary_logo", NullValueHandling = NullValueHandling.Ignore)]
        public Image SecondaryLogo { get; set; }

        [JsonProperty("transparent_logo", NullValueHandling = NullValueHandling.Ignore)]
        public Image TransparentLogo { get; set; }

        [JsonProperty("conference", NullValueHandling = NullValueHandling.Ignore)]
        public League Conference { get; set; }

        [JsonProperty("division", NullValueHandling = NullValueHandling.Ignore)]
        public League Division { get; set; }

        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public League Uid { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("data")]
        public ImageData Data { get; set; }

        [JsonProperty("links")]
        public PurpleLinks Links { get; set; }
    }

    public partial class ImageData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("meta")]
        public DataMeta Meta { get; set; }
    }

    public partial class DataMeta
    {
        [JsonProperty("alt")]
        public string Alt { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public partial class Jsonapi
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("meta")]
        public JsonapiMeta Meta { get; set; }
    }

    public partial class JsonapiMeta
    {
        [JsonProperty("links")]
        public DatumLinks Links { get; set; }
    }

    public partial class DataLinks
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }
    }


    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
