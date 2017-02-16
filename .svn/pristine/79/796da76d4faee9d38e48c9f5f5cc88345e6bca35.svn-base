using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Resources;

namespace FACE_ChannelManagement.Services.ChannelServices
{
    [Export(typeof(ScreenSettingsService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ScreenSettingsService
    {
        /// <summary>
        /// 设置分屏,并添加子项
        /// </summary>
        /// <param name="i">几分屏</param>
        public static Action SetVideoGridScreen(int sceenCount, Grid VideoPartGrid, List<WindowsFormsHost> windowsFormHostList)
        {
            Action setVideoGridScreen = null;

            if (VideoPartGrid == null) VideoPartGrid = new Grid();
            try
            {
                //设置分屏,添加行列
                int rowCount = 0;
                int ColCount = 0;
                for (int i = 0; i < VideoPartGrid.Children.Count; i++)
                {
                    if (VideoPartGrid.Children[i] is Grid)
                    {
                        ((Grid)VideoPartGrid.Children[i]).Children.Clear();
                    }
                }
                //foreach (Grid thing in VideoPartGrid.Children)
                //{
                //    thing.Children.Clear();
                //}
                VideoPartGrid.Children.Clear();
                VideoPartGrid.RowDefinitions.Clear();
                VideoPartGrid.ColumnDefinitions.Clear();
                switch (sceenCount)
                {
                    case 1:
                        rowCount = 1;
                        ColCount = 1;
                        break;
                    case 2:
                        rowCount = 2;
                        ColCount = 1;
                        break;
                    case 3:
                        rowCount = 2;
                        ColCount = 2;
                        break;
                    case 4:
                        rowCount = 2;
                        ColCount = 2;
                        break;
                    case 5:
                    case 6:
                        rowCount = 3;
                        ColCount = 2;
                        break;
                    case 7:
                    case 8:
                    case 9:
                        rowCount = 3;
                        ColCount = 3;
                        break;
                    case 10:
                    case 11:
                    case 12:
                        rowCount = 4;
                        ColCount = 3;
                        break;
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                        rowCount = 4;
                        ColCount = 4;
                        break;
                }
                for (int i = 1; i <= rowCount; i++)
                {
                    VideoPartGrid.RowDefinitions.Add(new RowDefinition());
                }
                for (int i = 1; i <= ColCount; i++)
                {
                    VideoPartGrid.ColumnDefinitions.Add(new ColumnDefinition());
                }

                //添加子项
                for (int i = 0; i < sceenCount; i++)
                {
                    Grid screenGrid = new Grid();
                    ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
                    StreamResourceInfo streamResourceInfo;
                    string resourceStr = string.Empty;
                    resourceStr = @"pack://application:,,,/FACE;component/Resources/noVideoBackground.png";
                    streamResourceInfo = Application.GetResourceStream(new Uri(resourceStr, UriKind.Absolute));
                    screenGrid.Background = new ImageBrush((ImageSource)imageSourceConverter.ConvertFrom(streamResourceInfo.Stream));
                    if (sceenCount == 3 && i == 2)
                    {
                        screenGrid.SetValue(Grid.RowProperty, i / ColCount);
                        screenGrid.SetValue(Grid.ColumnProperty, i % ColCount);
                        screenGrid.SetValue(Grid.ColumnSpanProperty, 2);
                    }
                    else
                    {
                        screenGrid.SetValue(Grid.RowProperty, i / ColCount);
                        screenGrid.SetValue(Grid.ColumnProperty, i % ColCount);
                    }

                    screenGrid.Children.Add(windowsFormHostList[i]);
                    VideoPartGrid.Children.Add(screenGrid);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return setVideoGridScreen;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="VideoPartGrid"></param>
        /// <param name="windowsFormHostList"></param>
        /// <returns></returns>
        public Action SingleScreen(Grid VideoPartGrid, List<WindowsFormsHost> windowsFormHostList)
        {
            Action act = () => { };
            //{
            //页面上若已存在，必须执行清理工作
            if (VideoPartGrid == null) VideoPartGrid = new Grid();
            try
            {
                //设置分屏,添加行列
                for (int i = 0; i < VideoPartGrid.Children.Count; i++)
                {
                    ((Grid)VideoPartGrid.Children[i]).Children.Clear();
                }

                VideoPartGrid.Children.Clear();
                VideoPartGrid.RowDefinitions.Clear();
                VideoPartGrid.ColumnDefinitions.Clear();

                VideoPartGrid.RowDefinitions.Add(new RowDefinition());
                VideoPartGrid.ColumnDefinitions.Add(new ColumnDefinition());

                //添加子项
                Grid screenGrid = new Grid();
                ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
                StreamResourceInfo streamResourceInfo;
                string resourceStr = string.Empty;
                resourceStr = @"pack://application:,,,/FACE;component/../Resources/noVideoBackground.png";
                streamResourceInfo = Application.GetResourceStream(new Uri(resourceStr, UriKind.Absolute));
                screenGrid.Background = new ImageBrush((ImageSource)imageSourceConverter.ConvertFrom(streamResourceInfo.Stream));

                screenGrid.Children.Add(windowsFormHostList[0]);
                VideoPartGrid.Children.Add(screenGrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //};

            return act;
        }

    }
}
