using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Version = Server.Models.Version;

namespace Server.Services
{
    public class ApplicationService
    {
        private readonly MainDbContext        _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationService(MainDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context             = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IList<string> GetList()
        {
            var rs = _context.Applications
                             .Where(app => app.Name == "bbb")
                             .Include(app => app.Versions)
                             .ToList();

            rs[0].Versions.Add(new Version
            {
                Id            = Guid.NewGuid().ToString(),
                Value         = "xxxxxxxxxxxxxx",
                NuGetVersion  = null,
                CreateTime    = DateTime.Now,
                Url           = "",
                ApplicationId = rs[0].Id
            });

            var cc = _context.SaveChanges();

            return new List<string>();
        }
    }
}