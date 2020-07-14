using Ask2Friends.BLL.BusinessAspects.Autofac;
using Ask2Friends.BLL.Constants;
using Ask2Friends.BLL.Interfaces;
using Ask2Friends.DAL.Interfaces;
using AutoMapper;
using MG.Core.Aspects.Autofac.Caching;
using MG.Core.Aspects.Autofac.Logging;
using MG.Core.Aspects.Autofac.Performance;
using MG.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using MG.Core.Dtos.Concrete;
using MG.Core.Entites.Concrete;
using MG.Core.Utilities.Results.Concrete;
using MG.Core.Utilities.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ask2Friends.BLL.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;

        public UserManager(IUserDAL userDAL, IMapper mapper)
        {
            _userDAL = userDAL;
            _mapper = mapper;
        }

        public IDataResult<List<UserOperationClaimDto>> GetClaims(User user)
        {
            List<UserOperationClaimDto> claims = _userDAL.GetClaims(user);

            return new SuccessDataResult<List<UserOperationClaimDto>>(claims);
        }

        [CacheRemoveAspect("IUserService.Get")]
        public IResult AddAsync(User user)
        {
            _userDAL.Add(user);

            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<User> GetByMail(string email)
        {
            User user = _userDAL.Get(u => u.Email == email);

            return new SuccessDataResult<User>(user);
        }

        [LogAspect(typeof(DatabaseLogger))]
        //[SecuredOperation("User.List,Admin")]
        [CacheAspect(duration: 1)]
        [PerformanceAspect(interval: 5)]
        public IDataResult<List<UserDto>> GetAllUsers()
        {
            //Thread.Sleep(5000);

            //int a = Convert.ToInt32("asds");

            IList<User> userList = _userDAL.GetList();

            List<UserDto> userDtoList = _mapper.Map<List<UserDto>>(userList);

            return new SuccessDataResult<List<UserDto>>(userDtoList);
        }
    }
}
