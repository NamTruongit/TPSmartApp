using Schedule.DataManager.SqlServer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.DataManager.SqlServer.IRepositories
{
    public interface ICommodityRepository
    {
        Task<Commodity> CreateCommodity(Commodity commodity);
        Task<Commodity> GetCommodityByID(int id);
        Task<Commodity> GetCommodityByField(int stament, string value);
        Task<IEnumerable<Commodity>> GetAllCommodity();
        Task UpdateCommodity(int id, Commodity commodity);
        Task DeleteCommodity(int id);
    }
}
