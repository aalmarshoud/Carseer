using Carseer.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carseer.Services.Service
{
    public class CarModel : ICarModelService
    {
        public Task<List<CarModelDto>> GetCarModelAsync(int makeId, int modelYear)
        {
            throw new NotImplementedException();
        }
    }
}
