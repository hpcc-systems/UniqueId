using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using com.lexisnexis.risk.lnuidnet;
using System.Collections.Concurrent;

namespace Tester_lnuidnet
{
    public partial class frmlnuidTester : Form
    {
        public frmlnuidTester()
        {
            InitializeComponent();
        }

        string nL = Environment.NewLine;
        private ConcurrentDictionary<string, object> mUIDS = new ConcurrentDictionary<string, object>();
        private const int GenIdAmount = 1000000;

        private void btnGenerateId_Click(object sender, EventArgs e)
        {
            try
            {
               
                LNUniqueIdGenerator oG = new LNUniqueIdGenerator();                
                string val = oG.getUniqueIdAsString();
                sbyte[] tIDDec = Base58.decode(val);

                string NewLine = Environment.NewLine;

               

                this.txtResult.Text = "LN UID: " + val;
                this.txtResult.Text += NewLine;
                txtResult.Text += "LN UID Bytes: " +  this.GetBytesToString(tIDDec);

                
                
            }//try
            catch (Exception ex)
            {
                txtResult.Text = "Error Occured: \n" + ex.ToString();
            }//catch
        }//btnGenerateId_Click


        private void btnPerformanceTest_Click(object sender, EventArgs e)
        {
            try
            {
              
                this.txtResult.Text = "Running performance test..." + nL;
                this.txtResult.Text += this.GenerateIds();
            }//try
            catch (Exception ex)
            {
                txtResult.Text += "Error Occured: \n" + ex.ToString();
            }//catch


        }//btnGenerate

        private void btnMultiThreadTest_Click(object sender, EventArgs e)
        {
            try
            {


                DateTime StartTime = DateTime.Now;
                this.txtResult.Text = "Starting: " + StartTime.ToString("yyyy/MM/dd HH:mm:ss.hhh") + nL;

                System.Threading.Thread oTh1 = new System.Threading.Thread(GenerateIds_2);
                oTh1.Start(); this.txtResult.Text += "Thread 1 Started" + nL; 

                System.Threading.Thread oTh2 = new System.Threading.Thread(GenerateIds_2);
                oTh2.Start(); this.txtResult.Text += "Thread 2 Started" + nL;
                
                System.Threading.Thread oTh3 = new System.Threading.Thread(GenerateIds_2);
                oTh3.Start(); this.txtResult.Text += "Thread 3 Started" + nL;

                System.Threading.Thread oTh4 = new System.Threading.Thread(GenerateIds_2);
                oTh4.Start(); this.txtResult.Text += "Thread 4 Started" + nL;

                System.Threading.Thread oTh5 = new System.Threading.Thread(GenerateIds_2);
                oTh5.Start(); this.txtResult.Text += "Thread 5 Started" + nL;

                System.Threading.Thread oTh6 = new System.Threading.Thread(GenerateIds_2);
                oTh6.Start(); this.txtResult.Text += "Thread 6 Started" + nL;

                System.Threading.Thread oTh7 = new System.Threading.Thread(GenerateIds_2);
                oTh7.Start(); this.txtResult.Text += "Thread 7 Started" + nL;

                System.Threading.Thread oTh8 = new System.Threading.Thread(GenerateIds_2);
                oTh8.Start(); this.txtResult.Text += "Thread 8 Started" + nL;

                System.Threading.Thread oTh9 = new System.Threading.Thread(GenerateIds_2);
                oTh9.Start(); this.txtResult.Text += "Thread 9 Started" + nL;

                System.Threading.Thread oTh10 = new System.Threading.Thread(GenerateIds_2);
                oTh10.Start(); this.txtResult.Text += "Thread 10 Started" + nL;

                System.Threading.Thread oTh11 = new System.Threading.Thread(GenerateIds_2);
                oTh11.Start(); this.txtResult.Text += "Thread 11 Started" + nL;

                System.Threading.Thread oTh12 = new System.Threading.Thread(GenerateIds_2);
                oTh12.Start(); this.txtResult.Text += "Thread 12 Started" + nL;

                System.Threading.Thread oTh13 = new System.Threading.Thread(GenerateIds_2);
                oTh13.Start(); this.txtResult.Text += "Thread 13 Started" + nL;

                System.Threading.Thread oTh14 = new System.Threading.Thread(GenerateIds_2);
                oTh14.Start(); this.txtResult.Text += "Thread 14 Started" + nL;

                System.Threading.Thread oTh15 = new System.Threading.Thread(GenerateIds_2);
                oTh15.Start(); this.txtResult.Text += "Thread 15 Started" + nL;

                System.Threading.Thread oTh16 = new System.Threading.Thread(GenerateIds_2);
                oTh16.Start(); this.txtResult.Text += "Thread 16 Started" + nL;

                System.Threading.Thread oTh17 = new System.Threading.Thread(GenerateIds_2);
                oTh17.Start(); this.txtResult.Text += "Thread 17 Started" + nL;

                System.Threading.Thread oTh18 = new System.Threading.Thread(GenerateIds_2);
                oTh18.Start(); this.txtResult.Text += "Thread 18 Started" + nL;

                System.Threading.Thread oTh19 = new System.Threading.Thread(GenerateIds_2);
                oTh19.Start(); this.txtResult.Text += "Thread 19 Started" + nL;

                System.Threading.Thread oTh20 = new System.Threading.Thread(GenerateIds_2);
                oTh20.Start(); this.txtResult.Text += "Thread 20 Started" + nL;
               
                while (oTh1.IsAlive || oTh2.IsAlive || oTh3.IsAlive || oTh4.IsAlive || oTh5.IsAlive || oTh6.IsAlive || oTh7.IsAlive ||
                         oTh8.IsAlive || oTh9.IsAlive || oTh10.IsAlive || oTh11.IsAlive || oTh12.IsAlive || oTh13.IsAlive || oTh14.IsAlive ||
                          oTh15.IsAlive || oTh16.IsAlive || oTh17.IsAlive || oTh18.IsAlive || oTh19.IsAlive || oTh20.IsAlive)
                {
                    this.txtResult.Text += "Threads still running: going to sleep." + nL; 
                    Thread.Sleep(2000);
                    

                }//while


                int IDsAmount = GenIdAmount * 20;
                DateTime EndTime = DateTime.Now;
                double milliSecsTaken = (EndTime - StartTime).TotalMilliseconds;
                double avgMilSecs = (double)(milliSecsTaken / IDsAmount);

                
                this.txtResult.Text += "Completed generating " + IDsAmount.ToString() + " UIDs." + nL;
                this.txtResult.Text += "Finished: " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.hhh") + nL;
                this.txtResult.Text += "Total milliseconds taken: " + milliSecsTaken.ToString() + nL;
                this.txtResult.Text += "Avg. milliseconds per id: " + avgMilSecs.ToString();

              


            }//try
            catch (Exception ex)
            {
                txtResult.Text = "Error Occured: \n" + ex.ToString();
            }//catch


        }//btnMultiThreadTest_Click

