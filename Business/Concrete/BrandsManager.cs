using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandsManager : IBrandsService
    {
        IBrandsDal _brandsDal;

        public BrandsManager(IBrandsDal brandsDal)
        {
            _brandsDal = brandsDal;
        }

        public List<Brands> GetById(int brandId)
        {
           return _brandsDal.GetById(brandId);
        }

    }
}
