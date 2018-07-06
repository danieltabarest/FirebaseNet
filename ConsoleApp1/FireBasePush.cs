using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp1
{
    public class FireBasePush
    {
        private string FIREBASE_URL = "https://fcm.googleapis.com/fcm/send";
        private string KEY_SERVER;
        private string SenderId;
        public FireBasePush(String key_server)
        {
            this.KEY_SERVER = key_server;
            this.SenderId = "1006590962368";
        }
        public async Task SendPush(PushMessage message, string DeviceID)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://fcm.googleapis.com/fcm/");
                client.DefaultRequestHeaders
                                      .Accept
                                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", "=" + this.KEY_SERVER);
                client.DefaultRequestHeaders.Add("Sender", "id=" + SenderId);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
                var data = new
                {
                    to = "/topics/general",
                    //topic = "general",
                    //to = "/topics/ZY32223PNK",
                    notification = new
                    {
                        body = message.body,
                        color = message.color,
                        title = "Mensaje Ingetrans",
                        icon = "icon",
                        identifier = message.identifier
                    }

                };
                var json = JsonConvert.SerializeObject(data);
                request.Content = new StringContent(json,
                                                    Encoding.UTF8,
                                                    "application/json");//CONTENT-TYPE header

                var data1 = await client.PostAsync("send", request.Content);
                var d = data1.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {

            }

        }
    }
    public class PushMessage
    {
        private string _to;
        private string _body, _color, _identifier;
        private PushMessageData _notification;

        private dynamic _data;
        private dynamic _click_action;
        public dynamic data
        {
            get { return _data; }
            set { _data = value; }
        }

        public string identifier
        {
            get { return _identifier; }
            set { _identifier = value; }
        }
        public string body
        {
            get { return _body; }
            set { _body = value; }
        }

        public string color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string to
        {
            get { return _to; }
            set { _to = value; }
        }


        public PushMessageData notification
        {
            get { return _notification; }
            set { _notification = value; }
        }

        public dynamic click_action
        {
            get
            {
                return _click_action;
            }

            set
            {
                _click_action = value;
            }
        }
    }

    public class PushMessageData
    {
        private string _title;
        private string _text;
        private string _sound = "default";
        private string _click_action;
        public string sound
        {
            get { return _sound; }
            set { _sound = value; }
        }

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string click_action
        {
            get
            {
                return _click_action;
            }

            set
            {
                _click_action = value;
            }
        }
    }
}
