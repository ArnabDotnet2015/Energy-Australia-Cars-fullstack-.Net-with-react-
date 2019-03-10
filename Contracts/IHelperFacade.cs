using Domains.Enums;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Contracts
{
    public interface IHelperFacade<T> where T: class
    {
        Task<IList<T>> GetAllResponseAsync(EntityTypes entityType);
    }
}
