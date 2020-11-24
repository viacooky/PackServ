using System;
using System.ComponentModel.DataAnnotations.Schema;
using NuGet.Versioning;

namespace Server.Models
{
    public class Version
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public NuGetVersion NuGetVersion { get; set; }
        public DateTime CreateTime { get; set; }
        public string Url { get; set; }
        public string ApplicationId { get; set; }
    }
}