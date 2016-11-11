using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simple_catowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void NavigateToPage()
        {
            webBrowser1.Navigate(textBox1.Text);

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)ConsoleKey.Enter)
            {
                NavigateToPage();
            }
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            // this is done to prevent dividing be 0 error
            if (e.CurrentProgress != 0 && e.MaximumProgress != 0)
            {
                // calculating the bar's complition
                int percentage = (int)(e.CurrentProgress * 100 / e.MaximumProgress);

                // ignore if the value is greater than 100
                if (percentage <= 100)
                {
                    toolStripProgressBar1.ProgressBar.Value = percentage;
                }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //if page is loaded progress bar is filled
            toolStripProgressBar1.ProgressBar.Value = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // when pressing the cat mode button all images that are loaded are swaped for a pretty cat 
            //http://www.zastavki.com/pictures/1920x1200/2011/Animals_Cats_beautiful_cat_031832_.jpg
            if (webBrowser1.Document != null)
            {
                //looking for an img tag in html code
                foreach (HtmlElement imgElemt in webBrowser1.Document.Images)
                {
                    imgElemt.SetAttribute("src", "http://www.zastavki.com/pictures/1920x1200/2011/Animals_Cats_beautiful_cat_031832_.jpg");
                }
            }
        }
    }
}
