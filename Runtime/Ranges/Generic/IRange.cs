namespace Zigurous.DataStructures
{
    public interface IRange<T>
    {
        T Random();
        T Clamp(T value);
        bool Includes(T value);
    }

}
