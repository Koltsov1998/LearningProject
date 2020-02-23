using VkApi;

namespace VkApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiAccessProvider apiProvider = new ApiAccessProvider();
            var groupInfos = apiProvider.GetGroupInfo("dank_memes_ayylmao").GetAwaiter().GetResult();
            ;
        }
    }
}