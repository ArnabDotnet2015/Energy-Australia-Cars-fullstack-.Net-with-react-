using System;
using Contracts;
using Domains.Enums;
using Newtonsoft.Json;
using System.Net.Http;
using Domains.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Domains;

namespace Facade
{
    public class CarShowFacade: IHelperFacade<CarShow>
    {
        private static string _endpointBaseUrl { get; set; }
        public CarShowFacade(IOptions<EnvironmentConfig> env)
        {
            _endpointBaseUrl = env.Value.endpointBaseUrl;
        }
        public async Task<IList<CarShow>> GetAllResponseAsync(EntityTypes entityType)
        {
            switch (entityType)
            {
                case EntityTypes.cars:
                    return await GetShows(EntityTypes.cars.ToString());
                default:
                    return null;
            }
        }

        private static async Task<IList<CarShow>> GetShows(string entity)
        {
            using (HttpClient client = new HttpClient())
            {
                string json;
                var url = new Uri(_endpointBaseUrl + entity);
                var response = await client.GetAsync(url);
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                return JsonConvert.DeserializeObject<IList<CarShow>>(json);
            }
        }
    }
}
