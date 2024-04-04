namespace DevHunter.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class TechnologyJobOffersEntityConfiguration : IEntityTypeConfiguration<TechnologyJobOffers>
	{
		public void Configure(EntityTypeBuilder<TechnologyJobOffers> builder)
		{
			builder.HasData(this.GenerateTechnologyJobOffers());
		}

		private IEnumerable<TechnologyJobOffers> GenerateTechnologyJobOffers()
		{
			return new HashSet<TechnologyJobOffers>()
			{
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("CFC14C53-8311-4BB3-B84A-1AFE4459F7B9"),
					TechnologyId = Guid.Parse("7397E5D6-527E-47F9-8F23-20DD62692500"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("E88F42DA-D4F3-4274-97A3-F42178AB2BDD"),
					TechnologyId = Guid.Parse("7397E5D6-527E-47F9-8F23-20DD62692500"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("11FF421D-FA24-4716-9DEC-F5C831325F00"),
					TechnologyId = Guid.Parse("7397E5D6-527E-47F9-8F23-20DD62692500"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("BF796FB9-4F5B-417D-9889-C42F5F36737E"),
					TechnologyId = Guid.Parse("74638738-681D-4375-95A7-3C9016B68383"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("E88F42DA-D4F3-4274-97A3-F42178AB2BDD"),
					TechnologyId = Guid.Parse("E6218084-2B54-4165-B8A9-60C0D9EE7E1D"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("C10664CB-7542-442D-8BDD-1363DE49A0BA"),
					TechnologyId = Guid.Parse("B540D04C-7569-493E-A390-62F3DF559D4F"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("57681628-C674-413A-A2E1-A42F9ECC5D7C"),
					TechnologyId = Guid.Parse("B540D04C-7569-493E-A390-62F3DF559D4F"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("BF796FB9-4F5B-417D-9889-C42F5F36737E"),
					TechnologyId = Guid.Parse("E702256C-0504-41E2-AA0D-65C3BFFA1095"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("C10664CB-7542-442D-8BDD-1363DE49A0BA"),
					TechnologyId = Guid.Parse("29704A55-8DFF-46D3-AD94-6FCA2A393B48"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("F8E5E143-AD02-4273-8028-1F96BFF84347"),
					TechnologyId = Guid.Parse("85D93D19-68E5-4BAA-8D91-72CD70A6FCEA"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("D0A74A0E-AD6C-424A-906F-AB5FF256D5F1"),
					TechnologyId = Guid.Parse("85D93D19-68E5-4BAA-8D91-72CD70A6FCEA"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("E88F42DA-D4F3-4274-97A3-F42178AB2BDD"),
					TechnologyId = Guid.Parse("85D93D19-68E5-4BAA-8D91-72CD70A6FCEA"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("D0A74A0E-AD6C-424A-906F-AB5FF256D5F1"),
					TechnologyId = Guid.Parse("DD012C57-87FA-421B-A955-75A7504B7794"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("F8E5E143-AD02-4273-8028-1F96BFF84347"),
					TechnologyId = Guid.Parse("85EB8C55-D4AC-4408-8167-8887F9B3DC78"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("F8E5E143-AD02-4273-8028-1F96BFF84347"),
					TechnologyId = Guid.Parse("097D02E0-0577-4110-8FB7-8989F60D53B9"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("57681628-C674-413A-A2E1-A42F9ECC5D7C"),
					TechnologyId = Guid.Parse("2C1B6D09-A0CE-4247-827D-8AC66F0D3BF4"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("C10664CB-7542-442D-8BDD-1363DE49A0BA"),
					TechnologyId = Guid.Parse("68153BF6-F21F-4029-ADD0-95575725AFED"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("57681628-C674-413A-A2E1-A42F9ECC5D7C"),
					TechnologyId = Guid.Parse("AC85A8F7-8055-431E-A343-96126FCD4680"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("D0A74A0E-AD6C-424A-906F-AB5FF256D5F1"),
					TechnologyId = Guid.Parse("AC85A8F7-8055-431E-A343-96126FCD4680"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("C10664CB-7542-442D-8BDD-1363DE49A0BA"),
					TechnologyId = Guid.Parse("A367010C-A083-490C-B2ED-976EE8F49C53"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("11FF421D-FA24-4716-9DEC-F5C831325F00"),
					TechnologyId = Guid.Parse("40E8906F-241B-4B60-B957-9E64B1C1E7A7"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("BF796FB9-4F5B-417D-9889-C42F5F36737E"),
					TechnologyId = Guid.Parse("DBD65E30-7822-429C-9217-9F53ADCC8060"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("E88F42DA-D4F3-4274-97A3-F42178AB2BDD"),
					TechnologyId = Guid.Parse("6208ABEE-B855-4281-BEAA-AA94673784A0"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("CFC14C53-8311-4BB3-B84A-1AFE4459F7B9"),
					TechnologyId = Guid.Parse("64FF7067-EB71-49D1-8672-AC5D71DA71AC"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("11FF421D-FA24-4716-9DEC-F5C831325F00"),
					TechnologyId = Guid.Parse("64FF7067-EB71-49D1-8672-AC5D71DA71AC"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("CFC14C53-8311-4BB3-B84A-1AFE4459F7B9"),
					TechnologyId = Guid.Parse("0B05DA1D-B9AE-42E2-A86E-B3746674E6CD"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("CFC14C53-8311-4BB3-B84A-1AFE4459F7B9"),
					TechnologyId = Guid.Parse("5CD0472E-8077-4893-890E-B4BB953C0885"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("E88F42DA-D4F3-4274-97A3-F42178AB2BDD"),
					TechnologyId = Guid.Parse("9DCFDDDA-5DE8-4406-8E73-C4C0F6F0951E"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("F8E5E143-AD02-4273-8028-1F96BFF84347"),
					TechnologyId = Guid.Parse("F66C9FC1-F609-4049-A8E4-CD01B152315E"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("BF796FB9-4F5B-417D-9889-C42F5F36737E"),
					TechnologyId = Guid.Parse("F66C9FC1-F609-4049-A8E4-CD01B152315E"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("11FF421D-FA24-4716-9DEC-F5C831325F00"),
					TechnologyId = Guid.Parse("F66C9FC1-F609-4049-A8E4-CD01B152315E"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("CFC14C53-8311-4BB3-B84A-1AFE4459F7B9"),
					TechnologyId = Guid.Parse("56E3673E-0798-4F06-B348-D6129E385BAD"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("D0A74A0E-AD6C-424A-906F-AB5FF256D5F1"),
					TechnologyId = Guid.Parse("56E3673E-0798-4F06-B348-D6129E385BAD"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("E88F42DA-D4F3-4274-97A3-F42178AB2BDD"),
					TechnologyId = Guid.Parse("56E3673E-0798-4F06-B348-D6129E385BAD"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("F8E5E143-AD02-4273-8028-1F96BFF84347"),
					TechnologyId = Guid.Parse("8B8D6DC4-5ABE-46FE-B7F9-DBE2C5D2FAC9"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("D0A74A0E-AD6C-424A-906F-AB5FF256D5F1"),
					TechnologyId = Guid.Parse("8B8D6DC4-5ABE-46FE-B7F9-DBE2C5D2FAC9"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("E88F42DA-D4F3-4274-97A3-F42178AB2BDD"),
					TechnologyId = Guid.Parse("8B8D6DC4-5ABE-46FE-B7F9-DBE2C5D2FAC9"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("E88F42DA-D4F3-4274-97A3-F42178AB2BDD"),
					TechnologyId = Guid.Parse("4815599E-4D99-458A-AD41-DE90B75B3C0F"),
				},
				new TechnologyJobOffers
				{
					JobOfferId = Guid.Parse("57681628-C674-413A-A2E1-A42F9ECC5D7C"),
					TechnologyId = Guid.Parse("2961DB2F-88A5-4831-B721-EBF69EFF0E2B"),
				},
			};
		}
	}
}
