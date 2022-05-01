using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P2_2019AM604_2018PR603.Models
{
    public partial class Departamento
    {
        [Key]
        public int IdDpt { get; set; }
        [Display(Name = "Departamento")]
        public string? NombreDpt { get; set; }

    }
}
