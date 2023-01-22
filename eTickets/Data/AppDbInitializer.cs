using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Category
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Name = "iPhone",
                            Logo = "https://www.shareicon.net/data/256x256/2016/11/24/856497_apple_512x512.png",
                            Description = "This is iPhone category. All iPhone products are here."
                        },
                        new Category()
                        {
                            Name = "Android",
                            Logo = "https://1000logos.net/wp-content/uploads/2016/10/Android-Logo-2008.png",
                            Description = "This is Android category. All Android products are here."
                        },
                        new Category()
                        {
                            Name = "Phone Charger",
                            Logo = "https://www.dealsmagnet.com/images/17bgBnhh/2022/April/01/large/mi-wall-charger-for-mobile-phones-with-micro-usb.jpg",
                            Description = "This is Phone Charger category. All Phone Charger products are here."
                        },
                        new Category()
                        {
                            Name = "Phone Case",
                            Logo = "https://cdn.shopify.com/s/files/1/0399/2767/7078/products/b227ef46-0301-4dc2-a9e5-2ddc9d2f61dd_256x.png",
                            Description = "This is Phone Case category. All Phone Case products are here."
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Shops.Any())
                {
                    context.Shops.AddRange(new List<Shop>()
                    {
                        new Shop()
                        {
                            Name = "Apple Store",
                            Description = "This is offical page of Apple Store.",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/8/8e/Shop.svg"

                        },
                        new Shop()
                        {
                            Name = "You & Me Shop",
                            Description = "This is offical page of You & Me Shop.",
                            ProfilePictureURL = "https://i.pinimg.com/736x/ce/56/99/ce5699233cbc0f142250b520d967dff7.jpg"
                        },
                        new Shop()
                        {
                            Name = "S Shop",
                            Description = "This is offical page of S Shop.",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQXydvmmjrPPXIJCOm2aLWc2VtLRrKH7ub6Ug&usqp=CAU"
                        },
                        new Shop()
                        {
                            Name = "Mobile Shop",
                            Description = "This is offical page of Mobile Shop.",
                            ProfilePictureURL = "https://d2q79iu7y748jz.cloudfront.net/s/_squarelogo/256x256/2397a6fc06495b74b0e289d4af0f643e"
                        },
                        new Shop()
                        {
                            Name = "Flomo Shop",
                            Description = "This is offical page of Flomo Shop.",
                            ProfilePictureURL = "https://appadvice.com/cdn-cgi/mirage/eaec890b32ee033953d1542683469dcff009881bb0833aa6a0a8b9f19c50cef4/1280/https://is3-ssl.mzstatic.com/image/thumb/Purple114/v4/56/20/e8/5620e885-6e07-0635-0fe3-27487d478fcb/source/256x256bb.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //Items
                if (!context.Items.Any())
                {
                    context.Items.AddRange(new List<Item>()
                    {
                        new Item()
                        {
                            Name = "iPhone 14",
                            Description = "This is iPhone 14",
                            Price = 1200.50,
                            ImageURL = "https://www.apple.com/v/iphone-14/d/images/overview/selfies/selfie_startframe__ex2suisayck2_large.jpg",
                            CategoryId = 1,
                            ShopId = 3
                        },
                        new Item()
                        {
                            Name = "iPhone Case",
                            Description = "This is an iPhone case",
                            Price = 29.50,
                            ImageURL = "https://ae01.alicdn.com/kf/H0ea950b94f224d8184d9a30572a55f38O/HOCO-Original-Clear-Soft-TPU-Case-for-iPhone-12-13-Pro-Max-Transparent-Protective-Cover-Ultra.jpg_Q90.jpg_.webp",
                            CategoryId = 1,
                            ShopId = 1
                        },
                        new Item()
                        {
                            Name = "High Speed Charger",
                            Description = "This is a high speed charger",
                            Price = 39.50,
                            ImageURL = "https://m.media-amazon.com/images/I/51aVdvZyiBL.jpg",
                            CategoryId = 4,
                            ShopId = 4
                        },
                        new Item()
                        {
                            Name = "Samsung Phone",
                            Description = "This is a Samsung phone",
                            Price = 39.50,
                            ImageURL = "https://m.media-amazon.com/images/I/91W42b8YW+L._SX679_.jpg",
                            CategoryId = 1,
                            ShopId = 2
                        },
                        new Item()
                        {
                            Name = "Samsung Tablet",
                            Description = "This is a Samsung tablet",
                            Price = 39.50,
                            ImageURL = "https://images.samsung.com/is/image/samsung/id-galaxy-tab-s6-lite-p615-sm-p615nzaaxid-frontgray-thumb-231807775",
                            CategoryId = 1,
                            ShopId = 3
                        }
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@admin.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "klerisa@trupja.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Klerisa Trupja",
                        UserName = "Klerisa-Trupja",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

                string sonilaUserEmail = "sonila@tafhasi.com";
                var sonilaUser = await userManager.FindByEmailAsync(sonilaUserEmail);
                if (sonilaUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Sonila Tafhasi",
                        UserName = "Sonila-Tafhasi",
                        Email = sonilaUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

                string geraldaUserEmail = "geralda@shehu.com";
                var geraldaUser = await userManager.FindByEmailAsync(geraldaUserEmail);
                if (geraldaUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Geralda Shehu",
                        UserName = "Geralda-Shehu",
                        Email = geraldaUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

                string sabianUserEmail = "sabian@lala.com";
                var sabianUser = await userManager.FindByEmailAsync(sabianUserEmail);
                if (sabianUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Sabian Lala",
                        UserName = "Sabian Lala",
                        Email = sabianUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
