using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace student_testing.Models.Admin
{

    public class AdminPageModel
    {
        [Required]
        public Dictionary<string, string> Users { get; set; }

    }
}
