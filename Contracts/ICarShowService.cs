using Domains.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICarShowService
    {
        Task<IList<Make>> GetCarShows();
    }
}
