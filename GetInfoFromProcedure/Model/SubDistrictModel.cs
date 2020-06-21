﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInfoFromProcedure.Model
{
    public class SubDistrictModel
    {

        public int SubDistrictId { get; set; }
        public string SubDistrictCode { get; set; }
        public int ElectionId { get; set; }
        public int? DistrictId { get; set; }
        public string Name { get; set; }
        public string RegionCode { get; set; }
        public string CommunityCode { get; set; }
        public string Comment { get; set; }
        public double? PoisitionX { get; set; }
        public double? PoisitionY { get; set; }
        public string Settlement { get; set; }
        public int? Zone { get; set; }
    }
}
