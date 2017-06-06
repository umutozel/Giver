using System;
using System.Reflection;

namespace Giver {

    public abstract class ValueGenerator<T>: IValueGenerator {

        public virtual bool CanGenerate(Type memberType, MemberInfo memberInfo) {
#if NET_STANDARD
            if (memberType.GetTypeInfo().IsGenericType && memberType.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                memberType = memberType.GenericTypeArguments[0];
            }
#else
            if (memberType.IsGenericType && memberType.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                memberType = memberType.GetGenericArguments()[0];
            }
#endif

            return typeof(T) == memberType;
        }

        public abstract T GetValue(MemberInfo memberInfo);

        object IValueGenerator.GetValue(MemberInfo memberInfo) {
            return GetValue(memberInfo);
        }
    }

    public interface IValueGenerator {

        bool CanGenerate(Type memberType, MemberInfo memberInfo);

        object GetValue(MemberInfo memberInfo);
    }
}
