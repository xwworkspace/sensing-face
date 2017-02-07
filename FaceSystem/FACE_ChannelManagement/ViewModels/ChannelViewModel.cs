using FACE_ChannelManagement.Models;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;

namespace FACE_ChannelManagement.ViewModels
{
    public class ChannelViewModel: NotificationObject
    {
        #region Data

        readonly ReadOnlyCollection<ChannelViewModel> _children;
        readonly ChannelViewModel _parent;
        readonly Channel _person;

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
            _parent = parent;

            _children = new ReadOnlyCollection<ChannelViewModel>(
                    (from child in _person.Children
                     select new ChannelViewModel(child, this))
                     .ToList<ChannelViewModel>());
        }

        #endregion // Constructors

        #region Person Properties

        public ReadOnlyCollection<ChannelViewModel> Children
        {
            get { return _children; }
        }

        public string Name
        {
            get { return _person.Name; }
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
                    this.OnPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                if (_isExpanded && _parent != null)
                    _parent.IsExpanded = true;
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
                    this.OnPropertyChanged("IsSelected");
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

        public ChannelViewModel Parent
        {
            get { return _parent; }
        }

        #endregion // Parent

        #endregion // Presentation Members        

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members
    }
}
