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
    public class ChannelGroupViewModel : NotificationObject
    {
        #region Data

        Collection<ChannelViewModel> _firstGeneration;
        ChannelViewModel _rootNode;

        IEnumerator<ChannelViewModel> _matchingChannelEnumerator;
        string _searchText = String.Empty;

        #endregion // Data

        #region Constructor

        public ICommand SearchCommand { get; private set; }
        
        public ChannelGroupViewModel()
        {
            Channel rootNode = DataAccess.GetFamilyTree();            
            _rootNode = new ChannelViewModel(rootNode);

            _firstGeneration = new Collection<ChannelViewModel>(
                new ChannelViewModel[]
                {
                    _rootNode
                });

            SearchCommand = new DelegateCommand<object>(QueryCommandFunc);
        }
        
        private void QueryCommandFunc(object obj)
        {
            MessageBox.Show(_rootNode.IsSelected.ToString());
            this.PerformSearch();
            
        }

        #endregion // Constructor

        #region Properties

        #region FirstGeneration

        public Collection<ChannelViewModel> FirstGeneration
        {
            get { return _firstGeneration; }
            set
            {
                _firstGeneration = value;
                this.RaisePropertyChanged("FirstGeneration");
            }
        }

        #endregion // FirstGeneration

        #region SearchText

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
        #endregion // SearchText

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

        IEnumerable<ChannelViewModel> FindMatches(string searchText, ChannelViewModel person)
        {
            if (person.NameContainsText(searchText))
                yield return person;

            foreach (ChannelViewModel child in person.Children)
                foreach (ChannelViewModel match in this.FindMatches(searchText, child))
                    yield return match;
        }

        #endregion // Search Logic

    }
}
