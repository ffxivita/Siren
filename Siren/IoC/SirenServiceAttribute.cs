using System;
using Siren.IoC.Internal;

namespace Siren.IoC
{
    /// <summary>
    ///     Marks a property as something that can be injected into via the <see cref="SirenServiceContainer" />.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SirenServiceAttribute : Attribute
    {
    }
}