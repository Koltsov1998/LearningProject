using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VkApi.Messages;

namespace VkApi
{
    public class ApiAccessProvider
    {
        private readonly HttpClient _httpClient;

        private readonly string _accessToken =
            "7b17d1c97b17d1c97b17d1c93c7b7844a177b177b17d1c92529628d18971e6abea713d2";


        public ApiAccessProvider()
        {
            _httpClient = new HttpClient();
        }

        public async Task<GroupInfo> GetGroupInfo(string groupUriName)
        {
            var response = await _httpClient.GetAsync(
                $"{BASE_URI}" +
                $"groups.getById?" +
                $"&access_token={_accessToken}" +
                $"&group_id={groupUriName}" +
                $"&v={API_VERSION}"
                );

            var responseBody = await response.Content.ReadAsStringAsync();

            var groupInfo = JsonConvert.DeserializeObject<GroupInfoResponse>(responseBody)
                .Response
                .First(); // Так запрашиваем инфо только по одному паблику, то в коллекции будет только один объект

            return groupInfo;
        }

        public async Task<GetPhotosInfos> GetPhotoAlbum(int groupId)
        {
            var response = await _httpClient.GetAsync(
                $"{BASE_URI}" +
                $"photos.get?" +
                $"&access_token={_accessToken}" +
                $"&owner_id=-{groupId}" +
                $"&album_id=wall" +
                $"&v={API_VERSION}"
            );

            var responseBody = await response.Content.ReadAsStringAsync();

            var photosInfo = JsonConvert.DeserializeObject<GetPhotosInfos>(responseBody);

            return photosInfo;
        }

        private const string BASE_URI = "https://api.vk.com/method/";
        private const string API_VERSION = "5.103";
    }

    enum RequestTypes
    {
        GroupIdRequest,
    }
}
