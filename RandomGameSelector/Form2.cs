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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Reflection.Emit;
using System.Reflection.Metadata;
//using System.Reflection.Emit;
//using Microsoft.VisualBasic.ApplicationServices;
//using RandomGameSelector.Properties;
//using Microsoft.VisualBasic;
//using System.Reflection.Metadata;
//using System.Data.Common;

namespace RandomGameSelector
{
    public partial class Form2 : Form
    {
        //Pull Current Settings
        public string[] PullSettings()
        {
            String[] Settings = new string[10];
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("Selector_Settings.txt");
                //Read Filename, Sheet, Columns, and required Cell contents
                Settings[0] = sr.ReadLine().Replace("Filename:", "").TrimStart(' ');
                Settings[1] = sr.ReadLine().Replace("Sheet:", "").TrimStart(' ');
                sr.ReadLine();
                Settings[2] = sr.ReadLine().Replace("Column 1:", "").TrimStart(' ');
                Settings[3] = sr.ReadLine().Replace("Input 1:", "").TrimStart(' ');
                sr.ReadLine();
                Settings[4] = sr.ReadLine().Replace("Column 2:", "").TrimStart(' ');
                Settings[5] = sr.ReadLine().Replace("Input 2:", "").TrimStart(' ');
                sr.ReadLine();
                Settings[6] = sr.ReadLine().Replace("Column 3:", "").TrimStart(' ');
                Settings[7] = sr.ReadLine().Replace("Input 3:", "").TrimStart(' ');
                sr.ReadLine();
                Settings[8] = sr.ReadLine().Replace("Column 4:", "").TrimStart(' ');
                Settings[9] = sr.ReadLine().Replace("Input 4:", "").TrimStart(' ');

                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            return Settings;
        }

        private void WriteSettings(string[] WSettings)
        {

            //Write Current Settings
            textBox1.Text = WSettings[0].ToString();
            textBox2.Text = WSettings[1].ToString();
            textBox3.Text = WSettings[2].ToString();
            textBox4.Text = WSettings[3].ToString();
            textBox5.Text = WSettings[4].ToString();           //Write Current Settings
            textBox6.Text = WSettings[5].ToString();
            textBox7.Text = WSettings[6].ToString();
            textBox8.Text = WSettings[7].ToString();
            textBox9.Text = WSettings[8].ToString();
            textBox10.Text = WSettings[9].ToString();
        }

        private void SaveSettings()
        {

            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("Selector_Settings.txt");
                sw.WriteLine("Filename:" + textBox1.Text);
                sw.WriteLine("Sheet:" + textBox2.Text);
                sw.WriteLine("");
                sw.WriteLine("Column 1:" + textBox3.Text);
                sw.WriteLine("Input 1:" + textBox4.Text);
                sw.WriteLine("");
                sw.WriteLine("Column 2:" + textBox5.Text);
                sw.WriteLine("Input 2:" + textBox6.Text);
                sw.WriteLine("");
                sw.WriteLine("Column 3:" + textBox7.Text);
                sw.WriteLine("Input 3:" + textBox8.Text);
                sw.WriteLine("");
                sw.WriteLine("Column 4:" + textBox9.Text);
                sw.WriteLine("Input 4:" + textBox10.Text);
                sw.WriteLine("");
                sw.WriteLine("Locked:");
                sw.WriteLine("");
                sw.WriteLine("OR");
                sw.WriteLine("");
                sw.WriteLine("AND");
                sw.WriteLine("");
                sw.WriteLine("Place information from the xlsx file for the Filename, Sheet Name, Column name and required content of the cell.");
                sw.WriteLine("Put NA for ignored Columns except for the first");
                sw.WriteLine("Put AND for Column 4 for OR Operator with 3/4 options");
                sw.WriteLine("Input xlsx needs Title and Console in first two rows");

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }


        public Form2()
        {
            String[] Settings = new string[10];
            Settings = PullSettings();

            InitializeComponent();
            WriteSettings(Settings);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SaveSettings();
            String[] SettingsNew = new string[20];
            SettingsNew = PullSettings();
            WriteSettings(SettingsNew);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { textBox3.Text = "NA"; textBox3.ReadOnly = true; }
            if (!checkBox1.Checked) { textBox3.ReadOnly = false; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { textBox5.Text = "NA"; textBox5.ReadOnly = true; }
            if (!checkBox2.Checked & !checkBox5.Checked & !checkBox8.Checked) { textBox5.ReadOnly = false; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) { textBox7.Text = "NA"; textBox7.ReadOnly = true; }
            if (!checkBox3.Checked & !checkBox6.Checked & !checkBox9.Checked) { textBox7.ReadOnly = false; }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked) { textBox9.Text = "NA"; textBox9.ReadOnly = true; }
            if (!checkBox4.Checked & !checkBox7.Checked & !checkBox10.Checked) { textBox9.ReadOnly = false; }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked) { textBox5.Text = "OR"; textBox5.ReadOnly = true; }
            if (!checkBox2.Checked & !checkBox5.Checked & !checkBox8.Checked) { textBox5.ReadOnly = false; }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked) { textBox7.Text = "OR"; textBox7.ReadOnly = true; }
            if (!checkBox3.Checked & !checkBox6.Checked & !checkBox9.Checked) { textBox7.ReadOnly = false; }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked) { textBox9.Text = "OR"; textBox9.ReadOnly = true; }
            if (!checkBox4.Checked & !checkBox7.Checked & !checkBox10.Checked) { textBox9.ReadOnly = false; }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked) { textBox5.Text = "AND"; textBox5.ReadOnly = true; }
            if (!checkBox2.Checked & !checkBox5.Checked & !checkBox8.Checked) { textBox5.ReadOnly = false; }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked) { textBox7.Text = "AND"; textBox7.ReadOnly = true; }
            if (!checkBox3.Checked &!checkBox6.Checked & !checkBox9.Checked) { textBox7.ReadOnly = false; }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked) { textBox9.Text = "AND"; textBox9.ReadOnly = true; }
            if (!checkBox4.Checked & !checkBox7.Checked & !checkBox10.Checked) { textBox9.ReadOnly = false; }
        }
    }
}

