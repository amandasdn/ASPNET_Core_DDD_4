using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Models
{
    class Product : Entity
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

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

        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}
