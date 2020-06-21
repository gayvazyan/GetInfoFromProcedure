using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInfoFromProcedure.Model
{
    public class Community
    {
        public string CommunityCode { get; set; }
        public string RegionCode { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public double? PositionX { get; set; }
        public double? PositionY { get; set; }
        public string Pr { get; set; }
        public string Consolidated { get; set; }
        public int? Zone { get; set; }
    }
}
