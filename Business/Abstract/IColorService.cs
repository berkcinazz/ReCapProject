using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult AddColor(ColorForAddDto color);
        IDataResult<List<Color>> GetAllColor();
        IDataResult<Color> GetColorById(int colorId);
    }
}
