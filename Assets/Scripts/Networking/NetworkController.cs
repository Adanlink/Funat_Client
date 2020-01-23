using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Assets.Scripts.IoC;
using Autofac;
using ChickenAPI.Core.Utils;
using Networking.Packets;
using Networking.Packets.Handlers.LoginRegisterMenu;
using Networking.Serializers;
using Server.SharedThings.Packets;
using UnityEngine;
using System.Linq;
using System.Text;

namespace Networking
{
    public class NetworkController : INetworkController
    {
        public string Username { get; set; }
        
        public string SessionId { get; set; }
        
        private TcpClient Client { get; set; }

        private Thread RecieverThread { get; set; }

        private NetworkStream Stream { get; set; }

        private ISerializer Serializer { get; }

        private IPacketFactory PacketFactory { get; }

        private GameController GameController { get; }

        private static Encoding Encoding = Encoding.GetEncoding(1256);

        public NetworkController(ISerializer serializer, IPacketFactory packetFactory, GameController gameController)
        {
            Serializer = serializer;
            PacketFactory = packetFactory;
            PreparePacketFactory(PacketFactory);
            GameController = gameController;
            StartClient();
        }

        public bool IsConnected()
        {
            return Client.Connected;
        }

        private void StartClient()
        {
            LoadClient();

            void Start()
            {
                while (true)
                {
                    try
                    {
                        if (Stream == null) 
                        {
                            Thread.Sleep(3);
                            continue;
                        }

                        var bytes = new byte[Client.ReceiveBufferSize];

                        Stream.Read(bytes, 0, Client.ReceiveBufferSize);

                        HandlePacket(bytes);
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
            }

            Task HandlePacket(byte[] buffer)
            {
                /*var asd = new StringBuilder();
                foreach (var _byte in buffer)
                {
                    asd.Append(_byte.ToString() + "|");
                }
                Debug.Log(asd.ToString());*/
                var asd2 = Encoding.GetString(buffer);
                //Debug.Log(asd2);
                var packets = asd2.Split(new string[] { "Funat" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var packet in packets)
                {
                    if (string.IsNullOrEmpty(packet))
                    {
                        return Task.CompletedTask;
                    }
                    PacketFactory.Handle(Serializer.Deserialize(Encoding.GetBytes(packet)));
                }
                return Task.CompletedTask;
            }

            RecieverThread = new Thread(Start)
            {
                IsBackground = true
            };
            RecieverThread.Start();
        }

        private void LoadClient()
        {
            Client = new TcpClient
            {
                NoDelay = true
            };
            Client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
        }

        private static void PreparePacketFactory(IPacketFactory packetFactory)
        {
            try
            {
                var asd = new LoginFailedHandler(null).GetType().Assembly
                    .GetTypesImplementingGenericClass(typeof(GenericPacketHandlerAsync<>));
                foreach (var _packetHandler in asd)
                {
                    if (!(UsefulContainer.Instance.Resolve(_packetHandler) is IPacketHandler packetHandler))
                    {
                        continue;
                    }
                    var packetType = _packetHandler.BaseType.GenericTypeArguments[0];
                    packetFactory.RegisterAsync(packetHandler, packetType).ConfigureAwait(false).GetAwaiter().GetResult();
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        public void Connect(string host, int port)
        {
            try
            {
                var wanted = new IPEndPoint(Dns.GetHostEntry(host).AddressList[0], port);
                if (Client.Connected)
                {
                    var actual = Client.Client.RemoteEndPoint as IPEndPoint;

                    if (actual.Address.MapToIPv6().ToString() == wanted.Address.MapToIPv6().ToString()
                        && actual.Port == wanted.Port
                        && actual.AddressFamily == wanted.AddressFamily)
                    {
                        return;
                    }
                }
                Disconnect();
                StartClient();
                Client.Connect(wanted);

                Stream = Client.GetStream();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                GameController.MessageController.SendNoIntrusiveMsg("Something went wrong while trying to connect...");
            }
        }

        public void SendPacket<T>(T packet) where T : IPacket
        {
            WriteAPacket(packet);
            Stream.Flush();
        }

        private void WriteAPacket<T>(T packet) where T : IPacket
        {
            if (!Stream.CanWrite || packet == null)
            {
                return;
            }
            var _packet = Serializer.Serialize(packet);
            if (_packet == null)
            {
                return;
            }
            Stream.WriteAsync(_packet, 0, _packet.Length);
        }

        public void SendPackets<T>(IEnumerable<T> packets) where T : IPacket
        {
            if (packets == null)
            {
                return;
            }

            foreach (var packet in packets)
            {
                WriteAPacket(packet);
            }

            Stream.Flush();
        }

        public void SendPackets(IEnumerable<IPacket> packets)
        {
            if (packets == null)
            {
                return;
            }

            foreach (var packet in packets)
            {
                WriteAPacket(packet);
            }

            Stream.Flush();
        }

        public Task SendPacketAsync<T>(T packet) where T : IPacket
        {
            _ = WriteAnAsyncPacket(packet);
            Stream.Flush();
            return Task.CompletedTask;
        }

        private Task WriteAnAsyncPacket<T>(T packet) where T : IPacket
        {
            if (!Stream.CanWrite || packet == null)
            {
                return Task.CompletedTask;
            }

            var _packet = Serializer.Serialize(packet);

            return _packet == null ? Task.CompletedTask : Stream.WriteAsync(_packet, 0, _packet.Length);
        }

        public Task SendPacketsAsync<T>(IEnumerable<T> packets) where T : IPacket
        {
            if (packets == null)
            {
                return Task.CompletedTask;
            }

            foreach (var packet in packets)
            {
                WriteAnAsyncPacket(packet);
            }

            Stream.Flush();
            return Task.CompletedTask;
        }

        public Task SendPacketsAsync(IEnumerable<IPacket> packets)
        {
            if (packets == null)
            {
                return Task.CompletedTask;
            }

            foreach (var packet in packets)
            {
                WriteAnAsyncPacket(packet);
            }

            Stream.Flush();
            return Task.CompletedTask;
        }

        public void Disconnect()
        {
            RecieverThread?.Abort();
            Stream?.Flush();
            Stream?.Close();
            Client?.Close();
        }
    }
}