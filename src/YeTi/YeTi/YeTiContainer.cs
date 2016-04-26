using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeTi
{
    public class YeTiContainer
    {
        readonly Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();
        
        public void Register<TRegistration, TImplementation>()
        {
            _registrations.Add(typeof(TRegistration), typeof(TImplementation));
            //_registrations.Add(typeof(String), typeof(Int32));
        }

        object Resolve(Type type)
        {
            var requested_type = type;

            Type actual_type = _registrations[requested_type];

            var ctors = actual_type.GetConstructors();

            var ctor = ctors.First();

            IEnumerable<Type> dependencyTypes = ctor.GetParameters().Select(x => x.ParameterType);

            var dependencies = dependencyTypes.Select(c => this.Resolve(c)).ToArray();

            var instance = Activator.CreateInstance(actual_type, dependencies);

            return instance;
        }

        public T Resolve<T>()
        {
            return (T)this.Resolve(typeof(T));
        }
    }
}
