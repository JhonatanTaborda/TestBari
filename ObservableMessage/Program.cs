using System;
using System.IO;
using System.Net;
using System.Reactive.Linq;

namespace ObservableMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new Message();

            var observable = Observable
            .Interval(TimeSpan.FromSeconds(5));

            var observableQueue = Observable
            .Interval(TimeSpan.FromSeconds(8));

            //mensagem automática
            observable.Subscribe((x) =>
            {

                Console.WriteLine(message.ReturnMessage());
                Console.WriteLine();
                Console.WriteLine("===============================================");
                Console.WriteLine();

            });

            //mensagem por serviços
            observableQueue.Subscribe((x) =>
            {

                message.SendMessage();
                Console.WriteLine(message.ReadMessage());
                Console.WriteLine();
                Console.WriteLine("===============================================");
                Console.WriteLine();
            });

            Console.ReadKey();
        }
    }

    public class Message
    {
        public string ReturnMessage()
        {
            string responseFromServer = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8081/api/ReceiveMessage/GetMessage");
            request.Method = "GET";

            var response = request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }

            response.Close();

            return responseFromServer;

        }


        public void SendMessage()
        {
            string responseFromServer = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8082/api/SendMessage?queue=list");
            request.Method = "GET";

            var response = request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }

            response.Close();
        }

        public string ReadMessage()
        {
            string responseFromServer = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8081/api/ReceiveMessage?queue=list");
            request.Method = "GET";

            var response = request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }

            response.Close();

            return responseFromServer;

        }

    }
}
