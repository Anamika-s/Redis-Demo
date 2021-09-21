using System;
using StackExchange.Redis;
using System.Threading.Tasks;



namespace RedisDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString="redisdemo2109.redis.cache.windows.net:6380,password=OG89gr2BrvR5pMgvBALOt2r4MHQwkbpL4fn1K+3YAlA=,ssl=True,abortConnect=False";
            using (var cache = ConnectionMultiplexer.Connect(connectionString))
            {
                IDatabase db = cache.GetDatabase();

                bool setValue = await db.StringSetAsync("test:demokey", "100");
                Console.WriteLine($"SET: {setValue}");

                string getValue = await db.StringGetAsync("test:demokey");
                Console.WriteLine($"GET: {getValue}");
                
                bool deleted= await db.KeyDeleteAsync("test:demokey");
                Console.WriteLine($"DELETED: {deleted}");
                
            }

        }
    }
}
