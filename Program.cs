using System;

namespace AsyncServerExperiment
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var server = new Server();
            //server.Start();
            for (int i = 0; i < 100;i++)
                server.AcceptClientAsync(new Client() { Name = $"client {i:0000}" });
            Console.ReadLine();
            server.Stop();
        }
    }
}
