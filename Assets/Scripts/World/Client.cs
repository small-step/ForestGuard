using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using UnityEngine;

namespace ForestGuard
{
    public class Client
    {
        private static string _hostname;
        private static int _port;

        private TcpClient _connection;
        private NetworkStream _stream;

        private Thread _recvThread;
        private Thread _heartbeatThread;
        
        private Client()
        {
            string[] lines = System.IO.File.ReadAllLines(System.Environment.CurrentDirectory + "/Config/socket.txt");
            _hostname = lines[0].TrimEnd('\n');
            _port = int.Parse(lines[1].TrimEnd('\n'));

            try
            {
                _connection = new TcpClient(_hostname, _port);
                _stream = _connection.GetStream();
                _stream.ReadTimeout = 15000; // 15s
                Event.RegistEvent();
                _recvThread = new Thread(Revcive);
                _heartbeatThread = new Thread(HeartBeat);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e.Message);
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

        public void Run()
        {
            _recvThread.Start();
            _heartbeatThread.Start();
        }

        public void Stop()
        {
            _recvThread.Abort();
            _heartbeatThread.Abort();
            _connection.Close();
        }

        public bool IsThreadAlive()
        {
            return _recvThread.IsAlive;
        }

        public void Revcive()
        {
            var header = new byte[4];
            int numOfBytes = 0;
            while (true)
            {
                try
                {
                    do
                    {
                        numOfBytes = _stream.Read(header, 0, header.Length);
                        var ret = ParseHeader(header);
                        if (ret.Item2 == 0)
                        {
                            Dispatcher.Handle(ret.Item1, new byte[0]);
                        }
                        else
                        {
                            var data = new byte[ret.Item2];
                            numOfBytes = _stream.Read(data, 0, data.Length);
                            Dispatcher.Handle(ret.Item1, data);
                        }
                    } while (_stream.DataAvailable);
                }
                catch (Exception e)
                {

                    Debug.Log("revc: " + e.Message);
                }
            }
        }

        public async void Send(RequestType type, byte[] data)
        {
            try
            {
                var packet = MakePacket((uint)(type), data);
                await _stream.WriteAsync(packet, 0, packet.Length);
                //await _stream.FlushAsync();
            }
            catch (Exception e)
            {
                Debug.Log("send: " + e.Message);
            }
        }

        public void HeartBeat()
        {
            while (true)
            {
                Send(RequestType.KeepAlive, new byte[0]);
                Thread.Sleep(3000);
            }
        }

        private Tuple<uint, int> ParseHeader(byte[] header)
        {
            uint type = header[0];
            int length = (header[2] << 8)| header[3];
            return new Tuple<uint, int>(type, length);
        }

        private byte[] MakePacket(uint type, byte[] data)
        {
            int byte_count = data.Length;
            //Console.WriteLine(data.Length);
            byte[] int_bytes = BitConverter.GetBytes(byte_count);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(int_bytes);
            byte[] result = int_bytes;
            //Console.WriteLine(BitConverter.ToString(result));
            byte[] header = new byte[4]
            {
            (byte)(type & 0xff), 0x33, result[2], result[3]
            };
            if (byte_count == 0)
            {
                return header;
            }
            var packet = new byte[header.Length + byte_count];
            Buffer.BlockCopy(header, 0, packet, 0, header.Length);
            Buffer.BlockCopy(data, 0, packet, header.Length * sizeof(byte), byte_count);
            return packet;
        }
    }
}