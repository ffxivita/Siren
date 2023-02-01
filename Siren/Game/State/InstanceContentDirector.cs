using FFXIVClientStructs.FFXIV.Client.Game.Event;
using Siren.Game.Enums;

namespace Siren.Game.State
{
    public static class InstanceContentDirector
    {
        /// <summary>
        ///  Gets the ContentFlag of the current instance if available.
        /// </summary>
        /// <returns>The ContentFlag of the current instance, or null if not available.</returns>
        public static unsafe ContentFlag? GetInstanceContentFlag()
        {
            var instanceCD = EventFramework.Instance()->GetInstanceContentDirector();
            if (instanceCD == null)
            {
                return null;
            }

            var contentFlags = instanceCD->ContentDirector.Director.ContentFlags;
            return (ContentFlag)contentFlags;
        }

        /// <summary>
        /// Returns if the given content flag is set.
        /// </summary>
        /// <param name="flag">The content flag to check.</param>
        /// <returns>True if the flag is set, false otherwise.</returns>
        public static bool HasFlag(ContentFlag flag) => GetInstanceContentFlag() == flag;
    }
}