using Server.Models.Network;
using Server.Services;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public class Server
    {
        private UdpState _udpState;
        private Messenger _messenger;

        public Server()
        {
            _udpState = new UdpState();
            _udpState.ServerEP = new IPEndPoint(IPAddress.IPv6Any, 80);
            _udpState.UdpClient = new UdpClient(_udpState.ServerEP);
            //_udpState.udpClient.Client.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false); //accept IPv6 or IPv4 etc.
            _messenger = new Messenger();
        }

        public void Listen()
        {
            Console.WriteLine("Listening...");

            while (true)
            {
                try
                {
                    _udpState.UdpClient.BeginReceive(new AsyncCallback(ListenerCallBack), _udpState);
                    
                    Thread.Sleep(15); //defaults to 15.6ms (64 ticks per second)
                }
                catch (Exception ex)
                {
                    Console.WriteLine($@"Server interrupted by exception: 
                    {ex.Message} - 
                    {ex.StackTrace}
                        {ex.InnerException}");

                    Console.WriteLine("Resuming...");
                    continue;
                }
            }
        }

        public void StopServer()
        {
            _udpState.UdpClient.Close();
            Console.WriteLine("Closed server connection...");
        }

        private void ListenerCallBack(IAsyncResult asyncResult)
        {
            UdpState udpState = (UdpState)asyncResult.AsyncState;

            byte[] receivedBytes = udpState.UdpClient.EndReceive(asyncResult, ref udpState.ServerEP);
            string receivedString = Encoding.ASCII.GetString(receivedBytes);

            _messenger.ProcessMessage(receivedString, udpState);

            Console.WriteLine($"Received message {receivedString} from client at IP address: {udpState.ServerEP.Address}");
        }
    }
}
