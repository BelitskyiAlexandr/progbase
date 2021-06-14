using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System;
using System.Xml.Serialization;

public class Server
{
    public static void Start()
    {
        IPAddress ipAddress = IPAddress.Loopback;
        int port = 3000;

        Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);

            while (true)
            {
                Socket handler = listener.Accept();
                Thread thead = new Thread(ClientRun);
                thead.IsBackground = true;
                thead.Start(handler);
            }
        }
        catch (Exception e)
        {
            StreamWriter sw = new StreamWriter("log.txt", true);
            sw.WriteLine(DateTime.Now + e.ToString());
            sw.Close();
            sw.Dispose();
        }
    }

    static void ClientRun(Object input)
    {
        Socket handler = (Socket)input;
        while (true)
        {
            byte[] bytes = new byte[8096];
            int bytesRec = 0;

            try
            {
                bytesRec = handler.Receive(bytes);

                StreamWriter sw = new StreamWriter("log.txt", true);
                sw.WriteLine(DateTime.Now + "   Recieved: " + Encoding.ASCII.GetString(bytes, 0, bytesRec));
                sw.Close();
                sw.Dispose();

            }
            catch { continue; }
            string data = Encoding.ASCII.GetString(bytes, 0, bytesRec);

            string answer = DataHandler(data);

            byte[] msg = Encoding.ASCII.GetBytes(answer);
            int bytesSent = handler.Send(msg);
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();

            StreamWriter ssw = new StreamWriter("log.txt", true);
            ssw.WriteLine(DateTime.Now + "   Sent: " + answer);
            ssw.Close();
            ssw.Dispose();

        }
    }

    static string DataHandler(string request)
    {
        string answer = "HTTP/1.1 OK 200\nContent-Type: application/xml\nContent-Length: ";
        try
        {
            request = request.Remove(0, 5);
        }
        catch
        {
            string s = Serialize(new Nominations());
            answer += s.Length + "\n\n" + s;
            return answer;
        }
        request = request.Remove(request.IndexOf(" "));
        request = request.Replace("%20", " ");

        string[] splitedCommand = request.Split("/");
        
       
        return answer;
    }

    public static string Serialize(Nominations values)
    {
        XmlSerializer ser = new XmlSerializer(typeof(Nominations));
        StreamWriter sw = new StreamWriter("creatxml.txt");
        ser.Serialize(sw, values);
        sw.Close();
        string answ = File.ReadAllText("creatxml.txt");
        File.Delete("creatxml.txt");
        return answ;
    }

}
