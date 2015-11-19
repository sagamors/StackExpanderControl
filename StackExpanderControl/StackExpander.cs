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
            var contentPresenter = ((ContentControl) element);
            if (item is FrameworkElement)
            {
                RemoveLogicalChild(item);
                RemoveVisualChild((Visual) item);
            }
            contentPresenter.ContentTemplate = ItemTemplate;
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
