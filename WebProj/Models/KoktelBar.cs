using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace WebProj.Models
{
    [Table("KoktelBar")]
    public class KoktelBar
    {
        
        [Key]
        [Column("ID")]
        public int ID {get; set;}

        
        [Column("Naziv")]
        [MaxLength(255)] 
          public string Naziv {get; set;}

        [Column("Adresa")]
        public string Adresa {get; set;}

        [Column("Kapacitet")] 
        public int Kapacitet {get; set;}

        [Column("MaxLjudi")]
        public int MaxLjudi {get; set;}


        [Column("MaxLokala")]
        public int MaxLokala {get; set;} 



        public virtual List<Sto> Stolovi{get;set;}
        public virtual List<Porudzbina> Porudzbine{get;set;}

        


    }
}