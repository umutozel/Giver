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
            var company = _give.Single<Company>();

            Assert.Equal(company.CompanyName, "DT");
        }

        [Fact]
        public void With_Order() {
            var testModel = _give.Me<TestModel>().With(tm => tm.OrdersProp = _give.Many<Order>(5)).Now();

            Assert.Equal(testModel.OrdersProp.Count, 5);
        }

        [Fact]
        public void With_Company() {
            TestModel testModel = _give.Me<TestModel>()
                .With(tm => tm.CompanyField = _give.Me<Company>())
                .With(tm => tm.OrdersProp = _give.Many<Order>(0));

            Assert.NotNull(testModel.CompanyField);
            Assert.True(testModel.OrdersProp != null && testModel.OrdersProp.Count == 0);
        }

        [Fact]
        public void With_Many() {
            var testModels = _give.Me<TestModel>().With(tm => tm.CompanyField = _give.Me<Company>()).Now(5);

            Assert.Equal(testModels.Count, 5);
        }

        [Fact]
        public void ReadOnly_Property()
        {
            OrderLine orderLine = _give.Me<OrderLine>()
                .With(ol => ol.Quantity = 1);

            Assert.Equal(orderLine.Price * orderLine.Quantity, orderLine.TotalPrice);
        }
    }

    public class CustomStringGenerator: StringGenerator {

        public override string GetValue(MemberInfo memberInfo) {
            return memberInfo.Name == "CompanyName" ? "DT" : base.GetValue(memberInfo);
        }
    }
}
