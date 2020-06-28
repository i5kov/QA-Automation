using Newtonsoft.Json;

namespace BookRequests.Model
{
    public static class JsonHelper
    {
        public static string ToJson(this Household self) => JsonConvert.SerializeObject(self, Helper.Settings);

        public static string ToJson(this User self) => JsonConvert.SerializeObject(self, Helper.Settings);
    }
}
