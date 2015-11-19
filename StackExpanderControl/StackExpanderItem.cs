using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace StackExpanderControl
{
    public class StackExpanderItem : ExpanderEx
    {

        public StackExpander ParentStackExpander
        {
            get
            {
                var parent = VisualTreeHelper.GetParent(this);
                return ItemsControl.ItemsControlFromItemContainer(this) as StackExpander;
            }
        }

        public StackExpanderItem()
        {
            Expanded += StackExpanderItem_Expanded;
            Collapsed += StackExpanderItem_Collapsed;
        }

        private void StackExpanderItem_Collapsed(object sender, RoutedEventArgs routedEventArgs)
        {
            var parent = ParentStackExpander;
            if (parent == null && parent.ExpandedExpanderItems == null) return;
            parent.ExpandedExpanderItems.Remove(this);
        }

        private void StackExpanderItem_Expanded(object sender, RoutedEventArgs e)
        { 
            var parent = ParentStackExpander;
            if (parent == null) return;
            if (parent.MultiExpanded)
            {
                parent.ExpandedExpanderItems.Add(this);
            }
            else
            {
                if (parent.ExpandedExpanderItems.Count != 0)
                {
                    var clone = new List<StackExpanderItem>(parent.ExpandedExpanderItems);
                    foreach (var expanderItem in clone)
                    {
                        expanderItem.IsExpanded = false;
                    }
                }
                parent.ExpandedExpanderItems.Add(this);
            }
        }
    }
}
