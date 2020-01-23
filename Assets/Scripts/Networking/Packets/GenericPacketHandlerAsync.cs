using System.Threading.Tasks;
using Server.SharedThings.Packets;

namespace Networking.Packets
{
    public abstract class GenericPacketHandlerAsync<T> : IPacketHandler where T : class, IPacket
    {
        public Task Handle(IPacket packet/*, ISession session*/)
        {
            if (!(packet is T typedPacket) /*|| session == null*/)
            {
                return Task.CompletedTask;
            }

            return Handle(typedPacket/*, session*/);
        }

        protected abstract Task Handle(T packet/*, ISession session*/);
    }
}