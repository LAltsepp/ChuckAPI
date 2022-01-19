using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace ChuckNorris.API
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");
            GetJokes();
        }

        public static void GetJokes()
        {
            string url = "https://api.icndb.com/jokes/random";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            using(var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                Joke joke = JsonConvert.DeserializeObject<Joke>(response);
                Console.WriteLine(joke.value);
            }
        }
    }
}
