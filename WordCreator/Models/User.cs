using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordCreator.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Computer { get; set; }
        public string City { get; set; }
        public string ServiceTag { get; set; }

        public DateTime Time { get; set; }
    }
}
