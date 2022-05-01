using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P2_2019AM604_2018PR603.Models
{
    public partial class Genero
    {
        [Key]
        public int IdGen { get; set; }
        [Display(Name = "Genero")]
        public string? NombreGen { get; set; }

    }
}
