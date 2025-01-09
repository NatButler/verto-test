using System.ComponentModel.DataAnnotations;

namespace IOTA.Areas.Admin.Models
{
    public class HomePage
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string SliderOverlayHeading { get; set; }
        [Required]
        [StringLength(50)]
        public string TopBannerHeading { get; set; }
        [Required]
        [StringLength(100)]
        public string TopBannerText { get; set; }
        [Required]
        [StringLength(50)]
        public string CaseStudy1Heading { get; set; }
        [StringLength(200)]
        public string? CaseStudy1Summary { get; set; }
        [Required]
        [StringLength(50)]
        public string CaseStudy2Heading { get; set; }
        [StringLength(200)]
        public string? CaseStudy2Summary { get; set; }
        [Required]
        [StringLength(50)]
        public string CaseStudy3Heading { get; set; }
        [StringLength(200)]
        public string? CaseStudy3Summary { get; set; }
        [Required]
        [StringLength(50)]
        public string ImageOverlayHeading { get; set; }
        [Required]
        [StringLength(100)]
        public string ImageOverlayText { get; set; }
    }
}
