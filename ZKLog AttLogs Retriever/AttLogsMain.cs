using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace AttLogs
{
    public partial class AttLogsMain : Form
    {
        public AttLogsMain(string[] args)
        {
            InitializeComponent();
            connect(args[0]);
            String startDate = args[1] + " " + args[2];
            String endDate = args[3] + " " + args[4];
            string input = startDate + endDate; 
            // Remove all spaces
            string noSpaces = input.Replace(" ", string.Empty); 
            // Remove all non-alphanumeric characters
            string cleanString = Regex.Replace(noSpaces, @"[^a-zA-Z0-9]", string.Empty); 
            getRangeAndSave(startDate, endDate, cleanString);
            
        }
        //Connect to biometric device with port 4370
        public void connect(string ipAddress)
        {
            int idwErrorCode = 0;
            Cursor = Cursors.WaitCursor;
            bIsConnected = axCZKEM1.Connect_Net(ipAddress, Convert.ToInt32(4370));
            if (bIsConnected == true)
            {
                
                iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
                Environment.Exit(1);
            }
            Cursor = Cursors.Default;
        }

        //get range then save to file
        public async void getRangeAndSave(string startDate, string endDate, string fileName)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                Environment.Exit(1) ;
            }
            // Reset progress bar
            progressBar1.Value = 0; 
            // Simulate progress
            
            
            
            string strStartTime = startDate;
            string strEndTime = endDate;
            string filePath = $"\\records\\{fileName}.dat";

            string sdwEnrollNumber = "";
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;

            int idwErrorCode = 0;
            int iGLCount = 0;
            int iIndex = 0;

            Cursor = Cursors.WaitCursor;
            
            axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
            if (axCZKEM1.ReadTimeGLogData(iMachineNumber, strStartTime, strEndTime))//read all the attendance records to the memory
            {
                while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                           out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                {
                    iGLCount++;
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.Write(sdwEnrollNumber + "\t");
                        writer.Write(idwVerifyMode.ToString() + "\t");
                        writer.Write(idwInOutMode.ToString() + "\t");
                        writer.Write(idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString() + "\t");
                        writer.Write(idwWorkcode.ToString() + "\t");
                        writer.Write('\n');
                        /*lvLogs.Items.Add(iGLCount.ToString());
                        lvLogs.Items[iIndex].SubItems.Add(sdwEnrollNumber);//modify by Darcy on Nov.26 2009
                        lvLogs.Items[iIndex].SubItems.Add(idwVerifyMode.ToString());
                        lvLogs.Items[iIndex].SubItems.Add(idwInOutMode.ToString());
                        lvLogs.Items[iIndex].SubItems.Add(idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString());
                        lvLogs.Items[iIndex].SubItems.Add(idwWorkcode.ToString());*/
                        iIndex++;
                        for (int i = 0; i <= 100; i++)
                        {
                            // Update the progress bar
                            progressBar1.Value = i; // Wait for a short period to simulate work
                            await Task.Delay(50);
                        }
                        MessageBox.Show("Process Complete!");
                    }
                }
            }
            else
            {
                Cursor = Cursors.Default;
                axCZKEM1.GetLastError(ref idwErrorCode);

                if (idwErrorCode != 0)
                {
                    MessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString(), "Error");
                }
                else
                {
                    MessageBox.Show("No data from terminal returns!", "Error");
                }
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);//enable the device
            Cursor = Cursors.Default;

        }
        
        //Create Standalone SDK class dynamicly.
        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();

        private bool bIsConnected = false;//the boolean value identifies whether the device is connected
        private int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.
    }
} 
