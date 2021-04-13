namespace Zigurous.DataStructures
{
    public interface IRange<T>
    {
        T min { get; set; }
        T max { get; set; }

        bool Includes(T value);
    }

    public interface INumberRange<T> : IRange<T>
    {
        T Delta { get; }
        T Median { get; }

        T Random();
        T Clamp(T value);
    }

}
