# Giver
Generate gibberish filled objects!

Supports .Net Standard 1.0.

```csharp
// static api
// take an instance
var testModel = Give<TestModel>.Single();

// take a list
var testModels = Give<TestModel>.Many(5);

// build an instance
var testModel = Give<TestModel>
                .ToMe(tm => tm.OrdersProp = Give<Order>.Many(5))
                .With(tm => tm.CompanyField = Give<Company>.Single())
                .Now();

// you can emit .Now() when explicitly declaring the type
TestModel testModel = Give<TestModel>
                .ToMe(tm => tm.OrdersProp = Give<Order>.Many(5))
                .With(tm => tm.CompanyField = Give<Company>.Single());

// build a list
var testModels = Give<TestModel>
                 .ToMe(tm => tm.CompanyField = Give<Company>.Single())
                 .Now(5);
                
// another way, with declaring the type explicitly
TestModel testModel = new Give<TestModel>();

// or use Give instance
var give = new Give();

var testModel = give.Single<TestModel>();
var testModels = give.Many<TestModel>(5);
TestModel testModel = give.Me<TestModel>().With(tm => tm.CompanyField = give.Single<Company>());

// you can modify value generation
public class CustomStringGenerator: StringGenerator {
    public override string GetValue(MemberInfo memberInfo) {
        return memberInfo.Name == "CompanyName" ? "CustomCompany" : base.GetValue(memberInfo);
    }
}

var give = new Give(new CustomStringGenerator());
// CompanyName's value is "CustomCompany"
var company = give.Single<Company>();
```
