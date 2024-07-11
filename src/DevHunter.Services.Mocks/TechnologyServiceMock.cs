namespace DevHunter.Services.Mocks
{
	using Moq;

	using Data.Interfaces;

	public class TechnologyServiceMock
	{
		public static ITechnologyService Instance
		{
			get
			{
				var technologyServiceMock = new Mock<ITechnologyService>();

				//technologyServiceMock.Setup(x => x.AllByDevelopmentAsync(It.IsAny<string>()))
				//	.ReturnsAsync((string id) =>
				//		technologies.Where(t => t.DevelopmentId.ToString() == id).ToList());

				return technologyServiceMock.Object;
			}
		}
	}
}
