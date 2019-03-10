using System.Collections.Generic;

namespace Domains.ViewModels
{
    public class Make
    {
        public Make()
        {
            Models = new List<Model>();
        }
        public string Name { get; set; }
        public IList<Model> Models { get; set; }
    }
}
