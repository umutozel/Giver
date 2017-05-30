using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace Giver {

    internal static class Helper {

        public static List<Member> GetPrimitiveMembers(Type type) {
            return type.GetRuntimeProperties()
                .Where(p => p.SetMethod.IsPublic && !p.SetMethod.IsStatic && IsPrimitive(p.PropertyType))
                .Select(p => new Member(p, p.PropertyType))
                .Union(type.GetRuntimeFields()
                    .Where(f => f.IsPublic && !f.IsStatic && IsPrimitive(f.FieldType))
                    .Select(f => new Member(f, f.FieldType))
                ).ToList();
        }

        public static bool IsPrimitive(Type type) {
            return type.GetTypeInfo().IsValueType || type == typeof(string);
        }

        public static void SetValue(object instance, MemberInfo memberInfo, object value) {
            var propertyInfo = memberInfo as PropertyInfo;
            if (propertyInfo != null) {
                propertyInfo.SetValue(instance, value);
                return;
            }

            var fieldInfo = memberInfo as FieldInfo;
            if (fieldInfo != null) {
                fieldInfo.SetValue(instance, value);
                return;
            }

            throw new InvalidOperationException($"Cannot set {memberInfo}.");
        }

        public static int NextIntRange(this Random random) {
            var firstBits = random.Next(0, 1 << 4) << 28;
            var lastBits = random.Next(0, 1 << 28);
            return firstBits | lastBits;
        }
    }
}
