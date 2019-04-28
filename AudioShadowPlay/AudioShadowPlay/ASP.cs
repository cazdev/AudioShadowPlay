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
using NAudio.Wave;
using System.IO;

namespace AudioShadowPlay
{
    public partial class ASP : Form
    {
        private static bool SaveNext = false;
        private static int TimeBeforeCleanUp = 120;
        private static int FileCount = 0;
        private static bool filesLogEnabled = false;
        private static int SamplingRate = 44100;


        private static string outputPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\ASP\Temp\";
        private static string savedPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\ASP\SavedAudio\";
        private static string configPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\ASP\config.asp";
        private static string saveSoundPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\ASP\save.mp3";

        private WasapiLoopbackCapture CaptureInstance = null;
        private WaveFileWriter RecordedAudioWriter = null;

        KeyboardHook hook = new KeyboardHook();

        public ASP()
        {
            InitializeComponent();

            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + alt + F12 combination as hot key.
            hook.RegisterHotKey(AudioShadowPlay.ModifierKeys.Alt, Keys.F8);
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            // HotKey pressed
            btnSave.PerformClick();

            var reader = new Mp3FileReader(saveSoundPath);
            var waveOut = new WaveOut(); // or WaveOutEvent()
            waveOut.Init(reader);
            waveOut.Play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            System.IO.FileInfo file1 = new System.IO.FileInfo(outputPath);
            file1.Directory.Create(); // If the directory already exists, this method does nothing.

            System.IO.FileInfo file2 = new System.IO.FileInfo(savedPath);
            file2.Directory.Create(); // If the directory already exists, this method does nothing.

            File.WriteAllBytes(saveSoundPath, AudioShadowPlay.Properties.Resources.save);

            if (!File.Exists(configPath))
            {
                FileStream fs = File.Create(configPath);
                fs.Dispose();
            }

            txtTempSave.Text = "30";
            txtFileExpire.Text = "120";
            txtSamplingRate.Text = "44100";

            StreamReader sr = new StreamReader(configPath);
            string contents = sr.ReadToEnd();
            foreach (string line in File.ReadLines(configPath))
            {
                if (line.Contains("TempSaveInterval = "))
                {
                    txtTempSave.Text = line.Substring(18, line.Length - 18);
                    RestartRecording.Interval = Int16.Parse(line.Substring(18, line.Length - 18)) * 1000;
                }

                if (line.Contains("TempFileExpire = "))
                {
                    txtFileExpire.Text = line.Substring(17, line.Length - 17);
                    TimeBeforeCleanUp = Int16.Parse(line.Substring(17, line.Length - 17));
                }

                if (line.Contains("SaveSamplingRate = "))
                {
                    txtSamplingRate.Text = line.Substring(19, line.Length - 19);
                    SamplingRate = Int16.Parse(line.Substring(19, line.Length - 19));
                }

                if (line.Contains("FilesLog = False"))
                {
                    chkLog.Checked = false;
                    lstFiles.Visible = false;
                }
                else if (line.Contains("FilesLog = True"))
                {
                    chkLog.Checked = true;
                    lstFiles.Visible = true;
                }

                if (line.Contains("SavedPath = "))
                {
                    savedPath = line.Substring(12, line.Length - 12);
                }
            }
            sr.Dispose();
        }

        private void StartRecording()
        {
            string outputFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\ASP\Temp\temp_audio_{FileCount}.wav";
            
            // Redefine the capturer instance with a new instance of the LoopbackCapture class
            this.CaptureInstance = new WasapiLoopbackCapture();

            // Redefine the audio writer instance with the given configuration
            this.RecordedAudioWriter = new WaveFileWriter(outputFilePath, CaptureInstance.WaveFormat);

            // When the capturer receives audio, start writing the buffer into the mentioned file
            this.CaptureInstance.DataAvailable += (s, a) =>
            {
                this.RecordedAudioWriter.Write(a.Buffer, 0, a.BytesRecorded);
            };

            CaptureInstance.StartRecording();

            pnlRecording.Visible = true;

            pnlRecording.Visible = true;

            RestartRecording.Start();
        }

        private void StopRecording()
        {
            RestartRecording.Stop();

            if (CaptureInstance != null && RecordedAudioWriter != null)
            {
                // Stop audio recording
                CaptureInstance.StopRecording();
                this.RecordedAudioWriter.Dispose();
                this.RecordedAudioWriter = null;
                CaptureInstance.Dispose();
            }

            FileCount++;

            pnlRecording.Visible = false;

            SaveAudio();
        }

