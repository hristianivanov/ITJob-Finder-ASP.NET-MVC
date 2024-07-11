namespace DevHunter.Web.ViewModels.JobOffer
{
	using System.ComponentModel.DataAnnotations;

	using Data.Models.Enums;

	public class LocationTypeFormModel
	{
		public PlaceToWork LocationType { get; set; }
		public string DisplayName { get; set; }

		public LocationTypeFormModel(PlaceToWork locationType)
		{
			LocationType = locationType;
			DisplayName = GetDisplayName(locationType);
		}

		private string GetDisplayName(PlaceToWork locationType)
		{
			var displayAttribute = typeof(PlaceToWork)
					.GetField(locationType.ToString())?
					.GetCustomAttributes(typeof(DisplayAttribute), false)
				as DisplayAttribute[];

			return displayAttribute?.Length > 0 ? displayAttribute[0].Name : locationType.ToString();
		}
	}
}
