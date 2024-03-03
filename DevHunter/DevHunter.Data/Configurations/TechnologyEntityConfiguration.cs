namespace DevHunter.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class TechnologyEntityConfiguration : IEntityTypeConfiguration<Technology>
	{
		public void Configure(EntityTypeBuilder<Technology> builder)
		{
			//builder.OwnsOne(t => t.Image, i =>
			//	{
			//		i.Property(i => i.OriginalFileName).HasColumnName("ImageFileName");
			//		i.Property(i => i.OriginalContent).HasColumnName("ImageOriginalContent");
			//		i.Property(i => i.ThumbnailContent).HasColumnName("ImageThumbnailContent");
			//		i.Property(i => i.OriginalType).HasColumnName("ImageOriginalType");
			//	});

			builder.HasData(this.GenerateTechnologies());
		}

		private IEnumerable<Technology> GenerateTechnologies()
		{
			return new HashSet<Technology>()
			{
				new Technology
				{
					Id = Guid.NewGuid(),
					Name = "Go",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png"
				},
				new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Html5",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png"
				},
				new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Kubernetes",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png"
				},
				new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Apache",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png"
				},
				new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Angular",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png"
				},
				new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Javascript",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png"
				},
				new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Go",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png"
				},
				new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Gitlab",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg"
				},
				new Technology
				{
					Id= Guid.NewGuid(),
					Name = "CSS",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png"
				},
				new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Bootstrap",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png"
				},
				new Technology
				{
					Id= Guid.NewGuid(),
					Name = "React",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png"
				},
				new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Python",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png"
				},
				new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Django",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png"
				},
				new Technology
				{
					Id= Guid.NewGuid(),
					Name = "MongoDb",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png"
				},new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Ansible",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png"
				},new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Django",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png"
				},new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Flink",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png"
				},new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Ecma",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png"
				},new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Linux",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png"
				},new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Typescript",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png"
				},new Technology
				{
					Id= Guid.NewGuid(),
					Name = "MariaDb",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png"
				},new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Nodejs",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png"
				},new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Docker",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg"
				},new Technology
				{
					Id= Guid.NewGuid(),
					Name = "Vue",
					ImageUrl =
						"http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png"
				},
			};
		}
	}
}
