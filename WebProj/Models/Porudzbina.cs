using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebProj.Models
{
    [Table("Porudzbina")]
    public class Porudzbina
    {
        [Key]
        [Column("IDPorudzbine")]
        public int IDPorudzbine {get; set;}

        [Column("Pice")]
        [MaxLength(255)]
        public string Pice{get; set;}

        [Column("Deserti")]
        [MaxLength(255)]
        public string Deserti{get; set;}

        [JsonIgnore]
        public KoktelBar KoktelBar {get; set;}


        

    }
}