using System.Linq;
using Giver.Tests.Model;
using Xunit;

namespace Giver.Tests {

    public class SimpleTests {

        [Fact]
        public void Static_Api_Single() {
            var testModel = Give<TestModel>.Single();

            Assert.NotNull(testModel);
            Assert.Null(testModel.CompanyField);
            Assert.Null(testModel.OrdersProp);
        }

        [Fact]
        public void Static_Api_Single_Convert() {
            TestModel testModel = Give<TestModel>.ToMe();

            Assert.NotNull(testModel);
            Assert.Null(testModel.CompanyField);
            Assert.Null(testModel.OrdersProp);
        }

        [Fact]
        public void Static_Api_Multi() {
            var testModels = Give<TestModel>.Many(5);

            Assert.Equal(testModels.Count, 5);
            Assert.True(testModels.All(tm => tm != null && tm.CompanyField == null && tm.OrdersProp == null));
        }

        [Fact]
        public void Instance_Api_Single() {
            var give = new Give();
            var testModel = give.Single<TestModel>();

            Assert.NotNull(testModel);
            Assert.Null(testModel.CompanyField);
            Assert.Null(testModel.OrdersProp);
        }

        [Fact]
        public void Instance_Api_Single_Convert() {
            var give = new Give();
            TestModel testModel = give.Me<TestModel>();

            Assert.NotNull(testModel);
            Assert.Null(testModel.CompanyField);
            Assert.Null(testModel.OrdersProp);
        }

        [Fact]
        public void Instance_Api_Multi() {
            var give = new Give();
            var testModels = give.Many<TestModel>(5);

            Assert.Equal(testModels.Count, 5);
            Assert.True(testModels.All(tm => tm != null && tm.CompanyField == null && tm.OrdersProp == null));
        }
    }
}
