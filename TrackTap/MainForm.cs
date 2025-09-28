using TrackTap.Models;

namespace TrackTap
{
    public partial class MainForm : Form
    {
        public VideoInspection CurrentVideoInspection { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
