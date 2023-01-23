﻿using System;
using System.Reflection;
using Dalamud.Plugin;
using Siren.IoC.Internal;
namespace Siren
{
    /// <summary>
    ///     Contains core methods for interacting with Siren.
    /// </summary>
    public static class SirenCore
    {

        /// <inheritdoc cref="ServiceContainer"/>
        internal static readonly ServiceContainer IoC = new();

        /// <summary>
        ///     Whether or not Siren has been disposed.
        /// </summary>
        private static bool isDisposed;

        /// <summary>
        ///     The initializing assembly.
        /// </summary>
        private static Assembly? initializerAssembly;

        /// <summary>
        ///     The name of the assembly/plugin that initialized Siren.
        /// </summary>
        private static string? initializerName;

        /// <summary>
        ///     Initializes the Siren library, using the provided <see cref="DalamudPluginInterface"/> to access Dalamud services.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Initialize is required to be called before accessing any Siren services, as it is responsible for creating
        ///         Both a <see cref="ServiceContainer"/> and a <see cref="SharedServices"/> instance.
        ///     </para>
        /// </remarks>
        /// <param name="pluginInterface">Your plugin's <see cref="DalamudPluginInterface"/>.</param>
        /// <param name="pluginName"></param>
        /// <exception cref="InvalidOperationException">Thrown if Siren has already been initialized.</exception>
        /// <exception cref="ObjectDisposedException">Thrown if Siren has been disposed.</exception>
        public static void Initialize(DalamudPluginInterface pluginInterface, string pluginName)
        {
            // Create Dalamud services.
            pluginInterface.Create<SharedServices>();

            // Set initializer information.
            initializerAssembly = Assembly.GetCallingAssembly();
            initializerName = pluginName;

            SirenLog.IDebug($"Initialized successfully!");
        }

        /// <summary>
        ///     Disposes of Siren resources.
        /// </summary>
        public static void Dispose()
        {
            if (isDisposed)
            {
                return;
            }

            IoC.Dispose();
            isDisposed = true;
        }

        /// <summary>
        ///     Gets the initializing assembly.
        /// </summary>
        /// <returns>The initializing assembly.</returns>
        /// <exception cref="InvalidOperationException">Thrown if Siren has not been initialized.</exception>
        public static Assembly Initializer => initializerAssembly ?? throw new InvalidOperationException("Siren has not been initialized.");

        /// <summary>
        ///     Gets the name of the assembly/plugin that initialized Siren.
        /// </summary>
        /// <returns>The name of the assembly/plugin that initialized Siren.</returns>
        /// <exception cref="InvalidOperationException">Thrown if Siren has not been initialized.</exception>
        public static string InitializerName => initializerName ?? throw new InvalidOperationException("Siren has not been initialized.");

        /// <inheritdoc cref="ServiceContainer.InjectServices{T}"/>
        public static void InjectServices<T>() => IoC.InjectServices<T>(Assembly.GetCallingAssembly());

        /// <inheritdoc cref="ServiceContainer.GetService{T}"/>
        public static T? GetService<T>() => IoC.GetService<T>();

        /// <inheritdoc cref="ServiceContainer.GetOrCreateService{T}"/>
        public static T GetOrCreateService<T>() => IoC.GetOrCreateService<T>();
    }
}