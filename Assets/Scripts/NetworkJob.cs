using Client;
using Client.Jobs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NetworkJob : ThreadedJob
{
    /*public string Ip { get; set; }

    public int Port { get; set; }

    public ICustomTcpChannelHandler ChannelHandler { get; set; }

    public TestingDotnetty NetworkManager { get; set; }

    protected override void ThreadFunction()
    {
        // Do your threaded task. DON'T use the Unity API here
        if (NetworkManager == null)
        {
            return;
        }

        NetworkManager.ConnectClientAsync(Ip, Port, ChannelHandler);
    }

    protected override void OnFinished()
    {
        // This is executed by the Unity main thread when the job is finished

    }*/
}
