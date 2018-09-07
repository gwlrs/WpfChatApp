using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Private member

        #endregion

        #region  Public properties
        /// <summary>
        /// the email of the user
        /// </summary>
        public string Email { get; set; }

        public bool RegisterIsRunning { get; set; }

        #endregion

        #region Commands

        public ICommand RegisterCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RegisterViewModel()
        {
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async () => await LoginAsync());
        }
        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">passed of the user's secure password string</param>
        /// <returns></returns>
        private async Task RegisterAsync(object parameter)
        {
            await RunCommandAsync(() => this.RegisterIsRunning, async () =>
            {
                await Task.Delay(5000);
                var email = this.Email;
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }


        /// <summary>
        /// Attempts to go to register page
        /// </summary>
        /// <param name="parameter">passed of the user's secure password string</param>
        /// <returns></returns>
        private async Task LoginAsync()
        {
            //IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;
            //return;

            //((WindowViewModel)(((MainWindow)Application.Current.MainWindow).DataContext)).CurrentPage = ApplicationPage.Register;

            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);

            await Task.Delay(1);
         

        }
    }
}
