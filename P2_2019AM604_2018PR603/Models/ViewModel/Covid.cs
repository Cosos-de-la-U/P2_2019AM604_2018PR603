using System.ComponentModel.DataAnnotations;

namespace P2_2019AM604_2018PR603.Models.ViewModel
{
    public partial class Covid
    {
        [Key]
        public String? Departamento { get; set; }
        public String? Genero { get; set; }
        public int? Confirmados { get; set; }
        public int? Recuperados { get; set; }
        public int? Fallecidos { get; set; }
    }
}
