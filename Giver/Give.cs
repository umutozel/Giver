using System.Collections.Generic;
using System.Linq;
using Giver.ValueGenerators;

namespace Giver {

    public class Give {
        private static readonly IList<IValueGenerator> _defaultGenerators;
        private IList<IValueGenerator> _generators;

        static Give() {
            _defaultGenerators = new List<IValueGenerator> {
                new BooleanGenerator(),
                new ByteGenerator(),
                new CharGenerator(),
                new DecimalGenerator(),
                new DoubleGenerator(),
                new Int16Generator(),
                new Int32Generator(),
                new Int64Generator(),
                new SByteGenerator(),
                new SingleGenerator(),
                new UInt16Generator(),
                new UInt32Generator(),
                new UInt64Generator(),
                new StringGenerator()
            };
        }

        public Give() {
            _generators = _defaultGenerators;
        }

        public Give(params IValueGenerator[] generators) {
            Init(generators);
        }

        public Give(IEnumerable<IValueGenerator> generators) {
            Init(generators);
        }

        private void Init(IEnumerable<IValueGenerator> generators) {
            _generators = generators != null
                ? generators.Union(_defaultGenerators).ToList()
                : _defaultGenerators;
        }

        public virtual Builder<T> Me<T>() where T : new() {
            return new Builder<T>(this);
        }

        public virtual T Now<T>() where T : new() {
            return Now<T>(Helper.GetPrimitiveMembers(typeof(T)));
        }

        internal T Now<T>(IEnumerable<Member> members) where T : new() {
            var t = new T();

            foreach (var member in members) {
                var generator = _generators.FirstOrDefault(g => g.CanGenerate(member.Type, member.MemberInfo));
                if (generator != null) {
                    Helper.SetValue(t, member.MemberInfo, generator.GetValue(member.MemberInfo));
                }
            }

            return t;
        }
    }

    public static class Give<T> where T : new() {
        private static Give _give = new Give();

        public static Builder<T> ToMe() {
            return _give.Me<T>();
        }
    }
}
