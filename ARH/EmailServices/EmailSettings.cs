using System.Security.Cryptography.Xml;

namespace Skyline_Manager.EmailServices
{
    public class EmailSettings
    {
        internal string EmailSenderAccount = null;
        internal string EmailSenderName = null;
        internal string EmailSenderAccountSecret = null;
        internal int Port = 0;
        internal string Host = null;
        internal string Body = "";
        internal string Signature = "";



        public EmailSettings()
        {
            var configuation = GetConfiguration();
            EmailSenderAccount = configuation.GetSection("AppSettings").GetSection("EmailSenderAccount").Value;
            EmailSenderName = configuation.GetSection("AppSettings").GetSection("EmailSenderName").Value;
            EmailSenderAccountSecret = configuation.GetSection("AppSettings").GetSection("EmailSenderAccountSecret").Value;
            Port = Convert.ToInt16(configuation.GetSection("AppSettings").GetSection("Port").Value);
            Host = configuation.GetSection("AppSettings").GetSection("Host").Value;
            Body = configuation.GetSection("AppSettings").GetSection("Body").Value;
            Signature = configuation.GetSection("AppSettings").GetSection("Signature").Value;

        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();

        }

    }
}