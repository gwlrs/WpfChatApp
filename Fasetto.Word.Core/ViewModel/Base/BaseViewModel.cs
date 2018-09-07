using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{

    /// <summary>
    /// A base viewmodel that fires a property changed events as needs
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when child property changed its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged  = (sender, e)=> { };


        /// <summary>
        /// call this to fire <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }


        #region Command Helpers

        /// <summary>
        /// Runs a commang if the updatinflag is not set
        /// If the flag is true (indicating the function is already running) then the action won't run.
        /// If the flag is false (indicating the function is not running) then the action will run
        /// Once the action is finished if it was run, then the flag is reset to false
        /// </summary>
        /// <param name="updatingFlag">the boolean property flag defining if the command runs</param>
        /// <param name="action">The action to run if the command is not running</param>
        /// <returns></returns>
        protected async Task RunCommandAsync(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            // Check if the flag property is true (if it is true then the function already running)
            if (updatingFlag.GetPropertyValue())
                return;

            // Set propery flag to true to indicate we are running
            updatingFlag.SetPropertyValue(true);

            try
            {
                // run the passed action
                await action();
            }
            finally
            {
                // Set again the flag to false
                updatingFlag.SetPropertyValue(false);
            }
        }
        #endregion
    }
}
