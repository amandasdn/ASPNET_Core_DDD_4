using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain
{
    public abstract class Entity
    {
        [Display(Name = "Data de Cadastro")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy HH:mm")]
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

        [Display(Name = "Ativo")]
        public bool Active { get; set; } = true;

        [Display(Name = "Removido")]
        public bool Removed { get; set; } = false;
    }
}
