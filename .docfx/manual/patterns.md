# Design Patterns

Design patterns are commonly used in association with data structures. The Data Structures package includes a few different design pattern implementations commonly used in Unity games.

#### [SingletonBehavior](xref:Zigurous.DataStructures.SingletonBehavior`1)

A singleton behavior that can be used to ensure that only one instance of a class is created.

```csharp
public class MySingleton : SingletonBehavior<MySingleton>
```

#### [ValueAccumulator](xref:Zigurous.DataStructures.ValueAccumulator`1)

Accumulates a set of stored values into a single total value.

#### [ObjectPool](xref:Zigurous.DataStructures.ObjectPool`1)

Reuses objects from a shared pool to prevent instantiating new objects. The object pool can have a set capacity or it can grow in size.

#### [Modules](xref:Zigurous.DataStructures.Modules`1)

Manages a list of registered entity modules.
