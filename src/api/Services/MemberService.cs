using System;
using System.Linq;
using api.Models;

namespace api.Services
{
    public class MemberService
    {
        private readonly MemberContext memberContext;
        public MemberService(MemberContext memberContext)
        {
            this.memberContext = memberContext;
        }

        public Member Get_Member_Information_By_ID(string id)
        {
            try
            {
                return memberContext.Members.Single(m => Equals(m.Id, 1));
            }
            catch (System.Exception)
            {
                throw new Exception("Wrong username or password");
            }
        }
    }
}
