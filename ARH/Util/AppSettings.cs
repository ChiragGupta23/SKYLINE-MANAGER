using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Skyline_Manager.Util
{
	public class AppSettings
	{
		internal string Key = null;
		internal string Issuer = null;
		internal string Audience = null;


		public AppSettings()
		{
			var configuation = GetConfiguration();

			Key = configuation.GetSection("Jwt").GetSection("Key").Value;
			Issuer = configuation.GetSection("Jwt").GetSection("Issuer").Value;
			Audience = configuation.GetSection("Jwt").GetSection("Audience").Value;


		}
		public IConfigurationRoot GetConfiguration()
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			return builder.Build();

		}

	}
}


