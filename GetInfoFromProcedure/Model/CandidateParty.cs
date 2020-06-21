using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInfoFromProcedure.Model
{
    public partial class CandidateParty
    {
        public int CandidateId { get; set; }
        public int? State { get; set; }
        public DateTime? ActivityDate { get; set; }
        public bool? IsElected { get; set; }
        public int ElectionId { get; set; }
        public int DistrictId { get; set; }
        public int CommissionId { get; set; }
        public string OrderNum { get; set; }
        public int PartieOrPartyId { get; set; }
        public string FullName { get; set; }
        public string Prefix { get; set; }
        public string Platform { get; set; }
        public string FullNameEn { get; set; }
        public string PrefixEn { get; set; }
        public string PlatformEn { get; set; }
        public int CandidateSum { get; set; }
        public int Mandat { get; set; }
        public decimal Persent { get; set; }
        public int Zone1 { get; set; }
        public int Zone2 { get; set; }
        public int Zone3 { get; set; }
        public int Zone4 { get; set; }
        public int Zone5 { get; set; }
        public int Zone6 { get; set; }
        public int Zone7 { get; set; }
        public int Zone8 { get; set; }
        public int Zone9 { get; set; }
        public int Zone10 { get; set; }
        public int Zone11 { get; set; }
        public int Zone12 { get; set; }
        public int Zone13 { get; set; }
        public int SumZone { get; set; }
    }
}
