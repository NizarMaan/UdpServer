using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private  UdpState _udpState;

        private struct UdpState
        {
            public UdpClient udpClient;
            public IPEndPoint serverEP;
        }

        public Server()
        {
            _udpState = new UdpState();
            _udpState.serverEP = new IPEndPoint(IPAddress.IPv6Any, 80);
            _udpState.udpClient = new UdpClient(_udpState.serverEP);
            //_udpState.udpClient.Client.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false); //accept IPv6 or IPv4 etc.
        }

        public void Listen()
        {
            Console.WriteLine("Listening...");

            while (true)
            {
                try
                {
                    _udpState.udpClient.BeginReceive(new AsyncCallback(ListenerCallBack), _udpState);
                    
                    Thread.Sleep(15); //defaults to 15.6ms (64 ticks per second)
                }
                catch (Exception ex)
                {
                    Console.WriteLine($@"Server interrupted by exception: 
                    {ex.Message} - 
                    {ex.StackTrace}
                        {ex.InnerException}");

                    Console.WriteLine("Restarting...");
                    continue;
                }
            }
        }

        public void StopServer()
        {
            _udpState.udpClient.Close();
            Console.WriteLine("Closed server connection...");
        }

        private void ListenerCallBack(IAsyncResult asyncResult)
        {
            UdpState udpState = (UdpState)asyncResult.AsyncState;

            byte[] receivedBytes = udpState.udpClient.EndReceive(asyncResult, ref udpState.serverEP);
            string receivedString = Encoding.ASCII.GetString(receivedBytes);

            if (receivedString.Equals("Ping!"))
            {
                HandshakeReply(udpState);
            }
            else
            {
                Console.WriteLine($"Received message {receivedString} from client at IP address: {udpState.serverEP.Address}");
            }
        }

        private void HandshakeReply(UdpState udpState)
        {
            Console.WriteLine($"Handshaking with {udpState.serverEP.Address}...");
            byte[] reply = Encoding.ASCII.GetBytes("Pong!");

            udpState.udpClient.Send(reply, reply.Length, udpState.serverEP);
        }
    }
}
