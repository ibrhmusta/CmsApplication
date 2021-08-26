using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CmsContext>, IUserDal
    {
        public UserDetailDto GetUserDetails(Expression<Func<User, bool>> filter = null)
        {
            using (CmsContext context = new CmsContext())
            {
                var result = from user in filter == null ? context.Users : context.Users.Where(filter)
                             join company in context.Companies
                                on user.CompanyId equals company.Id
                             select new UserDetailDto
                             {
                                 UserId = user.Id,
                                 CompanyId = company.Id,
                                 CompanyName = company.Name,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 UserName = user.UserName,
                                 Email = user.Email,
                                 PhoneNumber = user.PhoneNumber
                             };
                return result.FirstOrDefault();
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (CmsContext context = new CmsContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = userOperationClaim.OperationClaimId,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }

        }
    }
}
