using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The application state as a viewmodel
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Chat;

        /// <summary>
        /// True if the side menu should be shown
        /// </summary>
        public bool SideMenuVisible { get; set; } = true;

        /// <summary>
        /// go to the specific page
        /// </summary>
        /// <param name="page">page</param>
        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;

            //if page is the chatpage side menu will be visible
            SideMenuVisible = page == ApplicationPage.Chat;

        }
    }
}
