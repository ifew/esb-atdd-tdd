using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using api.Models;

namespace api.Services
{
    public class MemberService
    {
        private readonly MemberContext _context;

        public MemberService(MemberContext context)
        {
            _context = context;
        }

        public Member Get_Member_Information_By_ID(string id)
        {
            return _context.Members.Where(m => m.Id == int.Parse(id)).FirstOrDefault();
        }

        public IEnumerable<Member> List_Members()
        {
            return _context.Members.ToList();
        }

        public Member Add_Members(Member data)
        {
            _context.Add(data);
            _context.SaveChanges();

            return data;
        }
    }

}
