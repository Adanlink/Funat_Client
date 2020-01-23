using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Server.SharedThings.Packets;

namespace Networking.Packets
{
    public class PacketFactory : IPacketFactory
    {
        private readonly IDictionary<uint, Type> packetsIdentities = new Dictionary<uint, Type>();
        private readonly IDictionary<Type, IPacketHandler> packetsHandlers = new Dictionary<Type, IPacketHandler>();

        /// <summary>
        /// If it couldn't find it, it return null.
        /// </summary>
        /// <param name="identifactor"></param>
        /// <returns>The type of the packet identified with that identification.</returns>
        public Type GetPacketById(uint identifactor)
        {
            return !packetsIdentities.TryGetValue(identifactor, out Type type) ? null : type;
        }

        public Task Handle(IPacket packet/*, ISession session*/)
        {
            if (packet == null)
            {
                return Task.CompletedTask;
            }

            if (!packetsHandlers.TryGetValue(packet.GetType(), out IPacketHandler handler))
            {
                return Task.CompletedTask;
            }

            handler.Handle(packet/*, session*/);
            return Task.CompletedTask;
        }

        public Task RegisterAsync(IPacketHandler handler, Type packetType)
        {
            if (packetsHandlers.ContainsKey(packetType))
            {
                return Task.CompletedTask;
            }
            packetsHandlers[packetType] = handler;
            packetsIdentities.Add(
                packetType.GetCustomAttribute<PacketPropertiesAttribute>().Identifier, packetType);
            return Task.CompletedTask;
        }

        public Task UnregisterAsync(IPacketHandler handler, Type packetType)
        {
            packetsHandlers.Remove(packetType);
            packetsIdentities.Remove(packetType.GetCustomAttribute<PacketPropertiesAttribute>().Identifier);
            return Task.CompletedTask;
        }
    }
}
