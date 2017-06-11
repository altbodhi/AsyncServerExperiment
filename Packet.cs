using System;
namespace AsyncServerExperiment
{
    public class Packet
    {
        public Guid Id { get; private set; }
        public string ClientName { get;private set; }
        public Packet()
        {
            Id = Guid.NewGuid();
        }
        public Packet(Client owner):this()
        {
            ClientName = owner.Name;
        }
        public Guid RequestId { get; private set; }

        public override string ToString()
        {
            return string.Format("[Packet: Id={0}, ClientName={1}, RequestId={2}]", Id, ClientName, RequestId);
        }
    }
}
