namespace DevHunter.Services.Data
{
    using Mapster;

    using DevHunter.Data.Models;
    using Web.ViewModels.Company;
    using Web.ViewModels.JobOffer;

    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<JobOffer, JobOfferEditFormModel>.NewConfig()
                .Map(dest => dest.Title, src => src.JobPosition)
                .Map(dest => dest.Location, src => src.PlaceToWork)
                .Map(dest => dest.LocationType, src => src.JobPlace);

            TypeAdapterConfig<Company, CompanyFormModel>.NewConfig()
                .Map(dest => dest.Address, src => src.Location)
                .Map(dest => dest.EmployeesCnt, src => src.EmployeeCount);
        }
    }
}
