using Ask2Friends.BLL.Constants;
using Ask2Friends.BLL.Interfaces;
using Ask2Friends.BLL.ValidationRules.FluentValidation;
using MG.Core.Aspects.Autofac.Validation;
using MG.Core.Dtos.Concrete;
using MG.Core.Entites.Concrete;
using MG.Core.Utilities.Business;
using MG.Core.Utilities.Results.Concrete;
using MG.Core.Utilities.Results.Interfaces;
using MG.Core.Utilities.Security.Common;
using MG.Core.Utilities.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask2Friends.BLL.Managers
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        [ValidationAspect(typeof(UserValidator), Priority = 1)]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            IResult result = BusinessRules.Run(UserExists(userForRegisterDto.Email));

            if (result != null)
            {
                return new ErrorDataResult<User>(result.Message);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Id = new Guid(),
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Username = userForRegisterDto.Username,
                BirthDate = userForRegisterDto.BirthDate,
                Gender = userForRegisterDto.Gender,
                isActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _userService.AddAsync(user);

            return new SuccessDataResult<User>(user);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);

            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IResult UserExists(string email)
        {
            IDataResult<User> user = _userService.GetByMail(email);
            if (user.Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
