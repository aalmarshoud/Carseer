using Carseer.Services.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Carseer.Services.Service
{
    public class CarModelService : ICarModelService
    {
        public async Task<CarModelDto> GetCarModelAsync(int makeId, int modelYear)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{modelYear}?format=json";
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                    Content = new StringContent("application/json", Encoding.UTF8, MediaTypeNames.Application.Json), // or "application/json" in older versions
                };

                var response = await client.SendAsync(request)
                    .ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);

                var mappedResult = JsonConvert.DeserializeObject<ResponseDto>(responseBody);

                return new CarModelDto
                {
                    Models = mappedResult.Results.Select(s => s.Model_Name).ToList()
                };
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
