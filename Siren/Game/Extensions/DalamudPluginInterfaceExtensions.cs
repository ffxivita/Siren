using System;
using Dalamud.Plugin;

namespace Siren.Game.Extensions
{
    /// <summary>
    ///     Extensions for <see cref="DalamudPluginInterface" />.
    /// </summary>
    public static class DalamudPluginInterfaceExtensions
    {
        /// <summary>
        ///     Checks to see if the plugin was loaded from the official Dalamud Plugin Repository.
        /// </summary>
        /// <param name="pluginInterface"></param>
        public static void IsMainRepo(this DalamudPluginInterface pluginInterface) => pluginInterface.SourceRepository.Equals("OFFICIAL", StringComparison.Ordinal);
    }
}