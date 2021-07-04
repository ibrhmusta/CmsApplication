using Business.Abstract;
using Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System.Collections.Generic;
using DataAccess.Abstract;
using Business.Constants;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        readonly IUserDal _userDal;
        readonly IUserOperationClaimService _userOperationClaimService;

        public UserManager(IUserDal userDal, IUserOperationClaimService userOperationClaimService)
        {
            _userDal = userDal;
            _userOperationClaimService = userOperationClaimService;
        }
        public IResult Add(User user)
        {
            user.CreatedDate = System.DateTime.Now;
            user.ModifiedDate = System.DateTime.Now;
            user.IsActive = true;
            user.IsDeleted = false;            
            _userDal.Add(user);
            UserOperationClaim claim = new UserOperationClaim() { OperationClaimId = 4, UserId = user.Id };
            _userOperationClaimService.Add(claim);
            return new SuccessResult(AspectMessages.USER_ADDED);
        }

        public IResult Delete(User user)
        {
            user.CreatedDate = System.DateTime.Now;
            user.ModifiedDate = System.DateTime.Now;
            user.IsActive = false;
            user.IsDeleted = true;
            _userDal.Update(user);
            return new SuccessResult(SuccessMessages.USER_DELETED);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),SuccessMessages.USERS_LISTED);
        }

        public IDataResult<User> GetByUserName(string userName)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserName == userName));
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }
        

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(SuccessMessages.USER_UPDATED);
        }
    }
}
