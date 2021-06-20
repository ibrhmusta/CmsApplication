using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITransactionProductService
    {
        IDataResult<List<TransactionProduct>> GetAll();
        IResult Add(TransactionProduct transactionProduct);
        IResult Delete(TransactionProduct transactionProduct);
        IResult Update(TransactionProduct transactionProduct);
    }

}
