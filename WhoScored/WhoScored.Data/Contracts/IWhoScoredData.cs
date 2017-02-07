using System;

namespace WhoScored.Data.Contracts
{
    public interface IWhoScoredData : IDisposable
    {
        void Commit();
    }
}
