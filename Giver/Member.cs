using System;
using System.Reflection;

namespace Giver {

    internal sealed class Member {

        public Member(MemberInfo memberInfo, Type type) {
            MemberInfo = memberInfo;
            Type = type;
        }      

        public MemberInfo MemberInfo { get; }

        public Type Type { get; }
    }
}