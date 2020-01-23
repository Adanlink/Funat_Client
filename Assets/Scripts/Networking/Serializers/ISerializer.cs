using Server.SharedThings.Packets;

namespace Networking.Serializers
{
    public interface ISerializer
    {
        IPacket Deserialize(byte[] buffer);
        byte[] Serialize<T>(T packet) where T : IPacket;
    }
}
