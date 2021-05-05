using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace student_testing.Models.Settings
{
    public class SettingsModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string oldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string newPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
    }
}
