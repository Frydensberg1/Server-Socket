using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Task;

namespace Server_Socket
{
    public class ClientHandler
    {



        public void ThreadsForClients()
        {

        }



        public void CommunicateWithClient()
        {

            while (true)
            {
                try
                {

                    Console.WriteLine("Waiting for connection");

                    // Wait here until someone is trying to connect to the listener/server.
                    // If success, it'll move on, if an exception happens, it'll jump out of the execution.
                    Socket client = server.AcceptSocket();
                    Console.WriteLine("You are connected");

                    // Networkstream can establish communication between the server and the clint.
                    NetworkStream stream = new NetworkStream(client);

                    // So we can write in text instead of binary.
                    // We use StreamReader and StreamWriter to help make communication between the server and the client easier.
                    StreamReader reader = new StreamReader(stream);
                    StreamWriter writer = new StreamWriter(stream);

                    writer.AutoFlush = true;

                    writer.WriteLine("Ready.");
                    writer.Flush();

                    string messageFromClient = reader.ReadLine();
                    Console.WriteLine(messageFromClient);
                    switch (messageFromClient.Split(' ').First())
                    {
                        case "Time?":
                            TimeSpan TodayTime = DateTime.Now.TimeOfDay;

                            writer.WriteLine(TodayTime.ToString());
                            writer.Flush();
                            break;

                        case "Date?":
                            DateTime TodayDate = DateTime.Now.Date;

                            writer.WriteLine(TodayDate.ToString());
                            writer.Flush();
                            break;

                        case "Add":
                            List<string> AddListe = new List<string>();
                            AddListe = messageFromClient.Split(' ').ToList();
                            AddListe.RemoveAt(0);

                            int finalnumber = 0;
                            foreach (string numre in AddListe)
                            {
                                finalnumber = finalnumber + Convert.ToInt32(numre);
                            }
                            writer.WriteLine("Sum " + finalnumber);
                            writer.Flush();
                            break;

                        case "sub":
                            List<string> subListe = new List<string>();
                            subListe = messageFromClient.Split(' ').ToList();
                            subListe.RemoveAt(0);

                            int finalnumber2 = Convert.ToInt32(subListe.ElementAt(0));
                            subListe.RemoveAt(0);
                            foreach (string numre in subListe)
                            {
                                finalnumber2 = finalnumber2 - Convert.ToInt32(numre);
                            }
                            writer.WriteLine("Difference " + finalnumber2);
                            writer.Flush();
                            break;


                        case "Exit":
                            writer.WriteLine("You have been disconnected from this insane freaking awesome server");
                            writer.Flush();
                            break;

                        default:
                            writer.WriteLine("Unknown command");
                            writer.Flush();


                            break;
                    }
                    if (messageFromClient != "Time?")
                    {
                        writer.WriteLine("Unknown command");
                        writer.Flush();
                    }
                    else
                    {

                    }

                }
                catch (Exception e)
                {

                    Console.WriteLine("An unspecified error happened. Please try again.");

                }

            }
        }



    }
} 
       