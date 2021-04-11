using System;
using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct GridSize : IEquatable<GridSize>, IComparable<GridSize>
    {
        /// <summary>
        /// The number of rows in the grid.
        /// </summary>
        [Tooltip("The number of rows in the grid.")]
        public int rows;

        /// <summary>
        /// The number of columns in the grid.
        /// </summary>
        [Tooltip("The number of columns in the grid.")]
        public int columns;

        /// <summary>
        /// Calculates the area of the grid (rows * columns).
        /// </summary>
        public int Area => System.Math.Abs(this.rows * this.columns);

        /// <summary>
        /// Shorthand for writing GridSize(0, 0).
        /// </summary>
        public static GridSize zero => new GridSize(0, 0);

        /// <summary>
        /// Shorthand for writing GridSize(1, 1).
        /// </summary>
        public static GridSize one => new GridSize(1, 1);

        /// <summary>
        /// Shorthand for writing GridSize(int.MaxValue, int.MaxValue).
        /// </summary>
        public static GridSize max => new GridSize(int.MaxValue, int.MaxValue);

        /// <summary>
        /// Shorthand for writing GridSize(2).
        /// </summary>
        public static GridSize sq2 => new GridSize(2);

        /// <summary>
        /// Shorthand for writing GridSize(4).
        /// </summary>
        public static GridSize sq4 => new GridSize(4);

        /// <summary>
        /// Shorthand for writing GridSize(8).
        /// </summary>
        public static GridSize sq8 => new GridSize(8);

        /// <summary>
        /// Shorthand for writing GridSize(16).
        /// </summary>
        public static GridSize sq16 => new GridSize(16);

        /// <summary>
        /// Shorthand for writing GridSize(32).
        /// </summary>
        public static GridSize sq32 => new GridSize(32);

        /// <summary>
        /// Shorthand for writing GridSize(64).
        /// </summary>
        public static GridSize sq64 => new GridSize(64);

        /// <summary>
        /// Shorthand for writing GridSize(128).
        /// </summary>
        public static GridSize sq128 => new GridSize(128);

        /// <summary>
        /// Shorthand for writing GridSize(256).
        /// </summary>
        public static GridSize sq256 => new GridSize(256);

        /// <summary>
        /// Shorthand for writing GridSize(512).
        /// </summary>
        public static GridSize sq512 => new GridSize(512);

        /// <summary>
        /// Shorthand for writing GridSize(1024).
        /// </summary>
        public static GridSize sq1024 => new GridSize(1024);

        /// <summary>
        /// Shorthand for writing GridSize(2048).
        /// </summary>
        public static GridSize sq2048 => new GridSize(2048);

        /// <summary>
        /// Shorthand for writing GridSize(4096).
        /// </summary>
        public static GridSize sq4096 => new GridSize(4096);

        /// <summary>
        /// Shorthand for writing GridSize(8192).
        /// </summary>
        public static GridSize sq8192 => new GridSize(8192);

        /// <summary>
        /// Creates a new GridSize with given rows and columns.
        /// </summary>
        public GridSize(int rows = 0, int columns = 0)
        {
            this.rows = rows;
            this.columns = columns;
        }

        /// <summary>
        /// Creates a new GridSize with uniform rows and columns.
        /// </summary>
        public GridSize(int size)
        {
            this.rows = size;
            this.columns = size;
        }

        public override string ToString()
        {
            return String.Format("(rows: {0}, columns: {1})", this.rows, this.columns);
        }

        public bool Equals(GridSize other)
        {
            return this.rows == other.rows &&
                   this.columns == other.columns;
        }

        public override bool Equals(object obj)
        {
            if (obj is GridSize size) {
                return Equals(size);
            } else {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.rows.GetHashCode(), this.columns.GetHashCode());
        }

        public int CompareTo(GridSize other)
        {
            int a = this.Area;
            int b = other.Area;

            if (a == b) return 0;
            else if (a > b) return 1;
            else return -1;
        }

        public static bool operator ==(GridSize lhs, GridSize rhs) => lhs.Equals(rhs);
        public static bool operator !=(GridSize lhs, GridSize rhs) => !lhs.Equals(rhs);

    }

}
