// Copyright (c) 2021 ezequias2d <ezequiasmoises@gmail.com> and the Ez.Numerics contributors
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ez.Numerics
{
    /// <summary>
    /// Represents a three-dimensional point.
    /// </summary>
    public struct Point2 : IEquatable<Point2>, IFormattable
    {
        /// <summary>
        /// Creates a new <see cref="Point2"/> instance whose elements have the specified values.
        /// </summary>
        /// <param name="x">The value to assign to the <see cref="X"/> field.</param>
        /// <param name="y">The value to assign to the <see cref="Y"/> field.</param>
        public Point2(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Creates a new <see cref="Point2"/> instance whose three elements have the same value.
        /// </summary>
        /// <param name="value">The value to assign to all three elements.</param>
        public Point2(int value) : this(value, value)
        {

        }

        /// <summary>
        /// The X component of the point.
        /// </summary>
        public int X;

        /// <summary>
        /// The Y component of the point.
        /// </summary>
        public int Y;

        /// <inheritdoc/>
        public bool Equals(Point2 other) =>
            X == other.X && Y == other.Y;

        /// <inheritdoc/>
        public override bool Equals(object obj) =>
            obj is Point2 p && Equals(p);

        /// <inheritdoc/>
        public override int GetHashCode() =>
            HashHelper<Point2>.Combine(X, Y);

        /// <inheritdoc/>
        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        /// <inheritdoc/>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var sb = new StringBuilder();
            string separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
            sb.Append('<');
            sb.Append(X.ToString(format, formatProvider));
            sb.Append(separator);
            sb.Append(' ');
            sb.Append(Y.ToString(format, formatProvider));
            sb.Append('>');
            return sb.ToString();
        }

        #region static
        #region properties
        /// <summary>
        /// Gets a point whose 3 elements are equal to one.
        /// </summary>
        public static Point2 One => new(1);

        /// <summary>
        /// Gets a point whose 3 elements are equal to zero.
        /// </summary>
        public static Point2 Zero => new(0);

        /// <summary>
        /// Gets the point (1, 0, 0).
        /// </summary>
        public static Point2 UnitX => new(1, 0);

        /// <summary>
        /// Gets the point (0, 1, 0).
        /// </summary>
        public static Point2 UnitY => new(0, 1);
        #endregion
        #region methods
        /// <summary>
        /// Returns a point whose elements are absolute values of each of the specified
        /// point's elements.
        /// </summary>
        /// <param name="value">A point.</param>
        /// <returns>The absolute value point.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2 Abs(in Point2 value) =>
            new(Math.Abs(value.X), Math.Abs(value.Y));

        /// <summary>
        /// Adds two points together.
        /// </summary>
        /// <param name="left">The first point to add.</param>
        /// <param name="right">The second point to add.</param>
        /// <returns>The summed point.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2 Add(Point2 left, Point2 right) =>
            new(left.X + right.X, left.Y + right.Y);

        /// <summary>
        /// Restricts a point between a minimum and maximum value.
        /// </summary>
        /// <param name="value">The point to restrict.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The restricted vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2 Clamp(Point2 value, Point2 min, Point2 max)
        {
            var x = Math.Clamp(value.X, min.X, max.X);
            var y = Math.Clamp(value.Y, min.Y, max.Y);
            return new Point2(x, y);
        }

        /// <summary>
        /// Computes the Euclidean distance between the two given points.
        /// </summary>
        /// <param name="value1">The first point.</param>
        /// <param name="value2">The second point.</param>
        /// <returns>The distance.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance(in Point2 value1, in Point2 value2) =>
            Math.Sqrt(DistanceSquared(value1, value2));

        /// <summary>
        /// Computes the Euclidean distance between the two given points.
        /// </summary>
        /// <param name="value1">The first point.</param>
        /// <param name="value2">The second point.</param>
        /// <returns>The distance.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceF(in Point2 value1, in Point2 value2) =>
            MathF.Sqrt(DistanceSquaredF(in value1, in value2));

        /// <summary>
        /// Returns the Euclidean distance squared between two specified points.
        /// </summary>
        /// <param name="value1">The first point.</param>
        /// <param name="value2">The second point.</param>
        /// <returns>The distance squared.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DistanceSquared(in Point2 value1, in Point2 value2)
        {
            double dx = value1.X - value2.X;
            double dy = value1.Y - value2.Y;

            return (dx * dx) + (dy * dy);
        }

        /// <summary>
        /// Returns the Euclidean distance squared between two specified points.
        /// </summary>
        /// <param name="value1">The first point.</param>
        /// <param name="value2">The second point.</param>
        /// <returns>The distance squared.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceSquaredF(in Point2 value1, in Point2 value2)
        {
            float dx = value1.X - value2.X;
            float dy = value1.Y - value2.Y;

            return (dx * dx) + (dy * dy);
        }

        /// <summary>
        /// Divides the specified point by a specified scalar value.
        /// </summary>
        /// <param name="left">The point.</param>
        /// <param name="divisor">The scalar value.</param>
        /// <returns>The point that results from the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2 Divide(in Point2 left, int divisor)
        {
            var x = left.X / divisor;
            var y = left.Y / divisor;
            return new(x, y);
        }

        /// <summary>
        /// Divides the first point by the second.
        /// </summary>
        /// <param name="left">The first point.</param>
        /// <param name="right">The second point.</param>
        /// <returns>The point resulting from the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2 Divide(in Point2 left, in Point2 right)
        {
            var x = left.X / right.X;
            var y = left.Y / right.Y;
            return new(x, y);
        }

        /// <summary>
        /// Returns a point whose elements are the maximum of each of the pairs of
        /// elements in two specified points.
        /// </summary>
        /// <param name="value1">The first point.</param>
        /// <param name="value2">The second point.</param>
        /// <returns>The maximized point.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2 Max(in Point2 value1, in Point2 value2)
        {
            var x = Math.Max(value1.X, value2.X);
            var y = Math.Max(value1.Y, value2.Y);
            return new(x, y);
        }

        /// <summary>
        /// Returns a point whose elements are the manimum of each of the pairs of
        /// elements in two specified points.
        /// </summary>
        /// <param name="value1">The first point.</param>
        /// <param name="value2">The second point.</param>
        /// <returns>The maximized point.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2 Min(in Point2 value1, in Point2 value2)
        {
            var x = Math.Min(value1.X, value2.X);
            var y = Math.Min(value1.Y, value2.Y);
            return new(x, y);
        }

        /// <summary>
        /// Multiplies a scalar value by a specified point.
        /// </summary>
        /// <param name="left">The scalar value.</param>
        /// <param name="right">The point to multiply.</param>
        /// <returns>The scaled point.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2 Multiply(int left, Point2 right)
        {
            var x = left * right.X;
            var y = left * right.Y;
            return new(x, y);
        }

        /// <summary>
        /// Multiplies a point by a specified scalar.
        /// </summary>
        /// <param name="left">The point to multiply.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>The scaled point.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2 Multiply(Point2 left, int right)
        {
            var x = left.X * right;
            var y = left.Y * right;
            return new(x, y);
        }

        /// <summary>
        /// Multiplies the first point by the second. 
        /// </summary>
        /// <param name="left">The first point.</param>
        /// <param name="right">The second point.</param>
        /// <returns>The point resulting from the multiplication.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2 Multiply(Point2 left, Point2 right)
        {
            var x = left.X * right.X;
            var y = left.Y * right.Y;
            return new(x, y);
        }

        /// <summary>
        /// Negates a specified point.
        /// </summary>
        /// <param name="value">The point to negate.</param>
        /// <returns>The negated point.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2 Negate(in Point2 value) =>
            new(-value.X, -value.Y);

        /// <summary>
        /// Subtracts the second point from the first.
        /// </summary>
        /// <param name="left">The first point.</param>
        /// <param name="right">The second point.</param>
        /// <returns>The difference point.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2 Subtract(in Point2 left, in Point2 right) =>
            new(left.X - right.X, left.Y - right.Y);

        #endregion
        #region operators
        /// <summary>
        /// Adds two pointers together.
        /// </summary>
        /// <param name="left">The first point to add.</param>
        /// <param name="right">The second point to add.</param>
        /// <returns>The summed point.</returns>
        public static Point2 operator +(in Point2 left, in Point2 right) => Add(left, right);

        /// <summary>
        /// Divides the first point by the second.
        /// </summary>
        /// <param name="left">The first point.</param>
        /// <param name="right">The second point.</param>
        /// <returns>The point that results from dividing <paramref name="left"/> 
        /// by <paramref name="right"/>.</returns>
        public static Point2 operator /(in Point2 left, in Point2 right) => Divide(left, right);

        /// <summary>
        /// Divides the specified point by a specified scalar value.
        /// </summary>
        /// <param name="left">The point.</param>
        /// <param name="divisor">The scalar value.</param>
        /// <returns>The point that results from the division.</returns>
        public static Point2 operator /(in Point2 left, int divisor) => Divide(left, divisor);

        /// <summary>
        /// Returns a value that indicates whether each pair of elements in two
        /// specified pointers is equal.
        /// </summary>
        /// <param name="left">The first point to compare.</param>
        /// <param name="right">The second point to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and 
        /// <paramref name="right"/> are qual; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(in Point2 left, in Point2 right) => left.Equals(right);

        /// <summary>
        /// Returns a value that indicates whether two specified points are not
        /// equal.
        /// </summary>
        /// <param name="left">The first point to compare.</param>
        /// <param name="right">The second point to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and 
        /// <paramref name="right"/> are not equal; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(in Point2 left, in Point2 right) => !(left == right);


        /// <summary>
        /// Multiplies the first point by the second. 
        /// </summary>
        /// <param name="left">The first point.</param>
        /// <param name="right">The second point.</param>
        /// <returns>The point resulting from the multiplication.</returns>
        public static Point2 operator *(in Point2 left, in Point2 right) => Multiply(left, right);

        /// <summary>
        /// Multiplies a point by a specified scalar.
        /// </summary>
        /// <param name="left">The point to multiply.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>The scaled point.</returns>
        public static Point2 operator *(in Point2 left, int right) => Multiply(left, right);

        /// <summary>
        /// Multiplies a scalar value by a specified point.
        /// </summary>
        /// <param name="left">The scalar value.</param>
        /// <param name="right">The point to multiply.</param>
        /// <returns>The scaled point.</returns>
        public static Point2 operator *(int left, in Point2 right) => Multiply(left, right);

        /// <summary>
        /// Subtracts the second point from the first.
        /// </summary>
        /// <param name="left">The first point.</param>
        /// <param name="right">The second point.</param>
        /// <returns>The difference point.</returns>
        public static Point2 operator -(in Point2 left, in Point2 right) => Subtract(left, right);

        /// <summary>
        /// Negates a specified point.
        /// </summary>
        /// <param name="value">The point to negate.</param>
        /// <returns>The negated point.</returns>
        public static Point2 operator -(in Point2 value) => Negate(value);

        #endregion
        #endregion
    }
}
