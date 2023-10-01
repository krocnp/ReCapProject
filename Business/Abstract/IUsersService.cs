using Core.DataAccess;
using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUsersService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetById(int id);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

    }
}
