using System.ComponentModel.DataAnnotations;
namespace CateringLarissa2.Models
{
    public class Pesan { 

            public int id { get; set; }
            public string menuname { get; set; }

            [Required]
            public string alamat { get; set; }

            [Required]
            [Phone]
            public string nomorhp { get; set; }
            public int price { get; set; }

            public string username { get; set; }
            public int status { get; set; }
            public DateTime orderedat { get; set; }
            public DateTime arrivedat  { get; set; }
            public Pesan()
            {
                this.orderedat = DateTime.Now;
            }
        }
    }
