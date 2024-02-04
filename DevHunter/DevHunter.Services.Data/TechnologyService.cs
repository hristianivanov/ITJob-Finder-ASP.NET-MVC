namespace DevHunter.Services.Data
{
	using Microsoft.Data.SqlClient;
	using Microsoft.EntityFrameworkCore;

	using SixLabors.ImageSharp;
	using SixLabors.ImageSharp.Formats.Jpeg;
	using SixLabors.ImageSharp.Formats.Png;
	using SixLabors.ImageSharp.Processing;

	using DevHunter.Data;
	using DevHunter.Data.Models;
	using DevHunter.Data.Models.Complex;

	using Interfaces;
	using Web.ViewModels.Images;
	using Web.ViewModels.Technology;

	using static Common.EntityValidationConstants.Technology;

	public class TechnologyService : ITechnologyService
	{
		private readonly DevHunterDbContext dbContext;

		public TechnologyService(DevHunterDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<bool> TechnologyExistsByNameAsync(string technologyName)
		{
			bool exists = await this.dbContext
				.Technologies
				.AnyAsync(t => t.Name.ToLower() == technologyName.ToLower());

			return exists;
		}

		public async Task AddAsync(TechnologyFormModel formModel)
		{
			var imageInput = new ImageInputModel()
			{
				Name = formModel.Image.FileName,
				Type = formModel.Image.ContentType,
				Content = formModel.Image.OpenReadStream(),
			};

			using var imageResult = await Image.LoadAsync(imageInput.Content);

			var original = await this.SaveImage(imageResult, imageResult.Width, imageInput.Type);
			var thumbnail = await this.SaveImage(imageResult, ThumbnailWidth, imageInput.Type);

			var image = new ImageData
			{
				OriginalFileName = imageInput.Name,
				OriginalType = imageInput.Type,
				OriginalContent = original,
				ThumbnailContent = thumbnail,
			};

			Technology technology = new Technology()
			{
				Name = formModel.Name,
				Image = image
			};

			await this.dbContext.Technologies.AddAsync(technology);
			await this.dbContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<TechnologyViewModel>> AllAsync()
		{
			var technologies = await this.dbContext
				.Technologies
				.Select(t => new TechnologyViewModel()
				{
					Id = t.Id.ToString(),
					Name = t.Name,
					ImageUrl = $"/Technology/Thumbnail/{t.Id}"
				})
				.AsNoTracking()
				.ToListAsync();

			return technologies;
		}

		public Task<Stream> GetThumbnail(string id)
			=> this.GetImageData(id, "Thumbnail");

		public Task<Stream> GetOriginal(string id)
			=> this.GetImageData(id, "Original");

		private async Task<Stream> GetImageData(string id, string size)
		{
			var database = this.dbContext.Database;

			var dbConnection = (SqlConnection)database.GetDbConnection();

			var command = new SqlCommand(
				$"SELECT Image{size}Content FROM Technologies WHERE Id = @id;",
				dbConnection);

			command.Parameters.Add(new SqlParameter("@id", id));

			dbConnection.Open();

			var reader = await command.ExecuteReaderAsync();

			Stream result = null;

			if (reader.HasRows)
			{
				while (reader.Read())
					result = reader.GetStream(0);
			}

			reader.Close();

			return result;
		}
		private async Task<byte[]> SaveImage(Image image, int resizedWidth, string imageType)
		{
			var width = image.Width;
			var height = image.Height;

			if (width > resizedWidth)
			{
				height = (int)((double)resizedWidth / width * height);
				width = resizedWidth;
			}

			image
				.Mutate(i => i.Resize(width, height));

			image.Metadata.ExifProfile = null;

			var memoryStream = new MemoryStream();

			switch (imageType)
			{
				case "image/jpeg":
					await image.SaveAsJpegAsync(memoryStream, new JpegEncoder()
					{
						Quality = 75
					}); break;
				case "image/png": await image.SaveAsPngAsync(memoryStream, new PngEncoder()); break;
				default:
					throw new NotSupportedException($"Unsupported image type: {imageType}");
			}

			return memoryStream.ToArray();
		}
	}
}
