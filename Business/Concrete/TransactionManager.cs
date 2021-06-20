using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class TransactionManager : ITransactionService
    {
        private readonly ITransactionDal _transactionDal;

        public TransactionManager(ITransactionDal transactionDal)
        {
            _transactionDal = transactionDal;
            //ToDo : nullCheck eklenecek...
        }
        public IResult Add(Transaction transaction)
        {
            //businessRules eklenecek
            transaction.CreatedDate = System.DateTime.Now;
            transaction.IsActive = true;
            transaction.IsDeleted = false;
            _transactionDal.Add(transaction);
            return new SuccessResult(SuccessMessages.TRANSACTION_ADDED);

            //constants yazılacak...
        }

        public IResult Delete(Transaction transaction)
        {
            _transactionDal.Delete(transaction);
            transaction.IsActive = false;
            transaction.IsDeleted = true;
            return new SuccessResult(SuccessMessages.TRANSACTION_DELETED);
        }

        public IDataResult<List<Transaction>> GetAll()
        {
            var result = _transactionDal.GetAll();
            return new SuccessDataResult<List<Transaction>>(result,SuccessMessages.TRANSACTIONS_LISTED);
        }

        public IDataResult<List<TransactionDetailDto>> GetAllTransactionDetails()
        {
            var result = _transactionDal.GetAllTransactionsDetails();
            return new SuccessDataResult<List<TransactionDetailDto>>(result,SuccessMessages.TRANSACTION_DETAILS_LISTED);
        }

        public IResult Update(Transaction transaction)
        {
            _transactionDal.Update(transaction);
            return new SuccessResult(SuccessMessages.TRANSACTION_UPDATED);
        }
    }
}
