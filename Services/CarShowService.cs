using Contracts;
using Domains.Enums;
using Domains.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Services
{
    public class CarShowService : ICarShowService
    {
        private IHelperFacade<CarShow> _helperFacade { get; set; }

        /// <summary>Initializes a new instance of the <see cref="CarShowService"/> class.</summary>
        /// <param name="helperFacade">The helper facade.</param>
        public CarShowService(IHelperFacade<CarShow> helperFacade)
        {
            _helperFacade = helperFacade;
        }

        /// <summary>Gets the car shows.</summary>
        /// <returns></returns>
        public async Task<IList<Make>> GetCarShows()
        {
            IList<CarShow> carShows = await _helperFacade.GetAllResponseAsync(EntityTypes.cars);
            IList<Make> makes = new List<Make>();
            if (carShows.Count > 0)
                ConvertResponse(carShows, makes);

            return makes;
        }

        /// <summary>Converts the response.</summary>
        /// <param name="carShows">The car shows.</param>
        /// <param name="makes">The makes.</param>
        private static void ConvertResponse(IList<CarShow> carShows, IList<Make> makes)
        {
            foreach (var carShow in carShows)
            {
                carShow.Name = string.IsNullOrEmpty(carShow.Name) ? string.Empty : carShow.Name;
                Make make = new Make();
                Show show = new Show { Name = carShow.Name };
                foreach (var car in carShow.Cars)
                {
                    car.Model = string.IsNullOrEmpty(car.Model) ? string.Empty : car.Model;
                    car.Make = string.IsNullOrEmpty(car.Make) ? string.Empty : car.Make;

                    make = makes.Any(m => m.Name == car.Make) ?
                                makes.First(m => m.Name == car.Make) :
                                new Make { Name = car.Make };
                    Model model = make.Models.Any(m => m.Name == car.Model) ?
                                    make.Models.First(m => m.Name == car.Model) :
                                    new Model { Name = car.Model };
                    model.Shows.Add(show);
                    if (!make.Models.Any(m => m.Name == car.Model))
                        make.Models.Add(model);
                    if (!makes.Any(m => m.Name == make.Name))
                        makes.Add(make);
                }
            }
        }
    }
}
