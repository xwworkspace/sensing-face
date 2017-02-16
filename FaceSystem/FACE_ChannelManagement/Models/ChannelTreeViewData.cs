using FACE_ChannelManagement.Models;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FACE_ChannelManagement.Models
{
    /// <summary>
    /// ChannelTreeViewModel
    /// </summary>
    public class ChannelTreeViewData : NotificationObject
    {
        #region Data

        Collection<ChannelTreeViewData> _children;
        ChannelTreeViewData _root;
        Channel _channel;
        bool _isExpanded;
        bool _isSelected;



        public ChannelTreeViewData Root { get; set; }
        public Collection<ChannelTreeViewData> Children { get { return _children; } set { _children = value; } }
        public string Name { get { return _channel.Name; } set { _channel.Name = value; } }
        public string ID { get { return _channel.Name; } set { _channel.ID = value; } }
        /// <summary>
        /// 展开/折叠 树
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

                if (_isExpanded && _root != null)
                    _root.IsExpanded = true;
            }
        }

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

        #endregion // Data

        #region Constructors

        public ChannelTreeViewData(Channel person)
            : this(person, null)
        {
        }

        private ChannelTreeViewData(Channel person, ChannelTreeViewData parent)
        {
            _channel = person;
            _root = parent;

            _children = new Collection<ChannelTreeViewData>(
                    (from child in _channel.Children
                     select new ChannelTreeViewData(child, this))
                     .ToList<ChannelTreeViewData>());
        }

        #endregion // Constructors

        public bool NameContainsText(string text)
        {
            if (String.IsNullOrEmpty(text) || String.IsNullOrEmpty(this.Name))
                return false;

            return this.Name.IndexOf(text, StringComparison.InvariantCultureIgnoreCase) > -1;
        }        
    }
}
