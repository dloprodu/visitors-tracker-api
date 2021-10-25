﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using VisitorsTracker.Models;
using VisitorsTracker.BLL.BusinessLogic;
using VisitorsTracker.BLL.Services;

namespace VisitorsTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackerController : Controller
    {

        private readonly IGuestService _service;
        private readonly ILogger<TrackerController> _logger;

        public TrackerController(ILogger<TrackerController> logger, IGuestService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult Ping()
        {
            return Ok("Vistors Tracker API");
        }

        [HttpGet, Route("visits/show")]
        public async Task<ActionResult<(long total, List<Guest> result)>> Get([FromQuery] string userAgent, [FromQuery] string platform, [FromQuery] string language, [FromQuery] string country )
        {
            var result = await (new FetchGuestsManager(this._service, new FetchGuestInput { 
                userAgent = userAgent,
                platform = platform,
                language = language,
                country = country
            } )).DoAction();

            return new OkObjectResult(result);
        }

        [HttpPost, Route("visit")]
        public async Task<ActionResult<Guest>> Create([Required, FromBody] Guest guest)
        {
            try
            {
                var result = await (new RegisterGuestManager(this._service, new RegisterGuestInput
                {
                    guest = guest
                })).DoAction();

                if (result == null)
                {
                    return BadRequest();
                }

                return new OkObjectResult(result);
            } 
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
