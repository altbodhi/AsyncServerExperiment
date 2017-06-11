using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
namespace AsyncServerExperiment
{
    public class Client
    {
        private string name;
        public string Name { get { return name ?? "noname" ; } set { name = value; } }
        public Client()
        {
        }
        public void Send(Server server)
        {
            server.Send(new Packet(this));
        }
    }
}