        private void GenerateIds_2()
        {
            
            DateTime StartTime = DateTime.Now;
            for (int i = 1; i <= GenIdAmount; i++)
            {
                LNUniqueIdGenerator oG = new LNUniqueIdGenerator();                              
                string val = oG.getUniqueIdAsString();

            }//for
            DateTime EndTime = DateTime.Now;
            double milliSecsTaken = (EndTime - StartTime).TotalMilliseconds;
            double avgMilSecs = (double)(milliSecsTaken / GenIdAmount);

            String sRet = "";
            sRet = "Number of Ids Generated: " + GenIdAmount.ToString();
            sRet += nL + "Total milliseconds taken: " + milliSecsTaken.ToString();
            sRet += nL + "Avg. milliseconds per id: " + avgMilSecs.ToString();
            

        }//GenerateIds


        String Error = "";
        private void GenerateIds_3()
        {
            
            DateTime StartTime = DateTime.Now;
            for (int i = 1; i <= GenIdAmount; i++)
            {
                LNUniqueIdGenerator oG = new LNUniqueIdGenerator();
                             
                string val = oG.getUniqueIdAsString();
                if (!this.mUIDS.TryAdd(val, ""))
                {
                    Error = val + ": id already exists.";

                }

            }//for
            DateTime EndTime = DateTime.Now;
            double milliSecsTaken = (EndTime - StartTime).TotalMilliseconds;
            double avgMilSecs = (double)(milliSecsTaken / GenIdAmount);

            String sRet = "";
            sRet = "Number of Ids Generated: " + GenIdAmount.ToString();
            sRet += nL + "Total milliseconds taken: " + milliSecsTaken.ToString();
            sRet += nL + "Avg. milliseconds per id: " + avgMilSecs.ToString();


        }//GenerateIds

        private String GenerateIds(int GenIdAmount = 1000000)
        {
            DateTime StartTime = DateTime.Now;            
            for (int i = 1; i <= GenIdAmount; i++)
            {
                LNUniqueIdGenerator oG = new LNUniqueIdGenerator();
                               
                string val = oG.getUniqueIdAsString();

            }//for
            DateTime EndTime = DateTime.Now;
            double milliSecsTaken = (EndTime - StartTime).TotalMilliseconds;
            double avgMilSecs = (double)(milliSecsTaken / GenIdAmount);

            String sRet = "";
            sRet = "Number of Ids Generated: " + GenIdAmount.ToString();
            sRet += nL + "Total milliseconds taken: " + milliSecsTaken.ToString();
            sRet += nL + "Avg. milliseconds per id: " + avgMilSecs.ToString();
            return sRet;

        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            txtResult.SelectionStart = txtResult.Text.Length;
            txtResult.ScrollToCaret();
            this.Refresh();
            

        }

