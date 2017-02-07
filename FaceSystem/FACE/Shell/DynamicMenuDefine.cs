using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Shell.ViewModels;
using SING.Data;

namespace Shell
{
    public class ParagraphMenuItemViewMode : MenuItemViewModel
    {

        private Thickness paragraphMargin;

        public Thickness ParagraphMargin
        {
            get { return paragraphMargin; }
            set
            {
                paragraphMargin = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("ParagraphMargin"));
            }
        }
        public ParagraphMenuItemViewMode()
        {

        }
    }
    public class ParagraphImageMenuItemViewMode : MenuViewModel
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

        public ParagraphImageMenuItemViewMode()
        {

        }
    }

    public class ComboxMenuItemViewMode : MenuViewModel
    {
        public string[] ComboxItems { get; set; }

        public string Title { get; set; }

        private object _selectIndex;
        private PropertyInfo _propertyInfo;

        public PropertyInfo PropertyInfo
        {
            get { return _propertyInfo; }
            set { _propertyInfo = value; }
        }

        private object test1;

        public object SelectIndex
        {
            get { return _selectIndex; }
            set
            {
                _selectIndex = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("SelectIndex"));
                if (DataContext != null)
                {
                    PropertyInfo.SetValue(DataContext, value, null);
                }
            }
        }

        public ShellViewModel DataContext { get; set; }

        public ComboxMenuItemViewMode()
        {

        }
    }

    /// <summary>
    /// 含有角标的图片菜单。
    /// </summary>
    public class SubscriptImageMenuItemViewMode : MenuItemViewModel
    {
        public SubscriptImageMenuItemViewMode()
        {

        }

        /// <summary>
        /// 显示的计数量。
        /// </summary>
        private int promptCount;

        public int PromptCount
        {
            get { return promptCount; }
            set
            {
                promptCount = value;

                if (value <= 0)
                {
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.Visibility = Visibility.Visible;
                }

                this.OnPropertyChanged(new PropertyChangedEventArgs("PromptCount"));
            }
        }

        /// <summary>
        /// 是否显示角标。
        /// </summary>
        private Visibility visibility;

        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;

                this.OnPropertyChanged(new PropertyChangedEventArgs("Visibility"));
            }
        }
    }

    public class MenuItemStyleSelector : StyleSelector
    {
        public Style Logo { get; set; }
        public Style TopLevel { get; set; }
        public Style TopLevelSection { get; set; }
        public Style Title { get; set; }
        public Style Link { get; set; }
        public Style SpecialLink { get; set; }
        public Style Paragraph { get; set; }
        public Style Gallery { get; set; }
        public Style Image { get; set; }
        public Style Button { get; set; }
        public Style STopLevel { get; set; }
        public Style Combox { get; set; }
        public Style ParagraphImage { get; set; }
        public Style SubscriptImage { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            MenuItemViewModel menuItem = item as MenuItemViewModel;
            if (menuItem != null)
            {
                switch (menuItem.Type)
                {
                    case MenuItemViewModel.MenuItemTypes.Logo:
                        return this.Logo;
                    case MenuItemViewModel.MenuItemTypes.TopLevel:
                        return this.TopLevel;
                    case MenuItemViewModel.MenuItemTypes.STopLevel:
                        return this.STopLevel;
                    case MenuItemViewModel.MenuItemTypes.TopLevelSection:
                        return this.TopLevelSection;
                    case MenuItemViewModel.MenuItemTypes.Title:
                        return this.Title;
                    case MenuItemViewModel.MenuItemTypes.Link:
                        return this.Link;
                    case MenuItemViewModel.MenuItemTypes.SpecialLink:
                        return this.SpecialLink;
                    case MenuItemViewModel.MenuItemTypes.Paragraph:
                        return this.Paragraph;
                    case MenuItemViewModel.MenuItemTypes.Gallery:
                        return this.Gallery;
                    case MenuItemViewModel.MenuItemTypes.Image:
                        return this.Image;
                    case MenuItemViewModel.MenuItemTypes.Button:
                        return this.Button;
                    case MenuItemViewModel.MenuItemTypes.SubscriptImage:
                        return this.SubscriptImage;
                    default:
                        return this.Link;
                }
            }

            ComboxMenuItemViewMode comboxMenuItem = item as ComboxMenuItemViewMode;
            if (comboxMenuItem != null)
            {
                return this.Combox;
            }

            ParagraphImageMenuItemViewMode imageMenuItem = item as ParagraphImageMenuItemViewMode;
            if (imageMenuItem != null)
            {
                return this.ParagraphImage;
            }

            return null;
        }
    }
}
