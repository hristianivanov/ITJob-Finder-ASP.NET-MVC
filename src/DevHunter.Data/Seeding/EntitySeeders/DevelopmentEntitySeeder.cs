namespace DevHunter.Data.Seeding.EntitySeeders
{
    using Microsoft.EntityFrameworkCore;

    using Models;
    using Contacts;

    public class DevelopmentEntitySeeder : IEntitySeeder
    {
        public async Task SeedAsync(DevHunterDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Developments.AnyAsync())
            {
                return;
            }

            var developments = GenerateDevelopments();

            await dbContext.Developments.AddRangeAsync(developments);
            await dbContext.SaveChangesAsync();
        }

        private IEnumerable<Development> GenerateDevelopments()
        {
            return new HashSet<Development>()
            {
                new Development()
                {
                    Id = Guid.Parse("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"),
                    Name = "Backend Development",
                    ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1711954697/DevHunter/development/Backend%20Development.png",
                    DevelopmentTechnologies = new HashSet<TechnologyDevelopments>()
                    {
                        new TechnologyDevelopments
                        {
                            TechnologyId = Guid.Parse("85d93d19-68e5-4baa-8d91-72cd70a6fcea")
                        },
                        new TechnologyDevelopments
                        {
	                        TechnologyId = Guid.Parse("85eb8c55-d4ac-4408-8167-8887f9b3dc78")
                        },
                        new TechnologyDevelopments
                        {
	                        TechnologyId = Guid.Parse("64ff7067-eb71-49d1-8672-ac5d71da71ac")
                        },
                        new TechnologyDevelopments
                        {
	                        TechnologyId = Guid.Parse("075ec4e5-5197-456c-9a75-aa215fa8b3da")
                        },
                        new TechnologyDevelopments
                        {
	                        TechnologyId = Guid.Parse("b540d04c-7569-493e-a390-62f3df559d4f")
                        },
                        new TechnologyDevelopments
                        {
	                        TechnologyId = Guid.Parse("bb8aafc8-0ac4-4694-9dda-a10ddfdd31ce")
                        },
                        new TechnologyDevelopments
                        {
	                        TechnologyId = Guid.Parse("4972cc43-375b-40a7-829d-9c0acaefbcf0")
                        }
                    }
				},
                new Development()
                {
                    Id = Guid.Parse("c385035d-2a4d-442a-b6ca-6443bb378be1"),
                    Name = "Frontend Development",
                    ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1711959225/DevHunter/development/Frontend%20Development.png",
                    DevelopmentTechnologies = new HashSet<TechnologyDevelopments>()
                    {
                        new TechnologyDevelopments
                        {
                            TechnologyId = Guid.Parse("56e3673e-0798-4f06-b348-d6129e385bad")
                        },
                        new TechnologyDevelopments
                        {
	                        TechnologyId = Guid.Parse("8b8d6dc4-5abe-46fe-b7f9-dbe2c5d2fac9")
                        },
                        new TechnologyDevelopments
                        {
	                        TechnologyId = Guid.Parse("9dcfddda-5de8-4406-8e73-c4c0f6f0951e")
                        },
                        new TechnologyDevelopments
                        {
	                        TechnologyId = Guid.Parse("e6218084-2b54-4165-b8a9-60c0d9ee7e1d")
                        }
                    }
				},
                new Development()
                {
                    Id = Guid.Parse("010164b3-025f-461c-b393-b35bd679bf30"),
                    Name = "Customer Support",
                    ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052843/DevHunter/development/Customer%20Support.png"
                },
                new Development()
                {
                    Id = Guid.Parse("58e9c362-031c-4106-a273-7b730162f23b"),
                    Name = "Fullstack Development",
                    ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052406/DevHunter/development/Fullstack%20Development.png"
                },
                new Development()
                {
                    Id = Guid.Parse("f86ea64b-6602-48e6-a951-c4eed172decd"),
                    Name = "Data Science",
                    ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052843/DevHunter/development/Data%20Science.png",
                    DevelopmentTechnologies = new HashSet<TechnologyDevelopments>
                    {
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("e0988db1-54b6-47b9-9293-c96423280230")
	                    },
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("c43707a9-9307-476c-95e6-3c1381364e0e")
	                    },
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("2a698b89-b775-41f4-b97d-f20942a72b8d")
	                    },
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("1835a5be-934c-4149-a7bf-72e4d22589b0")
	                    }
                    }
				},
                new Development() {
                    Id = Guid.Parse("5f4e14ae-b693-4f22-8167-4c808c436391"),
                    Name = "IT Management",
                    ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/IT%20Management.png",
                },
                new Development() {
                    Id = Guid.Parse("8b1cdd7b-2455-4067-96f0-452a7a9eba50"),
                    Name = "ERP / CRM Development",
                    ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052843/DevHunter/development/ERP%20-%20CRM%20development.png",
                    DevelopmentTechnologies = new HashSet<TechnologyDevelopments>
                    {
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("1e27c97f-ffdb-4d3a-afc6-6d4d75532711")
	                    },
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("8c8373a3-a9bf-4b31-96d8-e9a8ec6a5f13")
	                    }
                    }
				},
                new Development() {
                    Id = Guid.Parse("134cb2eb-71a2-430f-ae7d-b01895cbefb8"),
                    Name = "Infrastructure",
                    ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/Infrastructure.png",
                    DevelopmentTechnologies = new HashSet<TechnologyDevelopments>
                    {
                        new TechnologyDevelopments
                        {
                            TechnologyId = Guid.Parse("1194737c-bef9-4091-a36c-6dc1c8f574e9")
                        },
                        new TechnologyDevelopments
                        {
	                        TechnologyId = Guid.Parse("a367010c-a083-490c-b2ed-976ee8f49c53")
                        },
                        new TechnologyDevelopments
                        {
	                        TechnologyId = Guid.Parse("f7861a1b-f927-475f-9a9c-86aa1e923b73")
                        },
                        new TechnologyDevelopments
                        {
	                        TechnologyId = Guid.Parse("e1fdc176-5f0e-44a2-8b02-84f757fe5118")
                        }
                    }
				},
                new Development() {
                    Id = Guid.Parse("60151c1f-394a-49e4-8777-fd85d41f1341"),
                    Name = "Junior/Intern",
                    ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/Junior%20-%20Intern.png",
                },
                new Development() {
                    Id = Guid.Parse("09b3a04b-ca29-42db-8f68-85e92f8c83ac"),
                    Name = "Mobile Development",
                    ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/Mobile%20Development.png",
                    DevelopmentTechnologies = new HashSet<TechnologyDevelopments>
                    {
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("4815599e-4d99-458a-ad41-de90b75b3c0f")
	                    },
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("6208abee-b855-4281-beaa-aa94673784a0")
	                    }
                    }
				},
                new Development() {
                    Id = Guid.Parse("3925bab7-3529-47e6-807f-37a57d9c9cfd"),
                    Name = "PM/BA and more",
                    ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/PM%20-%20BA%20and%20more.png",
                    DevelopmentTechnologies = new HashSet<TechnologyDevelopments>
                    {
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("88a342ad-594b-4fff-91ee-ce21baadf092")
	                    },
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("81692dbb-1b59-432b-a2fa-a56115b38e77")
	                    },
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("646b656f-3fb9-47d5-80e4-ba0f807e70d3")
	                    },
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("2961db2f-88a5-4831-b721-ebf69eff0e2b")
	                    },
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("f1aaf947-ccbf-4418-a55a-7c48931cb4bf")
	                    }
					}
				},
                new Development() {
                    Id = Guid.Parse("8448cd52-5cb6-4a42-8324-17c34e58837f"),
                    Name = "Quality Assurance",
                    ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052845/DevHunter/development/Quality%20Assurance.png",
                    DevelopmentTechnologies = new HashSet<TechnologyDevelopments>
                    {
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("d9fa804a-d7dd-4ba4-b790-8827a6b06e1e")
	                    },
	                    new TechnologyDevelopments
	                    {
		                    TechnologyId = Guid.Parse("ed1f9d3f-835c-4af3-95a1-fa2f32e67f4e")
	                    }
                    }
				},
                new Development() {
                    Id = Guid.Parse("5223d4e3-3508-47ca-a24c-538923500838"),
                    Name = "Technical Support",
                    ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052845/DevHunter/development/Technical%20Support.png",
                }
            };
        }
    }
}
