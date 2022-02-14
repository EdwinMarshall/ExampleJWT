using Microsoft.Extensions.Configuration;
using System;

namespace ExampleJWT.UI.Helpers
{
    public class AppSettings
    {
        private readonly static IConfigurationRoot configuration =
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();


        public static string BaseUriApi
        {
            get
            {
                try
                {
                    return configuration["BaseUriApi"];
                }
                catch (NullReferenceException)
                {
                    throw new Exception("No \"BaseUriApi\" defined");
                }
            }
        }


    }
}
