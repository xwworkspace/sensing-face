using FACE_ChannelManagement.ViewModels;
using System.Windows.Controls;

namespace FACE_ChannelManagement.UserControls
{
    /// <summary>
    /// Interaction logic for ChannelTreeControl.xaml
    /// </summary>
    public partial class ChannelTreeControl : UserControl
    {
        public ChannelTreeControl()
        {
            InitializeComponent();
            this.DataContext = new ChannelGroupViewModel();
        }
    }
}
