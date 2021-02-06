using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct ColorRange : INumberRange<Color>
    {
        [Tooltip("The lower bound of the range.")]
        [SerializeField]
        private Color _min;

        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        public Color min
        {
            get => _min;
            set => _min = value;
        }

        [Tooltip("The upper bound of the range.")]
        [SerializeField]
        private Color _max;

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        public Color max
        {
            get => _max;
            set => _max = value;
        }

        /// <summary>
        /// The difference between the range min and max.
        /// </summary>
        public Color Delta => _max - _min;

        /// <summary>
        /// The color in the middle of the range min and max.
        /// </summary>
        public Color Median => (_min + _max) / 2;

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
            _min = min;
            _max = max;
        }

        /// <summary>
        /// Determines if the given color is between the range
        /// min [inclusive] and max [inclusive].
        /// </summary>
        public bool Includes(Color value) =>
            value.r >= _min.r && value.r <= _max.r &&
            value.g >= _min.g && value.g <= _max.g &&
            value.b >= _min.b && value.b <= _max.b &&
            value.a >= _min.a && value.a <= _max.a;

        /// <summary>
        /// Returns a random color between the range
        /// min [inclusive] and max [inclusive].
        /// </summary>
        public Color Random() => Color.Lerp(_min, _max, UnityEngine.Random.value);

        /// <summary>
        /// Clamps the given color between the range min and max.
        /// </summary>
        public Color Clamp(Color value)
        {
            value.r = Mathf.Clamp(value.r, _min.r, _max.r);
            value.g = Mathf.Clamp(value.g, _min.g, _max.g);
            value.b = Mathf.Clamp(value.b, _min.b, _max.b);
            value.a = Mathf.Clamp(value.a, _min.a, _max.a);
            return value;
        }

    }

}
