using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        public IResult Add(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
