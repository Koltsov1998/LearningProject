using VkApi;

namespace VkApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiAccessProvider apiProvider = new ApiAccessProvider();
            var groupInfos = apiProvider.GetPhotoAlbum(120254617).GetAwaiter().GetResult();
            ;
        }
    }
}