        private void btnRunWithCheckDupes_Click(object sender, EventArgs e)
        {

            try
            {
                
                this.mUIDS.Clear();

                this.txtResult.Text = "Running test..." + nL;
                DateTime StartTime = DateTime.Now;
                this.txtResult.Text = "Starting: " + StartTime.ToString("yyyy/MM/dd HH:mm:ss.hhh") + nL;

                Thread oTh1 = new Thread(GenerateIds_3); oTh1.Start();
                this.txtResult.Text += "Thread 1 Started" + nL;

                Thread oTh2 = new Thread(GenerateIds_3); oTh2.Start();
                this.txtResult.Text += "Thread 2 Started" + nL;

                Thread oTh3 = new Thread(GenerateIds_3); oTh3.Start();
                this.txtResult.Text += "Thread 3 Started" + nL;

                Thread oTh4 = new Thread(GenerateIds_3); oTh4.Start();
                this.txtResult.Text += "Thread 4 Started" + nL;

                Thread oTh5 = new Thread(GenerateIds_3); oTh5.Start();
                this.txtResult.Text += "Thread 5 Started" + nL;

                Thread oTh6 = new Thread(GenerateIds_3); oTh6.Start();
                this.txtResult.Text += "Thread 6 Started" + nL;

                Thread oTh7 = new Thread(GenerateIds_3); oTh7.Start();
                this.txtResult.Text += "Thread 7 Started" + nL;

                Thread oTh8 = new Thread(GenerateIds_3); oTh8.Start();
                this.txtResult.Text += "Thread 8 Started" + nL;

                Thread oTh9 = new Thread(GenerateIds_3); oTh9.Start();
                this.txtResult.Text += "Thread 9 Started" + nL;

                Thread oTh10 = new Thread(GenerateIds_3); oTh10.Start();
                this.txtResult.Text += "Thread 10 Started" + nL;



                while (oTh1.IsAlive || oTh2.IsAlive || oTh3.IsAlive || oTh4.IsAlive || oTh5.IsAlive
                    || oTh6.IsAlive || oTh7.IsAlive || oTh8.IsAlive || oTh9.IsAlive || oTh10.IsAlive)
                {
                    this.txtResult.Text += "Threads still running: going to sleep." + nL;
                    Thread.Sleep(2000);


                }//while


                int IDsAmount = GenIdAmount * 10;
                DateTime EndTime = DateTime.Now;
                double milliSecsTaken = (EndTime - StartTime).TotalMilliseconds;
                double avgMilSecs = (double)(milliSecsTaken / IDsAmount);

                if (Error != "") this.txtResult.Text += "Completed processing; dupe IDs generated. " + Error + nL;
                else this.txtResult.Text += "Completed generating " + IDsAmount.ToString() + " UIDs; no dupe UIDs generated." + nL;
                this.txtResult.Text += "Finished: " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.hhh") + nL;
                this.txtResult.Text += "Total milliseconds taken: " + milliSecsTaken.ToString() + nL;
                this.txtResult.Text += "Avg. milliseconds per id: " + avgMilSecs.ToString();
                

                this.mUIDS.Clear();
                this.mUIDS = null;
                this.mUIDS = new ConcurrentDictionary<string, object>();







            }//try
            catch (Exception ex)
            {
                txtResult.Text += "Error Occured: \n" + ex.ToString();
                this.mUIDS.Clear();
            }//catch

        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            try
            {
                LNUniqueIdGenerator oLNG = new LNUniqueIdGenerator();
                sbyte[] osBytes = Base58.decode(this.txtDecodeID.Text);
                this.txtResult.Text = "Original Bytes: "  + GetBytesToString(osBytes) + nL;
                string sTime = oLNG.getTimeFromBinaryId(osBytes);
                this.txtResult.Text += "Time Component: " + sTime;


               


            }//try
            catch (Exception ex)
            {
                txtResult.Text += "Error Occured: \n" + ex.ToString();
            }//catch

        }

        private string GetBytesToString(sbyte[] oBytes)
        {
            string sVal = "";
            for (int i = 0; i < oBytes.Length; i++)
            {
                sVal += oBytes[i].ToString() + ", ";                
            }//for

            sVal = sVal.Trim().TrimEnd(',');
            return "{ " + sVal + " }";
        }


     


    }//class
}//namespace
