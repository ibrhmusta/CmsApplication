using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        public IResult Add(User user)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(User user)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
