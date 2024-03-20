using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Interface
{
    public interface IHandler<T> 
    {
        T GetByRegNr();
        T[] GetByPropety();
    }
}
