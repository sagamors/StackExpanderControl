using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace StackExpanderControl
{
    public class ExpanderEx : Expander
    {

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ChangePath("Header", DisplayHeaderPath);
        }

        public static readonly DependencyProperty DisplayHeaderPathProperty = DependencyProperty.Register(
            "DisplayHeaderPath", typeof(string), typeof(ExpanderEx), new PropertyMetadata(default(string),
                (o, args) =>
                {
                    var control = (ExpanderEx)o;
                    control.ChangePath("Header", control.DisplayHeaderPath);
                }));

        public string DisplayHeaderPath
        {
            get { return (string)GetValue(DisplayHeaderPathProperty); }
            set { SetValue(DisplayHeaderPathProperty, value); }
        }

        private void ChangePath(string NameProperty, string newPath)
        {
            var descriptor = DependencyPropertyDescriptor.FromName(NameProperty, GetType(), GetType());
            var bindingExpression = this.GetBindingExpression(descriptor.DependencyProperty);
            if (bindingExpression == null) return;
            var _binding = bindingExpression.ParentBinding;
            SetBinding(descriptor.DependencyProperty, _binding.Clone("DataContext." + newPath));
        }

        public static readonly DependencyProperty DisplayMemberPathProperty = DependencyProperty.Register(
            "DisplayMemberPath", typeof(string), typeof(ExpanderEx), new PropertyMetadata(default(string),
                (o, args) =>
                {
                    var control = (ExpanderEx)o;
                    control.ChangePath("Content", control.DisplayMemberPath);
                }));

        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }
    }

    public static class BindingEx
    {
        public static Binding Clone(this Binding self)
        {
            return self.Clone(self.Path.Path);
        }

        public static Binding Clone(this Binding self, string path)
        {
            Binding clone = new Binding(path);
            if (self.Source != null)
                clone.Source = self.Source;
            clone.AsyncState = self.AsyncState;
            clone.BindsDirectlyToSource = self.BindsDirectlyToSource;
            clone.Converter = self.Converter;
            clone.ConverterParameter = self.ConverterParameter;
            if (self.ElementName != null)
                clone.ElementName = self.ElementName;
            clone.ConverterCulture = self.ConverterCulture;
            clone.IsAsync = clone.IsAsync;
            clone.NotifyOnSourceUpdated = self.NotifyOnSourceUpdated;
            clone.NotifyOnTargetUpdated = self.NotifyOnTargetUpdated;
            clone.Mode = self.Mode;
            clone.NotifyOnValidationError = self.NotifyOnValidationError;
            clone.UpdateSourceTrigger = self.UpdateSourceTrigger;
            clone.ValidatesOnDataErrors = self.ValidatesOnDataErrors;
            clone.UpdateSourceExceptionFilter = self.UpdateSourceExceptionFilter;
            clone.ValidatesOnNotifyDataErrors = self.ValidatesOnNotifyDataErrors;
            clone.ValidatesOnExceptions = self.ValidatesOnExceptions;

            foreach (var validationRule in self.ValidationRules)
            {
                clone.ValidationRules.Add(validationRule);
            }

            clone.BindingGroupName = self.BindingGroupName;
            clone.StringFormat = self.StringFormat;
            clone.FallbackValue = self.FallbackValue;
            clone.Delay = self.Delay;
            clone.RelativeSource = self.RelativeSource;
            clone.XPath = self.XPath;
            clone.TargetNullValue = self.TargetNullValue;

            return clone;
        }
    }
}
