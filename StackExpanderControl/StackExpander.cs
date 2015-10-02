using System.Windows;
using System.Windows.Controls;

namespace StackExpanderControl
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:StackExpanderControl"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:StackExpanderControl;assembly=StackExpanderControl"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class StackExpander : ItemsControl
    {
        static StackExpander()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (StackExpander),
                new FrameworkPropertyMetadata(typeof (StackExpander)));
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is StackExpanderItem;
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);

            var contentPresenter = ((StackExpanderItem)element);
            contentPresenter.ContentTemplate = ItemTemplate;
            var framework = item as FrameworkElement;
            if (framework != null && framework.Parent!=null)
            {
        /*        RemoveChildHelper.RemoveChild(framework.Parent, framework);*/
                contentPresenter.Content = "rety";
            }
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new StackExpanderItem();
        }
    }
}
