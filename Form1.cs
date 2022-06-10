﻿using System;
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
        }
    }
}
