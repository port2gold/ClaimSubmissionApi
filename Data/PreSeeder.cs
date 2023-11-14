using ClaimSubmissionApi.Model;
using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;

namespace ClaimSubmissionApi.Data
{
    public static class PreSeeder
    {
        public static async Task SeedDatabase(AppDbContext ctx, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            await ctx.Database.EnsureCreatedAsync();


            if (!roleManager.Roles.Any())
            {
                var listOfRoles = new List<IdentityRole>
                {
                    new IdentityRole("Admin"),
                    new IdentityRole("PolicyHolder")
                };

                foreach (var role in listOfRoles)
                {
                    await roleManager.CreateAsync(role);
                }

                List<ApplicationUser> listOfUsers;

                if (!userManager.Users.Any())
                {
                    listOfUsers = new List<ApplicationUser>
                    {
                        new ApplicationUser
                        {
                            Email = "abdulkabeer01omotoso@gmail.com",
                            FirstName = "Abdulkabir",
                            LastName = "Omotoso",
                            UserName = "abdulkabeer01omotoso@gmail.com",
                            Gender = Enums.Gender.MALE,
                            PhoneNumber = "08137358684"
                        },
                         new ApplicationUser
                        {
                            Email = "abdulkabeer.01omotoso@gmail.com",
                            FirstName = "Abdul",
                            LastName = "Omo",
                            UserName = "abdulkabeer.01omotoso@gmail.com",
                            Gender = Enums.Gender.MALE,
                            PhoneNumber = "08137358684",
                            PolicyNumber = "xyz1234"
                        },
                    };

                    foreach (var user in listOfUsers)
                    {
                        var result = await userManager.CreateAsync(user, "Fairpayy$$");

                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, "Admin");
                            await userManager.AddToRoleAsync(user, "PolicyHolder");

                        }
                    }
                    ctx.SaveChanges();
                }
            }
        }
    }
}
