using System;

namespace ApiCore.Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}
