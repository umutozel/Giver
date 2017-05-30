# Giver
Generate gibberish filled objects!
I needed a dummy object generator for my .net core unit tests, so I developed this last night.
Supports .Net Standard 1.0.

## Static API

### Generate an TestModel instance
```csharp
var testModel = Give<TestModel>.Now();
```

### You can get a list
```csharp
// return a list of 5 TestModel instance
var testModels = Give<TestModel>.Now(5);
```

### You can modify the generation
```csharp
var testModel = Give<TestModel>
                .ToMe()
                .With(tm => tm.OrdersProp = Give<Order>.Now(5))
                .Now();
```
