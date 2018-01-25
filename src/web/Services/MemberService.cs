using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using web.Models;

namespace web.Services
{
    public class MemberService
    {
        public void Register(Member member)
        {
            string url = "http://localhost:5001/api/member/register";
            var result = Call(url, member);
        }

        static async Task<string> Call(string url, object data)
        {
            HttpClient client = new HttpClient();

            string stringData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(url, contentData).Result;

            string result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}