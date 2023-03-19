
using GolfClub.dbconnect;
using GolfClub.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GolfClub.Services
{
    public interface IMemberService
    {
        Task AddNewMember(Member members);
    }
    public class MemberService : IMemberService
    {
        public async Task AddNewMember(Member members)
        {
            using(var context =new AppDb())
            {
                await context.members.AddAsync(members);
                await context.SaveChangesAsync();
             
            }
        }
    }
}
