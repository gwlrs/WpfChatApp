
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// Focused (keyboard focus) to this element on load
    /// </summary>
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // if we don't have a control
            if (!(sender is Control control))
                return;

            // focus this control once loaded
            control.Loaded += (s, se) => control.Focus(); 
            
        }

      
    }
}
