using System;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Generates identifiers.
    /// </summary>
    public static class Identifier
    {
        /// <summary>
        /// Creates an identifier based on unix time. Since time is always
        /// increasing, this value will be different than generations made in
        /// previous cycles.
        /// </summary>
        /// <remarks>
        /// This should not be used to guarentee uniqueness since ids generated
        /// within the same cycle will usually be identical.
        /// </remarks>
        public static long Temporal()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        }

    }

}
