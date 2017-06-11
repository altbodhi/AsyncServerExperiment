using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
namespace AsyncServerExperiment
{
    public class Server
    {
        Queue<Packet> queue = new Queue<Packet>();
        public Server()
        {
            Start();
        }
        public void AcceptClient(Client client)
        {
            Console.WriteLine($"accept {client.Name}"); 
            client.Send(this);
        }
        public Task AcceptClientAsync(Client client)
        {
            return Task.Run(() => AcceptClient(client));
        }

        public void Send(Packet packet)
        {
            lock(queue)
                queue.Enqueue(packet);    
        }

        public void ProcessPacket(Packet packet)
        {
            Console.WriteLine(packet);
        }
        public void ProcessPackets()
        {
            while (isRun)
                lock(queue)
                    if(queue.Count>0)
                        ProcessPacket(queue.Dequeue());
        }
        private bool isRun;
        public void Start()
        {
            isRun = true;
			Task.Run(() => ProcessPackets());
        }
        public void Stop()
        {
            isRun = false;
        }
    }
}
