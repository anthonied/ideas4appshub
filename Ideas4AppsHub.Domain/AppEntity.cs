using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ideas4AppsHub.Domain
{
    public class AppEntity
    {   
        public int Id { get; set; }
        public string TelephoneNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }
        public Status Status { get; set; }
    }
}
