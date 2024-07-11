namespace DevHunter.Web.ViewModels.JobOffer
{
	using System.ComponentModel.DataAnnotations;

	using Data.Models.Enums;

	public class SalaryTypeFormModel
	{
		public SalaryType SalaryType{ get; set; }
		public string DisplayName { get; set; }

		public SalaryTypeFormModel(SalaryType locationType)
		{
			SalaryType= locationType;
			DisplayName = GetDisplayName(locationType);
		}

		private string GetDisplayName(SalaryType locationType)
		{
			var displayAttribute = typeof(SalaryType)
					.GetField(locationType.ToString())?
					.GetCustomAttributes(typeof(DisplayAttribute), false)
				as DisplayAttribute[];

			return displayAttribute?.Length > 0 ? displayAttribute[0].Name : locationType.ToString();
		}
	}
}
