using FACE_ChannelManagement.Models;
using SING.Data.Controls.ActiveXControl.DZVideoActiveX;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms.Integration;

namespace FACE_ChannelManagement.Services.ChannelServices
{
    public class CloseChannelService
    {
        public static Action CloseChannelFunc(IEnumerable windowsFormHostList, ChannelConfigData currentCamera)
        {
            Action close = () =>
            {
                if (currentCamera.IsOpened == true)
                {
                    if (windowsFormHostList is List<WindowsFormsHost>)
                    {
                        foreach (WindowsFormsHost wfh in windowsFormHostList)
                        {
                            if (wfh.Tag != null && wfh.Tag.ToString() == currentCamera.ChannelCfgData.TcChaneelID)
                            {
                                (wfh.Child as AxDZVideoControl).CloseCamera();
                                wfh.Child = null;
                                wfh.Tag = null;
                                break;
                            }
                        }
                        currentCamera.IsOpened = false;
                    }
                }
            };
            return close;
        }
    }
}
