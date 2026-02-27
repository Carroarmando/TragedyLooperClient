using System.Net.Sockets;
using System.Text.Json;
using static TragedyLooperClient.Logger;

namespace TragedyLooperClient
{
    internal class Program
    {
        static int id = -1;
        static void Main(string[] args)
        {
            Logger.Grade = Logger.Grades.Trace;
            startClient();
        }
        static void startClient()
        {
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 5000);

            NetworkStream stream = client.GetStream();
            byte[]? read = Read(stream);
            if (read == null) return;
            Comando? msg = JsonSerializer.Deserialize<Comando>(read);
            if (msg != null)
                HendleMessage(msg);

            WriteLine(id, (int)Grades.Trace);

            while (true)
            {
                byte[]? data = Read(stream);
                if (data == null) break;
                string json = System.Text.Encoding.UTF8.GetString(data);
                Console.WriteLine($"Ricevuto: {json}");
            }

            client.Close();
        }
        static void HendleMessage(Comando msg)
        {
            WriteLine($"Ricevuto comando: {msg.Azione}", (int)Grades.Trace);
            switch (msg.Azione)
            {
                case "SetId":
                    if (msg.IdGiocatore.HasValue)
                    {
                        id = msg.IdGiocatore.Value;
                        WriteLine($"ID impostato a: {id}", (int)Grades.Trace);
                    }
                    else
                    {
                        WriteLine("Comando SetId ricevuto senza IdGiocatore", (int)Grades.Warn);
                    }
                    break;
                default:
                    WriteLine($"Azione sconosciuta: {msg.Azione}", (int)Grades.Warn);
                    break;
            }
        }
        public static byte[]? Read(NetworkStream stream)
        {
            byte[] length_buffer = new byte[4];
            try
            {
                ReadExactly(stream, length_buffer, 4);
            }
            catch (Exception ex) { Console.WriteLine($"Errore nella lettura della lunghezza: {ex.Message}"); return null; }

            int size = BitConverter.ToInt32(length_buffer, 0);

            byte[] data_buffer = new byte[size];
            try
            {
                ReadExactly(stream, data_buffer, size);
            }
            catch (Exception ex) { Console.WriteLine($"Errore nella lettura della lunghezza: {ex.Message}"); return null; }
            return data_buffer;
        }
        public static void ReadExactly(NetworkStream stream, byte[] buffer, int size)
        {
            int total_read = 0;
            while (total_read < size)
            {
                int read = stream.Read(buffer, total_read, size - total_read);
                if (read == 0)
                    throw new Exception("Connessione chiusa");
                total_read += read;
            }
        }
        public static void Send(NetworkStream stream, byte[] data)
        {
            byte[] length_buffer = BitConverter.GetBytes(data.Length);
            stream.Write(length_buffer, 0, length_buffer.Length);
            stream.Write(data, 0, data.Length);
        }
    }
}