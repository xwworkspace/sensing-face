using FACE_ChannelManagement.Models;
using FACE_ChannelManagement.ViewModels;
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
    /// Interaction logic for ChannelTreeControl.xaml
    /// </summary>
    public partial class ChannelTreeControl : UserControl
    {
        readonly ChannelTreeViewModel _familyTree;
        public ChannelTreeControl()
        {
            InitializeComponent();

            Channel rootPerson = DataAccess.GetFamilyTree();

            _familyTree = new ChannelTreeViewModel(rootPerson);

            base.DataContext = _familyTree;
        }
    }
}
