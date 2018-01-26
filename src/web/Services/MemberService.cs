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
        public Member Register(Member member)
        {
            string url = "http://localhost:5001/api/member/register";
            Member result = Call(url, member).Result;
            //Member memberModel = (Member)result;
            //var memberModel = JsonConvert.DeserializeObject<Member>(result);

            return result;
        }

        public Member Get_Member_Info(string id)
        {
            string url = "http://localhost:5001/api/member/info/"+id;
            Member result = CallGet(url).Result;

            return result;
        }

        static async Task<Member> Call(string url, Member data)
        {
            HttpClient client = new HttpClient();

            string stringData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(url, contentData).Result;

            var result = await response.Content.ReadAsStringAsync();
            var repositories = JsonConvert.DeserializeObject<Member>(result);

            return repositories;
        }

        static async Task<Member> CallGet(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var repositories = JsonConvert.DeserializeObject<Member>(response);

            return repositories;
        }
    }
}