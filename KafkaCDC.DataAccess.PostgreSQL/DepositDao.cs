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
            //insert into public."Deposits" ("Name","Sum") values ('123',1)
            string sql = $"insert into public.\"Deposits\" (\"Name\",\"Sum\") values ('{deposit.Name}',{deposit.Sum})";

            return connection.ExecuteAsync(sql);
        }
    }
}
