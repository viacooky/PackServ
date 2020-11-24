using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Services;
using Version = Server.Models.Version;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/Application")]
    public class ApplicationController:ControllerBase
    {
        private ApplicationService _application;

        public ApplicationController(ApplicationService applicationService)
        {
            _application = applicationService;
        }

        [HttpGet("get")]
        public JsonResult Get()
        {
            var ccc = _application.GetList();
            // var rs = _context.Applications
            //                  .Where(app=>app.Name == "bbb")
            //                  .Include(app=>app.Versions)
            //                  .ToList();
            
            return new JsonResult("");
        }
    }
}
