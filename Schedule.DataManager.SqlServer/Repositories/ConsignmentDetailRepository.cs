using Dapper;
using Schedule.DataManager.SqlServer.Context;
using Schedule.DataManager.SqlServer.Entites;
using Schedule.DataManager.SqlServer.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.DataManager.SqlServer.Repositories
{
    public class ConsignmentDetailRepository : IConsignmentDetailRepository
    {
        private readonly DapperContext _context;

        public ConsignmentDetailRepository(DapperContext context)
        {
            this._context = context;
        }

        public async Task<ConѕignmentDetails> CreateConѕignmentDetail(ConѕignmentDetails conѕignmentDetail)
        {
            var query = "EXEC ConsignmentDetail_Insert @CommodityId,@CustomerId,@ConѕignmentId,@JapanCode,@VNCode,@Note,@ExportDateFromHCM,@ExportDateFromHue,@UserID";
            var parameters = new DynamicParameters();
            parameters.Add("ProducerCode", conѕignmentDetail.CommodityId, DbType.Int32);
            parameters.Add("CustomerId", conѕignmentDetail.CustomerId, DbType.Int32);
            parameters.Add("ConѕignmentId", conѕignmentDetail.ConѕignmentId, DbType.Int32);
            parameters.Add("JapanCode", conѕignmentDetail.JPCode, DbType.String);
            parameters.Add("VNCode", conѕignmentDetail.VNCode, DbType.String);
            parameters.Add("Note", conѕignmentDetail.Note, DbType.String);
            parameters.Add("ExportDateFromHCM", conѕignmentDetail.ExportDateFromHCM, DbType.Date);
            parameters.Add("ExportDateFromHue", conѕignmentDetail.ExportDateFromHue, DbType.Date);
            parameters.Add("UserID", conѕignmentDetail.UserID, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdConѕignmentDetail = new ConѕignmentDetails
                {
                    CommodityId = conѕignmentDetail.CommodityId,
                    CustomerId = conѕignmentDetail.CustomerId,
                    ConѕignmentId = conѕignmentDetail.ConѕignmentId,
                    JPCode = conѕignmentDetail.JPCode ,
                    VNCode = conѕignmentDetail.VNCode,
                    Note = conѕignmentDetail.Note,
                    ExportDateFromHCM = conѕignmentDetail.ExportDateFromHCM ,
                    ExportDateFromHue = conѕignmentDetail.ExportDateFromHue,
                    UserID = conѕignmentDetail.UserID 
                };
                return createdConѕignmentDetail;
            }
        }

        public async Task DeleteConѕignmentDetail(int id)
        {
            var query = "EXEC ConѕignmentDetail_Delete @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<ConѕignmentDetails>> GetAllConѕignmentDetail()
        {
            var query = "SELECT * FROM ConѕignmentDetail";
            using (var connection = _context.CreateConnection())
            {
                var conѕignmentDetails = await connection.QueryAsync<ConѕignmentDetails>(query);
                return conѕignmentDetails.ToList();
            }
        }

        public Task<ConѕignmentDetails> GetConѕignmentDetailByField(int stament, string value)
        {
            throw new NotImplementedException();
        }

        public async Task<ConѕignmentDetails> GetConѕignmentDetailByID(int id)
        {
            var query = "EXEC ConѕignmentDetail_GetByID @Id";
            using (var connection = _context.CreateConnection())
            {
                var conѕignmentDetail = await connection.QueryFirstOrDefaultAsync<ConѕignmentDetails>(query, new { Id = id });
                return conѕignmentDetail;
            }
        }

        public async Task UpdateConѕignmentDetail(int id, ConѕignmentDetails conѕignmentDetail)
        {
            var query = "EXEC ConѕignmentDetail_Update @Id,@CommodityId,@CustomerId,@ConѕignmentId,@JapanCode,@VNCode,@Note,@ExportDateFromHCM,@ExportDateFromHue,@UserID";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("ProducerCode", conѕignmentDetail.CommodityId, DbType.Int32);
            parameters.Add("CustomerId", conѕignmentDetail.CustomerId, DbType.Int32);
            parameters.Add("ConѕignmentId", conѕignmentDetail.ConѕignmentId, DbType.Int32);
            parameters.Add("JapanCode", conѕignmentDetail.JPCode, DbType.String);
            parameters.Add("VNCode", conѕignmentDetail.VNCode, DbType.String);
            parameters.Add("Note", conѕignmentDetail.Note, DbType.String);
            parameters.Add("ExportDateFromHCM", conѕignmentDetail.ExportDateFromHCM, DbType.Date);
            parameters.Add("ExportDateFromHue", conѕignmentDetail.ExportDateFromHue, DbType.Date);
            parameters.Add("UserID", conѕignmentDetail.UserID, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
