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
    public class CommodityRepository : ICommodityRepository
    {
        private readonly DapperContext _context;

        public CommodityRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Commodity> CreateCommodity(Commodity commodity)
        {
            var query = "EXEC Commodity_Insert @CommodityCode,@CommodityName,@Decription,@CommodityGroup,@ProducerID,@Abbreviation,@UserID";
            var parameters = new DynamicParameters();
            parameters.Add("CommodityCode", commodity.CommodityCode, DbType.String);
            parameters.Add("CommodityName", commodity.CommodityName, DbType.String);
            parameters.Add("Decription", commodity.Decription, DbType.String);
            parameters.Add("CommodityGroup", commodity.CommodityGroup, DbType.String);
            parameters.Add("ProducerID", commodity.ProducerID, DbType.Int32);
            parameters.Add("Abbreviation", commodity.Abbreviation, DbType.String);
            parameters.Add("UserID", commodity.UserID, DbType.String);
            

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdCommodity = new Commodity
                {
                    CommodityCode = commodity.CommodityCode,
                    CommodityName = commodity.CommodityName,
                    Decription = commodity.Decription,
                    CommodityGroup = commodity.CommodityGroup,
                    ProducerID = commodity.ProducerID,
                    Abbreviation = commodity.Abbreviation,
                    UserID = commodity.UserID
                };
                return createdCommodity;
            }
        }

        public async Task DeleteCommodity(int id)
        {
            var query = "EXEC Commodity_Delete @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<Commodity>> GetAllCommodity()
        {
            var query = "SELECT * FROM Commodity";
            using (var connection = _context.CreateConnection())
            {
                var commodities = await connection.QueryAsync<Commodity>(query);
                return commodities.ToList();
            }
            
        }

        public  Task<Commodity> GetCommodityByField(int stament, string value)
        {
            throw new NotImplementedException();
        }

        public async Task<Commodity> GetCommodityByID(int id)
        {
            var query = "EXEC Commodity_GetById @Id";
            using (var connection = _context.CreateConnection())
            {
                var commodity = await connection.QueryFirstOrDefaultAsync<Commodity>(query, new { Id = id });
                return commodity;
            }
        }
        public async Task UpdateCommodity(int id, Commodity commodity)
        {
            var query = "EXEC Commodity_Update @Id,@CommodityCode,@CommodityName,@Decription,@CommodityGroup,@ProducerID,@Abbreviation,@UserID";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("CommodityCode", commodity.CommodityCode, DbType.String);
            parameters.Add("CommodityName", commodity.CommodityName, DbType.String);
            parameters.Add("Decription", commodity.Decription, DbType.String);
            parameters.Add("CommodityGroup", commodity.CommodityGroup, DbType.String);
            parameters.Add("ProducerID", commodity.ProducerID, DbType.Int32);
            parameters.Add("Abbreviation", commodity.Abbreviation, DbType.String);
            parameters.Add("UserID", commodity.UserID, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
