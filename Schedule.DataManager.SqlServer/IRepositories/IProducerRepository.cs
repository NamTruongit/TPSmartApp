using Schedule.DataManager.SqlServer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.DataManager.SqlServer.IRepositories
{
    public interface IProducerRepository
    {
        Task<Producer> CreateProducer(Producer producer);
        Task<Producer> GetProducerByID(int id);
        Task<Producer> GetProducerByField(int stament, string value);
        Task<IEnumerable<Producer>> GetAllProducer();
        Task UpdateProducer(int id, Producer producer);
        Task DeleteProducer(int id);
    }
}
