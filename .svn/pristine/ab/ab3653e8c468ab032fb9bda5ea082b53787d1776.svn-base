using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SING.Data
{
    public class MenuViewModel : ObservableCollection<MenuViewModel>
    {
        public string TagStr { get; set; }

        private Visibility _menuVisibility = Visibility.Visible;
        public Visibility MenuVisibility
        {
            get { return _menuVisibility; }
            set { _menuVisibility = value; }
        }

        private bool _menuIsEnabled = true;
        public bool MenuIsEnabled
        {
            get { return _menuIsEnabled; }
            set { _menuIsEnabled = value; }
        }
    }

    /// <summary>
    /// 菜单条目。
    /// </summary>
    public class MenuItemViewModel : MenuViewModel
    {
        public enum MenuItemTypes : uint { Logo, Link, SpecialLink, TopLevel, STopLevel, TopLevelSection, Title, Paragraph, Gallery, Image, Button, Combox, SubscriptImage };

        private string _content;

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Content"));
            }
        }

        private MenuItemTypes _type;

        public MenuItemTypes Type
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }

        private bool isSeparator = false;
        public bool IsSeparator
        {
            get
            {
                return isSeparator;
            }
            set
            {
                if (isSeparator != value)
                {
                    isSeparator = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("IsSeparator"));
                }
            }
        }

        private string _toolTip;
        public string ToolTip
        {
            get { return _toolTip; }
            set
            {
                _toolTip = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("ToolTip"));
            }
        }

        private int _selectIndex;

        /// <summary>
        /// “工作航迹”当前选择的索引（按全部的计算）。
        /// </summary>
        public int SelectIndex
        {
            get { return this._selectIndex; }
            set
            {
                _selectIndex = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("SelectIndex"));
            }
        }

        public MenuItemViewModel()
        {

        }
    }
}
