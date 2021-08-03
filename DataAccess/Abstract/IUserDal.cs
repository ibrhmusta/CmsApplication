using Core.DataAccess;
using DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        UserDetailDto GetUserDetails(Expression<Func<User, bool>> filter = null);
        List<OperationClaim> GetClaims(User user);
    }
}
