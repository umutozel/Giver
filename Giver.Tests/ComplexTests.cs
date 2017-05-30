using System.Reflection;
using Giver.Tests.Model;
using Giver.ValueGenerators;
using Xunit;

namespace Giver.Tests {

    public class ComplexTests {
        private readonly Give _give;

        public ComplexTests() {
            _give = new Give(new CustomStringGenerator());
        }

        [Fact]
        public void Custom_String_Generated() {
            Company company = _give.Me<Company>();

            Assert.Equal(company.CompanyName, "DT");
        }

        [Fact]
        public void With_Order() {
            TestModel testModel = _give.Me<TestModel>().With(tm => tm.OrdersProp = _give.Now<Order>(5));

            Assert.Equal(testModel.OrdersProp.Count, 5);
        }

        [Fact]
        public void With_Company() {
            TestModel testModel = _give.Me<TestModel>().With(tm => tm.CompanyField = _give.Me<Company>());

            Assert.NotNull(testModel.CompanyField);
        }
    }

    public class CustomStringGenerator: StringGenerator {

        public override string GetValue(MemberInfo memberInfo) {
            if (memberInfo.Name == "CompanyName") {
                return "DT";
            }

            return base.GetValue(memberInfo);
        }
    }
}
