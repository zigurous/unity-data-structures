---
slug: "/manual/patterns"
---

# Design Patterns

Design patterns are commonly used in association with data structures. The **Data Structures** package includes a different design pattern implementations commonly used in Unity games.

<br/>

### [SingletonBehavior](/api/Zigurous.DataStructures/SingletonBehavior-1)

A singleton behavior that can be used to ensure that only one instance of a class is created.

```csharp
public class Sample : SingletonBehavior<Sample>
```

<hr/>

### [ObjectPool](/api/Zigurous.DataStructures/ObjectPool-1)

Reuses objects from a shared pool to prevent instantiating new objects. The object pool can have a set capacity or it can grow in size.

<hr/>

### [Modules](/api/Zigurous.DataStructures/Modules-1)

Manages a list of registered entity modules.

<hr/>

### [ValueAccumulator](/api/Zigurous.DataStructures/ValueAccumulator-1)

Accumulates a set of stored values into a single total value.

- [DoubleAccumulator](/api/Zigurous.DataStructures/DoubleAccumulator)
- [FloatAccumulator](/api/Zigurous.DataStructures/FloatAccumulator)
- [IntAccumulator](/api/Zigurous.DataStructures/IntAccumulator)
- [QuaternionAccumulator](/api/Zigurous.DataStructures/QuaternionAccumulator)
- [Vector2Accumulator](/api/Zigurous.DataStructures/Vector2Accumulator)
- [Vector3Accumulator](/api/Zigurous.DataStructures/Vector3Accumulator)
- [Vector4Accumulator](/api/Zigurous.DataStructures/Vector4Accumulator)
