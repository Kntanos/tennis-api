using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface NationalityRepository
    {
        Task<IEnumerable<Entities.Nationality>> Get();
        Task<Entities.Nationality> Get(int id);
        Task<Entities.Nationality> Create(Entities.Nationality nationality);
        Task Update(Entities.Nationality player);
        Task Delete(int id);
    }
}
