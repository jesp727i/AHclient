using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    //jesper er en engel
    class Broadcast
    {
        static List<ClientHandler> clientList = new List<ClientHandler>();



        static public void addClientToList(ClientHandler client)
        {
            clientList.Add(client);
        }
        static public void BroadcastToClients(string messsageToAll)
        {
            foreach (ClientHandler client in clientList)
            {
                client.SendToClient(messsageToAll);
            }
        }
    }
}
