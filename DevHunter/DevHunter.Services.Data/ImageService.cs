namespace DevHunter.Services.Data
{
	using Microsoft.AspNetCore.Http;

	using CloudinaryDotNet;
	using CloudinaryDotNet.Actions;

	using Interfaces;

	public class ImageService : IImageService
	{
		private readonly ICloudinaryService cloudinaryService;

		public ImageService(ICloudinaryService cloudinaryService)
		{
			this.cloudinaryService = cloudinaryService;
		}

		public async Task<string> UploadImage(IFormFile file, string folder, string fileName)
		{
			await using var stream = file.OpenReadStream();

			var uploadParams = new ImageUploadParams()
			{
				Folder = folder,
				PublicId = fileName,
				File = new FileDescription(fileName, stream),
			};

			var uploadResult = await cloudinaryService.UploadAsync(uploadParams);

			if (uploadResult.Error != null)
			{
				throw new InvalidOperationException(uploadResult.Error.Message);
			}

			return uploadResult.Url.ToString();
		}

		public async Task<string> EditImage(IFormFile file, string оldImageUrl, string fileName, string folder)
		{
			await using var stream = file.OpenReadStream();

			var uploadParams = new ImageUploadParams()
			{
				Folder = folder,
				PublicId = fileName,
				File = new FileDescription(fileName, stream)
			};

			var deletionResult = await this.DeletePhotoAsync(оldImageUrl);

			if (deletionResult.Error != null)
			{
				throw new InvalidOperationException(deletionResult.Error.Message);
			}

			var uploadResult = await cloudinaryService.UploadAsync(uploadParams);

			if (uploadResult.Error != null)
			{
				throw new InvalidOperationException(uploadResult.Error.Message);
			}

			return uploadResult.Url.ToString();
		}

		private async Task<DeletionResult> DeletePhotoAsync(string id)
		{
			var deleteParams = new DeletionParams(id);

			var result = await this.cloudinaryService.DestroyAsync(deleteParams);

			return result;
		}

		#region Uploading to db

		/*public Task<Stream> GetThumbnail(string id)
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
		}*/

		#endregion
	}


}
