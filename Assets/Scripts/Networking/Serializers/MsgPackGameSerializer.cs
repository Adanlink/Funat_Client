using System;
using System.Reflection;
using MsgPack.Serialization;
using Networking.Packets;
using Server.SharedThings.Packets;

namespace Networking.Serializers
{
    public class MsgPackGameSerializer : ISerializer
    {
        private IPacketFactory PacketFactory { get; }

        //private IFormatterResolver GeneratedResolver { get; }

        public MsgPackGameSerializer(IPacketFactory packetFactory/*, IFormatterResolver formatterResolver*/)
        {
            PacketFactory = packetFactory;
            //GeneratedResolver = formatterResolver;
        }

        public IPacket Deserialize(byte[] buffer)
        {
            try
            {
                var packet = MessagePackSerializer.Get<BasicPacketCapsule>().UnpackSingleObject(buffer);
                var packetType = PacketFactory.GetPacketById(packet.Identifier);

                if (packetType == null)
                {
                    //Debug.Log($"Packet with identifier: [{packet.Identifier}] couldn't be found.");
                    return null;
                }

                return MessagePackSerializer.Get(packetType).UnpackSingleObject(packet.Packet) as IPacket;
            }
            catch (Exception e)
            {
                //Log.Error("[DESERIALIZE]", e);
                return null;
            }
        }

        public byte[] Serialize<T>(T packet) where T : IPacket
        {
            try
            {
                //var asd = MessagePackSerializer.Serialize(Convert.ChangeType(packet, packet.GetType()), CompositeResolver.Instance);
                return MessagePackSerializer.Get<BasicPacketCapsule>().PackSingleObject(new BasicPacketCapsule
                {
                    Identifier = packet.GetType().GetCustomAttribute<PacketPropertiesAttribute>().Identifier,
                    Packet = MessagePackSerializer.Get(packet.GetType()).PackSingleObject(packet)
                });
            }
            catch (Exception e)
            {
                //Log.Error("[SERIALIZE]", e);
                return null;
            }
        }
    }
}
