using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class WeightControl
    {   
        [Key]
        [Column("IdWeight")]
        public int IdWeight { get; set; }

        public int  IdCustomers { get; set; }

        [Range(1, 1000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Weight { get; set; }
        public decimal? Imc { get; set; }

        [Display(Name = "Date Weight")]
        [DataType(DataType.Date)]
        public DateTime DateWeight { get; set; }

        public virtual CorpCustomers IdCustomersNavigation { get; set; }
    }
}
