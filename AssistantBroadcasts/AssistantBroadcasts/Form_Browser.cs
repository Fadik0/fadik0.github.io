using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssistantBroadcasts
{
    public partial class Form_Browser : Form
    {
        public string url;
        public bool authorization = false;      

        public Form_Browser()
        {
            InitializeComponent();
        }

        private void Form_Browser_Load(object sender, EventArgs e)
        {            
            webBrowser.Url = new Uri(url);
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if ((webBrowser.Url.AbsoluteUri.IndexOf("https://api.twitch.tv/kraken/base#access_token=") == 0 || webBrowser.Url.AbsoluteUri.IndexOf("http://api.vk.com/blank.html#access_token=") == 0) && authorization)
            {               
                this.DialogResult = DialogResult.Yes;
            }            
            if (!authorization || webBrowser.Url.AbsoluteUri.IndexOf("http://www.twitch.tv/") == 0)
            {        
                webBrowser.Navigate("javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((new Date()).getTime()-1e11).toGMTString());}}}})())");
                this.DialogResult = DialogResult.No;
            }
            
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
