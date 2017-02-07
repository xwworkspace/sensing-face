using FACE_ChannelManagement.Models;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FACE_ChannelManagement.ViewModels
{
    public class ChannelViewModel: NotificationObject
    {
        #region Data

         Collection<ChannelViewModel> _children;
         ChannelViewModel _root;
         Channel _person;

        bool _isExpanded;
        bool _isSelected;

        #endregion // Data

        #region Constructors

        public ChannelViewModel(Channel person)
            : this(person, null)
        {
        }

        private ChannelViewModel(Channel person, ChannelViewModel parent)
        {
            _person = person;
            _root = parent;

            _children = new Collection<ChannelViewModel>(
                    (from child in _person.Children
                     select new ChannelViewModel(child, this))
                     .ToList<ChannelViewModel>());
        }

        #endregion // Constructors

        #region Person Properties

        public Collection<ChannelViewModel> Children
        {
            get { return _children; }
            set { value = _children; }
        }

        public string Name
        {
            get { return _person.Name; }
            set { value = _person.Name; }
        }

        #endregion // Person Properties

        #region Presentation Members

        #region IsExpanded

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is expanded.
        /// </summary>
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    this.RaisePropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                if (_isExpanded && _root != null)
                    _root.IsExpanded = true;
            }
        }

        #endregion // IsExpanded

        #region IsSelected

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    this.RaisePropertyChanged("IsSelected");
                }
            }
        }

        #endregion // IsSelected

        #region NameContainsText

        public bool NameContainsText(string text)
        {
            if (String.IsNullOrEmpty(text) || String.IsNullOrEmpty(this.Name))
                return false;

            return this.Name.IndexOf(text, StringComparison.InvariantCultureIgnoreCase) > -1;
        }

        #endregion // NameContainsText

        #region Parent

        public ChannelViewModel Root
        {
            get { return _root; }
        }

        #endregion // Parent

        #endregion // Presentation Members    
    }
}
