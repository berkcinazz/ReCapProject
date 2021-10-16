using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult AddBrand(BrandForAddDto brand)
        {
            Brand addToBrand = new Brand()
            {
                BrandName = brand.BrandName
            };
            _brandDal.Add(addToBrand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IDataResult<List<Brand>> GetAllBrand()
        {
            var result = _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(result);
        }

        public IDataResult<Brand> GetBrandById(int brandId)
        {
            var result = _brandDal.Get(b => b.BrandId == brandId);
            return new SuccessDataResult<Brand>(result);
        }
    }
}
