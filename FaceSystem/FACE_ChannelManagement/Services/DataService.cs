﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using FACE_ChannelManagement.ViewModels;
using FACE_ChannelManagement.Services.ChannelServices;
using FACE_ChannelManagement.Services.HelperServices;
using System;
using FACE_ChannelManagement.Models;
using System.Windows.Controls;
using System.Windows.Forms.Integration;

namespace FACE_ChannelManagement.Services
{
    [Export(typeof(IDataService))]
    public class DataService : IDataService
    {
        public void InitialChannel(ViewModel viewModel)
        {
            InitChannelService service = new InitChannelService();
            service.DoWork(viewModel);
        }

        public void InitThreshold(ViewModel viewModel)
        {
            ThresholdService thresholdService = new ThresholdService();
            thresholdService.DoWork(viewModel);
        }

        #region 通道数据管理

        public void InitChannelType(ViewModel viewModel, ref List<string> channelType)
        {
            InitChannelService service = new InitChannelService();
            channelType = service.QueryDefChannelType();
        }

        public void InitChannelCameraSourceType(ViewModel viewModel, ref List<string> cameraSourceType)
        {
            InitChannelService service = new InitChannelService();
            cameraSourceType = service.QueryDefCameraType();
        }

        public int InitAddChannelData(ViewModel viewModel, ChannelCfg cfg)
        {
            ChannelDataService service = new ChannelDataService();
            return service.AddChannel(cfg);
        }

        public int InitModifyChannelData(ViewModel viewModel, ChannelCfg cfg)
        {
            ChannelDataService service = new ChannelDataService();
            return service.ModifyChannel(cfg);
        }

        public ChannelCameraInfoViewData ConvertToViewData(ChannelCfg thriftData)
        {
            ChannelDataService service = new ChannelDataService();
            return service.ConvertToViewData(thriftData);
        }

        public ChannelCfg ConvertToChannelCfgData(ChannelCameraInfoViewData viewData)
        {
            ChannelDataService service = new ChannelDataService();
            return service.ConvertToChannelCfgData(viewData);
        }

        /// <summary>
        /// 删除当前选中的摄像头（通道）
        /// </summary>
        /// <param name="channelID"></param>
        /// <param name="ip_port"></param>
        /// <returns></returns>
        public int DelChannelService(string channelID, params object[] ip_port)
        {
            return new ChannelDataService().DelChannel(channelID, ip_port);
        }

        public Action SingleScreen(Grid VideoPartGrid, List<WindowsFormsHost> windowsFormHostList)
        {
            return new ScreenSettingsService().SingleScreen(VideoPartGrid, windowsFormHostList);
        }
        #endregion
    }
}
