using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Models
{
    public class Product : Entity
    {
        [Key]
        [Display(Name = "Código")]
        public Guid Id { get; set; } = new Guid();

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(1500)]
        public string Description { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        public float Price { get; set; } = 0.00f;

        [Display(Name = "Imagem")]
        public string Image { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
