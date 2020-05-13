using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities.Base.Interfaces
{
    /// <summary>Именованная сущность</summary>
    public interface INamedEntity : IBaseEntity
    {
        /// <summary>Название</summary>
        string Name { get; set; }
    }
}
