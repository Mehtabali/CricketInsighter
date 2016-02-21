using CricketInsighter.Core.Data;
using System;

namespace CricketInsighter.Core.Services
{
    public interface IService : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
