using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandsDal : IBrandsDal
    {
        List<Brand> _brands;

        public InMemoryBrandsDal()
        {
            _brands = new List<Brand> {
                new Brand { BrandId=1,BrandName="Range Rover"},
                new Brand { BrandId=2,BrandName="Mercedes"},
                new Brand { BrandId=3,BrandName="BWM"}
            };
        }

        public void Add(Brand entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brand entity)
        {
            throw new NotImplementedException();
        }

        public List<Brand> Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}
