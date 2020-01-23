using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;
using System.Net;

namespace Client
{
    public class TestingDotnetty : MonoBehaviour
    {/*
        private IChannel ConnectionChannel { get; set; }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void ConnectClientAsync(string ip, int port, ICustomTcpChannelHandler channelHandler)
        {
            var remoteAddress = new DnsEndPoint(ip, port)/*new IPEndPoint(2130706433, port);
            try
            {
                if (ConnectionChannel != null)
                {
                    lock (ConnectionChannel)
                    {
                        if (ConnectionChannel.Active)
                        {
                            ConnectionChannel.CloseAsync();
                        }

                        ConnectionChannel.ConnectAsync(remoteAddress);
                    }
                }
                else
                {
                    ConnectionChannel = GetTcpClient(channelHandler, remoteAddress);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private IChannel GetTcpClient(ICustomTcpChannelHandler channelHandler, EndPoint endPoint)
        {
            var workerGroup = new MultithreadEventLoopGroup();

            try
            {
                var bootstrap = new CustomBootstrap();
                bootstrap
                    .Option(ChannelOption.TcpNodelay, true)
                    .Group(workerGroup)
                    .Channel<TcpSocketChannel>()
                    .Handler(new ActionChannelInitializer<ISocketChannel>(channel =>
                    {
                        IChannelPipeline pipeline = channel.Pipeline;
                        pipeline.AddLast("handler", channelHandler.GetNewWithChannelHandler(channel));
                    }));

                return bootstrap.Connect(endPoint);
            }
            catch (Exception e)
            {
                Debug.LogError("Something went wrong generating a TCP client -> " + e);
                return null;
            }
        }*/
    }
}