﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class DeleteableEntity: Entity
    {
        public bool IsActive { get; set; } = true;
    }
}
