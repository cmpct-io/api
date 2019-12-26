using System.Collections.Generic;

namespace Compact.Api.Models.ResponseModels
{
    public class UserResponse
    {
        public string Id { get; set; }

        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}