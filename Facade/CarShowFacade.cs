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

        /// <summary>Initializes a new instance of the <see cref="CarShowFacade"/> class.</summary>
        /// <param name="env">The env.</param>
        public CarShowFacade(IOptions<EnvironmentConfig> env)
        {
            _endpointBaseUrl = env.Value.EndpointBaseUrl;
        }
        /// <summary>Gets all response asynchronously based on entity type.</summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <returns></returns>
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

        /// <summary>Gets the shows.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
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
