﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetInfoFromProcedure.Model
{
    public partial class SeesionData
    {
        [Key]
        public Guid SessionId { get; set; }
        public string Data { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
