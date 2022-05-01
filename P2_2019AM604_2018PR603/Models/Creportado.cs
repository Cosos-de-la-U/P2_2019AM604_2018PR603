using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P2_2019AM604_2018PR603.Models
{
    public partial class Creportado
    {
        [Key]
        public int IdCreportado { get; set; }
        public int? IdDpt { get; set; }
        public int? IdGen { get; set; }
        public int? Confirmado { get; set; }
        public int? Recuperado { get; set; }
        public int? Fallecido { get; set; }

    }
}
