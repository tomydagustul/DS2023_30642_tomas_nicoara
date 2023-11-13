using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevicesAPI.Models
{
    public class Devices
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string? description { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? adress { get; set; }

        [Column(TypeName = "float")]
        [Range(minimum: 0.0, maximum: 1000.0)]
        public float? kWh_energy_consumption { get; set; }

    }
}
