using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Common.UOW
{
    public interface IUnitOfWork:IDisposable
    {
        int SaveChanges();
    }
}
