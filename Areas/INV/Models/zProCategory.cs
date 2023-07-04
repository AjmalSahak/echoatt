﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    [Table("zProCategory", Schema = "dbo")]
    public class zProCategory
    {
        [Key]
        public int PCID { get; set; }
        public string Category { get; set; }

    }
}