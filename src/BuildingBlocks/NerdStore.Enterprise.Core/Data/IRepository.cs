using NerdStore.Enterprise.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Enterprise.Core.DomainObjects
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
