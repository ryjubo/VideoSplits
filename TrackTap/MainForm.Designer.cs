
using AxWMPLib;
using System.Diagnostics.Eventing.Reader;
using System.Security;
using System.Windows.Forms;
using TrackTap.Models;
using WMPLib;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace TrackTap
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            TableLayoutPanel mainPanel = new TableLayoutPanel()
            {
                BackColor = System.Drawing.Color.AliceBlue,
                RowCount = 5,
                ColumnCount = 4,
                Dock = DockStyle.Fill
            };
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MediaPlayerControl = new AxWMPLib.AxWindowsMediaPlayer();

            ((System.ComponentModel.ISupportInitialize)MediaPlayerControl).BeginInit();
            SuspendLayout();

            MediaPlayerControl.Enabled = true;
            MediaPlayerControl.Name = "axWindowsMediaPlayer1";
            MediaPlayerControl.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            MediaPlayerControl.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(this.MediaPlayerControl, row: 0, column: 0);
            mainPanel.SetRowSpan(this.MediaPlayerControl, 3);
            mainPanel.SetColumnSpan(this.MediaPlayerControl, 3);

            //START MARK BUTTON
            this.StartMarkButton = new Button()
            {
                Text = "Mark Starting Time",
                Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 20f),
                Dock = DockStyle.Fill,
                BackColor = Color.DarkGreen,
                ForeColor = Color.White
            };
            StartMarkButton.Click += this.StartMarkButton_Click;
            mainPanel.Controls.Add(this.StartMarkButton, column: 0, row: 3);

            //MARK PLACER BUTTON
            this.MarkPlacerButton = new Button()
            {
                Text = "Mark Placer",
                Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 20f),
                Dock = DockStyle.Fill,
                BackColor = Color.Yellow,
                ForeColor = Color.Black
            };
            MarkPlacerButton.Click += this.MarkPlacerButton_Click;
            mainPanel.Controls.Add(this.MarkPlacerButton, column: 1, row: 3);

            //MOVEMENT TABLE
            TableLayoutPanel videoMovementPanel = new TableLayoutPanel()
            {
                BackColor = System.Drawing.Color.Transparent,
                RowCount = 1,
                ColumnCount = 4,
                Dock = DockStyle.Fill
            };
            videoMovementPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            videoMovementPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            videoMovementPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            videoMovementPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            System.Drawing.Font movementFont = new System.Drawing.Font(FontFamily.GenericSansSerif, 20);

            Button majorReverseButton = new Button() { Text = "<<", BackColor = Color.Gray, ForeColor = Color.White, Dock = DockStyle.Fill, Font = movementFont };
            majorReverseButton.Click += this.MajorReverseButton_Pressed;
            videoMovementPanel.Controls.Add(majorReverseButton);

            Button minorReverseButton = new Button() { Text = "<", BackColor = Color.LightGray, Dock = DockStyle.Fill, Font = movementFont };
            minorReverseButton.Click += this.MinorReverseButton_Pressed;
            videoMovementPanel.Controls.Add(minorReverseButton);

            Button minorForwardButton = new Button() { Text = ">", BackColor = Color.LightGray, Dock = DockStyle.Fill, Font = movementFont };
            minorForwardButton.Click += this.MinorFowardButton_Pressed;
            videoMovementPanel.Controls.Add(minorForwardButton);

            Button majorForwardButton = new Button() { Text = ">>", BackColor = Color.Gray, ForeColor = Color.White, Dock = DockStyle.Fill, Font = movementFont };
            majorForwardButton.Click += this.MajorForwardButton_Pressed;
            videoMovementPanel.Controls.Add(majorForwardButton);
            mainPanel.Controls.Add(videoMovementPanel, column: 2, row: 3);

            //LOAD VIDEO BUTTON
            this.LoadButton = new Button()
            {
                Text = "Load Video",
                Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 20f),
                Dock = DockStyle.Fill,
                BackColor = Color.Navy,
                ForeColor = Color.White
            };
            this.LoadButton.Click += this.LoadButton_Click;
            mainPanel.Controls.Add(this.LoadButton, column: 0, row: 4);
            mainPanel.SetColumnSpan(this.LoadButton, 2);

            //PRINT TO FILE
            this.PrintToFileButton = new Button()
            {
                Text = "Print To File",
                Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 20f),
                Dock = DockStyle.Fill,
                BackColor = Color.CornflowerBlue,
                ForeColor = Color.White
            };
            this.PrintToFileButton.Click += this.PrintToFileButton_Click;
            mainPanel.Controls.Add(this.PrintToFileButton, column: 2, row: 4);            

            //PLACER LIST VIEW TABLE
            mainPanel.Controls.Add(this.MarkedPlacerListView, column: 3, row: 0);
            mainPanel.SetRowSpan(this.MarkedPlacerListView, 5);

            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 768);
            this.Controls.Add(mainPanel);
            Name = "MainForm";
            Text = "Track Tap";
            ((System.ComponentModel.ISupportInitialize)MediaPlayerControl).EndInit();
            ResumeLayout(false);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MediaPlayerControl.URL = openFileDialog.FileName;
                this.MediaPlayerControl.Ctlcontrols.pause();

                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = "What event is this?",
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = "" };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                this.MediaPlayerControl.Ctlcontrols.stop();
                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    this.CurrentVideoInspection = new Models.VideoInspection(eventDescription: textBox.Text);
                }
            }
        }
        private void PrintToFileButton_Click(object sender, EventArgs e)
        {
            string fileName = $"{this.CurrentVideoInspection.EventDescription}_{DateTime.Now.ToString("yyyy_MM_ddTHH_mm")}.txt";

            File.Create(fileName).Close();
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(this.CurrentVideoInspection.EventDescription);

                foreach (VideoInspection.MarkedPlacer thisMarkedPlacer in this.CurrentVideoInspection.MarkedPlacers)
                {
                    sw.WriteLine($"  {thisMarkedPlacer.IdentifyingInformation}");
                    sw.WriteLine($"    {TimeSpan.FromMilliseconds(thisMarkedPlacer.MarkedMillisecondsInVideo - this.CurrentVideoInspection.StartTimeInMilliseconds)}");
                }                
            }
        }
        private void MarkPlacerButton_Click(object sender, EventArgs e)
        {
            if (this.CurrentVideoInspection == null)
            {
                return;
            }

            this.MediaPlayerControl.Ctlcontrols.pause();
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Add identifying information for this marked placer",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "" };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                this.CurrentVideoInspection.AddMarkedPlacer(textBox.Text, GetCurrentMillisecondsOfVideo());

                this.MarkedPlacerListView.Clear();

                this.MarkedPlacerListView.Items.Add(this.CurrentVideoInspection.EventDescription);

                foreach (VideoInspection.MarkedPlacer thisMarkedPlacer in this.CurrentVideoInspection.MarkedPlacers)
                {
                    this.MarkedPlacerListView.Items.Add($"  {thisMarkedPlacer.IdentifyingInformation}");
                    this.MarkedPlacerListView.Items.Add($"    {TimeSpan.FromMilliseconds(thisMarkedPlacer.MarkedMillisecondsInVideo - this.CurrentVideoInspection.StartTimeInMilliseconds)}");
                }
            }

            this.MediaPlayerControl.Ctlcontrols.pause();
        }

        private void StartMarkButton_Click(object sender, EventArgs e)
        {
            if (this.CurrentVideoInspection == null)
            {
                return;
            }

            this.CurrentVideoInspection.SetStartingMilliseconds(
                GetCurrentMillisecondsOfVideo()
            );
        }

        private void MajorReverseButton_Pressed(object sender, EventArgs e)
        {
            AdvanceVideo(millisecondsToAdvance: 0 - (this.MediaPlayerControl.network.encodedFrameRate * 5));
        }
        private void MinorReverseButton_Pressed(object sender, EventArgs e)
        {
            AdvanceVideo(millisecondsToAdvance: 0 - (this.MediaPlayerControl.network.encodedFrameRate * 2));
        }
        private void MinorFowardButton_Pressed(object sender, EventArgs e)
        {
            AdvanceVideo(millisecondsToAdvance: (this.MediaPlayerControl.network.encodedFrameRate));
        }
        private void MajorForwardButton_Pressed(object sender, EventArgs e)
        {
            AdvanceVideo(millisecondsToAdvance: (this.MediaPlayerControl.network.encodedFrameRate * 5));
        }
        private void AdvanceVideo(double millisecondsToAdvance)
        {
            this.MediaPlayerControl.Ctlcontrols.pause();
            double currentPosition = this.MediaPlayerControl.Ctlcontrols.currentPosition;            
            this.MediaPlayerControl.Ctlcontrols.currentPosition = currentPosition + (millisecondsToAdvance / 1000);
            ((WMPLib.IWMPControls2)this.MediaPlayerControl.Ctlcontrols).step(1);
            //this.MediaPlayerControl.Ctlcontrols.pause();
        }

        private double GetCurrentMillisecondsOfVideo()
        {
            return this.MediaPlayerControl.Ctlcontrols.currentPosition * 1000;
        }

        private AxWMPLib.AxWindowsMediaPlayer MediaPlayerControl;
        private Button LoadButton;
        private Button StartMarkButton;
        private Button MarkPlacerButton;
        private Button PrintToFileButton;
        private ListView MarkedPlacerListView = new ListView()
        {
            Dock = DockStyle.Fill,
            View = View.List
        };
    }
}
