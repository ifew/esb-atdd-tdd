using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
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

        static async Task<Member> Call(string url, Member data)
        {
            HttpClient client = new HttpClient();

            string stringData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(url, contentData).Result;

            var result = await response.Content.ReadAsStringAsync();
            var repositories = JsonConvert.DeserializeObject(result) as Member;

            return repositories;
        }
    }
}