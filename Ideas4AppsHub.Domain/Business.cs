using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ideas4AppsHub.Domain
{
    public class Business:AppEntity
    {        
        public string BusinessHours { get; set; }        
        public string Tags { get; set; }
        public string WebUrl { get; set; }
        public Address Address { get; set; }
        public Photo Photo { get; set; }
        public GPS GPS { get; set; }
        public Category Category { get; set; }        
        public bool Active { get; set; }
    }
}
