// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

#pragma warning disable SA1200 // Using directives should be placed correctly
#pragma warning disable SA1403 // File may only contain a single namespace
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters.Server.SharedThings.Packets.ClientPackets.Enums
{
    using System;
    using System.Buffers;
    using MessagePack;

    public sealed class MovementDirectionFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Server.SharedThings.Packets.ClientPackets.Enums.MovementDirection>
    {
        public void Serialize(ref MessagePackWriter writer, global::Server.SharedThings.Packets.ClientPackets.Enums.MovementDirection value, global::MessagePack.MessagePackSerializerOptions options)
        {
            writer.Write((Int32)value);
        }

        public global::Server.SharedThings.Packets.ClientPackets.Enums.MovementDirection Deserialize(ref MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            return (global::Server.SharedThings.Packets.ClientPackets.Enums.MovementDirection)reader.ReadInt32();
        }
    }
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning restore SA1403 // File may only contain a single namespace
#pragma warning restore SA1649 // File name should match first type name
