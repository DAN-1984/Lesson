using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations;
namespace WebStore.Domain.Entities.Base
{
    /// <summary>Именованная сущность</summary>
    public abstract class NamedEntity : BaseEntity, INamedEntity
    {
        [Required(ErrorMessage = "Обязательный к заполнению")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
