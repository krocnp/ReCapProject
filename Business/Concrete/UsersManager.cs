using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UsersManager : IUsersService
    {
        IUsersDal _usersDal;

        public UsersManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
                _usersDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _usersDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_usersDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<List<User>> GetById(int id)
        {
            return new SuccessDataResult<List<User>>(_usersDal.GetAll(u => u.Id == id).ToList());
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {

            _usersDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);

        }
    }
}
