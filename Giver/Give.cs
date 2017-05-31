using System;
using System.Collections.Generic;
using System.Linq;
using Giver.ValueGenerators;

namespace Giver {

    public class Give {
        private static readonly IList<IValueGenerator> _defaultGenerators;
        internal static Lazy<Give> Instance = new Lazy<Give>();
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
                new StringGenerator(),
                new DateTimeGenerator()
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
            _generators = generators?.Union(_defaultGenerators).ToList() ?? _defaultGenerators;
        }

        public virtual T Single<T>() where T : new() {
            return GenerateInstance<T>();
        }

        public virtual List<T> Many<T>(int count) where T : new() {
            return GenerateList<T>(count);
        }

        public virtual Builder<T> Me<T>(Action<T> buildAction = null) where T : new() {
            var builder = new Builder<T>(this);
            return buildAction != null ? builder.With(buildAction) : builder;
        }

        internal T GenerateInstance<T>(List<Action<T>> buildActions = null) where T : new() {
            return GenerateInstance(Helper.GetPrimitiveMembers<T>(), buildActions);
        }

        internal T GenerateInstance<T>(IEnumerable<Member> members, List<Action<T>> buildActions = null) where T : new() {
            var t = new T();

            foreach (var member in members) {
                var generator = _generators.FirstOrDefault(g => g.CanGenerate(member.Type, member.MemberInfo));
                if (generator != null) {
                    Helper.SetValue(t, member.MemberInfo, generator.GetValue(member.MemberInfo));
                }
            }

            if (buildActions != null) {
                Helper.RunBuildActions(t, buildActions);
            }

            return t;
        }

        internal List<T> GenerateList<T>(int count, List<Action<T>> buildActions = null) where T : new() {
            var list = new List<T>(count);
            if (count <= 0) return list;

            var members = Helper.GetPrimitiveMembers<T>();
            for (var i = 0; i < count; i++) {
                list.Add(GenerateInstance(members, buildActions));
            }
            return list;
        }
    }

    public class Give<T> where T : new() {

        public static Builder<T> ToMe(Action<T> buildAction = null) {
            return Give.Instance.Value.Me(buildAction);
        }

        public static T Single() {
            return Give.Instance.Value.Single<T>();
        }

        public static List<T> Many(int count) {
            return Give.Instance.Value.Many<T>(count);
        }

        public static implicit operator T(Give<T> give) {
            return Give.Instance.Value.Single<T>();
        }
    }
}
