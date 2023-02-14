#pragma warning disable CA1711 // Identifiers should not have incorrect suffix
using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace Siren.Game.Enums
{
    /// <summary>
    ///     Represents a content flag on a <see cref="Director" />.
    /// </summary>
    public enum ContentFlag : byte
    {
        ExplorerMode = 1,
    }
}