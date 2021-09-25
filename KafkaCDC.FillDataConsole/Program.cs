﻿using KafkaCDC.DataAccess.PostgreSQL;
using KafkaCDC.Domain.FillData;
using System;
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
                new (JohnMalkovich,10),
                new (JohnMalkovich,20),
                new (JohnMalkovich,30),
                new (DustinHoffman,40),
                new (DustinHoffman,50),
                new (DustinHoffman,60),
                new (DustinHoffman,70)
            };

            var depositDao = new DepositDao();

            foreach (var deposit in deposits)
            {
                await Task.Delay(10000);
                try
                {
                    await depositDao.Save(deposit);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"FillConsole error: {e.Message}");
                }
                
            }
        }
    }
}
