﻿using Microsoft.Extensions.Configuration;
using System;

namespace ExampleJWT.Security
{
    public sealed class GlobalConfiguration
    {
        public const string RepositoryFilesPathSharePoint = @"wwwroot\SharePoint";

        private readonly static IConfigurationRoot configuration =
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();


        public static string ProviderDB
        {
            get
            {
                try
                {
                    return configuration["ConnectionStrings:ProviderName"];
                }
                catch (NullReferenceException)
                {
                    throw new Exception("No se ha definido el proveedor para la base de datos en el archivo de configuración.");
                }
            }
        }

        public static string Issuer
        {
            get
            {
                try
                {
                    return configuration["Jwt:Issuer"];
                }
                catch (NullReferenceException)
                {
                    throw new Exception("No \"Issuer\" defined");
                }
            }
        }

        public static string KeyToken
        {
            get
            {
                try
                {
                    return configuration["Jwt:Key"];
                }
                catch (NullReferenceException)
                {
                    throw new Exception("No \"Key\" defined");
                }
            }
        }

        public static int MinutesExpiresToken
        {
            get
            {
                try
                {
                    return Convert.ToInt32(configuration["Jwt:MinutesExpiresToken"]);
                }
                catch (NullReferenceException)
                {
                    throw new Exception("No \"MinutesExpiresToken\" defined");
                }
            }
        }
    }
}
