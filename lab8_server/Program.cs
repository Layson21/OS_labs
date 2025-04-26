using System.Net;
using System.Net.Sockets;

class Server
{
    static TcpListener listener;
    static List<TcpClient> clients = new List<TcpClient>();

    static void Main()
    {
        listener = new TcpListener(IPAddress.Any, 5000);
        listener.Start();
        Console.WriteLine("Сервер запущен");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            clients.Add(client);

            Thread thread = new Thread(HandleClient);
            thread.Start(client);
        }
    }

    static void HandleClient(object obj)
    {
        TcpClient client = (TcpClient)obj;
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[4096];

        while (true)
        {
            try
            {
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0) break;

                foreach (var cl in clients)
                {
                    if (cl != client)
                    {
                        NetworkStream clStream = cl.GetStream();
                        clStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
            catch { break; }
        }
        clients.Remove(client);
        client.Close();
    }
}
