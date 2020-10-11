// -----------------------------------------------------------------------
// <copyright file="SharedMemoryMapView.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root
// for license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace Mlos.Core
{
    public abstract class SharedMemoryMapView : CriticalFinalizerObject, IDisposable
    {
        /// <summary>
        /// Creates a new shared memory view.
        /// </summary>
        /// <param name="sharedMemoryMapName"></param>
        /// <param name="sharedMemorySize"></param>
        /// <exception cref="InvalidOperationException">Thrown when executed on unsupported OS.</exception>
        /// <returns></returns>
        public static SharedMemoryMapView Create(string sharedMemoryMapName, ulong sharedMemorySize)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Windows.SharedMemoryMapView.Create(sharedMemoryMapName, sharedMemorySize);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Linux.SharedMemoryMapView.Create(sharedMemoryMapName, sharedMemorySize);
            }
            else
            {
                throw new InvalidOperationException("Unsupported OS.");
            }
        }

        /// <summary>
        /// Creates or opens a shared memory view.
        /// </summary>
        /// <param name="sharedMemoryMapName"></param>
        /// <param name="sharedMemorySize"></param>
        /// <returns></returns>
        public static SharedMemoryMapView CreateOrOpen(string sharedMemoryMapName, ulong sharedMemorySize)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Windows.SharedMemoryMapView.CreateOrOpen(sharedMemoryMapName, sharedMemorySize);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Linux.SharedMemoryMapView.CreateOrOpen(sharedMemoryMapName, sharedMemorySize);
            }
            else
            {
                throw new InvalidOperationException("Unsupported OS.");
            }
        }

        /// <summary>
        /// Opens an existing shared memory view.
        /// </summary>
        /// <param name="sharedMemoryMapName"></param>
        /// <param name="sharedMemorySize"></param>
        /// <returns></returns>
        public static SharedMemoryMapView Open(string sharedMemoryMapName, ulong sharedMemorySize)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Windows.SharedMemoryMapView.Open(sharedMemoryMapName, sharedMemorySize);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Linux.SharedMemoryMapView.Open(sharedMemoryMapName, sharedMemorySize);
            }
            else
            {
                throw new InvalidOperationException("Unsupported OS.");
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="SharedMemoryMapView"/> class.
        /// </summary>
        ~SharedMemoryMapView()
        {
            Dispose(false);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            //
            Dispose(true);

            // Suppress finalization.
            //
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary>
        /// <param name="disposing"></param>
        protected abstract void Dispose(bool disposing);

        public IntPtr Buffer;

        public ulong MemSize;

        public bool CleanupOnClose;

        protected bool isDisposed;
    }
}
