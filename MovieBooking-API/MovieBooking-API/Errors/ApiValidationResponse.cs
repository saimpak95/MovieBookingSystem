﻿using System.Collections.Generic;

namespace MovieBooking_API.Errors
{
    public class ApiValidationResponse : ApiResponse
    {
        public ApiValidationResponse() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}