using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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

namespace FACE_HistorySearchManagement.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    [Export("FACE.MainRegion.ViewContract", typeof(UserControl))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ExportMetadata("ProductPrimaryName", "FACE_HistorySearchManagement")]
    [ExportMetadata("ProductSecondaryName", "")]
    [ExportMetadata("AuthoizedWord", "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF")]
    [ExportMetadata("AvalonContentType", "DocumentContent")]
    [ExportMetadata("AvalonPaneGroup", "WorkPad")]
    [ExportMetadata("IfExists_DefaultValue", "UseIt")]
    //[ExportMetadata("IfExists_DefaultValue", "DoNotUseIt")]
    [ExportMetadata("ImageURI", "")]
    [ExportMetadata("Label", "历史检索")]
    [ExportMetadata("DockId", 0)]
    [ExportMetadata("Hidden", "False")]
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}
