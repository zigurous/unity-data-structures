# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.6.0] - 2022/05/20

### Added

- New update mode strategy pattern to allow behaviors to switch between update modes while maintaining performance and overhead
  - Behaviors with the same update mode are grouped to reduce the number of update calls
- Added lerp functions to `INumberRange` types
- Added overridable `defaultValue` property to `ValueAccumulator<T>`

### Changed

- Moved `INumberRange` into its own file
- Reorganized file directories
- Minor changes to documentation comments

## [1.5.2] - 2021/10/28

### Changed

- Naming convention of private serialized properties to match Unity conventions

## [1.5.1] - 2021/10/14

### Changed

- Set initial total amount for all value accumulators in default constructor
- Swapped `ValueAccumulator<T>.SetValue` parameter order to more closely align with other Unity conventions
- Rewrote and added new editor property drawers for data structures
- Reduced string padding on `Bitmask.ToString()`

## [1.5.0] - 2021/09/12

### Added

- New static function `Identifier.Guid`

### Changed

- Renamed `Identifier.Temporal` to `Identifier.UnixTime`

### Fixed

- SingletonBehaviour was causing errors due to the inaccessible private constructor
- ObjectPool type constraints were mistakenly required to implement IDisposable

## [1.4.0] - 2021/07/13

### Added

- Extension methods for shuffling arrays and lists `Shuffle()`

### Removed

- String extensions for abbreviating numbers (moved to different package https://github.com/zigurous/unity-math-utils)

## [1.3.0] - 2021/07/10

### Added

- `Vector4Range` data structure
- New extension methods for `List<T>`, `HashSet<T>`, and `SortedSet<T>`

### Changed

- Package description
- Documentation comments
- Small memory optimizations
- Renamed `Identifier.GenerateFromTime` to `Identifier.Temporal`
- Renamed `List<T>.ElementAt` to `List<T>.ItemAt`

## [1.2.1] - 2021/06/25

### Added

- Readme namespace import instructions

### Changed

- Code cleanup

## [1.2.0] - 2021/06/06

### Added

- DoubleAccumulator
- IntAccumulator
- QuaternionAccumulator
- Vector2IntAccumulator
- Vector3IntAccumulator
- Vector4Accumulator

## [1.1.0] - 2021/05/23

### Added

- Implicit conversion operators between Bitmask and int

### Changed

- Code cleanup and formatting

## [1.0.1] - 2021/04/13

### Removed

- ConditionalShowAttribute
- ConditionalHideAttribute

### Fixed

- Set Editor assembly to only compile for the Editor platform
- Size and GridSize were not printing the correct info in ToString()

## [1.0.0] - 2021/03/24

### Added

- ArrayExtensions
- Bitmask
- Bool3
- ClampedRange
- ColorRange
- ComparableExtensions
- DictionaryExtensions
- FloatAccumulator
- FloatRange
- GridSize
- HashCode
- HashSetExtensions
- Identifier
- IntRange
- ListExtensions
- Modules
- ObjectPool
- Quantity
- SingletonBehavior
- Size
- SortedSetExtensions
- StringExtensions
- UIntRange
- UnitIntervalRange
- Vector2Accumulator
- Vector2Range
- Vector3Accumulator
- Vector3Range
