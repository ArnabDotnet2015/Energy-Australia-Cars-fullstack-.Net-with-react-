using System.Collections.Generic;

namespace Domains.ViewModels
{
    public class CarShow
    {
        public string Name { get; set; }
        public IList<Car> Cars { get; set; }
    }
}
