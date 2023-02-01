using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Siren.IoC.Internal
{
    /// <summary>
    /// Handles the creation and management of services.
    /// </summary>
    internal sealed class ServiceContainer : IServiceProvider, IDisposable
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ServiceContainer"/> class.
        /// </summary>
        internal ServiceContainer() { }

        /// <summary>
        /// The services held by the <see cref="ServiceContainer"/>.
        /// </summary>
        private readonly Lazy<List<object>> services = new(() => new List<object>(), true);

        /// <summary>
        /// Whether or not the <see cref="ServiceContainer"/> has been disposed of.
        /// </summary>
        private bool disposedValue;

        /// <summary>
        /// Disposes of the <see cref="ServiceContainer"/> and all services contained within it that implement <see cref="IDisposable"/>.
        /// </summary>
        public void Dispose()
        {
            if (!this.disposedValue)
            {
                foreach (var service in this.services.Value)
                {
                    if (service is IDisposable disposableService)
                    {
                        SirenLog.IVerbose($"Disposing of service {disposableService.GetType().Name}.");
                        disposableService.Dispose();
                    }
                }

                SirenLog.IVerbose("Disposed of the service container and all services.");
                this.disposedValue = true;
            }
        }

        /// <summary>
        /// A boolean value indicating if the given type is a valid service.
        /// </summary>
        private static bool IsValidService(Type type)
        {
            var attribute = type.GetCustomAttribute<SirenServiceClassAttribute>();
            if (attribute == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Creates a new instance of the given service type and adds it to the service container if it is valid.
        /// </summary>
        /// <param name="type">The type of the service to add.</param>
        /// <exception cref="ObjectDisposedException">Thrown if the service container has been disposed.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the service type is not valid.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the service type already exists.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the service type does not have a parameterless constructor.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="type"/> is null.</exception>
        /// <returns>The newly created service.</returns>
        internal object CreateService(Type type)
        {
            if (this.disposedValue)
            {
                throw new ObjectDisposedException(nameof(ServiceContainer));
            }

            if (!IsValidService(type))
            {
                throw new InvalidOperationException($"Cannot create service of type {type.Name} because it is not a valid service.");
            }

            var existingService = this.GetService(type);
            if (existingService != null)
            {
                throw new InvalidOperationException($"Cannot create service of type {type.Name} because it already exists.");
            }

            var constructor = type.GetConstructor(Type.EmptyTypes);
            if (constructor == null)
            {
                throw new InvalidOperationException($"Cannot create service of type {type.Name} because it does not have a parameterless constructor.");
            }

            var service = constructor.Invoke(null);
            if (service == null)
            {
                throw new ArgumentNullException(service?.GetType().Name);
            }

            this.services.Value.Add(service);
            SirenLog.IVerbose($"Successfully created service of type {service.GetType().Name}.");
            return service;
        }

        /// <inheritdoc cref="CreateService(Type)"/>
        /// <typeparam name="T">The type of the service to add.</typeparam>
        internal T CreateService<T>() where T : class => (T)this.CreateService(typeof(T));

        /// <summary>
        /// Gets a service from the service container.
        /// </summary>
        /// <param name="type">The type of the service to get.</param>
        /// <exception cref="ObjectDisposedException">Thrown if the service container has been disposed.</exception>
        /// <returns>The service, or null if it was not found.</returns>
        public object? GetService(Type type)
        {
            if (this.disposedValue)
            {
                throw new ObjectDisposedException(nameof(ServiceContainer));
            }
            return this.services.Value.FirstOrDefault(service => service.GetType() == type);
        }

        /// <inheritdoc cref="GetService(Type)"/>
        /// <typeparam name="T">The type of the service to get.</typeparam>
        public T? GetService<T>() where T : class => (T?)this.GetService(typeof(T));

        /// <summary>
        /// Gets or creates a service from the service container.
        /// </summary>
        /// <param name="type">The type of the service to get.</param>
        /// <exception cref="ObjectDisposedException">Thrown if the service container has been disposed.</exception>
        /// <returns>The service.</returns>
        internal object GetOrCreateService(Type type) => this.GetService(type) ?? this.CreateService(type);

        /// <inheritdoc cref="GetOrCreateService(Type)"/>
        /// <typeparam name="T">The type of the service to get.</typeparam>
        internal T GetOrCreateService<T>() where T : class => (T)this.GetOrCreateService(typeof(T));

        /// <summary>
        /// Removes a service from the service container and disposes it if it implements <see cref="IDisposable"/>.
        /// </summary>
        /// <exception cref="ObjectDisposedException">Thrown if the service container has been disposed.</exception>
        /// <param name="service">The type of the service to remove.</param>
        internal void RemoveService(Type service)
        {
            if (this.disposedValue)
            {
                throw new ObjectDisposedException(nameof(ServiceContainer));
            }

            if (service is IDisposable disposable)
            {
                disposable.Dispose();
            }

            this.services.Value.Remove(service);
        }

        /// <inheritdoc cref="RemoveService(Type)"/>
        /// <typeparam name="T">The type of the service to remove.</typeparam>
        internal void RemoveService<T>() => this.RemoveService(typeof(T));

        /// <summary>
        /// Injects services into a class.
        /// </summary>
        /// <typeparam name="T">The type of the class to inject services into.</typeparam>
        /// <remarks>
        /// <para>
        ///  This method will inject services into any static properties of the class that are marked with the <see cref="SirenServiceAttribute"/> attribute
        ///  and are internally marked with <see cref="SirenServiceClassAttribute"/> .
        /// </para>
        /// <para>
        ///  If something goes wrong while injecting a service, an error will be thrown.
        /// </para>
        /// </remarks>
        /// <exception cref="ObjectDisposedException">Thrown if the service container has been disposed.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the class to inject services into is null.</exception>
        internal void InjectServices<T>() where T : class
        {
            if (this.disposedValue)
            {
                throw new ObjectDisposedException(nameof(ServiceContainer));
            }

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<SirenServiceAttribute>();
                if (attribute == null)
                {
                    continue;
                }

                if (!IsValidService(property.PropertyType))
                {
                    throw new InvalidOperationException($"Cannot inject service of type {property.PropertyType.Name} into class {typeof(T).Name} because it is not a valid service.");
                }

                var service = this.GetOrCreateService(property.PropertyType);
                property.SetValue(null, service);
                SirenLog.IVerbose($"Successfully injected service of type {service.GetType().Name} into class {typeof(T).Name}.");
            }
        }
    }
}