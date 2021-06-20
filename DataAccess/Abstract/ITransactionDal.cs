using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ITransactionDal : IEntityRepository<Transaction>
    {
        List<TransactionDetailDto> GetAllTransactionsDetails(Expression<Func<Transaction, bool>> filter = null);
    }

}
