using System;
using Siren.IoC.Internal;

namespace Siren.IoC
{
    /// <summary>
    ///     Marks a property as something that can be injected into via the <see cref="ServiceContainer" />.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SirenServiceAttribute : Attribute
    {
    }
}