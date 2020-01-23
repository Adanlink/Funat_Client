using Client;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{/*
    private TestingDotnetty NetworkManager_ { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        NetworkManager_ = GameObject.Find("NetworkManager").GetComponent<TestingDotnetty>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ConnectTo(string bruteIp)
    {
        if (NetworkManager_ == null)
        {
            return;
        }

        var tmp = bruteIp.Split(':');

        var job = new NetworkJob()
        {
            NetworkManager = NetworkManager_,
            Ip = tmp[0],
            Port = Convert.ToInt32(tmp[1]),
            ChannelHandler = null
        };

        job.Start();
    }*/
}
