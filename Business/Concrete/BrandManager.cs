using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult AddBrand(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult("Marka Eklendi");
        }

        public IDataResult<List<Brand>> GetAllBrand()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),"Tüm markalar listelendi");
        }

        public IDataResult<Brand> GetBrandById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId==brandId));
        }
    }
}
