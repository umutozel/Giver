using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace Giver {

    internal static class Helper {

        public static List<Member> GetPrimitiveMembers<T>() {
            var type = typeof(T);
#if NET_STANDARD
            return type.GetRuntimeProperties()
#else
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
#endif
                .Where(p => IsPrimitive(p.PropertyType))
                .Select(p => new Member(p, p.PropertyType))
#if NET_40
                .Union(type.GetFields()
#else
                .Union(type.GetRuntimeFields()
#endif
                    .Where(f => f.IsPublic && !f.IsStatic && IsPrimitive(f.FieldType))
                    .Select(f => new Member(f, f.FieldType))
                ).ToList();
        }

        public static bool IsPrimitive(Type type) {
#if NET_STANDARD
            return type.GetTypeInfo().IsValueType || type == typeof(string);
#else
            return type.IsValueType || type == typeof(string);
#endif
        }

        public static void SetValue(object instance, MemberInfo memberInfo, object value) {
            var propertyInfo = memberInfo as PropertyInfo;
            if (propertyInfo != null) {
                propertyInfo.SetValue(instance, value, null);
                return;
            }

            ((FieldInfo)memberInfo).SetValue(instance, value);
        }

        public static int NextIntRange(this Random random) {
            var firstBits = random.Next(0, 1 << 4) << 28;
            var lastBits = random.Next(0, 1 << 28);
            return firstBits | lastBits;
        }

        public static void RunBuildActions<T>(T value, IEnumerable<Action<T>> buildActions) {
            foreach (var ba in buildActions) {
                ba(value);
            }
        }
    }
}
