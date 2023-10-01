using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentaCarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomer()
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 Id = c.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
