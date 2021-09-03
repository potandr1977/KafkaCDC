using KafkaCDC.Domain.Mongo;
using System.Threading.Tasks;

namespace KafkaCDC.FillMongoConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string JohnMalkovich = "John Malkovich";
            const string DustinHoffman = "Dustin Hoffman";

            var deposits = new Deposit[]{
                new Deposit(JohnMalkovich,10),
                new Deposit(JohnMalkovich,20),
                new Deposit(JohnMalkovich,30),
                new Deposit(DustinHoffman,40),
                new Deposit(DustinHoffman,50)
            };

            var mongoDao = new MongoDao();

            foreach (var deposit in deposits)
            {
                await Task.Delay(10000);
                await mongoDao.Save(deposit);
            }
        }
    }
}
