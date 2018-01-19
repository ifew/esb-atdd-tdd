using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class MemberContext : DbContext
    {
        public MemberContext(DbContextOptions<MemberContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<Member> Members { get; set; }

        public Member Get_Member_Information_By_ID(string id)
        {
            try
            {
                return this.Members.Single(m => m.Id == int.Parse(id));
            }
            catch (System.Exception)
            {
                throw new Exception("Wrong ID");
            }
        }
    }
}