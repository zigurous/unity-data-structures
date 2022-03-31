---
slug: "/manual/utilities"
---

# Utility Classes

The **Data Structures** package includes a couple utility classes that provide commonly needed functions when creating and using data structures.

<br/>

### [HashCode](/api/Zigurous.DataStructures/HashCode)

Combines multiple hash codes into a single value.

```csharp
int hash = HashCode.Combine(a, b, c);
```

<hr/>

### [Identifier](/api/Zigurous.DataStructures/Identifier)

Generates identifiers.

```csharp
string guid = Identifier.Guid();
long id = Identifier.UnixTime();
```
