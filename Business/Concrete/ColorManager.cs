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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult AddColor(ColorForAddDto color)
        {
            Color addToColor = new Color() { 
            ColorName=color.ColorName
            };
            _colorDal.Add(addToColor);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IDataResult<List<Color>> GetAllColor()
        {
            var result = _colorDal.GetAll();
            return new SuccessDataResult<List<Color>>(result);
        }

        public IDataResult<Color> GetColorById(int colorId)
        {
            var result = _colorDal.Get(c => c.ColorId == colorId);
            return new SuccessDataResult<Color>(result); ;
        }
    }
}
