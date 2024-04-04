//using IronXL; //Not anymore, Paid only and very slow

//For EPPlus
using OfficeOpenXml;
using System;
using System.IO;

using System.Data;
using System.Windows.Forms;
using System.Reflection.Emit;
using Microsoft.VisualBasic.ApplicationServices;
using RandomGameSelector.Properties;
using Microsoft.VisualBasic;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Data.Common;

namespace RandomGameSelector
{
    public partial class Form1 : Form
    {

        public class ExcelUtility //Taken from C# Corner because I don't know how to use EPPlus
        {
            public static DataTable ExcelDataToDataTable(string filePath, string sheetName, bool hasHeader = true)
            {
                var dt = new DataTable();
                var fi = new FileInfo(filePath);
                // Check if the file exists
                if (!fi.Exists)
                    throw new Exception("File " + filePath + " Does Not Exists");

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var xlPackage = new ExcelPackage(fi);
                // get the first worksheet in the workbook
                var worksheet = xlPackage.Workbook.Worksheets[sheetName];

                dt = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column].ToDataTable(c =>
                {
                    c.FirstRowIsColumnNames = true;
                });

                return dt;
            }
        }


        public void CreateSettings() {
            
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("Selector_Settings.txt");
                sw.WriteLine("Filename: Test_Game_Lists.xlsx");
                sw.WriteLine("Sheet:Games_List");
                sw.WriteLine("");
                sw.WriteLine("Column 1:Recordable");
                sw.WriteLine("Input 1:yes");
                sw.WriteLine("");
                sw.WriteLine("Column 2:Physical/Digital");
                sw.WriteLine("Input 2:Digital");
                sw.WriteLine("");
                sw.WriteLine("Column 3:NA");
                sw.WriteLine("Input 3:NA");
                sw.WriteLine("");
                sw.WriteLine("Place information from the xlsx file for the Filename, Sheet Name, Column name and required content of the cell.");
                sw.WriteLine("Put NA for ignored options except for the first four.");

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


        public string PullSettings() {
            String settings;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("Selector_Settings.txt");
                //Read the first line of text
                settings = sr.ReadLine();
                //Continue to read until you reach end of file
                while (settings != null)
                {
                    //write the line to console window
                    Console.WriteLine(settings);
                    //Read the next line
                    settings = sr.ReadLine();
                }
                //close the file
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
            return "setting";
        }


        private void PullGameLists()
        {

            PullSettings();


            ////Was from working with IronExcel but was slow and paid 
            //Load Worksheet and convert to DataTable
            //WorkBook workBook = WorkBook.Load("Game_Lists.xlsx");
            //WorkSheet workSheet = workBook.GetWorkSheet("Games_List");
            //DataTable dataTable = workSheet.ToDataTable(true);

            try
            {
                //Replace path with path to 
                var path = @"Test_Game_Lists.xlsx";
                var dataList = ExcelUtility.ExcelDataToDataTable(path, "Games_List", true);

                //remove unrecordable, Got this from somewhere don't remember where
                for (int i = dataList.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dataList.Rows[i];
                    if (dr["Recordable"].ToString() != "yes")
                        dr.Delete();
                }
                dataList.AcceptChanges();

                while (dataList.Columns.Count > 3) // Remove Columns past #
                {
                    dataList.Columns.RemoveAt(3);
                }

                ////Originally used dataGrids to show data
                //dataGridView.Visible = true;

                //Generating the random number and need the same for each row
                int RowNum = dataList.Rows.Count;
                Random rnd = new Random();
                int Bob = rnd.Next(RowNum);
                int Bobb = rnd.Next(RowNum);
                int Bobby = rnd.Next(RowNum);

                //Post to Labels
                label1.Text = dataList.Rows[Bob][0].ToString() + " \n" + dataList.Rows[Bob][1].ToString();
                label2.Text = dataList.Rows[Bobb][0].ToString() + " \n" + dataList.Rows[Bobb][1].ToString();
                label3.Text = dataList.Rows[Bobby][0].ToString() + " \n" + dataList.Rows[Bobby][1].ToString();


                //button2.Text = dataList.Rows[Bobb][0].ToString() + " \n" + dataList.Rows[Bobb][1].ToString();
                //= dataList.Rows[Bobb][0].ToString() + " \n" + dataList.Rows[Bobb][1].ToString();           
                //dataGridView.DataSource = dataList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }


        public Form1()
        {
            InitializeComponent();

            //Check for settings file and create if missing
            if (!File.Exists("Selector_Settings.txt"))
            {
                CreateSettings();
            }
            
            //Initial pull for random games
            PullGameLists();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e) //Pictures hide on click
        {
            pictureBox1.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Hide();
        }

        private void button1_Click(object sender, EventArgs e) //Showing pictures then rerolling choices
        {
            //Reset picture visibility and reroll random games
            pictureBox1.Show();
            pictureBox2.Show();
            pictureBox3.Show();
            PullGameLists();
        }
    }
}