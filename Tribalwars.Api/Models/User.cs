using System.Collections.Generic;

namespace Tribalwars.Api.Models
{
    public class User
    {
        public string UserName { get; set; }

        public string World { get; set; }

        public Cookie Cookie { get; set; }

        public List<Village> Villages { get; set; }
    }
}
