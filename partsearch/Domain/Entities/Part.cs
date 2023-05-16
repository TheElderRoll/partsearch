using System.ComponentModel.DataAnnotations;

namespace partsearch.Domain.Entities
{
    public class Part : EntityBase
    {
        [Required(ErrorMessage = "Заполните название")]
        [Display(Name = "Название запчасти")]
        public override string? Title { get; set; }

        [Display(Name = "Краткое описание запчасти")]
        public override string? Subtitle { get; set; }

        [Display(Name = "Описание запчасти")]
        public override string? Text { get; set; }

        [Display(Name = "Цена")]
        public string? Cost { get; set; }

        [Display(Name = "Код запчасти")]
        public string? Code { get; set; }

    }
}
