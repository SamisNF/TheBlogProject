using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBlogProject.Data;
using TheBlogProject.Enums;
using TheBlogProject.Models;

namespace TheBlogProject.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            //Task: Create the DB from the Migrations
            await _dbContext.Database.MigrateAsync();
            
            //Task 1: Seed a few Roles into the system.
            await SeedRolesAsync();

            //Task 2: Seed a few Users into the system.
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            //If there are already roles in the system, do nothing.
            if (_dbContext.Roles.Any())
            {
                return;
            }

            //Otherwise/Else, create a role for each role listed in enum BlogRole.
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private async Task SeedUsersAsync()
        {
            if(_dbContext.Users.Any())
            {
                return;
            }

            //Step 1: Create a new instance of BlogUser
            var adminUser = new BlogUser()
            {
                Email = "mrfredtechnology@gmail.com",
                UserName = "Sam",
                FirstName = "Samis",
                LastName = "Fredrickson",                
                PhoneNumber = "(405) 812-2736",
                EmailConfirmed = true
            };

            //Step 2: Use the UserManager to create a new user that is defined by adminUser
            await _userManager.CreateAsync(adminUser, "Abc&123!");

            //Step 3: Give the new user the Administrator role.
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            //Step 1 repeat: Create the moderator user
            var modUser = new BlogUser()
            {
                Email = "metroparkokc@gmail.com",
                UserName = "ModKing",
                FirstName = "Samis",
                LastName = "Fredrickson",

                PhoneNumber = "(405) 848-1343",
                EmailConfirmed = true
            };

            //Step 2: Use the UserManager to create a new user that is defined by modUser
            await _userManager.CreateAsync(modUser, "Abc&123!");

            //Step 3: Give the new user the Moderator role.
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());
        }


    }
}
