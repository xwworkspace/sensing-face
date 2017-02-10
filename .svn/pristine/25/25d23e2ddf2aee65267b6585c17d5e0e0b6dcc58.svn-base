using FACE_ChannelManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FACE_ChannelManagement.UserControls
{
    /// <summary>
    /// Interaction logic for ChannelTreeControl.xaml
    /// </summary>
    public partial class ChannelTreeControl : UserControl
    {
        //ChannelGroupViewModel channelMgt;
        ChannelTreeViewModel channelVMdoel;

        public ChannelTreeControl()
        {
            InitializeComponent();

            //channelMgt = new ChannelGroupViewModel();
            //this.DataContext = channelMgt;
            
        }

        TextBox tBox = new TextBox();
        TextBlock tBlock = new TextBlock();
        TextBox retBox = new TextBox();
        static string rename = string.Empty;

        private void treeView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                TreeView tv = sender as TreeView;
                object selectedItem = treeView.SelectedItem;
                TreeViewItem item = GetParentObjectEx<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;

                channelVMdoel = item.DataContext as ChannelTreeViewModel;

                tBox = FindVisualChidl<TextBox>(item as DependencyObject);
                tBlock = FindVisualChidl<TextBlock>(item as DependencyObject);
                tBox.Visibility = Visibility.Visible;
                tBlock.Visibility = Visibility.Collapsed;

                tBox.Focus();
                tBox.LostFocus += TBox_LostFocus;
                tBox.TextChanged += TBox_TextChanged;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void TBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tBox = sender as TextBox;
            tBlock.Text = tBox.Text;
        }

        private IEnumerable<ChannelTreeViewModel> GetMatchesChannel(string renameText, ChannelTreeViewModel person)
        {
            if (person.NameContainsText(renameText))
                yield return person;

            foreach (ChannelTreeViewModel child in person.Children)
                foreach (ChannelTreeViewModel match in this.GetMatchesChannel(renameText, child))
                {
                    match.Name = renameText;

                    if (match.Children.Count != 0)
                    {
                        object obj = match.Children;
                    }

                }
        }

        private void TBox_LostFocus(object sender, RoutedEventArgs e)
        {
            tBox.Visibility = Visibility.Collapsed;
            tBlock.Visibility = Visibility.Visible;

            try
            {
                object obj = GetMatchesChannel(retBox.Text, channelVMdoel);

                //int index = channelMgt.FirstGeneration[0].Children.IndexOf(channelVMdoel);
                //channelMgt.FirstGeneration[0].Children.RemoveAt(index);

                //channelVMdoel.Name = rename = retBox.Text;
                //channelMgt.FirstGeneration[0].Children.Insert(index, channelVMdoel);
                //Collection<ChannelViewModel> coll = channelMgt.FirstGeneration;

                //channelMgt = null;
                //channelMgt = new ChannelGroupViewModel();
                //channelMgt.FirstGeneration = coll;

                //this.DataContext = channelMgt;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        public TreeViewItem GetParentObjectEx<TreeViewItem>(DependencyObject obj) where TreeViewItem : FrameworkElement
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);
            while (parent != null)
            {
                if (parent is TreeViewItem)
                {
                    return (TreeViewItem)parent;
                }
                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }

        private T FindVisualChidl<T>(DependencyObject obj) where T : DependencyObject
        {
            try
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(obj, i);

                    if (child != null && child is T)
                    {
                        return (T)child;
                    }
                    else
                    {
                        T childOfChild = FindVisualChidl<T>(child);

                        if (childOfChild != null)
                        {
                            return childOfChild;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

    }
}
