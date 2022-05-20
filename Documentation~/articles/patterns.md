---
slug: "/manual/patterns"
---

# Design Patterns

Design patterns are commonly used in association with data structures. The **Data Structures** package includes a different design pattern implementations commonly used in Unity games.

<br/>

### [SingletonBehavior](/api/Zigurous.DataStructures/SingletonBehavior-1)

A singleton behavior that can be used to ensure that only one instance of a class is created.

```csharp
class ExampleBehavior : SingletonBehavior<ExampleBehavior>
```

<hr/>

### [UpdateBehavior](/api/Zigurous.DataStructures/UpdateBehavior)

Allows a behavior to change the update mode without extra overhead or performance costs.

```csharp
class ExampleBehavior : UpdateBehavior
```

<hr/>

### [Modules](/api/Zigurous.DataStructures/Modules-1)

Manages a list of registered entity modules.

```csharp
Modules<ExampleModule> modules = new Modules<ExampleModule>(8);
```

<hr/>

### [ObjectPool](/api/Zigurous.DataStructures/ObjectPool-1)

Reuses objects from a shared pool to prevent instantiating new objects. The object pool can have a set capacity or it can grow in size.

```csharp
ObjectPool<ExampleObject> pool = new ObjectPool<ExampleObject>(8);
```

<hr/>

### [ValueAccumulator](/api/Zigurous.DataStructures/ValueAccumulator-1)

Accumulates a set of stored values into a single total value. Supported types:

- Double
- Float
- Int
- Quaternion
- Vector2
- Vector2Int
- Vector3
- Vector3Int
- Vector4
