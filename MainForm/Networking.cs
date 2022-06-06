using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Threading;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace KaFruit
{
    class Networking : Saving
    {
    
        public Socket sender;
        byte[] bytes = new byte[1024];
        public string code;
        public void connect()
        {
            try
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[1];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 6969);

                sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(remoteEP);
                send("pc"); // We tell the server we're the PC and not the phone

                // We get the code, I felt like this doesn't belong in the listen function
                // The listen function is more like for sharing like all of the users
                int bytesRec = sender.Receive(bytes);
                string response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (response.Contains("code")) // it definitely will this if statement is useless
                {
                    code = response.ToString().Split("_".ToCharArray())[1]; // code_1 --> 1

                    Debug.WriteLine("Code is: " + code);
                    

                    // Now we set up the listener
                    Thread t = new Thread(delegate ()
                    {
                        listen(); 
                    });
                    t.Start();
                }




            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        
        
        }

        public void send(string message)
        {
            byte[] msg = Encoding.ASCII.GetBytes(message);
            int byteSent = sender.Send(msg);
        }

        public void start()
        {   
            // Turns our objects into jsons
            List<Data> obbies = Saving.objects; // We make a copy of our list with objects
            List<string> convertedObjects = new List<string>();

            // there are better ways of doing this.
            // Right now python checks for the packet "start" 
            // from then on all of the following packets are quiz questions until python sees the "end" packet.
            convertedObjects.Add("start");
            foreach (var i in obbies)
            {
                string json = JsonConvert.SerializeObject(i);
                convertedObjects.Add(json);
                Debug.WriteLine(json);
            }
            convertedObjects.Add("end");
            


            
            foreach (string i in convertedObjects)
            {
                byte[] msg = Encoding.ASCII.GetBytes(i);
                int byteSent = sender.Send(msg);
                Thread.Sleep(50); // Makes sure python doesn't receive multiple packets at once (because it's so slow)
            }
           
        }

        public void listen()
        {
            while (true)
            {
                // Receive the response from the remote device.    
                int bytesRec = sender.Receive(bytes);
                var resposne = Encoding.ASCII.GetString(bytes, 0, bytesRec);


                
            }



        }

    }
}
