using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace CMS_API_DL
{
    public class DBCS
    {
        public static string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
           .Build();

            var str = configuration.GetSection("ConnectionString:DBCS").Value;
            return str;
        }
        public static string GetBaseURL()
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
           .Build();

            var str = configuration.GetSection("AppSettings:baseUrl").Value;
            return str;
        }

        public static string GetProfileImageDocumentType()
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
           .Build();

            var str = configuration.GetSection("DocumentTypeSettings:ProfileImage").Value;
            return str;
        }
        public static string GetPANDocumentType()
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
           .Build();

            var str = configuration.GetSection("DocumentTypeSettings:Pan").Value;
            return str;
        }
        public static string GetAadhaarDocumentType()
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
           .Build();

            var str = configuration.GetSection("DocumentTypeSettings:Aadhaar").Value;
            return str;
        }
        public static string GetAddressProofDocumentType()
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
           .Build();

            var str = configuration.GetSection("DocumentTypeSettings:AddressProof").Value;
            return str;
        }
    }
}
