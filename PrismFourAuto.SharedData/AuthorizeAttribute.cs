using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismFourAuto.SharedData
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AuthorizeAttribute : System.Attribute
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AuthorizeAttribute"/> class.
        /// </summary>
        public AuthorizeAttribute()
        {
            Roles = new string[] { };
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public string[] Roles { get; set; }

        #endregion Public Properties
    }
}