using System.Security;
using FFXIVClientStructs.FFXIV.Common.Math;
using ImGuiNET;

namespace Siren.Extensions
{
    public static class Vector4Extensions
    {
        public static uint ToUint(this Vector4 vector) => ImGui.GetColorU32(vector);
    }
}