using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using MessagePack;
using MessagePack.Resolvers;
using Networking.Packets;
using Server.SharedThings.Packets;
using UnityEngine;

namespace Networking.Serializers
{
    public class MessagePackGameSerializer : ISerializer
    {
        private IPacketFactory PacketFactory { get; }

        //private IFormatterResolver GeneratedResolver { get; }

        private static readonly Encoding Encoding = Encoding.GetEncoding(1256);

        public MessagePackGameSerializer(IPacketFactory packetFactory/*, IFormatterResolver formatterResolver*/)
        {
            PacketFactory = packetFactory;
            //GeneratedResolver = formatterResolver;
        }

        public IPacket Deserialize(byte[] buffer)
        {
            try
            {
                var packet = MessagePackSerializer.Deserialize<BasicPacketCapsule>(buffer);
                var packetType = PacketFactory.GetPacketById(packet.Identifier);

                if (packetType == null)
                {
                    return null;
                }

                return MessagePackSerializer.Deserialize(packetType, packet.Packet) as IPacket;
            }
            catch (Exception e)
            {
                Debug.LogError("[DESERIALIZE]" + e);
                return null;
            }
        }

        public byte[] Serialize<T>(T packet) where T : IPacket
        {
            try
            {
                //var asd = MessagePackSerializer.Serialize(Convert.ChangeType(packet, packet.GetType()), CompositeResolver.Instance);
                /*var asd = Encoding.GetBytes("Funat").ToList();
                asd.AddRange(MessagePackSerializer.Serialize(new BasicPacketCapsule
                {
                    Identifier = packet.GetType().GetCustomAttribute<PacketPropertiesAttribute>().Identifier,
                    Packet = MessagePackSerializer.Serialize(packet.GetType(), packet)
                }));*/
                /*var asd2 = new StringBuilder();
                foreach (var _byte in asd.ToArray())
                {
                    asd2.Append(_byte.ToString() + "|");
                }
                Debug.Log(asd.ToString());*/
                var asd = MessagePackSerializer.Serialize(new BasicPacketCapsule
                {
                    Identifier = packet.GetType().GetCustomAttribute<PacketPropertiesAttribute>().Identifier,
                    Packet = MessagePackSerializer.Serialize(packet.GetType(), packet)
                });
                return asd.ToArray();
            }
            catch (Exception e)
            {
                Debug.LogError("[SERIALIZE]" + e);
                return null;
            }
        }
    }
}
