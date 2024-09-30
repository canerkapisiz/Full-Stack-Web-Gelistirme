using System.ComponentModel.DataAnnotations;

namespace EfCoreApp.DataEntity
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }
        public string? OgrenciAd { get; set; }
        public string? OgrenciSoyad { get; set; }

        public string AdSoyad
        {
            get
            {
                return this.OgrenciAd + " " + this.OgrenciSoyad;
            }
        }
        public string? Image { get; set; }
        public string? Telefon { get; set; }
        public string? Eposta { get; set; }

        public ICollection<BootcampKayit> BootcampKayits { get; set; } = new List<BootcampKayit>();
    }
}