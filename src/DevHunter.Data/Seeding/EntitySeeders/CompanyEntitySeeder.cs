namespace DevHunter.Data.Seeding.EntitySeeders
{
    using Microsoft.EntityFrameworkCore;

    using Models;
    using Contacts;

    public class CompanyEntitySeeder : IEntitySeeder
    {
        public async Task SeedAsync(DevHunterDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Companies.AnyAsync())
            {
                return;
            }

            var companies = GenerateCompanies();

            await dbContext.Companies.AddRangeAsync(companies);
            await dbContext.SaveChangesAsync();
        }

        private IEnumerable<Company> GenerateCompanies()
        {
            return new HashSet<Company>()
            {
                new Company
                {
                    Id = Guid.Parse("A5F9C3A3-159C-4439-AA88-33CCFA06F55E"),
                    Name = "Yettel",
                    EmployeeCount = 1800,
                    Location = "Sofia, Mladost 4, Business Park Sofia, building 6",
                    FoundedDate = new DateTime(2001,5,3),
                    Sector = "Telecommunications",
                    Activity = "Telecommunications",
                    ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1712124044/DevHunter/companies/Yettel.png",
                    WebsiteUrl = "https://www.yettel.bg/",
                    CreatorId = Guid.Parse("9231CC3C-ED70-4A91-AF87-8D70252D9B50"),
                    Description = "We are Yettel.<br><br>Yettel Bulgaria, part of the PPF Telecom Group, is\r\n a telecommunications company that connects over 3 million customers \r\nwith people, devices and businesses. Until March 2022 the company is \r\npresent on the Bulgarian market as Telenor Bulgaria.<br><br>We are a \r\ncompany that wants to discover, develop and invest in technology to \r\nserve people in the most useful and efficient way for them. At Yettel, \r\nwe believe that a balanced life is a better life. That's why we do \r\neverything we can to help people balance what's important to them, make \r\nbetter choices, especially when it comes to technology and its role in \r\nour lives.<br><br>As a leading mobile operator at Yettel, we know that \r\ncuriosity opens up new possibilities, that good and bold ideas deserve \r\nto become reality. The people of Yettel are driven, curious and \r\nambitious, we are the driving force behind being leaders in the telecom \r\nmarket in Bulgaria and earning the trust of our customers. For us, a \r\ncareer is not just a job, but the drive to try again and again until we \r\nachieve what we want. What unites us is that we do not give up and know \r\nthat a career in a telecom leader is something special."
                },
                new Company
                {
                    Id = Guid.Parse("753DE47C-3E2D-4257-BA94-40B4D969E700"),
                    Name = "SmartIT",
                    EmployeeCount = 130,
                    Location = "Sofia, 28 Jawaharlal Nehru Blvd., Silver Center",
                    FoundedDate = new DateTime(2005, 5 , 7),
                    Sector = "Financial sector",
                    Activity = "A product company",
                    ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1712128457/DevHunter/companies/SmartIT.png",
                    WebsiteUrl = "https://smartit.bg/",
                    CreatorId = Guid.Parse("2F4BBC62-7DB6-4E14-8790-EA0C3D704158"),
                    Description = "<p><strong>Smart IT</strong> is the technological hub that enables the work of 8300 employees and companies within the Management Financial Group (MFG) in Bulgaria, Romania, Poland, Ukraine, North Macedonia, and Spain. MFG's businesses have over 16 years of experience in developing and managing complex software solutions and administering ICT infrastructure. Smart IT's main focus is on developing a common modular platform for the introduction of fintech companies with various business models without the need for code. We utilize technologies such as C# and .NET/Core, ASP.NET/Core MVC, Web API, RabbitMQ, OAuth 2.0, Microservices, Docker, Kubernetes, ELK Stack, Grafana/InfluxDB, Polymer, DevExpress, JavaScript, jQuery, SignalR, EF, EF Core, MS SQL, MongoDB.</p>\r\n<p>Our work provides a competitive advantage to all companies within the group with business models in fintech sectors such as consumer and business lending, credit and digital cards, P2P lending, and other alternative financial products and services.</p>\r\n"
                },
                new Company
                {
                    Id = Guid.Parse("BF0AA1CB-93F5-443E-A8F6-7377B84C3F6F"),
                    Name = "ROITI",
                    EmployeeCount = 70,
                    Location = "Sofia, 71 Professor Tsvetan Lazarov Blvd",
                    FoundedDate = new DateTime(2013,4,2),
                    Sector = "Energy and IT",
                    Activity = "IT consulting, Implementation of software systems",
                    ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1712130774/DevHunter/companies/ROITI.jpg",
                    WebsiteUrl = "https://roiti.com/",
                    CreatorId = Guid.Parse("89DCCCDC-645E-4968-822E-5A3761805A21"),
                    Description = "<strong>ROITI</strong> is a boutique consulting company operating in the energy markets sector. We build, implement, and maintain standard and personalized technological solutions for commodity trading, risk management, asset optimization, accounting, planning, and logistics. We work with some of the largest energy, gas, and oil trading companies in Germany, Austria, Sweden, and the Czech Republic.\r\n"
                 },
                new Company
                {
                    Id = Guid.Parse("2D41345B-3B00-4403-976B-73EE769CA17C"),
                    Name = "DXC Technology",
                    EmployeeCount = 250,
                    Location = "Sofia 1715, Mladost district, Business Park Sofia, Building 9",
                    FoundedDate = new DateTime(1959,8,31),
                    Sector = "IT industry / software development",
                    Activity = "IT consulting, Development solutions",
                    ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712129604/DevHunter/companies/DXC%20Technology.png",
                    WebsiteUrl = "https://dxc.com/us/en",
                    CreatorId = Guid.Parse("8BC9F34C-E049-478C-9D62-60B5A7E1AE87"),
                    Description = "DXC Technology is a global leader in providing comprehensive IT solutions. Our mission is to use the power of technology to build a better future for our customers, colleagues, communities and environment.<br><br>At DXC Bulgaria, our employees have the opportunity to work on the entire IT portfolio of the company. It covers more traditional services such as data centers, building and maintaining networks, building devices and connectivity for work mobility, cloud services. There is, of course, a great focus on doing everything according to the latest requirements from the point of view of Cybersecurity, as the company's largest Security team in Europe is also located in Bulgaria.<br><br>We build, maintain and modernize applications. We also offer Big Data Analytics services, where it is worth noting that in Bulgaria we support the development of autonomous cars of some of the world's concerns. We are also a development center for our own Insurance Software products, which we provide to major insurers worldwide."
                }
            };
        }
    }
}
