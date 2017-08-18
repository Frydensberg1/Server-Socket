using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace Server_Socket
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.RunExercise4();
        }

      


        public void RunExercise4()
        {

            // Make an instance of the listener, that look for clients trying to connect.
            TcpListener server = new TcpListener(IPAddress.Any, 20001);

            // Start listening for clients trying to connect.
            server.Start();

            ClientHandler CH = new ClientHandler();
            CH.CommunicateWithClient(server); 


        }




    }
}



  
   