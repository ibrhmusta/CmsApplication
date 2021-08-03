using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService; //normalde manager larda kendi dal interface i enjekte edilir, farklı bir dal dan destek almak için service hizmeti(IXService) tanımlanmalıdır.
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                CompanyId = userForRegisterDto.CompanyId,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                UserName = userForRegisterDto.UserName,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = System.DateTime.Now,
                ModifiedDate = System.DateTime.Now,
                IsActive = true,
                IsDeleted = false,
            };

            _userService.Add(user);
            return new SuccessDataResult<User>(user, AspectMessages.USER_ADDED);
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken);
        }


        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByUserName(userForLoginDto.UserName);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(AspectMessages.USER_NOT_FOUND);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(AspectMessages.PASSWORD_ERROR);
            }

            return new SuccessDataResult<User>(userToCheck.Data, AspectMessages.SUCCESS_LOGIN);
        }      

        public IResult UserExists(string userName)
        {
            var result = _userService.GetByUserName(userName);
            if (result.Data == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(AspectMessages.USER_ALREADY_EXIST);
        }
    }
}
