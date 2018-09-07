using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view model for any popup menus
    /// </summary>
    public class BasePopupMenuViewModel : BaseViewModel
    {

        #region Public properties

        /// <summary>
        /// the background of the bubble
        /// </summary>
        public string BubbleBackground { get; set; }

        /// <summary>
        /// the alignment of the buble's arrow
        /// </summary>
        public ElementHorizontalAlignment ArrowAlignment { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePopupMenuViewModel()
        {
            // Set default values
            // TODO: Move colors into Core and make use of it here
            BubbleBackground = "fff000";
            ArrowAlignment = ElementHorizontalAlignment.Right;
        }

        #endregion
    }
}
