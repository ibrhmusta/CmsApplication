using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TransactionProductManager : ITransactionProductService
    {
        public IResult Add(TransactionProduct transactionProduct)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(TransactionProduct transactionProduct)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<TransactionProduct>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(TransactionProduct transactionProduct)
        {
            throw new System.NotImplementedException();
        }
    }
}
