using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dept_Test.Models
{
    public class Measurement
    {

        // Object for the measurement info so this can be retrived from API.
        public string parameter { get; set; }
        public float value { get; set; }
        public DateTime lastUpdated { get; set; }
        public string unit { get; set; }

    }
}
