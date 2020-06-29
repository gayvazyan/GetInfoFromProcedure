using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInfoFromProcedure.Model
{
    public class PartieOrPartyPersonsByCanditateId
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstNameEn { get; set; }
        public string MiddleNameEn { get; set; }
        public string LastNameEn { get; set; }
        public int? ElectedType { get; set; }
        public int? Zone { get; set; }
    }
}
