using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.Domain.Models
{
    public class Category : Entity
    {
        [Key]
        [Display(Name = "Código")]
        public Guid Id { get; set; } = new Guid();

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome da categoria é obrigatória.")]
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
