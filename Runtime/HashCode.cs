namespace Zigurous.DataStructures
{
    public static class HashCode
    {
        /// <summary>
        /// Combines two hash codes into one unique hash.
        /// </summary>
        public static int Combine(int hash1, int hash2)
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + hash1;
                hash = hash * 23 + hash2;
                return hash;
            }
        }

        /// <summary>
        /// Combines three hash codes into one unique hash.
        /// </summary>
        public static int Combine(int hash1, int hash2, int hash3)
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + hash1;
                hash = hash * 23 + hash2;
                hash = hash * 23 + hash3;
                return hash;
            }
        }

        /// <summary>
        /// Combines four hash codes into one unique hash.
        /// </summary>
        public static int Combine(int hash1, int hash2, int hash3, int hash4)
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + hash1;
                hash = hash * 23 + hash2;
                hash = hash * 23 + hash3;
                hash = hash * 23 + hash4;
                return hash;
            }
        }

    }

}
