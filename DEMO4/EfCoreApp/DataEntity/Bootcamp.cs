using System.ComponentModel.DataAnnotations;

namespace EfCoreApp.DataEntity
{
    public class Bootcamp
    {
        [Key]
        public int BootcampId { get; set; }
        public string? BootcampName { get; set; }
        public string? Image { get; set; }
        public int EgitmenId { get; set; }
        public Egitmen Egitmen { get; set; } = null!;
        public ICollection<BootcampKayit> BootcampKayits { get; set; } = new List<BootcampKayit>();
    }
}