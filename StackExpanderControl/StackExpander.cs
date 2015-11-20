using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StackExpanderControl
{
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(StackExpanderItem))]
    public class StackExpander : ItemsControl
    {
        static StackExpander()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (StackExpander),
                new FrameworkPropertyMetadata(typeof (StackExpander)));
        }

        public StackExpander()
        {
            ExpandedExpanderItems= new List<StackExpanderItem>();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is StackExpanderItem;
        }

        public static readonly DependencyProperty MultiExpandedProperty = DependencyProperty.Register(
            "MultiExpanded", typeof (bool), typeof (StackExpander), new PropertyMetadata(default(bool), (o, args) =>
            {
                var control = (StackExpander) o;
                control.CollapseAll();
            }));

        public bool MultiExpanded
        {
            get { return (bool) GetValue(MultiExpandedProperty); }
            set { SetValue(MultiExpandedProperty, value); }
        }

        internal List<StackExpanderItem> ExpandedExpanderItems { get; set; }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            if (item is StackExpanderItem) return;
            base.PrepareContainerForItemOverride(element, item);
            if (item is FrameworkElement)
            {
                RemoveLogicalChild(item);
                RemoveVisualChild((Visual) item);
            }
        }

        private StackExpanderItem _lastExpandedExpanderItem;
        internal StackExpanderItem LastExpandedExpanderItem
        {
            get { return _lastExpandedExpanderItem; }
            set
            {
                _lastExpandedExpanderItem = value;
                SelectedItem = ItemContainerGenerator.ItemFromContainer(value);
            }
        }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem", typeof(object), typeof(StackExpander), new PropertyMetadata(default(object)));
        public object SelectedItem
        {
            get { return (object) GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public void CollapseAll()
        {
            var list = new List<StackExpanderItem>(ExpandedExpanderItems);
            foreach (var expanderItem in list)
            {
                expanderItem.IsExpanded = false;
            }
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new StackExpanderItem();
        }
    }
}
