﻿using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class MemberContext : DbContext
    {
        public MemberContext(DbContextOptions<MemberContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }
    }
}