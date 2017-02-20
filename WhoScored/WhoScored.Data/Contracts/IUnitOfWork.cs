using System;

namespace WhoScored.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
