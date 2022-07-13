using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CONTACT_TRACING_APP_A3_Clavecillas
{
    public partial class contactTracingApp : Form
    {
        public contactTracingApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            StreamWriter file = new StreamWriter(@"C:\Users\Christian\Desktop\OOP\contact tracing informations.txt", true);
            file.WriteLine("Name: " + surnameTextBox.Text + ", " + firstNameTextBox.Text);
            file.WriteLine("Date: " + dateTextBox.Text + "   Time-In: " + timeinTextBox.Text);
            file.WriteLine("Age: " + ageTextBox.Text + "   Gender: " + genderTextBox.Text);
            file.WriteLine("Email: " + emailTextBox.Text + "   Phone Number: " + phoneNumberTextBox.Text);
            file.WriteLine("Address: " + addressTextBox.Text);
            file.WriteLine("Experiencing: ");
            if (expSoreThroat.Checked)
            {
                file.WriteLine("   Sore Throat");
                expSoreThroat.Checked = false;
            }
            if (expBodyPains.Checked)
            {
                file.WriteLine("   Body Pains");
                expBodyPains.Checked = false;
            }
            if (expHeadache.Checked)
            {
                file.WriteLine("   Headache");
                expHeadache.Checked = false;
            }
            if (expFever.Checked)
            {
                file.WriteLine("   Fever for the past few days");
                expFever.Checked = false;
            }
            file.WriteLine("Had: ");
            if (hadContact.Checked)
            {
                file.WriteLine("   contact with anyone with fever, cough, colds, and sore throat in the past two (2) weeks");
                hadContact.Checked = false;
            }
            if (hadTravelledOutsidePH.Checked)
            {
                file.WriteLine("   travelled outside of the Philippines in the last fourteen (14) days");
                hadTravelledOutsidePH.Checked = false;
            }
            if (hadTravelledAroundNCR.Checked)
            {
                file.WriteLine("   travelled to any area in NCR aside from his/her home");
                hadTravelledAroundNCR.Checked = false;
            }
            file.WriteLine();
            file.Close();

            MessageBox.Show("Your information has been saved");

            surnameTextBox.Clear();
            firstNameTextBox.Clear();
            dateTextBox.Clear();
            ageTextBox.Clear();
            genderTextBox.Clear();
            emailTextBox.Clear();
            phoneNumberTextBox.Clear();
            timeinTextBox.Clear();
            addressTextBox.Clear();
        }

        private void displayBtn_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Christian\Desktop\OOP\contact tracing informations.txt";
            StreamReader reader = new StreamReader(path);
            string contactTracingProfiles = reader.ReadToEnd();
            displayRichTextBox.Text = contactTracingProfiles.ToString();
            reader.Close();
        }

        private void scanBtn_Click(object sender, EventArgs e)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Program Files (x86)\CodeTwo\QR Code Desktop Reader & Generator\CodeTwoQRCode.exe";
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;
            int exitCode;
            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();

                string QRinfo = Clipboard.GetText();
                string[] lines = QRinfo.Split('\n');
                foreach (string ln in lines)
                {
                    HiddenListBox.Items.Add(ln.Trim());
                }

                surnameTextBox.Text = lines[0];
                firstNameTextBox.Text = lines[1];
                ageTextBox.Text = lines[2];
                genderTextBox.Text = lines[3];
                emailTextBox.Text = lines[4];
                phoneNumberTextBox.Text = lines[5];
                addressTextBox.Text = lines[6];

                Clipboard.Clear();

                exitCode = proc.ExitCode;
            }
        }
    }
}
