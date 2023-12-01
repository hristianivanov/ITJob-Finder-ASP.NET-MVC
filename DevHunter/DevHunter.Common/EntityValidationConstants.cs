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
	}
}