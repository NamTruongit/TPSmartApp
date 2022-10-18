using Schedule.DataManager.SqlServer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.DataManager.SqlServer.IRepositories
{
    public interface IConsignmentDetailRepository
    {
        Task<ConѕignmentDetails> CreateConѕignmentDetail(ConѕignmentDetails conѕignmentDetail);
        Task<ConѕignmentDetails> GetConѕignmentDetailByID(int id);
        Task<ConѕignmentDetails> GetConѕignmentDetailByField(int stament, string value);
        Task<IEnumerable<ConѕignmentDetails>> GetAllConѕignmentDetail();
        Task UpdateConѕignmentDetail(int id, ConѕignmentDetails conѕignmentDetail);
        Task DeleteConѕignmentDetail(int id);
    }
}
