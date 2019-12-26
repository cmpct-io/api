using Compact.Api.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Compact.Api.Controllers
{
    public class UsersController : ControllerBase
    {
        [HttpGet("/api/users")]
        [ProducesResponseType(typeof(IEnumerable<UserResponse>), 200)]
        public ActionResult<IEnumerable<string>> Get()
        {
            var response = new List<UserResponse> {
                new UserResponse
                {
                    Id = "1",
                    Email = "spam@tommcclean.me",
                    GivenName = "Thomas",
                    FamilyName = "McClean",
                    Roles = new string[] { "admin" }
                }
            };

            return Ok(response);
        }
    }
}