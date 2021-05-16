using System;
using System.Collections.Generic;
using System.Text;

namespace DisciplinesAPI.Models.Interfaces
{
    public interface IEntityDto<TId>
    {
        public TId Id { get; set; }
        string Name { get; set; }
    }
}
