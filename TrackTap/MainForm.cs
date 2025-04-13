using TrackTap.Models;

namespace TrackTap
{
    public partial class MainForm : Form
    {
        public VideoInspection CurrentVideo { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
