using System;
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
        /// <inheritdoc cref="SirenServiceContainer" />
        private static readonly SirenServiceContainer IoC = new();

        /// <summary>
        ///     Whether or not Siren has been disposed.
        /// </summary>
        private static bool disposedValue;

        /// <summary>
        ///     The initializing assembly.
        /// </summary>
        internal static Assembly InitializerAssembly { get; private set; } = null!;

        /// <summary>
        ///     The name of the assembly/plugin that initialized Siren.
        /// </summary>
        internal static string InitializerName { get; private set; } = null!;

        /// <summary>
        ///     Initializes the Siren library, using the provided <see cref="DalamudPluginInterface" /> to access Dalamud
        ///     services.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Initialize is required to be called before accessing any Siren services, as it is responsible for creating
        ///         Both a <see cref="SirenServiceContainer" /> and a <see cref="SharedServices" /> instance.
        ///     </para>
        /// </remarks>
        /// <param name="pluginInterface">Your plugin's <see cref="DalamudPluginInterface" />.</param>
        /// <param name="pluginName"></param>
        /// <exception cref="InvalidOperationException">Thrown if Siren has already been initialized.</exception>
        /// <exception cref="ObjectDisposedException">Thrown if Siren has been disposed.</exception>
        public static void Initialize(DalamudPluginInterface pluginInterface, string pluginName)
        {
            // Set initializer information.
            InitializerAssembly = Assembly.GetCallingAssembly();
            InitializerName = pluginName;

            // Create Dalamud services.
            SharedServices.Initialize(pluginInterface);

            // Log initialization.
            SirenLog.Information($"Initialized Siren for {pluginName}.");
        }

        /// <summary>
        ///     Disposes of Siren resources.
        /// </summary>
        public static void Dispose()
        {
            if (!disposedValue)
            {
                IoC.Dispose();

                SirenLog.Information($"Disposed of Siren for {InitializerName}.");

                disposedValue = true;
            }
        }

        /// <inheritdoc cref="SirenServiceContainer.InjectServices{T}" />
        public static void InjectServices<T>() where T : class => IoC.InjectServices<T>();

        /// <inheritdoc cref="SirenServiceContainer.GetService{T}" />
        public static T? GetService<T>() where T : class => IoC.GetService<T>();

        /// <inheritdoc cref="SirenServiceContainer.GetOrCreateService{T}" />
        public static T GetOrCreateService<T>() where T : class => IoC.GetOrCreateService<T>();
    }
}