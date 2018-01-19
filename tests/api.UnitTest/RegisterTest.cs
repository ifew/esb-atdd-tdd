using System;
using System.Linq;
using api.Models;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace api.UnitTest
{
    public class RegisterTest
    {
        [Fact]
        public void Should_Display_Username_iFew(){
            
            var _options = new DbContextOptionsBuilder<MemberContext>().UseInMemoryDatabase("members").Options;
            var _context = new MemberContext(_options);

            _context.Members.Add(
                new Member
                {
                    Id = 1,
                    Fullname = "iFew",
                    Card_no = "6273885053341539",
                    Personal_id = "3100505143401",
                    Birthday = new DateTime(1987,01,01),
                    Mobilephone = "092224955"
                });
            _context.SaveChanges();

                
            MemberService _memberService = new MemberService(_context);
            Member actual = _memberService.Get_Member_Information_By_ID("1");

            Assert.Equal(1, actual.Id);
            Assert.Equal("iFew", actual.Fullname);
            Assert.Equal("6273885053341539", actual.Card_no);
            Assert.Equal("3100505143401", actual.Personal_id);
            Assert.Equal(new DateTime(1987, 01, 01), actual.Birthday);
            Assert.Equal("092224955", actual.Mobilephone);

        }
    }
}
