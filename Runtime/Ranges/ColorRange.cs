using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of Color values.
    /// </summary>
    [System.Serializable]
    public struct ColorRange : INumberRange<Color>
    {
        [Tooltip("The lower bound of the range.")]
        [SerializeField]
        private Color _min;

        [Tooltip("The upper bound of the range.")]
        [SerializeField]
        private Color _max;

        /// <inheritdoc />
        public Color min
        {
            get => _min;
            set => _min = value;
        }

        /// <inheritdoc />
        public Color max
        {
            get => _max;
            set => _max = value;
        }

        /// <inheritdoc />
        public Color Delta => _max - _min;

        /// <inheritdoc />
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
        /// Shorthand for writing ColorRange(Color.white, Color.black).
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
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public ColorRange(Color min, Color max)
        {
            _min = min;
            _max = max;
        }

        /// <inheritdoc />
        public Color Random()
        {
            return Color.Lerp(_min, _max, UnityEngine.Random.value);
        }

        /// <inheritdoc />
        /// <param name="value">The value to check.</param>
        public bool Includes(Color value)
        {
            return value.r >= _min.r && value.r <= _max.r &&
                   value.g >= _min.g && value.g <= _max.g &&
                   value.b >= _min.b && value.b <= _max.b &&
                   value.a >= _min.a && value.a <= _max.a;
        }

        /// <inheritdoc />
        /// <param name="value">The value to check.</param>
        public bool Includes(Color value, bool includeMin, bool includeMax)
        {
            return value.r.IsBetween(_min.r, _max.r, includeMin, includeMax) &&
                   value.g.IsBetween(_min.g, _max.g, includeMin, includeMax) &&
                   value.b.IsBetween(_min.b, _max.b, includeMin, includeMax) &&
                   value.a.IsBetween(_min.a, _max.a, includeMin, includeMax);
        }

        /// <inheritdoc />
        /// <param name="value">The value to clamp.</param>
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
