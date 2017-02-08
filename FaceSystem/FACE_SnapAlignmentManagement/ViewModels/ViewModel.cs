﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACE_SnapAlignmentManagement.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.ServiceLocation;
using Sofa.Commons;
using Sofa.Container;

namespace FACE_SnapAlignmentManagement.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ViewModel : NotificationObject, INavigationAware
    {
        public readonly IDataService _dataService;
        public readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;
        private readonly IServiceLocator _serviceLocator;

        [ImportingConstructor]
        public ViewModel(IDataService dataService, IEventAggregator eventAggregator, IRegionManager regionManager, IServiceLocator serviceLocator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            _serviceLocator = serviceLocator;

            CommandRefreshChannel = new DelegateCommand<string>(ExecuteCommandRefreshChannel, CanCommandRefreshChannel);
        }

        #region 属性
        #endregion

        #region RefreshChannel
        public DelegateCommand<string> CommandRefreshChannel { get; private set; }

        private void ExecuteCommandRefreshChannel(string commandParameter)
        {
            try
            {

            }
            catch (Exception err)
            {

            }
        }

        private bool CanCommandRefreshChannel(string commandParameter)
        {
            return true;
        }
        #endregion


        #region INavigationAware Members
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            // Called to see if this view can handle the navigation request.
            // If it can, this view is activated.
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // Called when this view is deactivated as a result of navigation to another view.
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // Called to initialize this view during navigation.

            // Retrieve any required paramaters from the navigation Uri.
            string id = navigationContext.Parameters["ID"];

        }
        #endregion

        #region SofaCommonEventHandler


        public SofaComponent ThisSofaComponent;
        public IBaseContainer Container;

        public void SofaCommonEventHandler(object sender, SofaEventArgs e)
        {
            if (e.TargetGUID == ThisSofaComponent.GUID)
            {
                if (e.EventType == "PostOpen")
                {



                }

                if (e.EventType == "DataItemSelected")
                {

                }

            }

            if (e.EventType == "GotFocus")
            {
                e.Handled = true;
            }

            if (e.EventType == "Closed")
            {

            }

        }

        public void SofaCommonCancelEventHandler(object sender, SofaCancelEventArgs e)
        {

        }
        #endregion
    }
}
