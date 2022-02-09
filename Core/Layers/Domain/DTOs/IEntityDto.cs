using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layers.Domain.DTOs
{
    public interface IEntityDto<out TKey>
    where TKey : IEquatable<TKey>
    {
        public TKey Id { get; }
    }
}
