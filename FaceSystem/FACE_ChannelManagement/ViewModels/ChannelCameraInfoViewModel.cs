using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace FACE_ChannelManagement.ViewModels
{
    public partial class ViewModel : NotificationObject
    {
        public ICommand CameraInfoSaveCommand { get; set; }

        public void InitChannelCameraInfoViewModel()
        {
            CameraInfoSaveCommand = new DelegateCommand(CameraInfoSaveFunc);
        }

        private void CameraInfoSaveFunc()
        {
            if (MessageBox.Show("保存成功", "保存结果", MessageBoxButton.OK) == MessageBoxResult.OK)
            {
                IsViewChannelList = Visibility.Visible;
                IsEditChannelCameraInfo = Visibility.Collapsed;
            }
        }
    }
}
