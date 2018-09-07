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
    public class LoginViewModel : BaseViewModel
    {
        #region Private member

        #endregion

        #region  Public properties
        /// <summary>
        /// the email of the user
        /// </summary>
        public string Email { get; set; }

        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }
        #endregion


        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">passed of the user's secure password string</param>
        /// <returns></returns>
        private async Task LoginAsync(object parameter)
        {
            await RunCommandAsync(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(1000);

                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat);
                //var email = this.Email;
                //var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }


        /// <summary>
        /// Attempts to go to register page
        /// </summary>
        /// <param name="parameter">passed of the user's secure password string</param>
        /// <returns></returns>
        private async Task RegisterAsync()
        {
            //IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;
            //return;

            //((WindowViewModel)(((MainWindow)Application.Current.MainWindow).DataContext)).CurrentPage = ApplicationPage.Register;

            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);

            await Task.Delay(1);


        }
    }
}
