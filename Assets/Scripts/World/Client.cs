using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using World;

public class Client {

    private static string _hostname;
    private static int _port;

    private TcpClient _connection;
    private NetworkStream _stream;

    private Client()
    {
        string[] lines = System.IO.File.ReadAllLines(System.Environment.CurrentDirectory + "/Config/socket.txt");
        _hostname = lines[0].TrimEnd('\n');
        _port = int.Parse(lines[1].TrimEnd('\n'));
        try
        {
            _connection = new TcpClient(_hostname, _port);
            _stream = _connection.GetStream();
            Debug.Log("connect server successfully");
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
            _connection.Close();
        }
    }

    private class Inner
    {
        static Inner() { }
        internal static readonly Client instance = new Client();
    }

    public static Client Instance
    {
        get
        {
            return Inner.instance;
        }
    }

    public void Send(byte[] data)
    {
        try
        {
            _stream.Write(data, 0, data.Length);
            //var revc = new byte[256];
            //Int32 bytes = _stream.Read(revc, 0, revc.Length);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
    }
}
