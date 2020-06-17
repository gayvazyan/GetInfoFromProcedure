using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetInfoFromProcedure.Model
{
    [Table("ee")]
    public partial class Ee
    {
        [StringLength(3)]
        public string CommunityCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SrartDate { get; set; }
        public bool? IsExtra { get; set; }
    }
}
