using System;
using System.Threading.Tasks;
using Server.SharedThings.Packets;

namespace Networking.Packets
{
    public interface IPacketFactory
    {
        Task RegisterAsync(IPacketHandler handler, Type packetType);

        Task UnregisterAsync(IPacketHandler handler, Type packetType);

        Task Handle(IPacket packet
            /*, ISession session*/);

        Type GetPacketById(uint identificator);
    }
}
