using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Domain
{
    public class Group : BaseEntity
    {
        [Required]
        public string CreatorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<Test> Tests { get; set; }
    }
}