using System.Collections.Generic;

namespace Compact.Api.Models.DomainModels
{
    public class User
    {
        public string Id { get; set; }

        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public string EmailAddress { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}