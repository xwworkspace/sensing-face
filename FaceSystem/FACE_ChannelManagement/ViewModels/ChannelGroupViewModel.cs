﻿using FACE_ChannelManagement.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace FACE_ChannelManagement.ViewModels
{
    /// <summary>
    /// ChannelGroupViewModel
    /// 通道分组视图 viewModel
    /// </summary>
    public partial class ViewModel : NotificationObject
    {
        #region Command
        public ICommand SearchCommand { get; private set; }
        public ICommand SelectedCommand { get; private set; }
        public ICommand AddNewFolderCommand { get; private set; }
        public ICommand RenameCommand { get; private set; }
        #endregion

        #region Data

        Collection<ChannelTreeViewData> _firstGeneration;
        ChannelTreeViewData _rootNode;
        public ChannelTreeViewData RootNode
        {
            get { return _rootNode; }
            set { _rootNode = value; RaisePropertyChanged("RootNode"); }
        }
        IEnumerator<ChannelTreeViewData> _matchingChannelEnumerator;
        string _searchText = String.Empty;


        public Collection<ChannelTreeViewData> FirstGeneration
        {
            get { return _firstGeneration; }
            set
            {
                _firstGeneration = value;
                this.RaisePropertyChanged("FirstGeneration");
            }
        }
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (value == _searchText)
                    return;

                _searchText = value;
                this.RaisePropertyChanged("SearchText");

                _matchingChannelEnumerator = null;
            }
        }

        #endregion // Data

        public void InitChannelGroupViewModel()
        {
            Channel rootNode = DataAccess.GetFamilyTree();
            _rootNode = new ChannelTreeViewData(rootNode);

            _firstGeneration = new Collection<ChannelTreeViewData>(
                new ChannelTreeViewData[]
                {
                    _rootNode
                });

            SearchCommand = new DelegateCommand<object>((obj) => { this.PerformSearch(); });
            AddNewFolderCommand = new DelegateCommand<object>(AddNewFolderFunc);
            RenameCommand = new DelegateCommand<object>(RenameFunc);
        }

        #region CommandFunc
        private void RenameFunc(object obj)
        {

        }

        private void AddNewFolderFunc(object obj)
        {

        }
        #endregion // Properties

        #region Search Logic
        void PerformSearch()
        {
            if (_matchingChannelEnumerator == null || !_matchingChannelEnumerator.MoveNext())
                this.VerifyMatchingChannelEnumerator();

            var channel = _matchingChannelEnumerator.Current;

            if (channel == null)
                return;

            // Ensure that this person is in view.
            if (channel.Root != null)
                channel.Root.IsExpanded = true;

            channel.IsSelected = true;
        }

        void VerifyMatchingChannelEnumerator()
        {
            var matches = this.FindMatches(_searchText, _rootNode);
            _matchingChannelEnumerator = matches.GetEnumerator();

            if (!_matchingChannelEnumerator.MoveNext())
            {
                MessageBox.Show(
                    "没有找到匹配的名称.",
                    "再试一次",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                    );
            }
        }

        IEnumerable<ChannelTreeViewData> FindMatches(string searchText, ChannelTreeViewData person)
        {
            if (person.NameContainsText(searchText))
                yield return person;

            foreach (ChannelTreeViewData child in person.Children)
                foreach (ChannelTreeViewData match in this.FindMatches(searchText, child))
                    yield return match;
        }

        #endregion // Search Logic

    }
}
