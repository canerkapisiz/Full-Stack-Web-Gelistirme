using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class ProductBook
    {
        [Display(Name = "Ürün Id")]
        public int BookId { get; set; }

        [Display(Name = "Kitap Adı")]
        [Required(ErrorMessage = "Kitap Adı Zorunlu")]
        public string? BookName { get; set; }

        [Display(Name = "Kitap Açıklaması")]
        [Required(ErrorMessage = "Kitap Açıklaması Zorunlu")]
        [StringLength(256, ErrorMessage = "Kitap Açıklaması 256 harfi geçmesin")]
        public string? Description { get; set; }

        [Display(Name = "Sayfa Sayısı")]
        [Range(0, 1250)]
        [Required(ErrorMessage = "Sayfa Sayısı Zorunlu")]
        public int PageCount { get; set; }

        [Display(Name = "Ürün Görseli")]
        public string Image { get; set; } = string.Empty;

        [Display(Name = "Aktiflik")]
        public bool IsActive { get; set; }

        [Display(Name = "Kategori")]
        [Required]
        public int? CategoryId { get; set; }
    }
}