using Newtonsoft.Json;

namespace VkApi.Messages
{
    public class GroupInfoResponse
    {
        [JsonProperty("response")]
        public GroupInfo[] Response { get; set; }
    }

    public class GroupInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        [JsonProperty("is_closed")]
        public bool IsClosed { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("is_member")]
        public bool IsMember { get; set; }

        [JsonProperty("is_advertiser")]
        public string IsAdvertiser { get; set; }

        [JsonProperty("description")]
        public string Descritption { get; set; }

        [JsonProperty("photo_50")]
        public string Photo50 { get; set; }

        [JsonProperty("photo_100")]
        public string Photo100 { get; set; }

        [JsonProperty("photo_200")]
        public string Photo200 { get; set; }

    }
}
