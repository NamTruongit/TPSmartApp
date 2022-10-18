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
    public class ProducerRepository : IProducerRepository
    {
        private readonly DapperContext _context;

        public ProducerRepository(DapperContext context)
        {
            this._context = context;
        }

        public async Task<Producer> CreateProducer(Producer producer)
        {
            var query = "EXEC Producer_Insert @ProducerCode,@Decription,@Mail,@Note,@UserID";
            var parameters = new DynamicParameters();
            parameters.Add("ProducerCode", producer.ProducerCode, DbType.String);
            parameters.Add("Decription", producer.ProducerCode, DbType.String);
            parameters.Add("Mail", producer.ProducerCode, DbType.String);
            parameters.Add("Note", producer.ProducerCode, DbType.String);
            parameters.Add("UserID", producer.ProducerCode, DbType.String);


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);
                var createdProducer = new Producer
                {
                    ProducerCode = producer.ProducerCode,
                    Decription = producer.Decription,
                    Mail = producer.Mail,
                    Note = producer.Note,
                    UserID = producer.UserID
                };
                return createdProducer;
            }
        }

        public async Task DeleteProducer(int id)
        {
            var query = "EXEC Producer_Delete @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<Producer>> GetAllProducer()
        {
            var query = "SELECT * FROM Producer";
            using (var connection = _context.CreateConnection())
            {
                var producers = await connection.QueryAsync<Producer>(query);
                return producers.ToList();
            }
        }

        public Task<Producer> GetProducerByField(int stament, string value)
        {
            throw new NotImplementedException();
        }

        public async Task<Producer> GetProducerByID(int id)
        {
            var query = "EXEC Producer_GetById @Id";
            using (var connection = _context.CreateConnection())
            {
                var producer = await connection.QueryFirstOrDefaultAsync<Producer>(query, new { Id = id });
                return producer;
            }
        }

        public async Task UpdateProducer(int id, Producer producer)
        {
            var query = "EXEC Producer_Update @Id,@ProducerCode,@Decription,@Mail,@Note,@UserID";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("ProducerCode", producer.ProducerCode, DbType.String);
            parameters.Add("Decription", producer.Decription, DbType.String);
            parameters.Add("Mail", producer.Mail, DbType.String);
            parameters.Add("Note", producer.Note, DbType.String);
            parameters.Add("UserID", producer.UserID, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
