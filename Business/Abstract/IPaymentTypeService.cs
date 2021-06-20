using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPaymentTypeService
    {
        IDataResult<List<PaymentType>> GetAll();
        IResult Add(PaymentType paymentType);
        IResult Delete(PaymentType paymentType);
        IResult Update(PaymentType paymentType);
    }

}
