using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ChatListItemViewModel"/>
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        /// <summary>
        /// A single instance of design model
        /// </summary>
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        /// <summary>
        /// Constructor
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "This is  a new super message app that you never used before like this";
            ProfilePictureRGB = "3099c5";
        }
    }
}
