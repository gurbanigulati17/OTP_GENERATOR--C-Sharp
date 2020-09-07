using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Collections.Specialized;
using System.IO;

namespace OTPSMSCode
{
    public partial class Form1 : Form
    {
		string randomNumber;
		public Form1()
        {
			
            InitializeComponent();
        }

		private void btnLogin_Click(object sender, EventArgs e)
        {
			String result;
			string apiKey = "V0JrtO6uz2c-hXmUhFgrdSLsMW8OS9CaeDNOFXcCON";
			string numbers = txtPhone.Text; // in a comma seperated list
			 sender = "GEET";
			string name = txtName.Text;
			Random rnd = new Random();
			randomNumber = (rnd.Next(100000,9999999)).ToString();
			Console.WriteLine(randomNumber);
			//string message = "Hey"+name+"Your OTP is"+randomNumber;
			string message = "Hey "+name+" Your OTP is " + randomNumber;
			Console.WriteLine(sender);
			Console.WriteLine(message);

			//String url = "https://api.textlocal.com/send/?apikey="+apiKey +"&numbers="+ numbers +"&message="+message+"&sender="+sender;
			//refer to parameters to complete correct url string
			String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + sender;
			Console.WriteLine(url);
			StreamWriter myWriter = null;
			HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

			objRequest.Method = "POST";
			objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
			objRequest.ContentType = "application/x-www-form-urlencoded";
			try
			{
				myWriter = new StreamWriter(objRequest.GetRequestStream());
				myWriter.Write(url);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				myWriter.Close();
			}

			HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
			using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
			{
				result = sr.ReadToEnd();
				// Close and clean up the StreamReader
				sr.Close();
			}
	
		MessageBox.Show("OTP send successfully "+message);

		}

	/*	private void btnLogin_Click(object sender, EventArgs e)
        {
			string customerId = "71E73325-1C5C-4196-881E-D3750AD05C40";
			string apiKey = "WybgrNsoDPaZ2z6m0HqoEeOcw8eWl+PFUWtTtNXv4yaacb9nYiU2FF42GuOGqaF7pFYPKFW06EMYvF7RVDM0VQ==";

			string phoneNumber = txtPhone.Text;

			string message = "You're scheduled for a dentist appointment at 2:30PM.";
			string messageType = "ARN";

			try
			{
				MessagingClient messagingClient = new MessagingClient(customerId, apiKey);
				RestClient.TelesignResponse telesignResponse = messagingClient.Message(phoneNumber, message, messageType);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			Console.WriteLine("Press any key to quit.");
			Console.ReadKey();
		}*/


		private void btnVerify_Click(object sender, EventArgs e)
        {
			if(txtVerOTP.Text == randomNumber)
            {
				MessageBox.Show("Login Successfully");
            }
            else
            {
				MessageBox.Show("Wrong OTP. Try Again");
            }
        }

    }
}
