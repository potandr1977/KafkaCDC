using Dapper;
using KafkaCDC.Domain.FillData;
using KafkaCDC.Settings;
using Npgsql;
using System.Threading.Tasks;

namespace KafkaCDC.DataAccess.PostgreSQL
{
    public class DepositDao
    {
        private readonly NpgsqlConnection connection;

        public DepositDao()
        {
            connection = new NpgsqlConnection(PostgreSettings.ConnectionString);
        }

        public Task Save(Deposit deposit)
        {
            string sql = $"Insert into Deposits (Name,Sum) values ('{deposit.Name}','{deposit.Sum}')";

            return connection.ExecuteAsync(sql);
        }

        public Task CreateDepositsTalbe()
        {
            string sql = @"CREATE TABLE Employee ( 
                            name varchar(100), 
                            sum integer
                         );";

            return connection.ExecuteAsync(sql);
        }
    }
}
