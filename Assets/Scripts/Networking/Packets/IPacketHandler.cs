using System.Threading.Tasks;
using Server.SharedThings.Packets;

namespace Networking.Packets
{
    public interface IPacketHandler
    {
        Task Handle(IPacket packet/*, ISession session*/);
    }
}
