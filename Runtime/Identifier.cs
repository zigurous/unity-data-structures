using System;

namespace Zigurous.DataStructures
{
    public static class Identifier
    {
        /// <summary>
        /// Creates a unique identifier based on unix time. Since time is always
        /// increasing, this value will always be different than previous
        /// generations.
        /// </summary>
        public static long GenerateFromTime()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        }

    }

}
