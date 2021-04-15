﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DAL.Domain
{
    public class Role : IdentityRole
    {
        public Role(string name) : base(name)
        { }
    }
}
