using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using TrackTap.Models;

namespace TrackTap
{
    public partial class MainForm : Form
    {
        public VideoInspection CurrentVideoInspection { get; set; }

        public MainForm()
        {
            InitializeComponent();

            _libVLC = new LibVLC();
            _mp = new LibVLCSharp.Shared.MediaPlayer(_libVLC);
            _videoView.MediaPlayer = _mp;
            _videoView.Dock = DockStyle.Fill;
        }
    }
}
