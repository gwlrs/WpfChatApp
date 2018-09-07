
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// No frame history attached property for creating  a <see cref="Frame"/> that 
    /// never shows navigation and keep navigation history empty
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the frame
            var frame = (sender as Frame);

            // hide the navigation bar
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            // clear history on navigate
            frame.Navigated += (ss, ee) =>  ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}
