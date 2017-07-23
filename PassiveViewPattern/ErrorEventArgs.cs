namespace PassiveViewPattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorEventArgs"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public ErrorEventArgs(String message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorEventArgs"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ErrorEventArgs(String message, Exception innerException)
        {
            this.Message = message;
            this.InnerException = innerException;
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public String Message { get; private set; }

        /// <summary>
        /// Gets the inner exception.
        /// </summary>
        public Exception InnerException { get; private set; }
    }
}
