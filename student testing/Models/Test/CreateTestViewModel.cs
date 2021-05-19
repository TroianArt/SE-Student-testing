using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_testing.Models.Test
{
    public class CreateTestViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateValid { get; set; }
        public TimeSpan Duration { get; set; }
        public long GroupId { get; set; }
    }
}
