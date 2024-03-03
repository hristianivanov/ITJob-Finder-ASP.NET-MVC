﻿namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class SavedJobOffer
	{
		[ForeignKey(nameof(User))]
		public Guid UserId { get; set; }
		public ApplicationUser User { get; set; } = null!;

		[ForeignKey(nameof(JobOffer))]
		public Guid JobOfferId { get; set; }
		public JobOffer JobOffer { get; set; } = null!;

		public DateTime Date { get; set; }
	}
}