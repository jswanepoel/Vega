﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        [Required]
        public ContactResource Contact { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<int> Features { get; set; }

        public VehicleResource()
        {
            Features = new Collection<int>();
        }
    }
}