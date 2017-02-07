using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls;

namespace Shell.Models
{
    public class OpendWindow
    {
        public OpendWindow()
        {

        }

        /// <summary>
        /// 窗体的Title。
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 窗体状态标识（标识当前激活）。
        /// </summary>
        public string ActiveColor
        {
            get
            {
                if (this.Window != null)
                {
                    return (this.Window.IsActive == true ? "#E4393C" : "#B7B7B7");
                }
                else
                {
                    return ((this.RadWindow.IsActiveWindow == true && this.RadWindow.WindowState == WindowState.Normal) ? "#E4393C" : "#B7B7B7");
                }
            }
            set
            {

            }
        }

        /// <summary>
        /// Window窗体。
        /// </summary>
        public Window Window { get; set; }

        /// <summary>
        /// RadWindow窗体。
        /// </summary>
        public RadWindow RadWindow { get; set; }
    }
}
