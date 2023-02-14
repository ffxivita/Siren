using FFXIVClientStructs.FFXIV.Common.Math;
using ImGuiNET;
using Siren.UserInterface.Style;

namespace Siren.UserInterface
{
    public static partial class SiGui
    {
        /// <summary>
        ///     A <see cref="ImGui.TextUnformatted(string)" /> element.
        /// </summary>
        /// <param name="text"></param>
        public static void Text(string text) => ImGui.TextUnformatted(text);

        /// <summary>
        ///     A <see cref="ImGui.TextWrapped(string)" /> element without formatting.
        /// </summary>
        /// <param name="text"></param>
        public static void TextWrapped(string text)
        {
            ImGui.PushTextWrapPos(ImGui.GetWindowContentRegionMax().X);
            ImGui.TextUnformatted(text);
            ImGui.PopTextWrapPos();
        }

        /// <summary>
        ///     A <see cref="ImGui.TextColored(Vector4, string)" /> element without formatting.
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="text"></param>
        public static void TextColoured(Vector4 colour, string text)
        {
            ImGui.PushStyleColor(ImGuiCol.Text, colour);
            ImGui.TextUnformatted(text);
            ImGui.PopStyleColor();
        }

        /// <summary>
        ///     A <see cref="ImGui.TextDisabled(string)" /> element without formatting.
        /// </summary>
        /// <param name="text"></param>
        public static unsafe void TextDisabled(string text)
        {
            ImGui.PushStyleColor(ImGuiCol.Text, *ImGui.GetStyleColorVec4(ImGuiCol.TextDisabled));
            ImGui.TextUnformatted(text);
            ImGui.PopStyleColor();
        }

        /// <summary>
        ///     A <see cref="ImGui.TextDisabled(string)" /> element without formatting and wrapped to the window width.
        /// </summary>
        /// <param name="text"></param>
        public static unsafe void TextDisabledWrapped(string text)
        {
            ImGui.PushStyleColor(ImGuiCol.Text, *ImGui.GetStyleColorVec4(ImGuiCol.TextDisabled));
            TextWrapped(text);
            ImGui.PopStyleColor();
        }

        /// <summary>
        ///     A <see cref="ImGui.TextWrapped(string)" /> element without formatting and with a custom colour.
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="text"></param>
        public static void TextWrappedColoured(Vector4 colour, string text)
        {
            ImGui.PushStyleColor(ImGuiCol.Text, colour);
            TextWrapped(text);
            ImGui.PopStyleColor();
        }

        /// <summary>
        ///     A heading text with a separator and spacing below.
        /// </summary>
        /// <param name="text"></param>
        public static void Heading(string text)
        {
            TextDisabled(text);
            ImGui.Separator();
            ImGui.Dummy(Spacing.HeaderSpacing);
        }

        /// <summary>
        ///     A footer text with a separator and spacing above.
        /// </summary>
        /// <param name="text"></param>
        public static void Footer(string text)
        {
            ImGui.Dummy(Spacing.FooterSpacing);
            ImGui.Separator();
            TextDisabled(text);
        }

        /// <summary>
        ///     Text with a description below.
        /// </summary>
        /// <param name="title">The non-wrapped text to use for title.</param>
        /// <param name="description">The wrapped text to use for description.</param>
        public static void TextWithDescription(string title, string description)
        {
            TextWrapped(title);
            TextDisabledWrapped(description);
        }
    }
}