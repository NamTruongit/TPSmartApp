using Schedule.DataManager.SqlServer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.DataManager.SqlServer.IRepositories
{
    public interface IConsignmentRepository
    {
        Task<Conѕignment> CreateConsignment(Conѕignment conѕignment);
        Task<Conѕignment> GetConsignmentByID(int id);
        Task<Conѕignment> GetConsignmentByField(int stament, string value);
        Task<IEnumerable<Conѕignment>> GetAllConsignment();
        Task UpdateConsignment(int id, Conѕignment conѕignment);
        Task DeleteConsignment(int id);
    }
}
