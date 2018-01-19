﻿using System;
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
            return _context.Members.Single(m => m.Id == int.Parse(id));
        }
    }
}
