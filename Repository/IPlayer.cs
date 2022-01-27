using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPlayer
    {
        Task<IEnumerable<Entities.Player>> Get();
        Task<Entities.Player> Get(int id);
        Task<Entities.Player> Create(Entities.Player player);
        Task Update(Entities.Player player);
        Task Delete(int id);
    }
}
