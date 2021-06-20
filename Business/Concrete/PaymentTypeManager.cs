using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PaymentTypeManager : IPaymentTypeService
    {
        public IResult Add(PaymentType paymentType)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(PaymentType paymentType)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<PaymentType>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(PaymentType paymentType)
        {
            throw new System.NotImplementedException();
        }
    }
}
