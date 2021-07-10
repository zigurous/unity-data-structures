# Data Structures

The Data Structures package contains common data structures and design pattern implementations for Unity projects. It also contains dozens of class extensions for common collection types and interfaces.

## Installation

Use the Unity [Package Manager](https://docs.unity3d.com/Manual/upm-ui.html) to install the Data Structures package.

1. Open the Package Manager in `Window > Package Manager`
2. Click the add (`+`) button in the status bar
3. Select `Add package from git URL` from the add menu
4. Enter the following Git URL in the text box and click Add:

```http
https://github.com/zigurous/unity-data-structures.git
```

For more information on the Package Manager and installing packages, see the following pages:

- [Unity's Package Manager](https://docs.unity3d.com/Manual/Packages.html)
- [Installing from a Git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html)

### Importing

Import the package namespace in each script or file you want to use it.

> **Note**: You may need to regenerate project files/assemblies first.

```csharp
using Zigurous.DataStructures;
```

## Reference

### Structs

- [Bool3](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.Bool3.html)
- [Bitmask](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.Bitmask.html)
- [Quantity](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.Quantity-1.html)
- [Size](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.Size.html)
- [GridSize](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.GridSize.html)
- [Range](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.Range-1.html)
- [ClampedRange](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.ClampedRange.html)
- [ColorRange](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.ColorRange.html)
- [EulerRange](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.EulerRange.html)
- [FloatRange](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.FloatRange.html)
- [IntRange](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.IntRange.html)
- [UIntRange](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.UIntRange.html)
- [UnitIntervalRange](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.UnitIntervalRange.html)
- [Vector2Range](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.Vector2Range.html)
- [Vector3Range](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.Vector3Range.html)
- [Vector4Range](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.Vector4Range.html)

### Patterns

- [SingletonBehavior](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.SingletonBehavior-1.html)
- [ValueAccumulator](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.ValueAccumulator-1.html)
- [ObjectPool](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.ObjectPool-1.html)
- [Modules](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.Modules-1.html)

### Extensions

- [ArrayExtensions](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.ArrayExtensions.html)
- [ComparableExtensions](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.ComparableExtensions.html)
- [DictionaryExtensions](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.DictionaryExtensions.html)
- [HashSetExtensions](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.HashSetExtensions.html)
- [ListExtensions](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.ListExtensions.html)
- [SortedSetExtensions](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.SortedSetExtensions.html)
- [StringExtensions](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.StringExtensions.html)

### Utilities

- [HashCode](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.HashCode.html)
- [Identifier](https://docs.zigurous.com/com.zigurous.datastructures/api/Zigurous.DataStructures.Identifier.html)
