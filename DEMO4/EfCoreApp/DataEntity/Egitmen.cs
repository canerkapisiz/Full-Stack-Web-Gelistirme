using System.ComponentModel.DataAnnotations;

namespace EfCoreApp.DataEntity
{
    public class Egitmen
    {
        [Key]
        public int EgitmenId { get; set; }
        public string? EgitmenAd { get; set; }
        public string? EgitmenSoyad { get; set; }
        public string AdSoyad
        {
            get
            {
                return this.EgitmenAd + " " + this.EgitmenSoyad;
            }
        }
        public string? Image { get; set; }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime BaslamaTarihi { get; set; }
        public ICollection<Bootcamp> Bootcamps { get; set; } = new List<Bootcamp>();
    }
}