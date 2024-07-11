namespace DevHunter.Data.Seeding.EntitySeeders
{
	using Microsoft.EntityFrameworkCore;

	using Contacts;
	using Models;
	using Models.Enums;

	public class JobOfferEntitySeeder : IEntitySeeder

	{
		public async Task SeedAsync(DevHunterDbContext dbContext, IServiceProvider serviceProvider)
		{
			if (await dbContext.JobOffers.AnyAsync())
			{
				return;
			}

			var jobOffers = this.GenerateJobOffers();

			await dbContext.JobOffers.AddRangeAsync(jobOffers);
			await dbContext.SaveChangesAsync();
		}

		private IEnumerable<JobOffer> GenerateJobOffers()
		{
			return new HashSet<JobOffer>()
			{
				new JobOffer
				{
					Id = Guid.Parse("C10664CB-7542-442D-8BDD-1363DE49A0BA"),
					JobPosition = "System Administrator – Security",
					CreatedOn = new DateTime(2024,4,2),
					CompanyId = Guid.Parse("753DE47C-3E2D-4257-BA94-40B4D969E700"),
					PlaceToWork = "Sofia",
					JobPlace = PlaceToWork.Road,
					Description = "<div>\r\n\t\t\t\t<p><strong>WHY join us?</strong></p>\r\n<p>Guided by our core values of Humanity, Innovation and Responsibility,\r\n we work openly in an environment of closeness, recognition and trust.</p>\r\n<p>You will be part of a team with smart, friendly, talented, hardworking and committed to doing great work people.</p>\r\n<p>You will be provided with plentiful opportunities as technologies and\r\n business models that empower you to show and expand your skills and \r\nabilities.</p>\r\n<p>You will be joining a stable environment and comfortable working conditions.</p>\r\n<p><strong>WHAT your essential role in the team will be:</strong></p>\r\n<p>If you are a Microsoft System Administrator with some knowledge in \r\nLinux and aspirations to move into the Security field, you are welcome \r\nto join our team!</p>\r\n<p>You must have in-depth knowledge of administering Windows Active \r\nDirectory networks and Windows servers and working knowledge of \r\nadministering Linux servers.</p>\r\n<p>We are looking for a <strong>System Administrator</strong> who wants to move into Security – and are willing to give you a chance, if you have the right mindset and skills.</p>\r\n<ul><li>Participate in the prevention, detection and response activities in the company.</li><li>You will need solid system administration capabilities to implement \r\nsecurity hardening for servers and desktops (Windows environment).</li><li>Scripting with PowerShell is a must, python is a plus.</li><li>You will be responsible for testing and implementing multiple \r\nsecurity controls across a broad range of IT infrastructure – Windows, \r\nLinux and network devices, databases and applications.</li></ul>\r\n<p><strong>WHAT necessary requirements for the position are needed:</strong></p>\r\n<ul><li>Bachelor’s Degree in Computer Science or relevant field or relevant work experience;</li><li>Security hardening (OS &amp; Application) skills;</li><li>Application security knowledge and experience;</li><li>Security product usage and administration – vulnerability management tools;</li><li>DevSecOps experience is a plus, but not a must;</li><li>5 years experience with Windows Server (Active Directory, GPO, File \r\nServices, DNS, IIS, DHCP) – installation, configuration and \r\nadministration;</li><li>Powershell;</li><li>Very good knowledge of GPO security;</li><li>Very good knowledge of Active Directory Hardening;</li><li>Previous experience in building and configuring complex Active Directory infrastructure;</li><li>Experience with security tools, such as SIEM, EDR, Vulnerability management and scanning tools.</li></ul>\r\n<p><strong>WHAT we are offering to you:</strong></p>\r\n<ul><li>Remote work opportunity</li><li>30 days of paid leave</li><li>Health insurance</li><li>Food vouchers</li><li>Interesting work on new and long-run projects</li><li>Multisport card at a discounted price</li><li>Healthy snacks – free fruits, nuts and beverages</li><li>Access to e-learning platforms</li><li>Smart mobile phone and sponsored mobile plan</li><li>Shopping cards with discounts</li><li>Company-sponsored training and certification</li><li>Recreation room</li><li>Regular team buildings and celebrations</li></ul>\r\n\t\t\t</div>",
					WorkingHours = 72,
					WorkingExperience = "5+ years work experience",
					JobOfferTechnologies = new HashSet<TechnologyJobOffers>()
					{
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("B540D04C-7569-493E-A390-62F3DF559D4F")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("29704A55-8DFF-46D3-AD94-6FCA2A393B48")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("68153BF6-F21F-4029-ADD0-95575725AFED")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("A367010C-A083-490C-B2ED-976EE8F49C53")
						}
					}
				},
				new JobOffer
				{
					Id = Guid.Parse("CFC14C53-8311-4BB3-B84A-1AFE4459F7B9"),
					JobPosition = "Senior .NET Developer",
					CreatedOn = new DateTime(2024,3,28),
					CompanyId = Guid.Parse("753DE47C-3E2D-4257-BA94-40B4D969E700"),
					PlaceToWork = "Remote",
					JobPlace = PlaceToWork.Remote,
					Description = "<div>\r\n\t\t\t\t<p><strong>WHY</strong><strong>&nbsp;join us?</strong></p>\r\n<p>Guided by our core values Humanity, Innovation and Responsibility, we\r\n work openly in an environment of closeness, recognition and trust.</p>\r\n<p>You will be part of a team with smart, friendly, talented, hardworking and committed to doing great work people.</p>\r\n<p>You will be provided with plentiful opportunities as technologies and\r\n business models that empower you to show and expand your skills and \r\nabilities;</p>\r\n<p>You will be joining a stable environment and comfortable working conditions.</p>\r\n<p><strong>WHAT&nbsp;your essential role in the team will be:</strong></p>\r\n<ul><li>Participate in the development of core services and Web applications\r\n using C# and .NET framework, SQL, ASP MVC/WebForms, Web API, WCF, \r\nRabbitMQ/EasyNetQ, Microservices, Polymer;</li><li>Analyse functional requirements, define tasks and estimate development time;</li><li>Design and implement database structure;</li><li>Design and implement services to interface with external applications (WCF, Web API);</li><li>Implement new features as well as fixing bugs and performance issues;</li><li>Refactor and improve code in terms of readability, design patterns, architecture;</li><li>Write and maintain unit tests;</li><li>Help junior developers and perform code reviews.</li></ul>\r\n<p><strong>WHAT</strong><strong>&nbsp;necessary requirements for the position are needed:</strong></p>\r\n<ul><li>A minimum of 4 years work experience with C#, SQL and the .NET world;</li><li>Practical experience with database design and implementation;</li><li>Good understanding of design patterns and reusable software design approaches;</li><li>Knowledge in JavaScript, jQuery, Angular or other related libraries/frameworks is an advantage;</li><li>Ability to work effectively in a team;</li><li>Good troubleshooting and problem solving skills;</li><li>Analytical skills and attention to detail.</li><li>„Can do“attitude.</li></ul>\r\n<p><strong>WHAT we are offering to you:</strong></p>\r\n<ul><li>Remote work opportunity</li><li>30 days of paid leave</li><li>Health insurance</li><li>Food vouchers</li><li>Interesting work on new and long-run projects</li><li>Multisport card at a discounted price</li><li>Healthy snacks – free fruits, nuts and beverages</li><li>Access to e-learning platforms</li><li>Smart mobile phone and sponsored mobile plan</li><li>Shopping cards with discounts</li><li>Company-sponsored training and certification</li><li>Recreation room</li><li>Regular team buildings and celebrations</li></ul>\r\n\t\t\t</div>",
					WorkingHours = 0,
					WorkingExperience = "2-5 years work experience",
					JobOfferTechnologies = new HashSet<TechnologyJobOffers>()
					{
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("7397E5D6-527E-47F9-8F23-20DD62692500")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("64FF7067-EB71-49D1-8672-AC5D71DA71AC")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("0B05DA1D-B9AE-42E2-A86E-B3746674E6CD")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("5CD0472E-8077-4893-890E-B4BB953C0885")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("56E3673E-0798-4F06-B348-D6129E385BAD")
						}
					}
				},
				new JobOffer
				{
					Id = Guid.Parse("F8E5E143-AD02-4273-8028-1F96BFF84347"),
					JobPosition = "Mid Java / Java + React Developer",
					CreatedOn = new DateTime(2024,4,1),
					CompanyId = Guid.Parse("753DE47C-3E2D-4257-BA94-40B4D969E700"),
					PlaceToWork = "Sofia",
					JobPlace = PlaceToWork.Location,
					Description = "<div>\r\n\t\t\t\t<p><strong>Responsibilities:</strong></p>\r\n<ul><li>Participate in design, development, and maintenance of our software products</li><li>Maintain existing code and introduce improvements to working systems</li><li>Produce quality code following best practice guidelines for \r\ndevelopment process, coding style, revision control and security \r\npractices</li><li>Be part of an agile and cross functional team</li><li>Work closely with other teams responsible for other components like UX and APIs</li><li>Share their expertise during code review activities and refinement sessions</li><li>Design code in a functional and scalable way</li><li>Understanding and consideration of mobile security best practices</li></ul>\r\n<p><strong>Skills:</strong></p>\r\n<ul><li>Excellent overview of the Java ecosystem</li><li>Solid understanding of OOP principals and Design Patterns</li><li>Experience with micoservice-based applications</li><li>Experience with relational and non-relational databases</li><li>Write scalable, maintainable and testable code</li><li>Experience with writing and maintaining unit and UI tests is an advantage</li><li>Experience with Git and CI/CD</li><li>Strong analytical and problem-solving skills</li><li>Experience with code optimization and performance improvements</li><li>Experience in Agile development methodologies</li><li>Experience with React Typescript is a major advantage</li></ul>\r\n<p><strong>Experience &amp; Education:</strong></p>\r\n<ul><li>4+ professional experience with Java</li><li>Experience in development of financial applications would be a great advantage</li><li>BS degree in Computer Science or a similar technical field of study</li><li>Working proficiency and communication skills in verbal and written English</li></ul>\r\n<p><strong>WHAT we are offering to you:</strong></p>\r\n<ul><li>Remote work opportunity</li><li>30 days of paid leave</li><li>Health insurance</li><li>Food vouchers</li><li>Interesting work on new and long-run projects</li><li>Multisport card at a discounted price</li><li>Healthy snacks – free fruits, nuts and beverages</li><li>Access to e-learning platforms</li><li>Smart mobile phone and sponsored mobile plan</li><li>Shopping cards with discounts</li><li>Company-sponsored training and certification</li><li>Recreation room</li><li>Regular team buildings and celebrations</li></ul>\r\n\t\t\t</div>",
					WorkingHours = 48,
					WorkingExperience = "1-2 years work experience",
					JobOfferTechnologies = new HashSet<TechnologyJobOffers>()
					{
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("85D93D19-68E5-4BAA-8D91-72CD70A6FCEA")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("85EB8C55-D4AC-4408-8167-8887F9B3DC78")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("097D02E0-0577-4110-8FB7-8989F60D53B9")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("F66C9FC1-F609-4049-A8E4-CD01B152315E")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("8B8D6DC4-5ABE-46FE-B7F9-DBE2C5D2FAC9")
						}
					}
				},
				new JobOffer
				{
					Id = Guid.Parse("57681628-C674-413A-A2E1-A42F9ECC5D7C"),
					JobPosition = "Data Warehouse Expert",
					CreatedOn = new DateTime(2024,3,20),
					CompanyId = Guid.Parse("A5F9C3A3-159C-4439-AA88-33CCFA06F55E"),
					PlaceToWork = "Sofia",
					JobPlace = PlaceToWork.Hybrid,
					Description = "<p><b>Role Overview:</b></p>\r\n<p>As<strong> a Data Warehouse (DWH) Exper</strong>t, you will be \r\nresponsible for performing analysis, design, development, maintenance, \r\nand other tasks related to Business Intelligence. Your expertise will \r\ncontribute to optimizing data storage, retrieval, and reporting \r\nprocesses, ensuring efficient data management and supporting informed \r\ndecision-making within the organization. Additionally, you will play a \r\ncrucial role in designing and implementing robust data warehouse \r\nsolutions that align with the company’s objectives and meet evolving \r\nbusiness requirements.</p>\r\n<p><b>Your responsibilities will be:</b></p>\r\n<ul><li><strong>Perform Business Requirements Analysis:</strong> Analyze and evaluate business needs for developing or enhancing Business Intelligence systems.</li><li><strong>Solution architecture and design&nbsp;BI Software:</strong> Develop and Configure, and optimize BI software systems to meet organizational requirements.</li><li><strong>Plan and Communicate Technical Strategies:</strong> Prepare \r\ntechnical plans, roadmaps, and operational procedures, while also \r\ncommunicating with vendors to ensure alignment with organizational \r\ngoals.</li><li><strong>Drive Efficiency and Quality:</strong> Propose improvements, establish standards, and define quality criteria to enhance BI operations efficiency and effectiveness.</li><li><strong>Stay Current with BI Trends:</strong> Continuously monitor and integrate the latest advancements in Business Intelligence to maintain relevance and competitiveness.</li><li><strong>Lead Project Initiatives:</strong> Lead or participate in projects, providing technical guidance, monitoring progress, and reporting statuses to management.</li><li><strong>Ensure System Reliability and Support:</strong> Plan, \r\nexecute, and monitor testing, implementation, and support activities to \r\nensure the availability and reliability of BI systems, while also \r\nproviding user support and training to maximize system utilization</li></ul>\r\n<p><b>What We Expect From You:&nbsp;</b></p>\r\n<ul><li><strong>Technical Savvy:</strong> Proficiency in Oracle SQL, Hadoop,\r\n Python, and familiarity with relational and free databases is highly \r\ndesired. Additionally, proficiency in MS Project, Word, Excel, \r\nPowerPoint, and familiarity with Jira is a must.</li><li><strong>Experience First:</strong> Your hands-on experience in the \r\nBI field is crucial. With at least 5 years of experience, showcase your \r\nsolid understanding of project management principles. A PM certification\r\n would be a plus.</li><li>P<strong>resentation Pro:</strong> We need someone with excellent presentation skills to deliver impactful messages to diverse audiences.</li><li><strong>Organized Planner:</strong> Demonstrate exceptional organizational and planning skills to ensure smooth project execution.</li><li><strong>Team Collaboration:</strong> Be an effective team player, contributing positively to a collaborative work environment.</li><li><strong>Interpersonal Charm:</strong> Exhibit strong interpersonal skills to foster positive relationships within the team and with stakeholders.</li></ul>\r\n<p><b>Benefits:</b></p>\r\n<ul><li>Positive workplace culture where you would receive all the support \r\nyou need from your peers and managers in order to achieve your personal \r\nand team goals</li><li>Annual bonus based on your personal performance</li><li>Preferential prices for mobile devices and accessories</li><li>Unlimited mobile services and mobile internet</li><li>Flexible working hours</li><li>Monthly food vouchers</li><li>Additional health insurance</li></ul>",
					WorkingHours = 72,
					WorkingExperience = "Junior",
					JobOfferTechnologies= new HashSet<TechnologyJobOffers>()
					{
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("B540D04C-7569-493E-A390-62F3DF559D4F")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("2C1B6D09-A0CE-4247-827D-8AC66F0D3BF4")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("AC85A8F7-8055-431E-A343-96126FCD4680")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("2961DB2F-88A5-4831-B721-EBF69EFF0E2B")
						}
					}
				},
				new JobOffer
				{
					Id = Guid.Parse("11FF421D-FA24-4716-9DEC-F5C831325F00"),
					JobPosition = "Senior C#.NET Software Engineer",
					CreatedOn = new DateTime(2024,3,16),
					CompanyId = Guid.Parse("BF0AA1CB-93F5-443E-A8F6-7377B84C3F6F"),
					PlaceToWork = "Varna",
					JobPlace = PlaceToWork.Hybrid,
					Description = "<div>\r\n\t\t\t\t<p>If you would like to…</p>\r\n<p><strong>Use the latest technologies by mingling software development with provisioning cloud infrastructure.<br>\r\n</strong></p>\r\n<p><strong>Create bespoke software solutions for:<br>\r\n</strong></p>\r\n<ul><li>Algorithmic trading</li><li>Commodity trading</li><li>Asset (power plant) optimization</li><li>Energy production and transmission scheduling</li><li>Market data management</li><li>Financial risk management</li><li>Regulatory and risk reporting</li></ul>\r\n<p><span style=\"background-color: var(--color-white); color: var(--color-text); text-align: var(--bs-body-text-align)\"><strong>Work and learn in a vital industry such as the Energy sector.</strong></span></p>\r\n<p>…then <strong>ROITI</strong> could be the place for you. Founded in \r\n2013 in Bulgaria, we are a boutique IT consultancy focused on the \r\nEuropean energy trading market. From our office in Sofia, we service \r\nsome of the largest power, gas and oil trading companies in Germany, \r\nAustria, Sweden, the UK, Switzerland, and the Czech Republic.</p>\r\n<p><strong>We are looking for:<br>\r\n</strong></p>\r\n<ul><li>Fluent written and spoken English.</li><li>Good analytical and problem-solving skills.</li><li>Proactive approach and can-do attitude.</li><li>Willingness to learn the business behind the code.</li><li>Experience creating web services with C#.NET 6+ and ASP.NET Core.</li><li>Experience in unit testing with xUnit.</li><li>Comprehension of relational databases beyond simple queries.</li><li>Past involvement in building and deploying software – ideally with Azure DevOps.</li><li>Familiarity with cloud infrastructure, ideally with Microsoft Azure.</li><li>Good understanding of DevOps and Agile methodologies.</li></ul>\r\n<p><strong>It would be an advantage if you understand (and yes, you will get to use some or all the below):<br>\r\n</strong></p>\r\n<ul><li>Fluent written and spoken German.</li><li>The Energy or Financial domain.</li><li>Infrastructure as code – ideally with Terraform.</li><li>Messaging and streaming software – ideally with RabbitMQ.</li><li>Parallel, concurrent, asynchronous, or reactive programming.</li><li>Front-end development – Angular 2+.</li><li>Other back-end languages – Java, Python.</li></ul>\r\n<p><strong>Your responsibilities will be:<br>\r\n</strong></p>\r\n<ul><li>Analysis, design, development, testing, configuration, deployment, and maintenance of software solutions.</li><li>Communicating with clients and users, clarification of requirements.</li><li>Ownership of design decisions and solutions.</li><li>Mentoring and sharing knowledge with colleagues.</li><li>Continuous learning and self-development.</li></ul>\r\n<p><strong>We offer:<br>\r\n</strong></p>\r\n<p><strong>Competitive remuneration package:<br>\r\n</strong></p>\r\n<ul><li>Above average market research-based salaries.</li><li>Options for additional stimuli in the long term.</li></ul>\r\n<p><span style=\"background-color: var(--color-white); color: var(--color-text); text-align: var(--bs-body-text-align)\"><strong>Challenges offering professional and personal growth and fully company-sponsored:</strong></span></p>\r\n<ul><li>Internal and external trainings and courses</li><li>Obtainment of certifications</li><li>Tickets for tech events</li></ul>\r\n<p><strong>Internal policies that allow you to take control of your own schedule:<br>\r\n</strong></p>\r\n<ul><li>Flexible home office</li><li>Floating working hours</li><li><span style=\"background-color: var(--color-white); color: var(--color-text); text-align: var(--bs-body-text-align)\">Additional paid leave days</span></li></ul>\r\n<p><strong>Transparent communication:<br>\r\n</strong></p>\r\n<ul><li>Regular town hall meetings where the CEO and CFO update everyone on current company matters.</li><li>Clear and open career path and salary brackets.</li><li>Salary and performance review every 6 months.</li></ul>\r\n<p><strong>Fully covered additional health insurance, including dental, \r\nyearly preventative medical examinations, and healthy food at the \r\noffice.<br>\r\n</strong></p>\r\n<p><strong>Fully covered mobile phone plan.<br>\r\n</strong></p>\r\n<p><strong>Fully covered Multisport card.<br>\r\n</strong></p>\r\n<p><strong>Pleasant team atmosphere – movie nights, charity work, parties, team buildings.<br>\r\n</strong></p>\r\n<p>If you are interested, we would enjoy seeing your CV!</p>\r\n\t\t\t</div>",
					WorkingHours = 0,
					WorkingExperience = "2-5 years work experience",
					JobOfferTechnologies = new HashSet<TechnologyJobOffers>()
					{
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("7397E5D6-527E-47F9-8F23-20DD62692500")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("40E8906F-241B-4B60-B957-9E64B1C1E7A7")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("64FF7067-EB71-49D1-8672-AC5D71DA71AC")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("F66C9FC1-F609-4049-A8E4-CD01B152315E")
						}
					}
				},
				new JobOffer
				{
					Id = Guid.Parse("D0A74A0E-AD6C-424A-906F-AB5FF256D5F1"),
					JobPosition = "Senior Java Developer",
					CreatedOn = new DateTime(2024,2,27),
					CompanyId = Guid.Parse("2D41345B-3B00-4403-976B-73EE769CA17C"),
					PlaceToWork = "Remote",
					JobPlace = PlaceToWork.Remote,
					Description = "<p><strong>About DXC Bulgaria</strong></p>\r\n<p>We are DXC – a Fortune 500 global IT services leader. In Bulgaria, we\r\n are among the largest employers with over 4,000 employees working on \r\nthe company’s entire IT portfolio. We are flexible – we provide \r\neverything you need to comfortably work from home, but we also keep our \r\noffices open for collaboration, meetings, and building a strong team \r\nspirit. We tailor everyone’s development path to their individual \r\ninterests through training and additional certifications.</p>\r\n<p>Our experience and desire to grow, our mission, and our values create\r\n an environment where ambitious people become successful at home. At \r\nhome – in Bulgaria.</p>\r\n<p>&nbsp;</p>\r\n<p><strong>GROW with APPS!<br>\r\n</strong></p>\r\n<p><strong>&nbsp;</strong></p>\r\n<p><strong>&nbsp;</strong></p>\r\n<p><strong>DXC Applications team Bulgaria</strong> capability deals with\r\n projects on latest technologies and develop server, cloud, and mobile \r\napplications. We deliver high value services to DXC customers, which are\r\n global leaders in their business domains such as Banking, Insurance, \r\nTransport, Health care, Engineering software and others.&nbsp; Our team of \r\n300+ application development professionals is focused on getting deep \r\nknowledge in how the customers work and to deliver them innovation \r\nthrough adoption of next generation IT solutions.</p>\r\n<p><strong>&nbsp;</strong></p>\r\n<p><strong>Daily challenges&nbsp;</strong></p>\r\n<ul><li>Produce high-quality, scalable, testable, and modularized code;</li><li>Supporting the team in the creation of technical solutions;</li><li>Providing estimated timeframe and technical assessment of the tasks;</li><li>Producing unit and integration tests as part of a thoroughly tested and robust development process;</li><li>Work in an Agile environment.</li></ul>\r\n<p><strong>&nbsp;</strong></p>\r\n<p><strong>eXperience and skills required&nbsp;</strong></p>\r\n<ul><li>Strong experience in Object Oriented Design, Design patterns;</li><li>4+ years of professional experience with Java/JEE development skills;</li><li>Experience with the Spring ecosystem;</li><li>Knowledge and experience with relational databases, ORMs;</li><li>Experience in tools and practices in CI/CD, Jenkins, Git.</li><li>Basic knowledge of Front End tools: JavaScript/Typescript, ReactJS/Angular.</li></ul>\r\n<p><strong>&nbsp;</strong></p>\r\n<p><strong>Company benefits&nbsp;</strong></p>\r\n<ul><li>Competitive remuneration package</li><li>Additional Medical § Life insurance</li><li>4 days additional paid leave (total: 24 days)</li><li>Food vouchers</li><li>Training, continuous learning and career development in the largest IT company on the market</li><li>Unlimited access courses from a bunch of external partners for the best learner’s experience (e.g., LinkedIn Learning, Udemy)</li><li>Access to a foreign language learning platform</li><li>Stable employment in an international company</li><li>Advancement opportunities within the organization (a variety of interesting projects with the array of technologies and tools)</li><li>Flexibility in work arrangement (hybrid or fully remote work, the home office culture is in our DNA)</li><li>Workplace equipment to organize your home office (e.g., chair, desk, additional monitor, headset etc.)</li><li>DXC Partner courses and certifications (Microsoft, SAP, ServiceNow, \r\nAWS, Google, Dell Technologies, IBM, Microfocus, Salesforce, Red Hat, \r\nVMware, Workday)</li><li>Employee Referral Program – a financial bonus for the referrer for successful candidate recommendation</li><li>Employee Recognition Program with points assigned by colleagues for the recognized employees (exchangeable for prizes)</li><li>Employee Assistance Program (providing 24/7 support for employees and their families in difficult life situations)</li><li>Opportunity to join our numerous charity and ecology-related events organized by our Employee Ambassadors team.</li></ul>\r\n<p>We Deliver Excellence for our Customers and colleagues every day. Our\r\n values form the foundation of everything we do and every decision we \r\nmake.</p>\r\n<p>Only shortlisted candidates will be contacted.</p>",
					WorkingHours = 0,
					WorkingExperience = "2-5 years work experience",
					JobOfferTechnologies = new HashSet<TechnologyJobOffers>()
					{
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("85D93D19-68E5-4BAA-8D91-72CD70A6FCEA")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("DD012C57-87FA-421B-A955-75A7504B7794")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("AC85A8F7-8055-431E-A343-96126FCD4680")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("56E3673E-0798-4F06-B348-D6129E385BAD")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("8B8D6DC4-5ABE-46FE-B7F9-DBE2C5D2FAC9")
						}
					}
				},
				new JobOffer
				{
					Id = Guid.Parse("BF796FB9-4F5B-417D-9889-C42F5F36737E"),
					JobPosition = "UX Designer",
					CreatedOn = new DateTime(2024,3,2),
					CompanyId = Guid.Parse("A5F9C3A3-159C-4439-AA88-33CCFA06F55E"),
					PlaceToWork = "Sofia",
					JobPlace = PlaceToWork.Hybrid,
					Description = "<p><b>Role Overview:</b></p>\r\n<p>The <strong>UX designer</strong> is responsible for tactical and \r\noperational design propositions and UX implementation of the company \r\nDigital Channel strategy, including online presence, self-care and \r\ne-commerce channel presence. Responsible to create, develop and \r\nestablish/operates with the UX brand guideline, providing functional UX \r\n&amp; UI designs to the users of Yettel product lines, and to develop \r\nand manage online journeys and related web- and mobile app interfaces.</p>\r\n<p><b>Your&nbsp;responsibilities would be:</b></p>\r\n<ul><li>Create storyboards and website mapping, build wireframes to \r\nconceptualize designs and accurately convey digital platform journeys to\r\n internal stakeholders and line manager</li><li>Design new and optimize existing customer journeys, serving both, user ease of use and business needs.</li><li>Regularly update UX benchmarks and develop improvements for the \r\ncompany digital channels – in terms of concepts, content, UI, UX, \r\nfunctional improvements and optimizations</li><li>Participate in generating ideas for online apps, new products and \r\nservices to develop relevant UX cases and use recent studies and \r\nfindings to establish&nbsp;&nbsp; optimal UX practice</li><li>Conduct field research through various media platforms and user \r\ntesting to gather feedback on user satisfaction and ease of interaction \r\nwith company’s products</li><li>Collaborate with cross-functional teams (internal &amp; external) on the UX development of new products and services aimed.</li></ul>\r\n<p><b>We expect from you</b><b>:</b></p>\r\n<ul><li>Bachelor’s or University degree in UX design, Graphic design, Marketing, Engineering, IT or related background</li><li>Minimum 2 years of work experience within UX design fields, products &amp; E2E projects</li><li>Proficient with visual design tools such as Figma, Adobe Photoshop, Illustrator, etc.</li><li>Strong understanding of UI and UX principles</li><li>Excellent understanding of Digital business (web, mobile, app and web-sales) in the sense of customer experience</li><li>Capability to consult stakeholders using analytical skills and \r\nstrategic thinking, leading the process from briefing, debriefing, \r\ndesign proposals and ad hoc improvements</li><li>Project management experience is an asset</li><li>Fluent knowledge of English (written &amp; verbal) is required</li></ul>\r\n<p><b>Benefits:</b></p>\r\n<ul><li>Positive workplace culture where you would receive all the support \r\nyou need from your peers and managers in order to achieve your personal \r\nand team goals</li><li>Annual bonus based on your personal performance</li><li>Preferential prices for mobile devices and accessories</li><li>Unlimited mobile services and mobile internet</li><li>Flexible working hours</li><li>Monthly food and gift vouchers</li><li>Transportation allowance</li><li>Additional health insurance</li></ul>",
					WorkingHours = 48,
					WorkingExperience = "1-2 years work experience",
					JobOfferTechnologies= new HashSet<TechnologyJobOffers>()
					{
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("74638738-681D-4375-95A7-3C9016B68383")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("E702256C-0504-41E2-AA0D-65C3BFFA1095")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("DBD65E30-7822-429C-9217-9F53ADCC8060")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("F66C9FC1-F609-4049-A8E4-CD01B152315E")
						}
					}
				},
				new JobOffer
				{
					Id = Guid.Parse("E88F42DA-D4F3-4274-97A3-F42178AB2BDD"),
					JobPosition = "Mobile Developer",
					CreatedOn = new DateTime(2024,4,1),
					CompanyId = Guid.Parse("2D41345B-3B00-4403-976B-73EE769CA17C"),
					PlaceToWork = "Remote",
					JobPlace = PlaceToWork.Remote,
					Description = "<div>\r\n\t\t\t\t<p><strong>About DXC Bulgaria</strong></p>\r\n<p>We are DXC – a Fortune 500 global IT services leader. In Bulgaria, we\r\n are among the largest employers with over 4,000 employees working on \r\nthe company’s entire IT portfolio. We are flexible – we provide \r\neverything you need to comfortably work from home, but we also keep our \r\noffices open for collaboration, meetings, and building a strong team \r\nspirit. We tailor everyone’s development path to their individual \r\ninterests through training and additional certifications.</p>\r\n<p>Our experience and desire to grow, our mission, and our values \r\n​​create an environment where ambitious people become successful at \r\nhome. At home – in Bulgaria.</p>\r\n<p>DXC Applications team Bulgaria capability deals with projects on \r\nlatest technologies and develop server, cloud, and mobile applications. \r\nWe deliver high value services to DXC customers, which are global \r\nleaders in their business domains such as Banking, Insurance, Transport,\r\n Health care, Engineering software and others. Our team of 300+ \r\napplication development professionals is focused on getting deep \r\nknowledge in how the customers work and to deliver them innovation \r\nthrough adoption of next generation IT solutions.</p>\r\n<p><strong>&nbsp;</strong></p>\r\n<p><strong>Daily challenges<br>\r\n</strong></p>\r\n<p>As a Mobile Developer, you will be part of impactful projects in the \r\npublic and private sector and therefore make a true difference to the \r\nworld. You will be responsible for developing</p>\r\n<p>a mobile application that enables users to pay their power bills, do \r\ntheir own meter reading, or check consumption directly from their \r\nsmartphone.</p>\r\n<p><strong>&nbsp;</strong></p>\r\n<p><strong>eXperience and skills required<br>\r\n</strong></p>\r\n<ul><li>4+ years of professional experience as a Mobile developer</li><li>Hands-on experience with Flutter, Xamarin and React Native</li><li>Knowledge of iOS Native, Android Native App</li><li>Hands-on experience with JS language and frameworks (React, Angular, Vue), .NET/JAVA</li><li>Knowledge of Container &amp; DevOps technology</li><li>Develop tests within the scope (Unit, Integration, TDD)</li><li>Understanding of mobile and responsive design</li><li>Ability to leverage modern software architecture, design patterns, and solutions to increase value</li><li>Good understanding of OOP</li></ul>\r\n<p><strong>&nbsp;</strong></p>\r\n<p><strong>Company benefits<br>\r\n</strong></p>\r\n<ul><li>Competitive remuneration package</li><li>Additional Medical § Life insurance</li><li>4 days additional paid leave (total: 24 days)</li><li>The possibility to work entirely remotely</li><li>Food vouchers</li><li>Training, continuous learning and career development in the largest IT company on the market</li><li>Unlimited access courses from a bunch of external partners for the best learner’s experience (e.g., LinkedIn Learning, Udemy)</li><li>Access to a foreign language learning platform</li><li>Stable employment in an international company</li><li>Advancement opportunities within the organization (a variety of interesting projects with the array of technologies and tools)</li><li>Flexibility in work arrangement (hybrid or fully remote work, the home office culture is in our DNA)</li><li>Workplace equipment to organize your home office (e.g., chair, desk, additional monitor, headset etc.)</li><li>DXC Partner courses and certifications (Microsoft, SAP, ServiceNow, \r\nAWS, Google, Dell Technologies, IBM, Microfocus, Salesforce, Red Hat, \r\nVMware, Workday)</li><li>Employee Referral Program – a financial bonus for the referrer for successful candidate recommendation</li><li>Employee Recognition Program with points assigned by colleagues for the recognized employees (exchangeable for prizes)</li><li>Employee Assistance Program (providing 24/7 support for employees and their families in difficult life situations)</li><li>Opportunity to join our numerous charity and ecology-related events organized by our Employee Ambassadors team</li></ul>\r\n<p>&nbsp;</p>\r\n<p><span style=\"text-align: var(--bs-body-text-align)\">&nbsp;</span></p>\r\n<p>We <strong>Deliver Excellence</strong> for our <strong>Customers</strong> and colleagues every day. Our values form the foundation of everything we do and every decision we make.</p>\r\n<p><span style=\"text-align: var(--bs-body-text-align)\">If you feel \r\ncomfortable with the above-mentioned requirements, please send us your \r\nCV in English. At DXC our employees’ safety and well-being remain a key \r\npriority for us. Therefore, we continue with stay-at-home recruiting and\r\n video interviewing for the foreseeable future.</span></p>\r\n<p>Please note only shortlisted candidates will be contacted.</p>\r\n<p>This is to inform you that DXC Technology is registered as an \r\nadministrator of personal data to the Commission for Data Protection. \r\nSome of the information that you provide voluntarily is personal \r\ninformation and falls under the special protection regime under the Law \r\non Personal Data Protection. The personal data provided by you will be \r\nprocessed for the purposes of the selection process as well as for the \r\nrealization of the legitimate interests of the data controller in \r\nrespect of any future contract of employment. DXC takes the \r\nresponsibility to handle, use and store your personal data, ensuring its\r\n protection in secret from third parties. We inform you and you agree \r\nthat DXC may provide your personal data to the government, municipal \r\ninstitutions, banks, companies, corporate bodies and individuals, where \r\nsuch obligation exists under a special legal provision, where it is \r\nnecessary for the realization of your rights and legal interests as a \r\nparticipant in the selection process, and when it is necessary to \r\nrealize the legitimate rights and interests of DXC. DXC can provide your\r\n personal information to corporate bodies and individuals who are \r\nassigned to actions and activities relating to the selection process and\r\n in respect of any future contract of employment.</p>\r\n\t\t\t</div>",
					WorkingHours = 0,
					WorkingExperience = "5+ years work experience",
					JobOfferTechnologies = new HashSet<TechnologyJobOffers>()
					{
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("7397E5D6-527E-47F9-8F23-20DD62692500")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("E6218084-2B54-4165-B8A9-60C0D9EE7E1D")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("85D93D19-68E5-4BAA-8D91-72CD70A6FCEA")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("6208ABEE-B855-4281-BEAA-AA94673784A0")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("9DCFDDDA-5DE8-4406-8E73-C4C0F6F0951E")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("56E3673E-0798-4F06-B348-D6129E385BAD")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("8B8D6DC4-5ABE-46FE-B7F9-DBE2C5D2FAC9")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("4815599E-4D99-458A-AD41-DE90B75B3C0F")
						}
					}
				},
				new JobOffer
				{
					Id = Guid.Parse("3D1AAE8B-26AC-4921-BCC4-FCBDA8B1475B"),
					JobPosition = "Senior Go Developer",
					CreatedOn = new DateTime(2024,4,14),
					CompanyId = Guid.Parse("2D41345B-3B00-4403-976B-73EE769CA17C"),
					PlaceToWork = "Remote",
					JobPlace = PlaceToWork.Remote,
					Description = "<div>\r\n\t\t\t\t<p>We invite a Senior Backend Developer to join an AdTech project \r\nand be responsible for turning our product vision and roadmap into \r\nbest-in-class code that delivers an awesome customer experience. We need\r\n a person who can provide solutions that optimally balance development \r\nefforts, deployment costs, and time–to market while ensuring product \r\nrequirements are met.</p>\r\n<p>This role requires a specialist with fully up-to-date knowledge of the latest software coding practices, tools, and languages.</p>\r\n<p>Ready to dive into this exciting project?</p>\r\n<p>&nbsp;</p>\r\n<p><strong>PROJECT</strong></p>\r\n<p>With the deprecation of cookies and mobile IDs, addressability at \r\nscale has become an industry-wide challenge. Working with partners with a\r\n future-proofed audience strategy and ID-less solution has become \r\nparamount, as has leveraging highly engaging and impactful creative to \r\ncapture customers’ attention.</p>\r\n<p>While the client has traditionally focused on AI-powered audiences \r\nand geo-location, we are evolving with the industry to refocus on what \r\ntruly matters in advertising and creativity. We leverage our powerful \r\nmachine-learning engine to deliver high-scale, dynamic creatives that \r\nshine in a native environment. Contextually relevant ads show greater \r\nresults.</p>\r\n<p>The software engineering team is the engine that drives our ambition to build the world’s best mobile advertising platform.</p>\r\n<p>Join us as we build future-proofed, AI-powered dynamic experiences for our customers.</p>\r\n<p>&nbsp;</p>\r\n<p><strong>Requirements</strong></p>\r\n<ul><li>Expert-level skills in Go</li><li>Experience in container-based architectures (esp. Kubernetes/AWS)</li><li>Hands-on experience in high performance, high scalability, high availability systems</li><li>Ability to design and implement a main system capable of effectively\r\n multiplexing incoming requests into multiple outward connections \r\n(http/s, http2), while ensuring the maintenance of state until all \r\noutgoing requests receive replies</li><li>Ability to organize software internally for optimal teamwork, \r\nincluding defining best development practices, environment setup, unit \r\ntest definition, and test runtime setup and build automation</li><li>Has experience in low-level socket management, timeouts, TCP keep \r\nalive, HTTP keep alive, timeouts, time wait states, and similar is \r\nhighly valued</li><li>Ability to diagnose Go language issues: internal metrics monitoring,\r\n defining the ideal metrics to monitor externally, debugging in \r\nisolation, profiling locally and in production</li><li>Experience with CI/CD</li></ul>\r\n<p>&nbsp;</p>\r\n<p><strong>WOULD BE A PLUS</strong></p>\r\n<ul><li>Experience with Node.js</li></ul>\r\n<p>&nbsp;</p>\r\n<p><strong style=\"color: var(--color-text); text-align: var(--bs-body-text-align); background-color: var(--color-white)\">&nbsp;</strong></p>\r\n<p>Personal profile</p>\r\n<ul><li>Strong analytical, problem-solving, and documentation skills</li><li>Comfortable with working in Agile frameworks</li><li>Experience working in distributed international teams</li><li>Highly personable, with good communication skills</li></ul>\r\n<p>&nbsp;</p>\r\n<p><strong>Responsibilities</strong></p>\r\n<ul><li>Design and implement large-scale software solutions and components using Golang</li><li>Do everything needed to keep a high level of quality</li><li>Be a great communicator to be able to actively collaborate and get context for complex tasks</li><li>Follow best engineering practices and company/client guidelines</li><li>Play supervisory, advisory, and coaching roles for less-senior engineers in the team</li><li>Be an active contributor to all team-related meetings, events, and ceremonies</li><li>Contribute to creating architectural and technical documentation</li><li>Promote clean code and design patterns/principles</li><li>Actively and permanently work on self-development and \r\nself-education, making lessons learned for further advancement to the \r\nPrincipal position</li></ul>\r\n\t\t\t</div>",
					WorkingHours = 0,
					WorkingExperience = "1-2 years work experience",
					JobOfferTechnologies = new HashSet<TechnologyJobOffers>()
					{
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("bb8aafc8-0ac4-4694-9dda-a10ddfdd31ce")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("5c55f4b2-7f9b-434b-9478-fae3c846f900")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("1194737c-bef9-4091-a36c-6dc1c8f574e9")
						},
					}
				},
				new JobOffer
				{
					Id = Guid.Parse("59317F18-B028-4CA7-9F90-7B1ED2F60462"),
					JobPosition = "Backend Software Developer",
					CreatedOn = new DateTime(2024,5,3),
					CompanyId = Guid.Parse("2D41345B-3B00-4403-976B-73EE769CA17C"),
					PlaceToWork = "Sofia",
					JobPlace = PlaceToWork.Road,
					Description = "<div>\r\n\t\t\t\t<p><strong>TopView Sightseeing</strong> is a New York-based group of\r\n companies offering a variety of sightseeing bus tours, cruises, and \r\nbike rentals and tours. Our team has served over 2 million customers, \r\ncreating unforgettable experiences for people around the world. As we \r\nscale, we are looking for aspiring professionals to join the team and \r\nhelp drive the growth further. Our company is experiencing a great \r\nvertical and horizontal expansion and has planned to start exporting the\r\n experience, knowledge and success of our operations to other locations \r\naround the world starting in late 2021 such as Washington DC, San \r\nFrancisco, Miami, Los Angeles, Philadelphia, Houston, Chicago, London, \r\nParis, Rome, Barcelona, Dubai, Isntabul and many others.</p>\r\n<p>As a <strong>Backend Developer</strong> you will play an important \r\nrole in developing the TopView Sightseeing platform and services that \r\nare the heart of the company’s operations, driving multiple mobile \r\napplications and websites, working closely with our iOS, Android and Web\r\n developers. Together we will build great apps and experiences for our \r\nusers.</p>\r\n<p>At TopView Sightseeing, we value start-up mentalities. We run in a \r\nfast-paced environment, always try to optimize, stay very competitive, \r\nand we are not afraid to challenge ourselves. If you are ready to build \r\nsomething big – we are waiting for you!</p>\r\n<p><strong>TopView offers competitive salaries and benefits:</strong></p>\r\n<ul><li>Guaranteed annual salary increase</li><li>Performance bonus</li><li>Health insurance</li><li>More</li></ul>\r\n<p><strong>Responsibilities include, but are not limited to:</strong></p>\r\n<ul><li>Build solid backend architectures that integrate easily with other systems and technologies</li><li>Implement and maintain new backend modules for internal and client-facing apps and websites</li><li>Apply the latest backend technologies with a focus on serverless development</li><li>Improve backend services performance</li><li>Perform code reviews</li><li>Clearly and concisely communicate highly technical challenges and solutions with both technical and non-technical peers</li><li>Collaborate with frontend developers and the Management team</li></ul>\r\n<p><strong>Required experience:</strong></p>\r\n<ul><li>At least 2+ years of experience in backend development</li><li>Experienced in NodeJS.</li><li>Experience building RESTful APIs.</li><li>Willingness to learn Firebase.</li><li>Working experience with GIT.</li><li>Good communication skills, fluent English is a plus.</li><li>Ability to write clean, scalable/modular code.</li><li>Organized and with great time management skills.</li><li>Attention to detail and a strong ability to QA one’s own work.</li></ul>\r\n<p><strong>Bonus experience:</strong></p>\r\n<ul><li>Firebase or other serverless services</li><li>TypeScript</li></ul>\r\n\t\t\t</div>",
					WorkingHours = 48,
					SalaryType = SalaryType.Range,
					MinSalary = 5000,
					MaxSalary = 10000,
					WorkingExperience = "5+ years work experience",
					JobOfferTechnologies = new HashSet<TechnologyJobOffers>()
					{
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("f66c9fc1-f609-4049-a8e4-cd01b152315e")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("4972cc43-375b-40a7-829d-9c0acaefbcf0")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("097d02e0-0577-4110-8fb7-8989f60d53b9")
						},
						new TechnologyJobOffers
						{
							TechnologyId = Guid.Parse("56e3673e-0798-4f06-b348-d6129e385bad")
						}
					}
				},
			};
		}
	}
}
