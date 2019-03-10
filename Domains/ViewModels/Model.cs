using System.Collections.Generic;

namespace Domains.ViewModels
{
    public class Model
    {
        public Model()
        {
            Shows = new List<Show>();
        }
        public string Name { get; set; }
        public IList<Show> Shows { get; set; }
    }
}
