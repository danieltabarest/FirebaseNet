using FirebaseNet.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        //place your server api key here for testing purposes
        private const string ServerApiKey = "AAAAF44dQ6Q:APA91bFVmK3v6uv5wujbcreheD5zgwPGWPXJFprhq_IQyvoqaLQebbxwC1fCnsEHtRj4t3ubEEldE9AQ2exY65sWo-hqPcIhDSmTeUOR-jENEUOL6moAe3Z7x1LxklqS0e2wCDlCj4Vw";



        static void Main(string[] args)
        {
            try
            {
                FireBasePush push = new FireBasePush(ServerApiKey);
                push.SendPush(new PushMessage() { body = "pruebas con ZY32223PNK", color = "ZY32223PNK", identifier = "ZY32223PNK" }, "/topics/ZY32223PNK");

                Console.ReadKey();
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
