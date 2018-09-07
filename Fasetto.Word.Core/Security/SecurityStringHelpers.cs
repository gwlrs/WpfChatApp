using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Helpers for <see cref="SecureString"/> class
    /// </summary>
   public static class SecurityStringHelpers
    {
        /// <summary>
        /// Unsecure a <see cref="SecureString"/> to a plain text
        /// </summary>
        /// <param name="secureString"></param>
        /// <returns></returns>
        public static string Unsecure(this SecureString secureString)
        {
            // make sure we have a secureString password
            if (secureString == null)
            {
                return String.Empty;
            }

            // Get a pointer for an unsecure string in memory
            var unmanagedString = IntPtr.Zero;
            try
            {
                // Unsecure the password
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                // clean up any memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
