using FACE_ChannelManagement.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace FACE_ChannelManagement.ViewModels
{
    public partial class ViewModel : NotificationObject
    {
        #region Command
        public ICommand SearchCommand { get; private set; }
        public ICommand SelectedCommand { get; private set; }
        public ICommand AddNewFolderCommand { get; private set; }
        public ICommand RenameCommand { get; private set; }
        #endregion

        #region Data

        Collection<ChannelTreeViewModel> _firstGeneration;
        ChannelTreeViewModel _rootNode;
        public ChannelTreeViewModel RootNode
        {
            get { return _rootNode; }
            set { _rootNode = value; RaisePropertyChanged("RootNode"); }
        }
        IEnumerator<ChannelTreeViewModel> _matchingChannelEnumerator;
        string _searchText = String.Empty;


        public Collection<ChannelTreeViewModel> FirstGeneration
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
            _rootNode = new ChannelTreeViewModel(rootNode);

            _firstGeneration = new Collection<ChannelTreeViewModel>(
                new ChannelTreeViewModel[]
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

        IEnumerable<ChannelTreeViewModel> FindMatches(string searchText, ChannelTreeViewModel person)
        {
            if (person.NameContainsText(searchText))
                yield return person;

            foreach (ChannelTreeViewModel child in person.Children)
                foreach (ChannelTreeViewModel match in this.FindMatches(searchText, child))
                    yield return match;
        }

        #endregion // Search Logic

    }
}
