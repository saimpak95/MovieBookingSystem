﻿using Microsoft.AspNetCore.Mvc;
using MovieBooking_API.Errors;
using MovieBooking_DomainModels;

namespace MovieBooking_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly DataContext db;

        public BuggyController(DataContext db)
        {
            this.db = db;
        }

        [HttpGet("NotFound")]
        public ActionResult GetNotFoundRequest()
        {
            var things = db.Movies.Find(988);
            if (things == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("ServerError")]
        public ActionResult GetServerError()
        {
            var things = db.Movies.Find(98);
            var thingsToReturn = things.ToString();
            return Ok();
        }

        [HttpGet("BadRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("BadRequest/{Id}")]
        public ActionResult GetNotFoundRequest(int Id)
        {
            return Ok();
        }
    }
}