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
    /// Interaction logic for ChannelGridControl.xaml
    /// </summary>
    public partial class ChannelGridControl : UserControl
    {
        public ChannelGridControl()
        {
            InitializeComponent();

            //IList<int> values = new List<int>();
            //for (int i = 0; i < 100; i++)
            //{
            //    values.Add(i);
            //}
            //cameraList.ItemsSource = values;
            

        }

        private void cameraList_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int count = cameraList.SelectedItems.Count - 1;
                if (cameraList.SelectedItems.Count > 1)
                {
                    for (int i = 0; i < count; i++)
                    {
                        cameraList.SelectedItems.RemoveAt(0);
                    }
                    ListView.SetIsSelected(cameraList, false);
                }
                else
                {
                    ListView.SetIsSelected(cameraList, true);
                    object obj = cameraList.SelectedItem;
                    if (obj == null)
                    {
                        MessageBox.Show("请左键选中摄像头");
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void cameraList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int count = cameraList.SelectedItems.Count - 1;
                if (cameraList.SelectedItems.Count > 1)
                {
                    for (int i = 0; i < count; i++)
                    {
                        cameraList.SelectedItems.RemoveAt(0);
                    }
                    ListView.SetIsSelected(cameraList, false);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }
    }
}
