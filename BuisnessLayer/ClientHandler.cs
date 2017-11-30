using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net.Sockets;

namespace BuisnessLayer
{
    public class ClientHandler
    {
        Thread clientThread;
        TcpClient newClient;

        NetworkStream nWS;
        StreamReader sR;
        StreamWriter sW;
        string Name;

        public ClientHandler(TcpClient newClient)
        {
            this.newClient = newClient;
            nWS = newClient.GetStream();
            sR = new StreamReader(nWS);
            sW = new StreamWriter(nWS);
            StartClient();
        }

        public void StartClient()
        {
            SendToClient("Indtast Navn:");
            Name = sR.ReadLine();
            SendToClient("Velkommen " + Name);
            clientThread = new Thread(HandelClient);
            clientThread.Start();
        }

        public void HandelClient()
        {
            string text;
            while (true)
            {
                text = sR.ReadLine();
                Console.WriteLine(text);
                Broadcast.BroadcastToClients(Name + " har budt " + text);
            }
        }
        public void SendToClient(string messageToClient)
        {
            sW.WriteLine(messageToClient);
            sW.Flush();

        }
    }
}
