namespace DevHunter.Common
{
	public static class EntityValidationConstants
	{
		public static class User
		{
			public const int PasswordMinLength = 6;
			public const int PasswordMaxLength = 100;

			public const int FirstNameMinLength = 2;
			public const int FirstNameMaxLength = 50;

			public const int LastNameMinLength = 3;
			public const int LastNameMaxLength = 50;
		}

		public static class Technology
		{
			public const int NameMinLength = 2;
			public const int NameMaxLength = 50;

			public const int ThumbnailWidth = 100;
			public const int ImageMaxMegaBytesFileSize = 8;
		}

		public static class Development
		{
			public const int NameMinLength = 2;
			public const int NameMaxLength = 50;

			public const int ThumbnailWidth = 100;
			public const int ImageMaxMegaBytesFileSize = 8;
		}

		public static class Company
		{
			public const int NameMinLength = 2;
			public const int NameMaxLength = 50;

			public const int ThumbnailWidth = 100;
			public const int ImageMaxMegaBytesFileSize = 8;
		}

		public static class JobOffer
		{
			public const int TitleMinLength = 2;
			public const int TitleMaxLength = 40;
		}
    }
}