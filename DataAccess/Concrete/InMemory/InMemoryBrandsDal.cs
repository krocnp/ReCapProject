using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandsDal : IBrandsDal
    {
        List<Brands> _brands;

        public InMemoryBrandsDal()
        {
            _brands = new List<Brands> {
                new Brands { BrandId=1,BrandName="Range Rover"},
                new Brands { BrandId=2,BrandName="Mercedes"},
                new Brands { BrandId=3,BrandName="BWM"}
                };
        }
            
        public List<Brands> GetById(int brandId)
        {
            
            return _brands.Where(p => p.BrandId == brandId).ToList();
        }

    }
}
