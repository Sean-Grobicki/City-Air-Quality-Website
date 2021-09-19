using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dept_Test.Models
{
    public class Meta
    {
        // Meta data used in case pagination would have been needed.
        public int page { get; set;}

        public int limit { get; set;}

        public int found { get; set; }

    }
}
