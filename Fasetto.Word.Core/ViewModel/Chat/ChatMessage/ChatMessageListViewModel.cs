using System.Collections.Generic;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view model for a chat message thread list
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The chat thread items for the list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }

        /// <summary>
        /// True to show the attachment menu, false to hide
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        /// <summary>
        /// The view model for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        #endregion

        #region Public Commands
        /// <summary>
        /// Attachment button command
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        #endregion

        #region Constructor

        public ChatMessageListViewModel()
        {
            // Set the attachment command action 
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);

            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }
        #endregion

        #region Command Methods

        /// <summary>
        /// When the attachment button is clicked, show/hide attachment popup
        /// </summary>
        public void AttachmentButton()
        {
            // Attachment menu visibility toggle
            AttachmentMenuVisible ^= true;
        }
        #endregion
    }
}