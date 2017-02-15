﻿using FACE_ChannelManagement.Models;
using FACE_ChannelManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_ChannelManagement.Services
{
    public interface IDataService
    {
        void InitialChannel(ViewModel viewModel);
        void InitThreshold(ViewModel viewModel);


        void InitChannelType(ViewModel viewModel, ref List<string> channelType);
        void InitChannelCameraSourceType(ViewModel viewModel, ref List<string> cameraSourceType);


        int InitAddChannelData(ViewModel viewModel,ChannelCfg cfg);//添加新的通道数据
        int InitModifyChannelData(ViewModel viewModel,ChannelCfg cfg);//编辑通道数据


        ChannelCameraInfoViewData ConvertToViewData(ChannelCfg thriftData);
        ChannelCfg ConvertToChannelCfgData(ChannelCameraInfoViewData viewData);
    }
}
