using System.ComponentModel.DataAnnotations;

namespace partsearch.Domain.Entities
{
    public class TextField:EntityBase
    {
        [Required] 
        public string? CodeWord { get; set; }

        [Display(Name = "Название страницы")]
        public override string? Title { get; set; } = "Ингформационная страница";

        [Display(Name = "Содержание страницы")]
        public override string? Text { get; set; } = "Содержание заполняется администратором";
    }
}
