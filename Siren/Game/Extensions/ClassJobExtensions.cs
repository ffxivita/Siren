using Lumina.Excel.GeneratedSheets;
using Siren.Game.Enums;

namespace Siren.Game.Extensions
{
    public static class ClassJobExtensions
    {
        /// <summary>
        ///     Get class job role from class job
        /// </summary>
        /// <param name="classJob"></param>
        /// <returns></returns>
        public static ClassJobRole GetJobRole(this ClassJob classJob) => (ClassJobRole)classJob.Role;
    }
}