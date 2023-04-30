using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorsDal : IColorsDal
    {
        List<Colors> _colors;

        public InMemoryColorsDal()
        {
            _colors = new List<Colors> {
            new Colors{ColorId=1,ColorName="Black" },
            new Colors{ColorId=2,ColorName="White"},
            new Colors{ColorId=3,ColorName="Blue"}
            };
        }

        public List<Colors> GetById(int colorsId)
        {
            return _colors.Where(p=>p.ColorId==colorsId).ToList();
        }
    }
}
