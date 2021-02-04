using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct ColorRange
    {
        /// <summary>
        /// The minimum color of the range.
        /// </summary>
        [Tooltip("The minimum color of the range.")]
        public Color min;

        /// <summary>
        /// The maximum color of the range.
        /// </summary>
        [Tooltip("The maximum color of the range.")]
        public Color max;

        /// <summary>
        /// The difference between the min and max value.
        /// </summary>
        public Color Delta => this.max - this.min;

        /// <summary>
        /// Shorthand for writing ColorRange(Color.black, Color.black).
        /// </summary>
        public static ColorRange black => new ColorRange(Color.black, Color.black);

        /// <summary>
        /// Shorthand for writing ColorRange(Color.white, Color.white).
        /// </summary>
        public static ColorRange white => new ColorRange(Color.white, Color.white);

        /// <summary>
        /// Shorthand for writing ColorRange(Color.black, Color.white).
        /// </summary>
        public static ColorRange blackToWhite => new ColorRange(Color.black, Color.white);

        /// <summary>
        /// Shorthand for writing ColorRange(Color.black, Color.white).
        /// </summary>
        public static ColorRange whiteToBlack => new ColorRange(Color.white, Color.black);

        /// <summary>
        /// Shorthand for writing ColorRange(Color(0,0,0,0), Color(0,0,0,1)).
        /// </summary>
        public static ColorRange fadeIn => new ColorRange(new Color(0.0f, 0.0f, 0.0f, 0.0f), new Color(0.0f, 0.0f, 0.0f, 1.0f));

        /// <summary>
        /// Shorthand for writing ColorRange(Color(0,0,0,1), Color(0,0,0,0)).
        /// </summary>
        public static ColorRange fadeOut => new ColorRange(new Color(0.0f, 0.0f, 0.0f, 1.0f), new Color(0.0f, 0.0f, 0.0f, 0.0f));

        /// <summary>
        /// Shorthand for writing ColorRange(Color(0,0,0,0), Color(0,0,0,0)).
        /// </summary>
        public static ColorRange transparent => new ColorRange(new Color(0.0f, 0.0f, 0.0f, 0.0f), new Color(0.0f, 0.0f, 0.0f, 0.0f));

        /// <summary>
        /// Creates a new ColorRange with given min and max colors.
        /// </summary>
        public ColorRange(Color min, Color max)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Returns a random color within the color range.
        /// </summary>
        public Color Random() => Color.Lerp(this.min, this.max, UnityEngine.Random.value);

    }

}
