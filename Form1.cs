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

namespace CONTACT_TRACING_APP_A3_Clavecillas
{
    public partial class Form1 : Form
    {
        public Form1()
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
            file.WriteLine();
            file.Close();

            MessageBox.Show("Your information has been saved");
        }
    }
}
