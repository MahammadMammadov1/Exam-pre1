﻿using Exam.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.DAL
{
    public class AppDbContext  : IdentityDbContext
    {
        public AppDbContext(DbContextOptions dbContext) : base(dbContext) { }
        

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
