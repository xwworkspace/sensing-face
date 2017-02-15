using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
