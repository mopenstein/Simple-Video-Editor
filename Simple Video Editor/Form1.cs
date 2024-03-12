using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;

namespace Simple_Video_Editor
{
    public partial class Form1 : Form
    {
        public static double Evaluate(string expression)
        {
            //found at https://stackoverflow.com/questions/5838918/evaluate-string-with-math-operators
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }

        public Form1()
        {
            InitializeComponent();
        }

        static string ffmpeg_location = "C:\\ffmpegY\\ffmpeg.exe";
        static string temp_folder = Path.GetDirectoryName(ffmpeg_location) + "\\temp_folder\\";

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            picStatus.Tag = DateTime.Now.Ticks;
            try
            {
                if (!Directory.Exists(temp_folder)) Directory.CreateDirectory(temp_folder);
            }
            catch
            {
                AddLog("Failed to create temp folder");
            }

            try
            {
                LoadSplitsCache();
            }
            catch { }
        }

        void process_Exited(object sender, EventArgs e)
        {
            // Handle exit here
            AddVLog("exited!!!!!!!");
            isProcessRunning = false;
        }


        private TimeSpan procTDur = new TimeSpan();

        void ProccesErrorDataReceived(object sender, DataReceivedEventArgs e)
        {

            if (isProcessRunning)
            {

                if (picStatus.BackColor == Color.Green && (DateTime.Now.Ticks - (long)picStatus.Tag) > 5000000)
                {
                    //AddLog("A " + DateTime.Now.Ticks.ToString() + ", " + picStatus.Tag.ToString());
                    picStatus.Tag = DateTime.Now.Ticks;
                    picStatus.BackColor = Color.Cyan;
                    picStatusB.BackColor = Color.Green;
                }
                else if (picStatus.BackColor != Color.Green && (DateTime.Now.Ticks - (long)picStatus.Tag) > 5000000)
                {
                    //AddLog("B " + DateTime.Now.Ticks.ToString() + ", " + picStatus.Tag.ToString());
                    picStatus.Tag = DateTime.Now.Ticks;
                    picStatus.BackColor = Color.Green;
                    picStatusB.BackColor = Color.Cyan;
                }
            }
            // Handle error here
            if (e.Data != null)
            {
                string line = e.Data.ToString();
                string dur = "";
                AddVLog(e.Data.ToString());
                int a = line.IndexOf("Duration");
                if (a >= 0)
                {
                    int b = line.IndexOf(",", a + 1);
                    dur = line.Substring(a + 10, b - a - 10);
                    //procTDur = TimeSpan.Parse(dur);
                    AddVLog("Found length " + dur.ToString());
                    //pbarReset();
                }

                try
                {
                    string find = "time=";
                    a = line.IndexOf(find);
                    if (a >= 0)
                    {
                        int b = line.IndexOf(" ", a + 1);
                        dur = line.Substring(a + find.Length, b - a - find.Length);
                        //tdur = TimeSpan.Parse(dur);
                        //AddLog(TimeSpan.Parse(dur).Ticks.ToString() + " - " + tdur.Ticks.ToString() + " - " + (TimeSpan.Parse(dur).Ticks / tdur.Ticks).ToString());
                        //AddLog(dur + " - " + tdur.ToString());
                        int percent = (int)((TimeSpan.Parse(dur).TotalSeconds / procTDur.TotalSeconds) * 100);
                        pbarUpdate(percent);
                        //AddLog(percent.ToString() + "%");
                    }
                    //AddLog("Err: " + e.Data.ToString());
                }
                catch
                { }
            }


        }
        void ProccesOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Handle output here using e.Data
            if (e.Data != null)
            {
                AddVLog("Err: " + e.Data.ToString());
            }
        }

        private void AddLog(string msg)
        {
            try
            {
                if (!InvokeRequired)
                {
                    txtLog.AppendText(msg + "\r\n");
                }
                else
                {
                    Invoke(new Action<string>(AddLog), msg);
                }
            }
            catch { }

        }

        private void AddVLog(string msg)
        {
            try
            {
                if (!InvokeRequired)
                {
                    txtVLog.AppendText(msg + "\r\n");
                }
                else
                {
                    Invoke(new Action<string>(AddVLog), msg);
                }
            }
            catch { }

        }


        private List<string> GetFiles(string folder)
        {
            if (!Directory.Exists(folder)) return new List<string>();
            if (folder == "") return new List<string>();
            List<string> str = new List<string>();
            int i = 0;
            foreach (string file in Directory.EnumerateFiles(folder, "*.*"))
            {
                string fe = Path.GetExtension(file.ToString());
                if (fe != ".filter" && fe != ".txt" && fe != ".threshold" && fe != ".options") str.Add(file.ToString());
                i++;
            }
            return str;
        }

        private void emptyTemp()
        {
            string folder = temp_folder;
            List<string> files = GetFiles(folder);
            AddLog("Cleaning up temp folder.");
            foreach (string s in files)
            {
                try
                {
                    File.Delete(s);
                }
                catch (Exception e)
                {
                    AddLog(e.ToString());
                }
            }
        }

        private int[] getVideoDimensions(string file)
        {
            //ffprobe -v error -show_entries stream=width,height -of csv=p=0:s=x input.m4v
            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            string fname_noext = Path.GetFileNameWithoutExtension(file);
            string fname_root = Path.GetDirectoryName(file);

            string filename = file;

            AddLog("Getting video Dimensions " + file.ToString());

            proc.StartInfo.Arguments = "-i \"" + filename + "\"";
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            //proc.StartInfo.CreateNoWindow = true;

            if (!proc.Start())
            {
                AddLog("Error starting");
            }
            StreamReader reader = proc.StandardError;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                //AddLog(line.ToString());
                int a = line.IndexOf("Stream #");
                if (a >= 0)
                {
                    string[] st = line.Split(' ');
                    foreach (string str in st)
                    {
                        int b = str.IndexOf("x");

                        if (b > 0) {

                            //dur = line.Substring(a + 10, b - a - 10);
                            //AddLog(str.Substring(0, str.Length-1));
                            string tstr = str;
                            if (str.Substring(str.Length - 1, 1) == ",")
                            {
                                tstr = str.Substring(0, str.Length - 1);
                            }
                            string[] spl = tstr.Split('x');
                            int v1;
                            int v2;
                            if (Int32.TryParse(spl[0], out v1) && Int32.TryParse(spl[1], out v2))
                            {

                                AddLog("Found dimensions: " + tstr);
                                int[] tx;
                                tx = new int[2];
                                tx[0] = v1;
                                tx[1] = v2;
                                return tx;
                            }
                        }
                    }
                    //AddLog("Found length " + dur.ToString());
                }
            }
            proc.Close();
            try
            {
                proc.Kill();
            }
            catch { }
            int[] t;
            t = new int[2];
            t[0] = 0;
            t[1] = 0;
            return t;
        }

        private void pbarMax()
        {
            picStatus.BackColor = Color.Red;
            picStatusB.BackColor = Color.Red;
            pbar.Value = pbar.Maximum;
        }

        private void pbarReset()
        {
            try
            {
                if (!InvokeRequired)
                {
                    picStatus.BackColor = Color.Red;
                    picStatusB.BackColor = Color.Red;
                    pbar.Maximum = 100;
                    pbar.Minimum = 0;
                    pbar.Value = 0;
                }
                else
                {
                    Invoke(new Action(pbarReset));
                }
            }
            catch { }
        }

        private void pbarUpdate(int val)
        {
            try
            {
                if (!InvokeRequired)
                {
                    if (val >= pbar.Minimum && val <= pbar.Maximum)
                    {
                        //picStatus.BackColor = Color.Green;
                        Application.DoEvents();
                        pbar.Value = val;
                    }
                }
                else
                {
                    Invoke(new Action<int>(pbarUpdate), val);
                }
            }
            catch { }
        }

        private string[] getDurationAndAudioFilter(string file)
        {

            pbarReset();

            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            string fname_noext = Path.GetFileNameWithoutExtension(file);
            string fname_root = Path.GetDirectoryName(file);

            string filename = file;
            string audio_filter = "";
            string dur = "";
            AddLog("Getting Duration and Audio Filter string for " + file.ToString());
            //get duration
            proc.StartInfo.Arguments = "-i " + "\"" + filename + "\"" + " -af replaygain -f null /dev/null";

            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;


            if (!proc.Start())
            {
                Console.WriteLine("Error starting");
            }
            StreamReader reader = proc.StandardError;
            string line;
            TimeSpan tdur = new TimeSpan();
            while ((line = reader.ReadLine()) != null)
            {
                //AddLog(line);
                int a = line.IndexOf("Duration");
                if (a >= 0)
                {
                    int b = line.IndexOf(",", a + 1);
                    dur = line.Substring(a + 10, b - a - 10);
                    tdur = TimeSpan.Parse(dur);
                    AddLog("Found length " + dur.ToString());
                }

                string find = "time=";
                a = line.IndexOf(find);
                if (a >= 0)
                {
                    int b = line.IndexOf(" ", a + 1);
                    dur = line.Substring(a + find.Length, b - a - find.Length);
                    //tdur = TimeSpan.Parse(dur);
                    //AddLog(TimeSpan.Parse(dur).Ticks.ToString() + " - " + tdur.Ticks.ToString() + " - " + (TimeSpan.Parse(dur).Ticks / tdur.Ticks).ToString());
                    //AddLog(dur + " - " + tdur.ToString());
                    int percent = (int)((TimeSpan.Parse(dur).TotalSeconds / tdur.TotalSeconds) * 100);
                    pbarUpdate(percent);
                    //AddLog(percent.ToString() + "%");
                }

                // time=00:22:22.25

                a = line.IndexOf("max_volume: ");
                if (a >= 0)
                {

                    int b = line.IndexOf("dB", a + 1);

                    string num = line.Substring(a + 12, b - a - 13);
                    audio_filter = num;

                }
                a = line.IndexOf("track_gain = ");
                if (a >= 0)
                {

                    int b = line.IndexOf("dB", a + 1);

                    string num = line.Substring(a + 13, b - a - 14);
                    audio_filter = (num.Substring(0, 1) == "+" ? num.Substring(1) : num);

                }
            }

            proc.Close();
            pbarMax();
            AddLog("Filter: " + audio_filter);
            return new string[] { dur, audio_filter };
        }

        private string getVideoDuration(string file)
        {
            //ffprobe -v error -show_entries stream=width,height -of csv=p=0:s=x input.m4v
            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            string fname_noext = Path.GetFileNameWithoutExtension(file);
            string fname_root = Path.GetDirectoryName(file);

            string filename = file;

            AddLog("Getting video Dimensions " + file.ToString());

            proc.StartInfo.Arguments = "-i \"" + filename + "\"" + "";
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            //proc.StartInfo.CreateNoWindow = true;

            if (!proc.Start())
            {
                AddLog("Error starting");
            }
            StreamReader reader = proc.StandardError;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                //AddLog(line);
                int a = line.IndexOf("Duration");
                if (a >= 0)
                {
                    string dur = "";
                    AddVLog(line);
                    int b = line.IndexOf(",", a + 1);
                    dur = line.Substring(a + 10, b - a - 10);
                    AddLog("Found length " + dur.ToString());
                    return dur;
                }

            }
            proc.Close();
            try
            {
                proc.Kill();
            }
            catch { }

            return null;
        }

        private string getScreenShot(string file, string pos, bool overright = false)
        {

            string filename = Path.GetFileName(file);   
            if (File.Exists(temp_folder + "\\screen_" + filename + pos + ".png"))
            {
                return temp_folder + "\\screen_" + filename + pos + ".png";
            }
            

            if (!File.Exists(file))
            {
                return null;
            }

            //if (File.Exists(temp_folder + "\\screen_" + pos + ".jpg"))
            //{
                //return temp_folder + "\\screen_" + pos + ".jpg";
            //}
            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            string fname_noext = Path.GetFileNameWithoutExtension(file);
            string fname_root = Path.GetDirectoryName(file);

            //string filename = file;
            //if (File.Exists(temp_folder + "\\screen_" + filename + pos + ".png")) File.Delete(temp_folder + "\\screen_" + pos + ".png");
            //get duration
            //proc.StartInfo.Arguments = "-ss " + pos + " -i " + "\"" + filename + "\" -vframes 1 -q:v 2 \"" + temp_folder + "\\screen_" + TimeSpan.Parse(pos).TotalSeconds.ToString() + ".jpg\"";\
//            AddLog((overright ? "-y " : "") + "-ss " + TimeSpan.FromSeconds(Double.Parse(pos)).ToString() + " -i " + "\"" + file + "\" -vframes 1 -q:v 2 \"" + temp_folder + "\\screen_" + filename + pos + ".png\"");
            
            proc.StartInfo.Arguments = (overright ? "-y " : "") +  "-ss " + TimeSpan.FromSeconds(Double.Parse(pos)).ToString() + " -i " + "\"" + file + "\" -vframes 1 -q:v 2 \"" + temp_folder + "\\screen_" + filename + pos + ".png\"";
            AddLog(proc.StartInfo.Arguments);
            //proc.StartInfo.RedirectStandardError = true;
            //proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;

            if (!proc.Start())
            {
                AddLog("Error starting");
            }

            DateTime st = DateTime.Now;
            //StreamReader reader = proc.StandardError;
            //while (!File.Exists(temp_folder + "\\screen_" + filename + pos + ".png"))
            while (processRunning(proc.Id)!=-1)
            {

                TimeSpan diff = DateTime.Now - st;
                Debug.WriteLine(diff.TotalSeconds);
                if (diff.TotalSeconds > 5 || File.Exists(temp_folder + "\\screen_" + filename + pos + ".png"))
                {
                    proc.Close();
                    break;
                }
                 
                System.Threading.Thread.Sleep(100);
                //break;
            }
            
            /*
            string line;
            DateTime start = DateTime.Now;
            while ((line = reader.ReadLine()) != null)
            {
                AddVLog(line.ToString());
                TimeSpan diff = DateTime.Now - start;
                AddVLog(diff.TotalSeconds.ToString());
                if (diff.TotalSeconds>5) break;
                //AddVLog(DateTime.Now.Ticks.ToString() + " - " + start.Ticks.ToString() + " = " + (DateTime.Now.Ticks -  start.Ticks).ToString());
            }
            */
            //Console.ReadKey();
            proc.Close();

            try
            {
                proc.Kill();
            }
            catch { }

            //return temp_folder + "\\screen_" + TimeSpan.Parse(pos).TotalSeconds.ToString() + ".jpg";
            if (!File.Exists(temp_folder + "\\screen_" + filename + pos + ".png")) return null;
            return temp_folder + "\\screen_" + filename + pos + ".png";


        }

        private string OpenFile(string fileName)
        {
            try
            {
                if (fileName.Length > 200) fileName = fileName.Substring(0, 200);
                System.IO.StreamReader myFile = new System.IO.StreamReader(fileName);
                string myString = myFile.ReadToEnd();
                myFile.Close();
                return myString;
            }
            catch
            {
                return "<error>";
            }
        }

        private int totalDuration = 0;

        private void loadFile(string filename)
        {
            emptyTemp();
            txtLog.Text = "";

                if (File.Exists(filename))
                {
                    picFrame.Image = null;
                    string[] filePaths = Directory.GetFiles(temp_folder);
                    foreach (string filePath in filePaths)
                    {
                        try
                        {
                            File.Delete(filePath);
                        }
                        catch
                        {
                            AddLog("Can't delete temp file");
                        }
                    }

                    txtFile.Text = filename;
                    TimeSpan res = getZVideoDuration(txtFile.Text);

                    totalDuration = (int)res.TotalSeconds;
                    scrollBar.Tag = totalDuration;
                    scrollBar.Maximum = totalDuration + (scrollBar.LargeChange - 1);

                    int[] ires = getVideoDimensions(txtFile.Text);
                    float dimX = ((float)ires[0] / (float)ires[1]);
                    float dimY = ((float)ires[1] / (float)ires[0]);

                    //180 is the max pic height

                    AddLog("Ratio: " + dimX.ToString());
                    AddLog("Ratio: " + dimY.ToString());

                    picFrame.Width = 295;
                    picFrame.Height = 180;

                    if (dimX < 1)
                    {
                        AddLog("resize width");
                        picFrame.Width = (int)(picFrame.Height * dimX);
                    }
                    else if (dimX > 1)
                    {
                        AddLog("resize height");
                        picFrame.Width = (int)(picFrame.Height * dimX);
                        picFrame.Height = (int)(picFrame.Width * dimY);
                    }
                    string scr = getScreenShot(txtFile.Text, Math.Round(res.TotalSeconds / 2).ToString());
                    if(scr != null) picFrame.Image = Image.FromFile(scr);

                    txtStartPos.Tag = new TimeSpan(0).Ticks;
                    txtEndPos.Tag = new TimeSpan(0).Ticks;

                }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadFile(openFileDialog1.FileName);
            }
        }

        private bool fromScrollBar = false;

        private void scrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            tmrScroll.Enabled = false;
            tmrScroll.Enabled = true;

            scrollBarMilli.Value = 0;

            TimeSpan time = TimeSpan.FromSeconds(scrollBar.Value);
            string str = time.ToString(@"hh\:mm\:ss") + ".0";

            fromScrollBar = true;
            txtCurrentPos.Text = str;
            fromScrollBar = false;


        }

        private void loadPosition()
        {
            //try
            //{


                TimeSpan time = TimeSpan.FromSeconds(scrollBar.Value);
                string str = time.ToString(@"hh\:mm\:ss");
                //string pfile = getScreenShot(txtFile.Text, str);
                string scr = getScreenShot(txtFile.Text, scrollBar.Value.ToString() + "." + scrollBarMilli.Value.ToString().PadLeft(2, '0'));
            if (scr == null)
            {
                AddLog("Couldn't get screenshot");
                return;
            }
                string pfile = scr;
                if(File.Exists(pfile))            picFrame.Image = Image.FromFile(pfile);
            //}
            //catch (Exception e)
            //{
            //    AddLog(e.ToString());
            //}
        }

        private void btnStartPos_Click(object sender, EventArgs e)
        {
            TimeSpan time = TimeSpan.FromSeconds(Double.Parse(scrollBar.Value.ToString() + "." + scrollBarMilli.Value.ToString()));

            txtStartPos.Tag = time.Ticks;//  scrollBar.Value.ToString() + "." + scrollBarMilli.Value.ToString();
            txtStartPos.Text = time.ToString(@"hh\:mm\:ss") + "." + scrollBarMilli.Value.ToString().PadLeft(2, '0');
        }

        private void btnEndPos_Click(object sender, EventArgs e)
        {
            TimeSpan time = TimeSpan.FromSeconds(Double.Parse(scrollBar.Value.ToString() + "." + scrollBarMilli.Value.ToString()));

            txtEndPos.Tag = time.Ticks;//  scrollBar.Value.ToString() + "." + scrollBarMilli.Value.ToString();
            txtEndPos.Text = time.ToString(@"hh\:mm\:ss") + "." + scrollBarMilli.Value.ToString().PadLeft(2, '0');
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnSeekEnd_Click(object sender, EventArgs e)
        {
            scrollBar.Value = scrollBar.Maximum - (scrollBar.LargeChange - 1);
            scrollBar_Scroll(sender, null);
        }

        private bool isProcessRunning = false;

        private bool verboseLogging = false;

        private int runProccess(string args, bool verbose = false)
        {
            if (isProcessRunning)
            {
                AddLog("***** Process running, please try again later ********");
                return -1;
            }

            verboseLogging = verbose;
            AddLog(args);
            isProcessRunning = true;

            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            proc.StartInfo.Arguments = "-y " + args;
            AddLog(proc.StartInfo.Arguments);
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;

            proc.EnableRaisingEvents = true;

            proc.Exited += process_Exited;
            proc.OutputDataReceived += ProccesOutputDataReceived;
            proc.ErrorDataReceived += ProccesErrorDataReceived;

            proc.Start();

            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();
            int procID = proc.Id;
            while (true)
            {
                Application.DoEvents();
                int info = processRunning(procID);
                if (info == -1)
                {
                    picStatus.BackColor = Color.Red;
                    break;
                }
                else
                {
                    //picStatus.BackColor = Color.Green;
                }
            }

            isProcessRunning = false;

            //proc.Close();

            try
            {
                //proc.Kill();
            }
            catch { }

            verboseLogging = false;
            return proc.Id;
        }


        static string SaveFile(string fileName, string contents)
        {
            try
            {
                FileInfo deletefile = new FileInfo(fileName);
                StreamWriter w;
                w = new StreamWriter(fileName);
                w.AutoFlush = true;
                w.Write(contents);
                w.Close();
                return "true";
            }
            catch
            {
                return "false";
            }
        }
        private void btnExec_Click(object sender, EventArgs e)
        {
            if (txtFile.Text == "")
            {
                AddLog("No video loaded");
                return;
            }

            saveFileDialog1.FileName = Path.GetFileName(txtFile.Text);
            if (lstSplit.Items.Count > 1) { saveFileDialog1.CheckFileExists = false; }
            else
            { saveFileDialog1.CheckFileExists = false; }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;
                if (lstSplit.Items.Count == 0) this.btnSplitQueue_Click(sender, e);

                double stime = 0;
                double etime = 0;

                pbar.Value = 0;
                pbar.Maximum = lstSplit.Items.Count-1;
                for (int i = 0; i < lstSplit.Items.Count; i++)
                {
                    pbar.Value = i;
                    string[] split = lstSplit.Items[i].ToString().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                    stime = float.Parse(split[0].ToString().Trim());// 0;// TimeSpan.Parse(txtStartPos.Text).TotalSeconds;
                    etime = float.Parse(split[1].ToString().Trim()); // 1;// TimeSpan.Parse(txtEndPos.Text).TotalSeconds;

                    if (stime - etime == 0)
                    {
                        AddLog("Start Time and End Time have to be different");
                        return;
                    }

                    if (stime - etime > 0)
                    {
                        AddLog("Start Time has to be before End Time");
                        return;
                    }



                    AddLog("Splitting video from " + file.ToString());
                    //AddLog("-y -i \"" + txtFile.Text + "\" -ss " + Math.Round(stime, 3).ToString() + " -to " + Math.Round(etime, 3).ToString() + " -async 1 -strict -2 \"" + i.ToString().PadLeft(lstSplit.Items.Count.ToString().Length, '0') + "_" + filename + "\"");

                    string pad = "_" + (i + 1).ToString().PadLeft(3, '0');
                    string path = Path.GetDirectoryName(file);
                    string file_name = Path.GetFileNameWithoutExtension(file);
                    string ext_name = (chkSplitForceMP4.Checked ? ".mp4" : Path.GetExtension(file));

                    AddLog("Process Started");
                    int procID = runProccess("-ss " + Math.Round(stime, 3).ToString() + " -i \"" + txtFile.Text + "\" -to " + (Math.Round(etime, 3) - Math.Round(stime, 3)).ToString() + " -r 29.97 -async 1 -strict -2 \"" + path + "\\" + file_name + (lstSplit.Items.Count > 1 ? pad : "") + ext_name + "\"");
                    AddLog("Process Ended");

                }
            }
            saveFileDialog1.CheckFileExists = false;
        }

        private void btnSeekBegin_Click(object sender, EventArgs e)
        {
            scrollBar.Value = 0;
            scrollBar_Scroll(sender, null);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void txtCurrentPos_TextChanged(object sender, EventArgs e)
        {
            AddLog(fromScrollBar.ToString());
            if (fromScrollBar) return;
            tmrPosEdit.Enabled = false;
            tmrPosEdit.Enabled = true;

        }

        private void tmrPosEdit_Tick(object sender, EventArgs e)
        {
            try
            {
                double ztime = TimeSpan.Parse(txtCurrentPos.Text).TotalSeconds;
                scrollBar.Value = (int)ztime;
                scrollBar_Scroll(sender, null);
            }
            catch
            {
                AddLog("Fix time or scrub with scroll bar.");
            }
            tmrPosEdit.Enabled = false;
        }

        private void btnGoStart_Click(object sender, EventArgs e)
        {

            double ztime = TimeSpan.Parse(txtStartPos.Text).TotalSeconds;
            scrollBar.Value = (int)ztime;
            scrollBar_Scroll(sender, null);

            string[] time = txtStartPos.Text.Split('.');
            int x = 0;
            Int32.TryParse(time[1].ToString(), out x);
            scrollBarMilli.Value = x;
            scrollBarMilli_Scroll(sender, null);

        }

        private void btnGoEnd_Click(object sender, EventArgs e)
        {
            double ztime = TimeSpan.Parse(txtEndPos.Text).TotalSeconds;
            if(ztime>scrollBar.Maximum)
            {
                AddLog("Can't scroll that far.");
                return;
            }
            scrollBar.Value = (int)ztime;
            scrollBar_Scroll(sender, null);

            string[] time = txtEndPos.Text.Split('.');
            int x = 0;
            Int32.TryParse(time[1].ToString(), out x);
            scrollBarMilli.Value = x;
            scrollBarMilli_Scroll(sender, null);


        }

        private void tmrScroll_Tick(object sender, EventArgs e)
        {
            if (File.Exists(txtFile.Text))
            {
                loadPosition();
                tmrScroll.Enabled = false;

            }
        }

        private void picFrame_Click(object sender, EventArgs e)
        {
            try
            {
                int dur = (int)scrollBar.Tag;

                Random rnd = new Random();
                picFrame.Image = Image.FromFile(getScreenShot(txtFile.Text, rnd.Next(0, dur).ToString()));
            }
            catch
            { }
        }

        private void btnJoinMerge_Click(object sender, EventArgs e)
        {
            if (lstJoin.Items.Count == 0) return;
            emptyTemp();
            txtLog.Text = "";

            AddLog("Checking for files to join...");

            saveFileDialog1.CheckFileExists = false;
            string tmpFilter = saveFileDialog1.Filter.ToString();
            saveFileDialog1.Filter = "MP4 Videos (*.mp4)|*.mp4";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string file = saveFileDialog1.FileName;

                string output_folder = Path.GetDirectoryName(file);

                string concat = "";

                if (chkJoinEncode.Checked)
                {

                    int[] res = getVideoDimensions(lstJoin.Items[0].ToString());

                    AddLog("Got dimensions: " + res[0].ToString() + "x" + res[1].ToString());

                    //return;
                    string scale = "";
                    string code = "";
                    for (int i = 0; i < lstJoin.Items.Count; i++)
                    {
                        string s = lstJoin.Items[i].ToString();
                        AddLog("Checking if file exists: " + s);
                        if (File.Exists(s))
                        {
                            concat += "-i \"" + s + "\" ";
                            scale += "[" + i.ToString() + "]scale=" + numJoinWidth.Value.ToString() + ":" + numJoinHeight.Value.ToString() + ",setsar=1[v" + i.ToString() + "];";
                            code += "[v" + i.ToString() + "][" + i.ToString() + (chkAudio.Checked ? ":a:0" : "") + "]";
                        }
                        else
                        {
                            AddLog("Could not find file " + s);
                        }

                    }


                    //AddLog(concat + " -filter_complex \"" + code + " concat=n=" + lstJoin.Items.Count.ToString() + ":v=1:a=1:unsafe=1 [outv] [outa]\" -map \"[outv]\" -map \"[outa]\" \"" + file + "\"");
                    //-y -r 30 -i concat  -filter_complex "[0]scale=640:480,setsar=1[v0];[1]scale=640:480,setsar=1[v1]; [v0][0:a:0][v1][1:a:0] concat=n=2:v=1:a=1:unsafe=1 [outv] [outa]" -map "[outv]" -map "[outa]" -vsync 2 "H:\tv station\commercials\december\test.mp4"
                    runProccess(" " + concat + " -filter_complex \"" + scale + " " + code + " concat=n=" + lstJoin.Items.Count.ToString() + ":v=1" + (chkAudio.Checked ? ":a=1" : "") + ":unsafe=1 [outv]" + (chkAudio.Checked ? " [outa]" : "") + "\" -map \"[outv]\" " + (chkAudio.Checked ? "-map \"[outa]\"" : "") + " -vsync 2 \"" + file + "\"", chkVerbose.Checked);

                }
                else
                {
                    for (int i = 0; i < lstJoin.Items.Count; i++)
                    {
                        string s = lstJoin.Items[i].ToString();
                        AddLog("Checking if file exists: " + s);
                        if (File.Exists(s))
                        {
                            concat += "file '" + s.Replace("\\", "\\\\").Replace("'", "\\\\'") + "'\r\n";
                        }
                        else
                        {
                            AddLog("Could not find file " + s);
                        }

                    }

                    File.WriteAllText(temp_folder + "files.txt", concat);

                    while (File.Exists(temp_folder + "files.txt") == false)
                    {
                        AddLog("Waiting for file to write...");
                    }


                    if (File.Exists(output_folder + "files.txt") == false)
                    {
                        AddLog("File no exists!!!!!!!!!!!!!!!!!!");
                    }


                    concat = concat.Substring(0, concat.Length - 1);
                    AddLog("CONCAT string generated: " + concat);
                    AddLog("Merging all files and commercials...");



                    runProccess("-f concat -safe 0 -i \"" + temp_folder + "files.txt\" " + (chkXFade.Checked == true ? "-filter_complex xfade=offset=4.5:duration=1 " : " ") + " -c copy -bsf:v h264_mp4toannexb \"" + file + "\"", chkVerbose.Checked);
                }

                AddLog("Merge complete. Cleaning up temp files...");
                AddLog("Finished converting " + file);
            }
            emptyTemp();
            saveFileDialog1.Filter = tmpFilter;
        }

        private void btnJoinAdd_Click(object sender, EventArgs e)
        {

            string tmpFilter = openFileDialog1.Filter.ToString();
            openFileDialog1.Filter = openFileDialog1.Tag.ToString();
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                foreach (String file in openFileDialog1.FileNames)
                {
                    if (File.Exists(file))
                    {

                        lstJoin.Items.Add(file);
                    }
                }
                lblJoinerFileCount.Text = lstJoin.Items.Count.ToString() + " file(s)";
            }
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = tmpFilter;
            lstJoin.SelectedIndex = lstJoin.Items.Count - 1;
        }

        private void scrollBarMilli_Scroll(object sender, ScrollEventArgs e)
        {
            tmrScroll.Enabled = false;
            tmrScroll.Enabled = true;


            TimeSpan time = TimeSpan.FromSeconds(scrollBar.Value);
            string str = time.ToString(@"hh\:mm\:ss") + "." + scrollBarMilli.Value.ToString().PadLeft(2,'0');

            fromScrollBar = true;
            txtCurrentPos.Text = str;
            fromScrollBar = false;

        }

        private void btnAudioComine_Click(object sender, EventArgs e)
        {
            AddLog("Checking for files to join...");

            string tmpFilter = saveFileDialog1.Filter.ToString();
            saveFileDialog1.Filter = "MP4 Videos (*.mp4)|*.mp4";
            saveFileDialog1.CheckFileExists = false;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;

                string output_folder = Path.GetDirectoryName(file);

                //AddLog("CONCAT string generated: " + concat);

                runProccess("-y -i \"" + txtAudioVideo.Text + "\" -i \"" + txtAudioAudio.Text + "\"" + (chkAudioTrim.Checked == true ? " -shortest" : "") + " -c:v copy -map 0:v:0 -map 1:a:0 \"" + file + "\"");

                AddLog("Finished converting " + file);
            }
            emptyTemp();
            saveFileDialog1.Filter = tmpFilter;

        }

        private void btnAudioVideo_Click(object sender, EventArgs e)
        {
            emptyTemp();
            txtLog.Text = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog1.FileName))
                {
                    txtAudioVideo.Text = openFileDialog1.FileName;
                }
            }
        }

        private void btnAudioAudio_Click(object sender, EventArgs e)
        {
            emptyTemp();
            txtLog.Text = "";
            string tmpFilter = openFileDialog1.Filter.ToString();
            openFileDialog1.Filter = "Audio Files (*.mp3,*.acc,*.wav,*wma)|*.mp3;*.acc;*.wav;*.wma";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog1.FileName))
                {
                    txtAudioAudio.Text = openFileDialog1.FileName;
                }
            }
            openFileDialog1.Filter = tmpFilter;
        }

        private void btnExtractAudio_Click(object sender, EventArgs e)
        {

            if (lstAudioMagic.Items.Count == 1)
            {

                string tmpFilter = saveFileDialog1.Filter.ToString();
                saveFileDialog1.Filter = "MP3 Audio (*.mp3)|*.mp3";
                saveFileDialog1.FileName = lstAudioMagic.Items[0].ToString();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string file = saveFileDialog1.FileName;

                    runProccess("-i \"" + lstAudioMagic.Items[0] + "\" -q:a 0 -map a \"" + file + "\"");
                    saveFileDialog1.Filter = tmpFilter;
                }
            }
            else
            {
                for (int i = 0; i < lstAudioMagic.Items.Count; i++)
                {
                    string file = lstAudioMagic.Items[i].ToString();

                    string pad = "_audio_" + (i + 1).ToString().PadLeft(3, '0');
                    string path = Path.GetDirectoryName(file);
                    string file_name = Path.GetFileNameWithoutExtension(file);
                    string ext_name = "mp3";

                    runProccess("-y -i \"" + file + "\" -vcodec copy -af \"volume = " + numVolume.Value.ToString() + "dB\" \"" + path + "\\" + file_name + pad + "." + ext_name + "\"");

                }
                AddLog("Finished audioing!");
            }
        }

        private void btnExtractAudioVideo_Click(object sender, EventArgs e)
        {
            emptyTemp();
            txtLog.Text = "";

            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                foreach (String file in openFileDialog1.FileNames)
                {
                    if (File.Exists(file))
                    {
                        if (chkAudioMagicGenerateFilter.Checked)
                        {
                            //string[] r = getDurationAndAudioFilter(file);
                            //if (r[1].Substring(0, 1) == "+") r[1] = r[1].Substring(1);
                            //runProccess("-i \"" + file + "\" -af loudnorm=I=-16:TP=-1.5:LRA=11:print_format=summary -f null /dev/null", true);
                            //lstAudioMagic.Items.Add("Volume: " + r[1] + "|" + file);


                            Process proc = new Process();
                            proc.StartInfo.FileName = ffmpeg_location;

                            proc.StartInfo.Arguments = "-i \"" + file + "\" -af loudnorm=I=-16:TP=-1.5:LRA=11:print_format=json -f null /dev/null";
                            proc.StartInfo.RedirectStandardError = true;
                            proc.StartInfo.UseShellExecute = false;
                            proc.StartInfo.CreateNoWindow = true;
                            if (!proc.Start())
                            {
                                Console.WriteLine("Error starting");
                            }
                            StreamReader reader = proc.StandardError;
                            string line;
                            string input_i = "";
                            string input_lra = "";
                            string input_tp = "";
                            string input_thresh = "";
                            string input_offset = "";

                            while ((line = reader.ReadLine()) != null)
                            {
                                AddVLog(line);
                                Application.DoEvents();
                                int a = 0;
                                string phrase = "";

                                phrase = "\"input_i\" : \"";
                                a = line.IndexOf(phrase);
                                if (a >= 0)
                                {
                                    int b = line.IndexOf("\"", a + phrase.Length + 1);
                                    input_i = line.Substring(a + phrase.Length, b - a - phrase.Length);
                                    AddLog("Found input_i: " + line.Substring(a + phrase.Length, b - a - phrase.Length));
                                    //return new string[] { dur, "5" };
                                }

                                phrase = "\"input_lra\" : \"";
                                a = line.IndexOf(phrase);
                                if (a >= 0)
                                {
                                    int b = line.IndexOf("\"", a + phrase.Length + 1);
                                    input_lra = line.Substring(a + phrase.Length, b - a - phrase.Length);
                                    AddLog("Found input_lra: " + line.Substring(a + phrase.Length, b - a - phrase.Length));
                                    //return new string[] { dur, "5" };
                                }

                                phrase = "\"input_tp\" : \"";
                                a = line.IndexOf(phrase);
                                if (a >= 0)
                                {
                                    int b = line.IndexOf("\"", a + phrase.Length + 1);
                                    input_tp = line.Substring(a + phrase.Length, b - a - phrase.Length);
                                    AddLog("Found input_tp: " + line.Substring(a + phrase.Length, b - a - phrase.Length));
                                    //return new string[] { dur, "5" };
                                }

                                phrase = "\"input_thresh\" : \"";
                                a = line.IndexOf(phrase);
                                if (a >= 0)
                                {
                                    int b = line.IndexOf("\"", a + phrase.Length + 1);
                                    input_thresh = line.Substring(a + phrase.Length, b - a - phrase.Length);
                                    AddLog("Found input_thresh: " + line.Substring(a + phrase.Length, b - a - phrase.Length));
                                    //return new string[] { dur, "5" };
                                }

                                phrase = "\"target_offset\" : \"";
                                a = line.IndexOf(phrase);
                                if (a >= 0)
                                {
                                    int b = line.IndexOf("\"", a + phrase.Length + 1);
                                    input_offset = line.Substring(a + phrase.Length, b - a - phrase.Length);
                                    AddLog("Found input_offset: " + line.Substring(a + phrase.Length, b - a - phrase.Length));
                                    //return new string[] { dur, "5" };
                                }
                            }

                            //ffmpeg -i in.wav -af loudnorm=I=-16:TP=-1.5:LRA=11:
                            //measured_I =-27.61:
                            //measured_LRA =18.06:
                            //measured_TP=-4.47:
                            //measured_thresh=-39.20:
                            //offset=0.58:linear=true:print_format=summary -ar 48k out.wav
                            //
                            proc.Close();
                            lstAudioMagic.Items.Add("measured_I=" + input_i + ":measured_LRA=" + input_lra + ":measured_TP=" + input_tp + ":measured_thresh=" + input_thresh + ":offset=" + input_offset + "|" + file);

                        }
                        else
                        {
                            lstAudioMagic.Items.Add(file);
                        }



                    }
                }
            }
            openFileDialog1.Multiselect = false;
        }

        private void btnAudioBoost_Click(object sender, EventArgs e)
        {

            AddLog("Changing volume...");

            //string tmpFilter = saveFileDialog1.Filter.ToString();
            //saveFileDialog1.Filter = "MP3 Audio (*.mp3)|*.mp3";
            string filter = numVolume.Value.ToString();
            if (lstAudioMagic.Items.Count == 1)
            {
                string input_file = lstAudioMagic.Items[0].ToString();
                if (input_file.IndexOf("|") > 0)
                {
                    string[] splits = input_file.Split('|');
                    if (chkAudioMagicUseFilter.Checked)
                    {
                        //I=-16:TP=-1.5:LRA=11:measured_I=-27.61:measured_LRA=18.06:measured_TP=-4.47:measured_thresh=-39.20:offset=0.58:linear=true:print_format=summary
                        filter = "loudnorm=I=-16:TP=-1.5:LRA=11:" + splits[0] + ":linear=true:print_format=summary";
                    }
                    else
                    {
                        filter = "\"volume = " + filter + "dB\"";
                    }
                    input_file = splits[1];
                }
                saveFileDialog1.FileName = input_file;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string file = saveFileDialog1.FileName;



                    AddLog("-i \"" + input_file + "\" -vcodec copy -af " + filter + " \"" + file + "\"");
                    runProccess("-i \"" + input_file + "\" -vcodec copy -af " + filter + " \"" + file + "\"", true);
                }
            }
            else
            {

                for (int i = 0; i < lstAudioMagic.Items.Count; i++)
                {
                    string input_file = lstAudioMagic.Items[i].ToString();
                    if (input_file.IndexOf("|") > 0)
                    {
                        string[] splits = input_file.Split('|');
                        if (chkAudioMagicUseFilter.Checked)
                        {
                            //I=-16:TP=-1.5:LRA=11:measured_I=-27.61:measured_LRA=18.06:measured_TP=-4.47:measured_thresh=-39.20:offset=0.58:linear=true:print_format=summary
                            filter = "loudnorm=I=-16:TP=-1.5:LRA=11:" + splits[0] + ":linear=true:print_format=summary";
                        }
                        else
                        {
                            filter = "\"volume = " + filter + "dB\"";
                        }
                        input_file = splits[1];
                    }

                    string pad = "_audio_" + (i + 1).ToString().PadLeft(3, '0');
                    string path = Path.GetDirectoryName(input_file);
                    string file_name = Path.GetFileNameWithoutExtension(input_file);
                    string ext_name = Path.GetExtension(input_file);

                    runProccess("-i \"" + input_file + "\" -vcodec copy -af " + filter + " \"" + path + "\\" + file_name + pad + "" + ext_name + "\"", true);
                }
            }
            AddLog("Finished audio volume!");

        }

        private void txtStartPos_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnResizeVideoFile_Click(object sender, EventArgs e)
        {
            emptyTemp();
            txtLog.Text = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog1.FileName))
                {
                    picFrame.Image = null;
                    string[] filePaths = Directory.GetFiles(temp_folder);
                    foreach (string filePath in filePaths)
                    {
                        try
                        {
                            File.Delete(filePath);
                        }
                        catch
                        {
                            AddLog("Can't delete temp file");
                        }
                    }

                    txtResizeVideoFile.Text = openFileDialog1.FileName;

                    string ress = getVideoDuration(txtResizeVideoFile.Text);

                    picResizeFrame.Tag = ress;

                    totalDuration = (int)TimeSpan.Parse(ress).TotalSeconds;

                    int[] res = getVideoDimensions(txtResizeVideoFile.Text);

                    numResizeVideoWidth.Tag = res[0];
                    numResizeVideoHeight.Tag = res[1];
                    try
                    {
                        numResizeVideoWidth.Value = res[0];
                        numResizeVideoHeight.Value = res[1];


                        picResizeFrameTemp.Width = res[0];
                        picResizeFrameTemp.Height = res[1];

                    }
                    catch
                    {
                        AddLog("Video size error!");
                    }


                    float dimX = ((float)res[0] / (float)res[1]);
                    float dimY = ((float)res[1] / (float)res[0]);

                    //180 is the max pic height

                    AddLog("Ratio: " + dimX.ToString());
                    AddLog("Ratio: " + dimY.ToString());

                    picResizeFrame.Width = 295;
                    picResizeFrame.Height = 204;

                    if (dimX < 1)
                    {
                        AddLog("resize width");
                        picResizeFrame.Width = (int)(picResizeFrame.Height * dimX);
                    }
                    else if (dimX > 1)
                    {
                        AddLog("resize height");
                        picResizeFrame.Height = (int)(picResizeFrame.Width * dimY);
                    }

                    picResizeFrameTemp.Image = Image.FromFile(getScreenShot(txtResizeVideoFile.Text, Math.Round(TimeSpan.Parse(ress).TotalSeconds / 2).ToString()));
                    picResizeFrame.Image = picResizeFrameTemp.Image;
                }
            }
        }



        private void btnResizeVideo_Click(object sender, EventArgs e)
        {

            AddLog("Resizing...");

            //string tmpFilter = saveFileDialog1.Filter.ToString();
            //saveFileDialog1.Filter = "MP3 Audio (*.mp3)|*.mp3";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;
                string ext = Path.GetExtension(file);

                runProccess("-i \"" + txtResizeVideoFile.Text + "\" -vf scale=" + numResizeVideoWidth.Value.ToString() + ":" + numResizeVideoHeight.Value.ToString() + " -c:a copy -strict -2 \"" + file + ".temp1." + ext + "\"", true);
                runProccess("-i \"" + file + ".temp1." + ext + "\" -aspect " + numResizeVideoWidth.Value.ToString() + ":" + numResizeVideoHeight.Value.ToString() + " -c:a copy -strict -2 \"" + file + "\"", true);

                try
                {
                    File.Delete(file + ".temp1." + ext);
                }
                catch
                { }

                AddLog("Finished converting " + file);
                //saveFileDialog1.Filter = tmpFilter;
            }

        }

        private void btnCustomSave_Click(object sender, EventArgs e)
        {
            AddLog("Customizing...");

            //string tmpFilter = saveFileDialog1.Filter.ToString();
            //saveFileDialog1.Filter = "MP3 Audio (*.mp3)|*.mp3";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;

                string strFilter = txtCustomFilter.Text.Replace("%IN%", txtCustomFile.Text).Replace("%OUT%", file).Replace(System.Environment.NewLine, "");
                AddLog("Custom Filter: " + strFilter);
                runProccess(strFilter);

                AddLog("Finished converting " + file);
                //saveFileDialog1.Filter = tmpFilter;
            }
        }

        private void btnCustomOpen_Click(object sender, EventArgs e)
        {
            emptyTemp();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog1.FileName))
                {
                    txtCustomFile.Text = openFileDialog1.FileName;
                }
            }
        }

        private void lstCustom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstCustom_DoubleClick(object sender, EventArgs e)
        {
            string[] filters = lstCustom.Text.ToString().Split('|');
            txtCustomFilter.Text = filters[1];
        }

        private void UpdateSplitsCache()
        {
            try
            {
                string s = "";

                for (int i = 0; i < lstSplit.Items.Count; i++)
                {
                    s += lstSplit.Items[i].ToString() + "\r\n";
                }
                SaveFile(Application.StartupPath.ToString() + @"\splits.txt", s);

            }
            catch { }
        }

        private void LoadSplitsCache()
        {
            try
            {

                var lines = File.ReadLines(Application.StartupPath.ToString() + @"\splits.txt");
                backUpSplitList = new string[lines.Count()];
                int i = 0;
                foreach (var line in lines)
                {
                    backUpSplitList[i] = line;
                    i++;
                }                

            }
            catch { }
        }

        private void btnSplitQueue_Click(object sender, EventArgs e)
        {
            try
            {
                lstSplit.Items.Add(TimeSpan.FromTicks((long)txtStartPos.Tag).TotalSeconds.ToString() + " - " + TimeSpan.FromTicks((long)txtEndPos.Tag).TotalSeconds.ToString());
                if (chkAutoSetStart.Checked) this.btnStartPos_Click(sender, e);
                UpdateSplitsCache();
            }
            catch
            {

            }
        }

        private void btnSplitListRemove_Click(object sender, EventArgs e)
        {
            if (lstSplit.SelectedIndex == -1) return;
            lstSplit.Items.RemoveAt(lstSplit.SelectedIndex);
            UpdateSplitsCache();
        }

        private string[] backUpSplitList;

        private void btnSplitListClear_Click(object sender, EventArgs e)
        {
            if(lstSplit.Items.Count == 0 && backUpSplitList.Length>0)
            {
                if (MessageBox.Show("Restore List?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (string a in backUpSplitList)
                        lstSplit.Items.Add(a);
                    return;
                }
            }
            if (MessageBox.Show("Clear List?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                backUpSplitList = lstSplit.Items.OfType<string>().ToArray();
                lstSplit.Items.Clear();
            }
            UpdateSplitsCache();
        }

        private void lstSplit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private int processRunning(int procId)
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.Id == procId)
                {
                    return theprocess.Id;
                }
            }
            return -1;
        }

        private void btnAudioMagicListRemove_Click(object sender, EventArgs e)
        {
            if (lstAudioMagic.SelectedIndex == -1) return;
            lstAudioMagic.Items.RemoveAt(lstAudioMagic.SelectedIndex);
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {

            AddLog("Cropping...");

            //string tmpFilter = saveFileDialog1.Filter.ToString();
            //saveFileDialog1.Filter = "MP3 Audio (*.mp3)|*.mp3";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;


                int maxWidth = (int)numResizeVideoWidth.Tag;
                int maxHeight = (int)numResizeVideoHeight.Tag;

                int left = (int)numCropVideoLeft.Value;
                int top = (int)numCropVideoTop.Value;
                int width = (int)numResizeVideoWidth.Value;
                int height = (int)numResizeVideoHeight.Value;

                if (left + width > maxWidth) width = maxWidth - left;
                if (top + height > maxHeight) height = maxHeight - top;

                runProccess("-i \"" + txtResizeVideoFile.Text + "\" -filter:v \"crop = " + width + ":" + height + ":" + left + ":" + top + "\" -c:a copy -strict -2 \"" + file + "\"");

                AddLog("Finished converting " + file);
                //saveFileDialog1.Filter = tmpFilter;
            }
        }

        private void resizeFrame()
        {
            if (picResizeFrameTemp.Image == null) return;

            Bitmap src = (Bitmap)picResizeFrameTemp.Image;

            int maxWidth = (int)numResizeVideoWidth.Tag;
            int maxHeight = (int)numResizeVideoHeight.Tag;

            int left = (int)numCropVideoLeft.Value;
            int top = (int)numCropVideoTop.Value;
            int width = (int)numResizeVideoWidth.Value;
            int height = (int)numResizeVideoHeight.Value;

            if (left + width > maxWidth) width = maxWidth - left;
            if (top + height > maxHeight) height = maxHeight - top;

            Rectangle cropRect = new Rectangle(left, top, width, height);
            try
            {
                picResizeFrame.Image = (Image)src.Clone(cropRect, src.PixelFormat);
            }
            catch
            {
                AddLog("Couldn't resize image");
            }
        }

        private void numCropVideoLeft_ValueChanged(object sender, EventArgs e)
        {
            resizeFrame();
        }

        private void numCropVideoTop_ValueChanged(object sender, EventArgs e)
        {
            resizeFrame();
        }

        private void numResizeVideoWidth_ValueChanged(object sender, EventArgs e)
        {
            resizeFrame();
        }

        private void numResizeVideoHeight_ValueChanged(object sender, EventArgs e)
        {
            resizeFrame();
        }

        private void btnAudioMagicListClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear List?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lstAudioMagic.Items.Clear();
            }
        }

        private void btnResizeAutoCrop_Click(object sender, EventArgs e)
        {
            Bitmap b = (Bitmap)picResizeFrameTemp.Image;
            int non_black = -1;
            for (int x = 0; x < picResizeFrameTemp.Width; x++)
            {
                Color c1 = b.GetPixel(x, 10);
                Color c2 = b.GetPixel(x, picResizeFrameTemp.Height - 10);
                if (c1.R < 10 && c1.G < 10 && c1.B < 10 && c2.R < 10 && c2.G < 10 && c2.B < 10)
                {
                    //AddLog(c.ToString());
                }
                else
                {
                    non_black++;
                }

                if (non_black > 4)
                {
                    numCropVideoLeft.Value = x - non_black;
                    break;
                }
            }

            non_black = -1;
            for (int x = picResizeFrameTemp.Width - 1; x > -1; x--)
            {
                Color c1 = b.GetPixel(x, 10);
                Color c2 = b.GetPixel(x, picResizeFrameTemp.Height - 10);
                if (c1.R < 10 && c1.G < 10 && c1.B < 10 && c2.R < 10 && c2.G < 10 && c2.B < 10)
                {
                    //AddLog(c.ToString());
                }
                else
                {
                    non_black++;
                }

                if (non_black > 4)
                {
                    numResizeVideoWidth.Value = (x + non_black) - numCropVideoLeft.Value;
                    break;
                }
            }

            non_black = -1;
            for (int x = 0; x < picResizeFrameTemp.Height; x++)
            {
                Color c1 = b.GetPixel(10, x);
                Color c2 = b.GetPixel(picResizeFrameTemp.Width - 10, x);
                if (c1.R < 10 && c1.G < 10 && c1.B < 10 && c2.R < 10 && c2.G < 10 && c2.B < 10)
                {
                    //AddLog(c.ToString());
                }
                else
                {
                    non_black++;
                }

                if (non_black > 4)
                {
                    numCropVideoTop.Value = x - non_black;
                    break;
                }
            }

            non_black = -1;
            for (int x = picResizeFrameTemp.Height - 1; x > -1; x--)
            {
                Color c1 = b.GetPixel(10, x);
                Color c2 = b.GetPixel(picResizeFrameTemp.Width - 10, x);
                if (c1.R < 10 && c1.G < 10 && c1.B < 10 && c2.R < 10 && c2.G < 10 && c2.B < 10)
                {
                    //AddLog(c.ToString());
                }
                else
                {
                    non_black++;
                }

                if (non_black > 4)
                {
                    numResizeVideoHeight.Value = (x + non_black) - numCropVideoTop.Value;
                    break;
                }
            }

        }

        private TimeSpan getZVideoDuration(string file)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            string filename = file;
            string dur = "";
            AddLog("Getting Duration " + file.ToString());
            //get duration
            proc.StartInfo.Arguments = "-i " + "\"" + filename + "\"" + " -f null -";
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            if (!proc.Start())
            {
                Console.WriteLine("Error starting");
            }
            StreamReader reader = proc.StandardError;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                int a = line.IndexOf("Duration");
                int xx = line.IndexOf("Durations");
                if (a >= 0 && xx == -1)
                {
                    int b = line.IndexOf(",", a + 1);
                    dur = line.Substring(a + 10, b - a - 10);
                    AddLog("Found length " + dur.ToString());
                    while (true)
                    {
                        try
                        {
                            proc.Kill();
                            break;
                        }
                        catch
                        { }
                    }
                    //proc.Close();
                    return TimeSpan.Parse(dur);
                    //Console.WriteLine("Found length " + dur.ToString());
                    //return new string[] { dur, "5" };
                }

            }
            //Console.ReadKey();
            proc.Close();
            return new TimeSpan();
        }

        private List<TimeSpan> scanForCommercialBreaks(string file, double threshhold, double wait, int min_time_add = 300, int min_end_time = 59, double black_level = 0.05)
        {
            TimeSpan vid_dur = getZVideoDuration(file);

            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            string fname_noext = Path.GetFileNameWithoutExtension(file);
            string fname_root = Path.GetDirectoryName(file);

            string filename = file;

            //get duration
            proc.StartInfo.Arguments = "-i \"" + filename + "\" -vf \"blackdetect=d=" + threshhold.ToString() + ":pix_th=" + black_level.ToString() + "\" -an -f null -";
            AddLog("scanForCommercialBreaks:" + proc.StartInfo.Arguments);

            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            if (!proc.Start())
            {
                AddLog("Error starting");
            }
            StreamReader reader = proc.StandardError;
            List<TimeSpan> nums = new List<TimeSpan>();
            string line;
            AddLog("Scanning for Commercial Breaks...");
            DateTime now = DateTime.Now;
            //nums.Add(TimeSpan.FromSeconds(0));
            double last_break = 0;
            while ((line = reader.ReadLine()) != null)
            {

                if ((DateTime.Now - now) > TimeSpan.FromSeconds(.25))
                {
                    //drawn a placeholder so the user doesn't think the process locked up
                    Console.Write(".");
                    now = DateTime.Now;
                }

                //AddLog(line.ToString());
                int a = line.IndexOf("blackdetect");
                if (a >= 0)
                {
                    a = line.IndexOf("black_start:");
                    int b = line.IndexOf(" ", a + 1);
                    double bstart = Convert.ToDouble(line.Substring(a + 12, b - a - 12));

                    a = line.IndexOf("black_end:", b + 1);
                    b = line.IndexOf(" ", a + 1);
                    double bend = Convert.ToDouble(line.Substring(a + 10, b - a - 10));

                    a = line.IndexOf("black_duration:", b + 1);
                    b = line.Length;
                    double bdur = Convert.ToDouble(line.Substring(a + 15, b - a - 15));

                    double bmed = ((bstart + bend) / 2);

                    //AddLog(bmed + " - " + wait);
                    //commercial breaks must start after the minimum wait time and be less than video length minus minimum end time
                    if (bmed > wait && ((vid_dur.TotalSeconds - bmed) > min_end_time))
                    {
                        //time between breaks must be longer than the set minimum time
                        if (((bmed - last_break) > min_time_add))
                        {
                            nums.Add(TimeSpan.FromSeconds(bmed));
                            last_break = bmed;
                            Console.Write("+");
                        }
                        else if (nums.Count == 0) //we should add first break regardless of minimun time difference 
                        {
                            nums.Add(TimeSpan.FromSeconds(bmed));
                            last_break = bmed;
                            Console.Write("+");
                        }
                        else
                        {
                            Console.Write("x");
                        }
                    }

                    //AddLog("start: " + TimeSpan.FromSeconds(bstart).ToString() + " end: " + TimeSpan.FromSeconds(bend).ToString() + " median: " + TimeSpan.FromSeconds(bmed).ToString() + " duration: " + bdur);
                }
            }
            Console.WriteLine();
            AddLog("Finished scan..... found " + nums.Count.ToString() + " breaks");
            try
            {
                proc.Kill();
            }
            catch
            {

            }
            try
            {
                proc.Close();
            }
            catch
            {

            }
            //
            return nums;

            //return commerical_breaks;
        }

        private List<TimeSpan> scanForZCommercialBreaks(string file, double threshhold)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            string fname_noext = Path.GetFileNameWithoutExtension(file);
            string fname_root = Path.GetDirectoryName(file);

            string filename = file;

            //get duration
            proc.StartInfo.Arguments = "-i " + "\"" + filename + "\"" + " -vf blackframe -an -f null -";
            AddLog("scanForCommercialBreaks:" + proc.StartInfo.Arguments);
            //proc.StartInfo.Arguments = "-i " + "\"" + filename + "\"" + " -vf select='gte(scene,0)' -an -f null -";

            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            if (!proc.Start())
            {
                AddLog("Error starting");
            }
            StreamReader reader = proc.StandardError;
            List<TimeSpan> nums = new List<TimeSpan>();
            string line;
            string last_num = "";
            AddLog("Scanning for Commercial Breaks...");
            DateTime now = DateTime.Now;
            while ((line = reader.ReadLine()) != null)
            {
                if ((DateTime.Now - now) > TimeSpan.FromSeconds(.5))
                {
                    Console.Write(".");
                    now = DateTime.Now;
                }
                int a = line.IndexOf("Parsed_blackframe");
                //AddLog(line.ToString());
                if (a >= 0)
                {
                    a = line.IndexOf(" t:");
                    int b = line.IndexOf(" ", a + 1);
                    string num = line.Substring(a + 3, b - a - 3);
                    //AddLog("NUM:" + num);
                    if (last_num != "")
                    {
                        //
                        if (Double.Parse(num) - Double.Parse(last_num) > 2) nums.Add(TimeSpan.FromSeconds(0));
                    }
                    last_num = num;
                    nums.Add(TimeSpan.FromSeconds(Double.Parse(num)));
                    //AddLog("blah:" + TimeSpan.FromSeconds(Double.Parse(num)));
                }
                else
                {
                    if (nums.Count > 0)
                    {
                        if (nums[nums.Count - 1].TotalSeconds != 0)
                        {
                            nums.Add(TimeSpan.FromSeconds(0));
                        }
                    }
                    //AddLog("sigal:" + line);
                }
            }
            AddLog("Scanning for Commercial Breaks...");
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i - 1].TotalSeconds == 0 && nums[i].TotalSeconds == 0)
                {
                    nums.RemoveAt(i);
                }
            }
            List<TimeSpan> commerical_breaks = new List<TimeSpan>();
            commerical_breaks.Add(TimeSpan.FromSeconds(0));
            int last = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                TimeSpan t = nums[i];
                AddLog(i + " - " + t.ToString());
                if (t.TotalSeconds == 0) //start new count
                {
                    if (last != 0)
                    {

                        TimeSpan q = nums[last + 1];
                        TimeSpan qa = nums[i - 1];
                        AddLog("Total: " + (qa - q).TotalSeconds + " - " + qa.ToString() + " - " + q.ToString());
                        AddLog("Total: " + (qa - q).TotalSeconds + " - " + qa.ToString() + " - " + q.ToString() + " ticks:" + (qa - q).Ticks + " thresh hold:" + TimeSpan.FromSeconds(threshhold).Ticks);
                        if ((qa - q).Ticks > TimeSpan.FromSeconds(threshhold).Ticks)
                        {

                            AddLog("Found commercial break at " + qa.ToString());
                            AddLog("Found commercial break between (" + q.ToString() + "," + qa.ToString() + ")");
                            TimeSpan tdiff = qa - q;
                            AddLog("Using difference: " + (q + new TimeSpan(tdiff.Ticks / 2)).ToString());
                            commerical_breaks.Add((q + new TimeSpan(tdiff.Ticks / 2)));
                        }
                        last = i;
                    }
                    else
                    {
                        last = i;
                    }
                }

                //AddLog(t.ToString());
            }
            AddLog("Commercial breaks found: " + commerical_breaks.Count);
            AddLog("Commercial breaks found: " + commerical_breaks.Count);
            //Console.ReadKey();
            proc.Close();

            TimeSpan lt = new TimeSpan(0, 0, 0);
            List<TimeSpan> new_com = new List<TimeSpan>();
            foreach (TimeSpan t in commerical_breaks)
            {
                if (t.TotalMinutes - lt.TotalMinutes > 5 || lt.TotalMinutes == 0 || threshhold == .1)
                {
                    new_com.Add(t);
                    AddLog("New Found commercial break at " + t.ToString());
                    AddLog("New Found commercial break at " + t.ToString());
                }

                lt = t;
            }

            return new_com;

            //return commerical_breaks;
        }

        private void btnSplitAutoScan_Click(object sender, EventArgs e)
        {
            List<TimeSpan> t = scanForCommercialBreaks(txtFile.Text, .1, 0, 0, 0, 0.1);
            for (int i = 1; i < t.Count(); i++)
            {
                //lstSplit.Items.Add(t[i - 1].ToString((@"hh\:mm\:ss\.ff")) + " - " + t[i].ToString((@"hh\:mm\:ss\.ff")));
                lstSplit.Items.Add(t[i - 1].TotalSeconds.ToString() + " - " + t[i].TotalSeconds.ToString());
            }
        }

        private void lstSplit_DoubleClick(object sender, EventArgs e)
        {
            string[] s = lstSplit.SelectedItem.ToString().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            AddLog(s[0] + "," + s[1]);

            TimeSpan time = TimeSpan.FromSeconds(Double.Parse(s[0]));
            txtStartPos.Tag = time.Ticks;
            txtStartPos.Text = time.ToString(@"hh\:mm\:ss\.ff");

            time = TimeSpan.FromSeconds(Double.Parse(s[1]));
            txtEndPos.Tag = time.Ticks;
            txtEndPos.Text = time.ToString(@"hh\:mm\:ss\.ff");

        }

        private void lstAudioMagic_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkAudioMagicUseFilter_CheckedChanged(object sender, EventArgs e)
        {
            numVolume.Enabled = (!chkAudioMagicUseFilter.Checked);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void picResizeFrame_Click(object sender, EventArgs e)
        {
            int dur = (int)TimeSpan.Parse(picResizeFrame.Tag.ToString()).TotalSeconds;

            Random rnd = new Random();
            Image img = Image.FromFile(getScreenShot(txtResizeVideoFile.Text, rnd.Next(0, dur).ToString()));
            picResizeFrameTemp.Image = img;
            picResizeFrame.Image = img;
        }

        private void btnJoinClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear List?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lstJoin.Items.Clear();
                lblJoinerFileCount.Text = lstJoin.Items.Count.ToString() + " file(s)";
            }
        }

        private void btnJoinRemove_Click(object sender, EventArgs e)
        {
            int num = lstJoin.SelectedIndex;

            lstJoin.Items.RemoveAt(lstJoin.SelectedIndex);
            lblJoinerFileCount.Text = lstJoin.Items.Count.ToString() + " file(s)";

            if (num == -1) return;
            if (num > lstJoin.Items.Count - 1) num = lstJoin.Items.Count - 1;
            lstJoin.SelectedIndex = num;
        }

        private void btnJoinMoveUp_Click(object sender, EventArgs e)
        {
            int num = lstJoin.SelectedIndex;
            if (num <= 0) return;
            object item = lstJoin.Items[num];
            lstJoin.Items.RemoveAt(num);
            lstJoin.Items.Insert(num - 1, item);
            lstJoin.SelectedIndex = num - 1;
        }

        private void btnJoinMoveDown_Click(object sender, EventArgs e)
        {
            int num = lstJoin.SelectedIndex;
            if (num >= lstJoin.Items.Count - 1) return;
            object item = lstJoin.Items[num];
            lstJoin.Items.RemoveAt(num);
            lstJoin.Items.Insert(num + 1, item);
            lstJoin.SelectedIndex = num + 1;
        }

        private void chkJoinEncode_CheckedChanged(object sender, EventArgs e)
        {
            label4.Enabled = chkJoinEncode.Checked;
            label5.Enabled = chkJoinEncode.Checked;
            numJoinHeight.Enabled = chkJoinEncode.Checked;
            numJoinWidth.Enabled = chkJoinEncode.Checked;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"H:\tv station\primetime\monday\";
            Debug.WriteLine(path);
            List<string> files = GetFiles(path);

            for (int i = 0; i < files.Count; i++)
            {
                Debug.WriteLine(files[i]);
                if (files[i].IndexOf("audio") == -1)
                {
                    File.SetAttributes(files[i], FileAttributes.Normal);
                    File.Delete(files[i]);
                }
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtCustomFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private bool joinFiles(string output_filename, bool encode, bool crossfade, List<string> files, int output_width,int output_height)
        {
            string file = output_filename;

            string output_folder = Path.GetDirectoryName(file);

            string concat = "";

            if (encode)
            {

                int[] res = getVideoDimensions(files[0]);

                AddLog("Got dimensions: " + res[0].ToString() + "x" + res[1].ToString());

                //return;
                string scale = "";
                string code = "";
                for (int i = 0; i < files.Count; i++)
                {
                    string s = files[i];
                    AddLog("Checking if file exists: " + s);
                    if (File.Exists(s))
                    {
                        concat += "-i \"" + s + "\" ";
                        scale += "[" + i.ToString() + "]scale=" + output_width.ToString() + ":" + output_height.ToString() + ",setsar=1[v" + i.ToString() + "];";
                        code += "[v" + i.ToString() + "][" + i.ToString() + ":a:0]";
                    }
                    else
                    {
                        AddLog("Could not find file " + s);
                    }

                }

                runProccess(" " + concat + " -filter_complex \"" + scale + " " + code + " concat=n=" + files.Count.ToString() + ":v=1:a=1:unsafe=1 [outv] [outa]\" -map \"[outv]\" -map \"[outa]\" -vsync 2 \"" + file + "\"", this.chkVerbose.Checked);

            }
            else
            {
                for (int i = 0; i < files.Count; i++)
                {
                    string s = files[i].ToString();
                    AddLog("Checking if file exists: " + s);
                    if (File.Exists(s))
                    {
                        concat += "file '" + s.Replace("\\", "\\\\").Replace("'", "\\\\'") + "'\r\n";
                    }
                    else
                    {
                        AddLog("Could not find file " + s);
                    }

                }

                File.WriteAllText(file + "_files.txt", concat);

                while (File.Exists(file + "_files.txt") == false)
                {
                    AddLog("Waiting for file to write...");
                }


                if (File.Exists(file + "_files.txt") == false)
                {
                    AddLog("File no exists!!!!!!!!!!!!!!!!!!");
                }


                concat = concat.Substring(0, concat.Length - 1);
                AddLog("CONCAT string generated: " + concat);
                AddLog("Merging all files and commercials...");



                runProccess("-f concat -safe 0 -i \"" + temp_folder + "files.txt\" " + (crossfade == true ? "-filter_complex xfade=offset=4.5:duration=1 " : " ") + " -c copy -bsf:v h264_mp4toannexb \"" + file + "\"", this.chkVerbose.Checked);
            }

            return false;
        }

        private void btnJoinBatch_Click(object sender, EventArgs e)
        {
            string tmpFilter = openFileDialog1.Filter.ToString();
            openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                XmlDocument xml = new XmlDocument();

                xml.Load(openFileDialog1.FileName);
                XmlNodeList xmlListJoins = xml.GetElementsByTagName("join");
                lblJoinerFileCount.Text = xmlListJoins.Count.ToString();
                int count = 0;
                foreach (XmlNode node in xmlListJoins)
                {
                    List<string> deletes = new List<string>();
                    lblJoinerFileCount.Text = count.ToString() + " file(s)";
                    List<List<string>> crossfades = new List<List<string>>();
                    List<double> video_lengths = new List<double>();
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        if(childNode.Name.ToString().ToLower()=="videos")
                        {

                            
                            bool crossfade = false;
                            bool encode = false;
                            int fps = -1;
                            string output_filename = "";
                            int width = 0;
                            int height = 0;

                            if (childNode.Attributes["fps"] != null)
                            {
                                try
                                {
                                    fps = Int32.Parse(childNode.Attributes["fps"].InnerText);
                                }
                                catch
                                {
                                    fps = -1;
                                }
                            }

                            if (childNode.Attributes["encode"] != null)
                            {
                                encode = (childNode.Attributes["encode"].InnerText.ToLower() == "true");
                            }

                            if (childNode.Attributes["output"] != null)
                            {
                                output_filename = childNode.Attributes["output"].InnerText;
                            }

                            if (childNode.Attributes["width"] != null)
                            {
                                if (Regex.IsMatch(childNode.Attributes["width"].InnerText, @"^\d+$"))
                                {
                                    width = Int32.Parse(childNode.Attributes["width"].InnerText);
                                }
                            }

                            if (childNode.Attributes["height"] != null)
                            {
                                if (Regex.IsMatch(childNode.Attributes["height"].InnerText, @"^\d+$"))
                                {
                                    height = Int32.Parse(childNode.Attributes["height"].InnerText);
                                }
                            }

                            AddLog(childNode.Attributes["width"].InnerText + " - " + childNode.Attributes["height"].InnerText + " - " + width.ToString() + " - " + height.ToString());
                            if (width>0 && height>0)
                            {
                                
                                AddLog(encode.ToString());
                                AddLog(width.ToString() + " x " + height.ToString());
                                AddLog(output_filename.ToString());
                                List<string> files = new List<string>();

                                bool skip = false;

                                foreach (XmlNode moreChildNode in childNode.ChildNodes)
                                {
                                    string start = null;
                                    string end = null;
                                    if (moreChildNode.Name.ToString().ToLower() == "file")
                                    {
                                        AddLog(moreChildNode.InnerText);
                                        if (File.Exists(moreChildNode.InnerText))
                                        {
                                            string file = moreChildNode.InnerText;

                                            if (moreChildNode.Attributes["start"] != null)
                                            {
                                                start = moreChildNode.Attributes["start"].InnerText;
                                            }

                                            if (moreChildNode.Attributes["end"] != null)
                                            {
                                                end = moreChildNode.Attributes["end"].InnerText;
                                            }

                                            if (end == null && start != null)
                                            {
                                                end = getVideoDuration(file);
                                            }

                                            if(start != null && end != null)
                                            {
                                                AddLog("Splitting video from " + file.ToString());
                                                //AddLog("-y -i \"" + txtFile.Text + "\" -ss " + Math.Round(stime, 3).ToString() + " -to " + Math.Round(etime, 3).ToString() + " -async 1 -strict -2 \"" + i.ToString().PadLeft(lstSplit.Items.Count.ToString().Length, '0') + "_" + filename + "\"");

                                                AddLog("S " + start.ToString() + " E " + end.ToString());

                                                string pad = "_temp";
                                                string path = Path.GetDirectoryName(file);
                                                string file_name = Path.GetFileNameWithoutExtension(file);
                                                string ext_name = Path.GetExtension(file);

                                                AddLog("Process Started");
                                                int procID = runProccess("-y -i \"" + file + "\" -ss " + start + " -to " + end + " -async 1 -strict -2 " + (ext_name.ToLower().IndexOf("avi")>-1? "-c:v copy " : "") + "\"" + path + "\\" + file_name + pad + ext_name + "\"");
                                                AddLog("Process Ended");
                                                file = path + "\\" + file_name + pad + ext_name;
                                                deletes.Add(file);
                                            }

                                            string vid_len = getVideoDuration(file);

                                            video_lengths.Add(Double.Parse(TimeSpan.Parse(vid_len).TotalSeconds.ToString()));

                                            if (moreChildNode.Attributes["crossfade"] != null)
                                            {
                                                crossfade = (moreChildNode.Attributes["crossfade"].InnerText.ToLower() == "true");
                                                string type = moreChildNode.Attributes["crossfade_type"].InnerText.ToLower();
                                                string duration = moreChildNode.Attributes["crossfade_duration"].InnerText.ToLower();
                                                if (crossfade)
                                                {
                                                    crossfades.Add(new List<string> { type, duration, vid_len });
                                                }
                                            }
                                            else
                                            {
                                                crossfades.Add(new List<string> { null });
                                            }

                                            AddLog(file);
                                            files.Add(file);
                                        } else
                                        {
                                            AddLog(moreChildNode.InnerText + " DOES NOT EXIST");
                                            skip = true;
                                        }
                                    }
                                }

                                if (files.Count > 0 && skip==false)
                                {


                                    //joinFiles(output_filename, encode, fps, files, width, height);


                                    string file = output_filename;

                                    string output_folder = Path.GetDirectoryName(file);

                                    string concat = "";

                                    if (encode)
                                    {

                                        int[] res = getVideoDimensions(files[0]);

                                        AddLog("Got dimensions: " + res[0].ToString() + "x" + res[1].ToString());

                                        //return;
                                        string scale = "";
                                        string code = "";
                                        double new_len = 0.0;

                                        for (int i = 0; i < files.Count; i++)
                                        {
                                            string scross = "";
                                            string across = "";
                                            string s = files[i];
                                            if (crossfades[i][0] != null)
                                            {
                                                AddLog(crossfades[i][0].ToString() + " - " + crossfades[i][1].ToString() + " - " + crossfades[i][2].ToString() + " - " + TimeSpan.Parse(crossfades[i][2]).TotalSeconds.ToString());
                                                scross = ",xfade=transition=" + crossfades[i][0] + ":duration=" + crossfades[i][1] + ":offset=" + (TimeSpan.Parse(crossfades[i][2]).TotalSeconds - Double.Parse(crossfades[i][1])).ToString();
                                                across = "acrossfade=duration=" + crossfades[i][1];


                                                new_len += (video_lengths[i] - (Double.Parse(crossfades[i][1])*2));
                                            }
                                            else
                                            {
                                                new_len += video_lengths[i];
                                            }
                                            AddLog("Checking if file exists: " + s);
                                            if (File.Exists(s))
                                            {
                                                concat += "-i \"" + s + "\" ";
                                                scale += (across!="" ? "[" + i.ToString() + "]" + across + "[a" + i.ToString() + "];" : "") + "[" + i.ToString() + "]scale=" + width.ToString() + ":" + height.ToString() + ",setsar=1" + scross + "[v" + i.ToString() + "];";
                                                code += "[v" + i.ToString() + "]" + (across != "" ? "[a" + i.ToString() + "]" : "[" + i.ToString() + ":a:0]");
                                            }
                                            else
                                            {
                                                AddLog("Could not find file " + s);
                                            }

                                        }
                                        AddLog(new_len.ToString()); //
                                        runProccess(" " + concat + " -filter_complex \"" + scale + " " + code + " concat=n=" + files.Count.ToString() + ":v=1:a=1:unsafe=1 [outv] [outa]\" -map \"[outv]\" -map \"[outa]\" -vsync 2 " + (fps > 0 ? "-r " + fps.ToString() : "") + " -t " + TimeSpan.FromSeconds(new_len).ToString() + " \"" + file + "\"", this.chkVerbose.Checked);

                                    }
                                    else
                                    {
                                        for (int i = 0; i < files.Count; i++)
                                        {
                                            string s = files[i].ToString();
                                            AddLog("Checking if file exists: " + s);
                                            if (File.Exists(s))
                                            {
                                                concat += "file '" + s.Replace("\\", "\\\\").Replace("'", "\\\\'") + "'\r\n";
                                            }
                                            else
                                            {
                                                AddLog("Could not find file " + s);
                                            }

                                        }

                                        File.WriteAllText(file + "_files.txt", concat);

                                        while (File.Exists(file + "_files.txt") == false)
                                        {
                                            AddLog("Waiting for file to write...");
                                        }


                                        if (File.Exists(file + "_files.txt") == false)
                                        {
                                            AddLog("File no exists!!!!!!!!!!!!!!!!!!");
                                        }


                                        concat = concat.Substring(0, concat.Length - 1);
                                        AddLog("CONCAT string generated: " + concat);
                                        AddLog("Merging all files and commercials...");

                                        runProccess("-f concat -safe 0 -i \"" + temp_folder + "files.txt\" " + " -c copy -bsf:v h264_mp4toannexb \"" + file + "\"", this.chkVerbose.Checked);
                                    }


                                    if (deletes.Count>0)
                                    {
                                        foreach(string s in deletes)
                                        {
                                            try
                                            {
                                                //File.Delete(s);
                                            }
                                            catch
                                            {
                                                AddLog("Error deleting temp file " + s);
                                            }
                                            
                                        }
                                    }
                                }
                            }
                        }

                        while(isProcessRunning)
                        {
                            Application.DoEvents();
                        }
                    }
                }


            }
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = tmpFilter;
        }

        private void picFrame_DragDrop(object sender, DragEventArgs e)
        {
            AddLog(e.ToString());
        }

        private bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = String.Empty;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".mp4") || (ext == ".avi") || (ext == ".mkv"))
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            string filename;
            bool validData = GetFilename(out filename, e);

            if (validData)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string filename;
            bool validData = GetFilename(out filename, e);
            if (validData)
            {
                e.Effect = DragDropEffects.Copy;
                loadFile(filename);
                AddLog(filename);
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //	ffmpeg -ss 00:01:45 -y -i "DVD_VIDEO_RECORDER_DK_CD1-1.mp4" -vf "eq=contrast=1.2:brightness=-0:saturation=1,vibrance=intensity=1.1:rbal=2:gbal=0:bbal=1, unsharp=3:3:1.5" -pix_fmt yuv420p -vframes 1 -q:v 2 "Donkey Kong - Episode 1.png"

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtColorFile.Text = openFileDialog1.FileName;
                string res = getVideoDuration(txtColorFile.Text);
                picColorNew.Tag = TimeSpan.Parse(res).TotalSeconds.ToString();
                picColorOrig.Tag = (TimeSpan.Parse(res).TotalSeconds / 2).ToString();
                picColorOrig.Image = Image.FromFile(getScreenShot(txtColorFile.Text, picColorOrig.Tag.ToString(), true));
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnColorTest_Click(object sender, EventArgs e)
        {
            //ffmpeg -ss 00:01:45 -y -i "DVD_VIDEO_RECORDER_DK_CD1-1.mp4" -vf "eq=contrast=1.2:brightness=-0:saturation=1,vibrance=intensity=1.1:rbal=2:gbal=0:bbal=1, unsharp=3:3:1.5" -pix_fmt yuv420p -vframes 1 -q:v 2 "Donkey Kong - Episode 1.png"
            string file = txtColorFile.Text;
            string res = getVideoDuration(txtColorFile.Text);
            
            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            string fname_noext = Path.GetFileNameWithoutExtension(file);
            string fname_root = Path.GetDirectoryName(file);

            string filename = file;


            string filter = "";

            if (numContrast.Value.ToString() != numContrast.Tag.ToString())
            {
                if (filter == "") filter = "eq=";
                filter += "contrast=" + numContrast.Value.ToString() + ":";
            }

            if (numBright.Value.ToString() != numBright.Tag.ToString())
            {
                if (filter == "") filter = "eq=";
                filter += "brightness=" + numBright.Value.ToString() + ":";
            }

            if (numSaturation.Value.ToString() != numSaturation.Tag.ToString())
            {
                if (filter == "") filter = "eq=";
                filter += "saturation=" + numSaturation.Value.ToString() + ":";
            }

            if (numGamma.Value.ToString() != numGamma.Tag.ToString())
            {
                if (filter == "") filter = "eq=";
                filter += "gamma=" + numGamma.Value.ToString() + ":";
            }

            if(filter!="")
            {
                if (filter.Substring(filter.Length - 1, 1) == ":") filter = filter.Substring(0, filter.Length - 1);
                filter = "-vf \"" + filter + "\"";
            }


            string stout = temp_folder + "\\screen_n_" + picColorOrig.Tag.ToString() + "_" + DateTimeOffset.Now.Ticks.ToString() + ".png";
            proc.StartInfo.Arguments = "-y -ss " + TimeSpan.FromSeconds(Double.Parse(picColorOrig.Tag.ToString())).ToString() + " -i \"" + filename + "\" " + filter + " -pix_fmt rgb24 -vframes 1 -q:v 2 \"" + stout + "\"";

            //proc.StartInfo.Arguments = "-ss " + TimeSpan.FromSeconds(TimeSpan.Parse(res).TotalSeconds / 2).ToString() + " -i " + "\"" + filename + "\" -vframes 1 -q:v 2 \"" + temp_folder + "\\screen_n_" + (TimeSpan.Parse(res).TotalSeconds/2).ToString() + ".jpg\"";
            AddLog(proc.StartInfo.Arguments);

            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;

            if (!proc.Start())
            {

            }
            StreamReader reader = proc.StandardError;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                AddVLog(line);
            }
            //Console.ReadKey();
            proc.Close();

            try
            {
                proc.Kill();
            }
            catch { }

            picColorNew.Image = Image.FromFile(stout);


        }

        private void picColorOrig_Click(object sender, EventArgs e)
        {
            double d = Double.Parse(picColorNew.Tag.ToString());
            Random r = new Random();

            d = d * (r.NextDouble() * 1);
            AddLog(d.ToString());

            picColorOrig.Tag = d.ToString();
            picColorOrig.Image = Image.FromFile(getScreenShot(txtColorFile.Text, d.ToString(), true));
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSplitUpdateTime_Click(object sender, EventArgs e)
        {
            int splitIndex = lstSplit.SelectedIndex;
            if(splitIndex>=0)
            {
                lstSplit.Items.RemoveAt(splitIndex);
                lstSplit.Items.Insert(splitIndex, TimeSpan.FromTicks((long)txtStartPos.Tag).TotalSeconds.ToString() + " - " + TimeSpan.FromTicks((long)txtEndPos.Tag).TotalSeconds.ToString());
                UpdateSplitsCache();
            }
            else
            {
                AddLog("Please select a split time to update first");
            }
        }

        private void picColorOrig_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void picColorOrig_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void picColorOrig_MouseEnter(object sender, EventArgs e)
        {
            picColorNew.Visible = true;
        }

        private void picColorNew_MouseLeave(object sender, EventArgs e)
        {
            picColorNew.Visible = false;
        }

        private void picColorNew_Click(object sender, EventArgs e)
        {
            picColorOrig_Click(null, null);
        }

        private static DialogResult ShowInputDialog(ref string input, string name)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = name;

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void btnJumpTime_Click(object sender, EventArgs e)
        {
            string input = "00:00:00";
            DialogResult r = ShowInputDialog(ref input, "Enter time string");
            if(r==DialogResult.OK)
            {
                if (IsNumeric(input))
                {
                    if (input.Length == 1) //seconds
                    {
                        input = "00:00:0" + input;
                    }
                    else if (input.Length == 2) //seconds
                    {
                        input = "00:00:" + input;
                    }
                    else if (input.Length == 3) //minutes
                    {
                        input = "00:0" + input.Substring(0, 1) + ":" + input.Substring(1, 2);
                    }
                    else if (input.Length == 4) //minutes
                    {
                        input = "00:" + input.Substring(0, 2) + ":" + input.Substring(2, 2);
                    }
                    else if (input.Length == 5) //hours
                    {
                        input = "0" + input.Substring(0, 1) + ":" + input.Substring(1, 2) + ":" + input.Substring(3, 2);
                    }
                    else if (input.Length == 6) //hours
                    {
                        input = input.Substring(0, 2) + ":" + input.Substring(2, 2) + ":" + input.Substring(4, 2);
                    }
                    else
                    {
                        return;
                    }
                    input += ".0";

                    double ztime = TimeSpan.Parse(input).TotalSeconds;
                    
                    if (ztime > scrollBar.Maximum) return;
                    scrollBar.Value = (int)ztime;
                    scrollBar_Scroll(sender, null);

                    string[] time = txtStartPos.Text.Split('.');
                    int x = 0;
                    Int32.TryParse(time[1].ToString(), out x);
                    scrollBarMilli.Value = x;
                    scrollBarMilli_Scroll(sender, null);

                    //txtCurrentPos.Text = input;
                }
                
            }
        }

        private void txtCurrentPos_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void lstSplit_SizeChanged(object sender, EventArgs e)
        {

        }

        private void btnSplitsRestore_Click(object sender, EventArgs e)
        {
            lstSplit.Items.Clear();
            foreach (string line in System.IO.File.ReadLines(Application.StartupPath.ToString() + @"\splits.txt"))
            {
                lstSplit.Items.Add(line); 
                
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void forward10SecsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scrollBar.Value + 10 > scrollBar.Maximum)
            {
                scrollBar.Value = scrollBar.Maximum;
            }
            else
            {
                scrollBar.Value += 10;
            }
            scrollBar_Scroll(sender, null);
        }

        private void chkSplitForceMP4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEndPos_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkAutoSetStart_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void forward1SecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(scrollBar.Value + 1 > scrollBar.Maximum)
            {
                scrollBar.Value = scrollBar.Maximum;
            }
            else
            {
                scrollBar.Value += 1;
            }
            
            scrollBar_Scroll(sender, null);
        }

        private void forward10SecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scrollBarMilli.Value + 10 > 99)
            {
                scrollBarMilli.Value = 99;// scrollBarMilli.Maximum;
            }
            else
            {
                scrollBarMilli.Value += 10;
            }
            scrollBarMilli_Scroll(sender, null);
        }

        private void forward1SecToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (scrollBarMilli.Value + 1 > 99)
            {
                scrollBarMilli.Value = 99;
            }
            else
            {
                scrollBarMilli.Value += 1;
            }
            scrollBarMilli_Scroll(sender, null);
        }

        private void back10SecsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scrollBar.Value < 10)
            {
                scrollBar.Value = 0;
            }
            else
            {
                scrollBar.Value -= 10;
            }
            scrollBar_Scroll(sender, null);
        }

        private void back1SecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scrollBar.Value < 1)
            {
                scrollBar.Value = 0;
            }
            else
            {
                scrollBar.Value -= 1;
            }
            scrollBar_Scroll(sender, null);
        }

        private void back10SecsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (scrollBarMilli.Value < 10)
            {
                scrollBarMilli.Value = 0;
            }
            else
            {
                scrollBarMilli.Value -= 10;
            }
            scrollBarMilli_Scroll(sender, null);
        }

        private void back01SecsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scrollBarMilli.Value < 1)
            {
                scrollBarMilli.Value = 0;
            }
            else
            {
                scrollBarMilli.Value -= 1;
            }
            scrollBarMilli_Scroll(sender, null);
        }

        private void beginningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scrollBarMilli.Value = 0;
            scrollBar.Value = 0;

            scrollBar_Scroll(sender, null);
            scrollBarMilli_Scroll(sender, null);
        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scrollBarMilli.Value = scrollBarMilli.Maximum - (scrollBarMilli.LargeChange - 1);
            scrollBar.Value = scrollBar.Maximum - (scrollBar.LargeChange - 1);

            scrollBar_Scroll(sender, null);
            scrollBarMilli_Scroll(sender, null);
        }

        private void seekToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void setStartPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStartPos_Click(sender, e);
        }

        private void setEndPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEndPos_Click(sender, e);
        }

        private void addToSplitQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSplitQueue_Click(sender, e);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}