        private void SaveAudio()
        {
            if (SaveNext)
            {
                int outRate = SamplingRate;
                string inFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\ASP\Temp\temp_audio_{FileCount - 1}.wav";
                string outFile = savedPath +$@"\recorded_audio_save_{FileCount}.wav";

                Console.WriteLine(outFile);

                try
                {
                    using (MediaFoundationReader reader = new MediaFoundationReader(inFile))
                    {
                        WaveFormat outFormat = new WaveFormat(outRate, reader.WaveFormat.Channels, 1);
                        using (MediaFoundationResampler resampler = new MediaFoundationResampler(reader, outFormat))
                        {
                            // resampler.ResamplerQuality = 60;
                            WaveFileWriter.CreateWaveFile(outFile, resampler);
                        }
                    }
                }
                catch { }

                SaveNext = false;
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            StopRecording();

            btnSettings.BackColor = Color.Teal;
            pnlSettings.Visible = false;

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            StartRecording();
            RestartRecording.Start();

            btnSettings.BackColor = Color.Teal;
            pnlSettings.Visible = false;

            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveAudio();

            SaveNext = true;

            btnSettings.BackColor = Color.Teal;
            pnlSettings.Visible = false;
        }

        private void ASP_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopRecording();

            System.IO.DirectoryInfo di = new DirectoryInfo(outputPath);

            foreach (FileInfo file in di.GetFiles())
            {
                    file.Delete();
            }

            Environment.Exit(0);
        }

        private void RestartRecording_Tick(object sender, EventArgs e)
        {
            StopRecording();

            StartRecording();

            //Clean up
            System.IO.DirectoryInfo di = new DirectoryInfo(outputPath);

            try
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    if (file.CreationTime < DateTime.Now.AddSeconds(-TimeBeforeCleanUp))
                    {
                        file.Delete();
                    }
                }
            }
            catch { }
            lstFiles.Items.Clear();
            PopulateListBox(lstFiles, outputPath, "*.wav");
        }

        private void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            if (pnlSettings.Visible)
            {
                btnSettings.BackColor = Color.Teal;
                pnlSettings.Visible = false;
            }
            else
            {
                btnSettings.BackColor = Color.DarkCyan;
                pnlSettings.Visible = true;
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            RestartRecording.Interval = Int16.Parse(txtTempSave.Text) * 1000;
            TimeBeforeCleanUp = Int16.Parse(txtFileExpire.Text);
             SamplingRate = Int16.Parse(txtSamplingRate.Text);
            lblTick.Visible = true;

            if (chkLog.Checked)
            {
                lstFiles.Visible = true;
            }
            else
            {
                lstFiles.Visible = false;
            }

            WriteToConfig();
        }

        private void WriteToConfig()
        {
            File.WriteAllText(configPath, "");
            string line1 = $"TempSaveInterval = {RestartRecording.Interval / 1000}" + Environment.NewLine;
            File.AppendAllText(configPath, line1) ;
            string line2 = $"TempFileExpire = {TimeBeforeCleanUp}" + Environment.NewLine;
            File.AppendAllText(configPath, line2);
            string line3 = $"SaveSamplingRate = {SamplingRate}" + Environment.NewLine;
            File.AppendAllText(configPath, line3);
            string line4 = $"FilesLog = {filesLogEnabled.ToString()}" + Environment.NewLine;
            File.AppendAllText(configPath, line4);
            string line5 = $"SavedPath = {savedPath}" + Environment.NewLine;
            File.AppendAllText(configPath, line5);
            string lineOther1 = Environment.NewLine + "--------------" + Environment.NewLine + Environment.NewLine;
            File.AppendAllText(configPath, lineOther1);
            string lineOther2 = "//Length of temp audio files (default = 30)" + Environment.NewLine;
            File.AppendAllText(configPath, lineOther2);
            string lineOther3 = "//TempFileExpire: Time before temp files are deleted (default = 120)" + Environment.NewLine;
            File.AppendAllText(configPath, lineOther3);
        }

        private void TxtTempSave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtTempSave_TextChanged(object sender, EventArgs e)
        {
            lblTick.Visible = false;    
        }

        private void TxtFileExpire_TextChanged(object sender, EventArgs e)
        {
            lblTick.Visible = false;
        }

        private void ASP_Click(object sender, EventArgs e)
        {
            btnSettings.BackColor = Color.Teal;
            pnlSettings.Visible = false;
        }

        private void BtnSaveDir_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "----------------------------------------------------------------------" + Environment.NewLine + "Select folder which AudioShadowPlay will save audio to." + Environment.NewLine + "----------------------------------------------------------------------";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    savedPath = fbd.SelectedPath;
                }
            }
        }

        private void ChkLog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLog.Checked)
            {
                lstFiles.Visible = true;
            }
            else
            {
                lstFiles.Visible = false;
            }
        }
    }
}
