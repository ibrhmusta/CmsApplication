using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITransactionService
    {
        IDataResult<List<Transaction>> GetAll();
        IDataResult<List<TransactionDetailDto>> GetAllTransactionDetails();
        IResult Add(Transaction transaction);
        IResult Delete(Transaction transaction);
        IResult Update(Transaction transaction);
    }

}
