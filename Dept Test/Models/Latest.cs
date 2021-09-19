using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dept_Test.Models
{
    // Model for latest object from API to get info rom it.
    public class Latest
    {
        public string location { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public List<Measurement> measurements { get; set; }

    }
}
