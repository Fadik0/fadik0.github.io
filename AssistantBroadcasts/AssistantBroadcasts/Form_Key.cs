using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssistantBroadcasts
{
    public partial class Form_Key : Form
    {
        public DataAccess data_access;
        public string svc = string.Empty;
        public string state = string.Empty;

        private string POST(string url, string data)
        {
            string result = String.Empty;
            WebRequest request = null;           
            try
            {
                request = WebRequest.Create(url);
                request.Method = "POST";
                byte[] byteArray = Encoding.UTF8.GetBytes(data);
                if (string.Equals(svc,"GOODGAME"))
                    request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                result = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception e)
            {
                tB_key.Text = "Try again. Error: " + e.Message;
            }           
            return result;           
        }

        public Form_Key()
        {
            InitializeComponent();
        }

        private void Form_Key_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {                            
                string url = string.Empty;
                string data = string.Empty;
                switch (svc)
                {
                    case "GOODGAME":
                        {
                            url = "http://api2.goodgame.ru/oauth";                           
                            data = "{\"redirect_uri\": \"/oauth/receivecode\", \"client_id\": \"Assistant Broadcasts\", \"client_secret\": \"c94ivpilc8zei82c87rmfqfwg8waz5mz\", \"code\": \"" + tB_key.Text + "\", \"grant_type\": \"authorization_code\"}";
                            break;
                        }
                    case "TWITCH":
                        {
                            url = "https://api.twitch.tv/kraken/oauth2/token";
                            data = "client_id=lez95j7ulvp449k1w47nvi0amsfin94&";
                            data += "client_secret=b6p4psxuc794xfprjsl18i569h67bb&";
                            data += "grant_type=authorization_code&redirect_uri=https://api.twitch.tv/kraken/base&";
                            data += "code=" + tB_key.Text + "&state=" + state;
                            break;
                        }
                    default:
                        return;
                }
                if (tB_key.Text.Length < 30)
                {
                    e.Cancel = true;
                    return;
                }
                string result = POST(url, data);
                if (!string.IsNullOrEmpty(result))
                {
                    switch (svc)
                    {
                        case "GOODGAME":
                            data_access = JsonConvert.DeserializeObject<DataAccess>(result);
                            break;
                        case "TWITCH":
                            data_access = JsonConvert.DeserializeObject<DataAccess>(result);
                            break;
                    }                 
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void Form_Key_Load(object sender, EventArgs e)
        {
            this.Text = "Авторизация " + svc;
            btn_ok.Text = Properties.Resources.ok;
            btn_cancel.Text = Properties.Resources.cancel;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

        }
    }

    public class DataAccess
    {
        public string access_token { get; set; }

        public string refresh_token { get; set; }
    }
}
