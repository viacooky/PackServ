using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Application
    {
        public string Id{get;set;}
        public string Name{get;set;}
        public string Description{get;set;}
        public DateTime CreateTime{get;set;}
        public List<Version> Versions { get; set; }
    }
}
