using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using WhoScored.Data.Contracts;

namespace WhoScored.Data
{
    public class WhoScoredUnitOfWork : IUnitOfWork
    {
        private readonly IWhoScoredContext context;

        public WhoScoredUnitOfWork(IWhoScoredContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
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
