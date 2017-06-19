# Giver
Generate gibberish filled objects!

Supports .Net Standard 1.0.

[![Build status](https://ci.appveyor.com/api/projects/status/777i8b6av83xs7gu?svg=true)](https://ci.appveyor.com/project/umutozel/giver)
[![Coverage Status](https://coveralls.io/repos/github/umutozel/Giver/badge.svg?branch=master)](https://coveralls.io/github/umutozel/Giver?branch=master)
[![NuGet Badge](https://buildstats.info/nuget/Giver)](https://www.nuget.org/packages/Giver/)
[![GitHub issues](https://img.shields.io/github/issues/umutozel/Giver.svg)](https://github.com/umutozel/Giver/issues)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/umutozel/Giver/master/LICENSE)

[![GitHub stars](https://img.shields.io/github/stars/umutozel/Giver.svg?style=social&label=Star)](https://github.com/umutozel/Giver)
[![GitHub forks](https://img.shields.io/github/forks/umutozel/Giver.svg?style=social&label=Fork)](https://github.com/umutozel/Giver)

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

// you can omit .Now() when explicitly declaring the type
TestModel testModel = Give<TestModel>
                .ToMe()
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
