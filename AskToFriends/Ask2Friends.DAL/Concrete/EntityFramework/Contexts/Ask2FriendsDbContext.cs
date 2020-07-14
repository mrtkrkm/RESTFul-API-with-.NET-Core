using Ask2Friends.Entities;
using MG.Core.Entites.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask2Friends.DAL.Concrete.EntityFramework.Contexts
{
    public class Ask2FriendsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AskToFriendsDb;Trusted_Connection=true");
        }

        public DbSet<Room> Room { get; set; }
        public DbSet<UserRoom> UserRoom { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<QuestionPool> QuestionPool { get; set; }
        public DbSet<RoomQuestion> RoomQuestion { get; set; }
        public DbSet<SavedQuestion> SavedQuestion { get; set; }
        public DbSet<UserQuestion> UserQuestion { get; set; }
    }
}
