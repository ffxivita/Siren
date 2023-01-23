using System.IO;
using System.Runtime.CompilerServices;
using Dalamud.Logging;

namespace Siren
{{
    /// <summary>
    ///     Logging utility wrapping <see cref="PluginLog"/> with a nicer format, for use internally by Sirensong itself.
    /// </summary>
    /// <remarks>
    ///     This class is not intended to be used by plugins because of the way Dalamud handles logging.
    ///     If this class is used inside of a plugin, ti will show up as "Sirensong" in the log.
    /// </remarks>
    internal static class SirenLog
    {
        /// <summary>
        ///     Formats a log message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caller"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        private static string Format(string message, string? caller, string? file) => $"<{Path.GetFileName(file)}::{caller}> via {SirenCore.InitializerName}: {message}";

        /// <inheritdoc cref="PluginLog.Verbose(string, object[])"/>
        internal static void IVerbose(string message, [CallerMemberName] string? caller = null, [CallerFilePath] string? file = null) => PluginLog.Verbose(Format(message, caller, file));

        /// <inheritdoc cref="PluginLog.Debug(string, object[])"/>
        internal static void IDebug(string message, [CallerMemberName] string? caller = null, [CallerFilePath] string? file = null) => PluginLog.Debug(Format(message, caller, file));

        /// <inheritdoc cref="PluginLog.Information(string, object[])"/>
        internal static void IInformation(string message, [CallerMemberName] string? caller = null, [CallerFilePath] string? file = null) => PluginLog.Information(Format(message, caller, file));

        /// <inheritdoc cref="PluginLog.Warning(string, object[])"/>
        internal static void IWarning(string message, [CallerMemberName] string? caller = null, [CallerFilePath] string? file = null) => PluginLog.Warning(Format(message, caller, file));

        /// <inheritdoc cref="PluginLog.Error(string, object[])"/>
        internal static void IError(string message, [CallerMemberName] string? caller = null, [CallerFilePath] string? file = null) => PluginLog.Error(Format(message, caller, file));
    }
}