using Bytes2you.Validation;
using System;
using WhoScored.Data.Contracts;

namespace WhoScored.Data
{
    public class WhoScoredData : IDisposable, IWhoScoredData
    {
        private IWhoScoredContext context;

        public WhoScoredData(IWhoScoredContext context)
        {
            Guard.WhenArgument(context, "context").IsNull();

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
