﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.Azure.ServiceBus.Primitives
{
    /// <summary>
    ///     Base Exception for various Service Bus errors.
    /// </summary>
    public class ServiceBusException : Exception
    {
        /// <summary>
        ///     Returns a new ServiceBusException
        /// </summary>
        /// <param name="isTransient">Specifies whether or not the exception is transient.</param>
        public ServiceBusException(bool isTransient)
        {
            IsTransient = isTransient;
        }

        /// <summary>
        ///     Returns a new ServiceBusException
        /// </summary>
        /// <param name="isTransient">Specifies whether or not the exception is transient.</param>
        /// <param name="message">The detailed message exception.</param>
        public ServiceBusException(bool isTransient, string message)
            : base(message)
        {
            IsTransient = isTransient;
        }

        /// <summary>
        ///     Returns a new ServiceBusException
        /// </summary>
        /// <param name="isTransient">Specifies whether or not the exception is transient.</param>
        /// <param name="innerException">The inner exception.</param>
        public ServiceBusException(bool isTransient, Exception innerException)
            : base(innerException.Message, innerException)
        {
            IsTransient = isTransient;
        }

        /// <summary>
        ///     Returns a new ServiceBusException
        /// </summary>
        /// <param name="isTransient">Specifies whether or not the exception is transient.</param>
        /// <param name="message">The detailed message exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public ServiceBusException(bool isTransient, string message, Exception innerException)
            : base(message, innerException)
        {
            IsTransient = isTransient;
        }

        /// <summary>
        ///     Gets the message as a formatted string.
        /// </summary>
        public override string Message
        {
            get
            {
                var baseMessage = base.Message;
                if (string.IsNullOrEmpty(ServiceBusNamespace))
                {
                    return baseMessage;
                }

                return "{0}, ({1})".FormatInvariant(ServiceBusNamespace);
            }
        }

        /// <summary>
        ///     A boolean indicating if the exception is a transient error or not.
        /// </summary>
        /// <value>returns true when user can retry the operation that generated the exception without additional intervention.</value>
        public bool IsTransient { get; }

        /// <summary>
        ///     Gets the Service Bus namespace from which the exception occured, if available.
        /// </summary>
        public string ServiceBusNamespace { get; internal set; }
    }
}