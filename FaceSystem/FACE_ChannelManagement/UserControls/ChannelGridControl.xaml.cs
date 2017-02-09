using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FACE_ChannelManagement.UserControls
{
    /// <summary>
    /// Interaction logic for ChannelGridControl.xaml
    /// </summary>
    public partial class ChannelGridControl : UserControl
    {
        public ChannelGridControl()
        {
            InitializeComponent();

            IList<int> values = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                values.Add(i);
            }
            channelCemaraIp.ItemsSource = values;
        }
    }
}
