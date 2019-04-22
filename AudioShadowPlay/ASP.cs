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
        
        private static string outputPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\ASP\Temp\";
        private static string savedPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\ASP\SavedAudio\";
        private static string configPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\ASP\config.asp";

        private WasapiLoopbackCapture CaptureInstance = null;
        private WaveFileWriter RecordedAudioWriter = null;

        public ASP()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.FileInfo file1 = new System.IO.FileInfo(outputPath);
            file1.Directory.Create(); // If the directory already exists, this method does nothing.

            System.IO.FileInfo file2 = new System.IO.FileInfo(savedPath);
            file2.Directory.Create(); // If the directory already exists, this method does nothing.

            if (!File.Exists(configPath))
            {
                FileStream fs = File.Create(configPath);
                fs.Dispose();
            }

            txtTempSave.Text = "30";
            txtFileExpire.Text = "120";

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
            }
            sr.Dispose();
        }

        private void StartRecording()
        {
            string outputFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\ASP\Temp\recorded_audio_{FileCount}.wav";
            
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

            btnStart.Enabled = false;
            btnStop.Enabled = true;

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

            btnStart.Enabled = true;
            btnStop.Enabled = false;

            if (SaveNext)
            {
                int outRate = 16000;
                string inFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\ASP\Temp\recorded_audio_{FileCount - 1}.wav";
                string outFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\ASP\SavedAudio\recorded_audio_save_{FileCount}.wav";

                using (MediaFoundationReader reader = new MediaFoundationReader(inFile))
                {
                    WaveFormat outFormat = new WaveFormat(outRate, reader.WaveFormat.Channels);
                    using (MediaFoundationResampler resampler = new MediaFoundationResampler(reader, outFormat))
                    {
                        // resampler.ResamplerQuality = 60;
                        WaveFileWriter.CreateWaveFile(outFile, resampler);
                    }
                }

                SaveNext = false;
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            StopRecording();

            btnSettings.BackColor = Color.Teal;
            pnlSettings.Visible = false;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            StartRecording();
            RestartRecording.Start();

            btnSettings.BackColor = Color.Teal;
            pnlSettings.Visible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            int outRate = 16000;
            string inFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\ASP\Temp\recorded_audio_{FileCount-1}.wav";
            string outFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\ASP\Saves\recorded_audio_save_{FileCount}.wav";

            try
            {
                using (MediaFoundationReader reader = new MediaFoundationReader(inFile))
                {
                    WaveFormat outFormat = new WaveFormat(outRate, reader.WaveFormat.Channels);
                    using (MediaFoundationResampler resampler = new MediaFoundationResampler(reader, outFormat))
                    {
                        // resampler.ResamplerQuality = 60;
                        WaveFileWriter.CreateWaveFile(outFile, resampler);
                    }
                }
            }
            catch { }

            SaveNext = true;

            btnSettings.BackColor = Color.Teal;
            pnlSettings.Visible = false;
        }

        private void ASP_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopRecording();

            Environment.Exit(0);
        }

        private void RestartRecording_Tick(object sender, EventArgs e)
        {
            StopRecording();

            StartRecording();

            //Clean up
            System.IO.DirectoryInfo di = new DirectoryInfo(outputPath);

            foreach (FileInfo file in di.GetFiles())
            {
                if (file.CreationTime < DateTime.Now.AddSeconds(-TimeBeforeCleanUp))
                {
                    file.Delete();
                }
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

            lblTick.Visible = true;

            WriteToConfig();
        }

        private void WriteToConfig()
        {
            File.WriteAllText(configPath, "");
            string line1 = $"TempSaveInterval = {RestartRecording.Interval / 1000}" + Environment.NewLine;
            File.AppendAllText(configPath, line1) ;
            string line2 = $"TempFileExpire = {TimeBeforeCleanUp}" + Environment.NewLine;
            File.AppendAllText(configPath, line2);
            string line3 = Environment.NewLine + "--------------" + Environment.NewLine + Environment.NewLine;
            File.AppendAllText(configPath, line3);
            string line4 = "//Length of temp audio files (default = 30)" + Environment.NewLine;
            File.AppendAllText(configPath, line4);
            string line5 = "//TempFileExpire: Time before temp files are deleted (default = 120)" + Environment.NewLine;
            File.AppendAllText(configPath, line5);
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
    }
}
