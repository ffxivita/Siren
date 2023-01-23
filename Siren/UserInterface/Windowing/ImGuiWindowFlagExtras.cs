﻿using ImGuiNET;
namespace Siren.UserInterface.Windowing
{
    /// <summary>
    ///     A collection of <see cref="ImGuiWindowFlags"/> that are not included in ImGui.NET.
    /// </summary>
    public static class ImGuiWindowFlagExtras
    {
        /// <summary>
        ///     A window that cannot be moved or resized.
        /// </summary>
        public const ImGuiWindowFlags LockedPosAndSize = ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize;
    }
}