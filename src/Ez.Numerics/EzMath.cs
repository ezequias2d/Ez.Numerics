// Copyright (c) 2021 ezequias2d <ezequiasmoises@gmail.com> and the Ez.Numerics contributors
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Ez.Numerics
{
    /// <summary>
    /// Provides constants and static methods to complement <see cref="Math"/>.
    /// </summary>
    public static class EzMath
    {
        /// <summary>
        /// A tiny floating point value.
        /// </summary>
        public const float Epsilon = 1.17549435E-38f;

        /// <summary>
        /// Represents the ratio of the circumference of a circle to its diameter, specified by the constant, π.
        /// </summary>
        public const float PI = (float)Math.PI;

        /// <summary>
        /// Represents the natural logarithmic base, specified by the constant, e.
        /// </summary>
        public const float E = (float)Math.E;

        /// <summary>
        /// Represents the number of radians in one turn, specified by the constant, τ.
        /// </summary>
        public const float Tau = (float)Math.Tau;

        /// <summary>
        /// Degrees-to-radians conversion constant.
        /// <see cref="Rad2Deg"/>
        /// </summary>
        public const float Deg2Rad = (float)(Math.PI / 180d);

        /// <summary>
        /// Radians-to-degrees conversion constant.
        /// <see cref="Deg2Rad"/>
        /// </summary>
        public const float Rad2Deg = (float)(180d / Math.PI);

        /// <summary>
        /// Natural logarithm of 2 inverted constant(1 / log 2).
        /// </summary>
        public const float InvLogE2 = 1.4426950408889634073599246810019f;

        /// <summary>
        /// The gamma value used in sRGB color space.
        /// </summary>
        public const float Gamma = 2.2f;

        /// <summary>
        /// The inverse gamma value used in sRGB color space.
        /// </summary>
        public const float InvGamma = 1f / Gamma;

        /// <summary>
        /// Returns the absolute value of a single-precision floating-point number.
        /// </summary>
        /// <param name="value">A number that is greater than or equal to <see cref="float.MinValue"/>, 
        /// but less than or equal to <see cref="float.MaxValue"/>.</param>
        /// <returns>A single-precision floating-point number, x, such that 0 ≤ x ≤ 
        /// <see cref="float.MaxValue"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(float value) => MathF.Abs(value);

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <param name="value">A number representing a cosine, where value must be greater than
        /// or equal to -1,
        /// but less than or equal to 1.</param>
        /// <returns>An angle, θ, measured in radians, such that 0 ≤ θ ≤ π.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acos(float value) => MathF.Acos(value);

        /// <summary>
        /// Compares two floating point values and returns true if they are similar.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <returns><see langword="true"/>, if they are within a small value epsilon; otherwise,
        /// <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Approximately(float a, float b)
        {
            if (a == 0 || b == 0)
                return MathF.Abs(a - b) <= Epsilon;

            var delta = MathF.Abs(a - b);
            var deltaA = delta / MathF.Abs(a);
            var deltaB = delta / MathF.Abs(b);

            return deltaA <= Epsilon &&
                deltaB <= Epsilon;
        }

        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// <param name="value">A number representing a sine, where x must be greater than or
        /// equal to -1, but less than or equal to 1.</param>
        /// <returns>An angle, θ, measured in radians, such that -π/2 ≤ θ ≤ π/2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asin(float value) => MathF.Asin(value);

        /// <summary>
        /// Returns the angle whose tangent is the specified number.
        /// </summary>
        /// <param name="value">A number representing a tangent.</param>
        /// <returns>An angle, θ, measured in radians, such that -π/2 ≤ θ ≤ π/2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan(float value) => MathF.Atan(value);

        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers.
        /// </summary>
        /// <param name="x">The y coordinate of a point.</param>
        /// <param name="y">The x coordinate of a point.</param>
        /// <returns>An angle, θ, measured in radians, such that -π ≤ θ ≤ π, and tan(θ) = y / x, 
        /// where (x, y) is a point in the Cartesian plane.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan2(float x, float y) => MathF.Atan2(x, y);

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified 
        /// single-precision floating-point number.
        /// </summary>
        /// <param name="a">A single-precision floating-point number.</param>
        /// <returns>The smallest integral value that is greater than or equal to <paramref name="a"/>. 
        /// If <paramref name="a"/> is equal to <see cref="float.NaN"/>, 
        /// <see cref="float.NegativeInfinity"/>, or <see cref="float.PositiveInfinity"/>, that value
        /// is returned. </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Ceiling(float a) => MathF.Ceiling(a);

        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// Returns the given value if it is within the min and max range.
        /// </summary>
        /// <param name="value">The value to restrict inside the range defined by the
        /// <paramref name="min"/> and <paramref name="max"/> values.</param>
        /// <param name="min">The minimum value to compare against.</param>
        /// <param name="max">The maximum value to compare against.</param>
        /// <returns>The float result between the min and max values.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(float value, float min, float max) => Math.Clamp(value, min, max);

        /// <summary>
        /// Clamps value between 0 and 1 and returns value.
        /// </summary>
        /// <param name="value">The value to restrict inside the range 0 and 1.</param>
        /// <returns>The value clamped between 0 and 1.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp01(float value) => Math.Clamp(value, 0, 1);

        /// <summary>
        /// Returns the cosine of the specified angle.
        /// </summary>
        /// <param name="value">An angle, measured in radians.</param>
        /// <returns>The cosine of <paramref name="value"/>. If x is equal to <see cref="float.NaN"/>, 
        /// <see cref="float.NegativeInfinity"/>, or <see cref="float.PositiveInfinity"/>,
        /// this method returns <see cref="float.NaN"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(float value) => MathF.Cos(value);

        /// <summary>
        /// Calculates the shortest difference between two given angles given in degrees.
        /// </summary>
        /// <param name="current">The first angle.</param>
        /// <param name="target">The second angle.</param>
        /// <returns>The shortest difference between two given angles in degrees.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DeltaAngle(float current, float target)
        {
            var diff = Math.Abs((target - current) % 360f);
            if (diff > 180)
                return diff - 180;
            return diff;
        }

        /// <summary>
        /// Returns e raised to the specified power.
        /// </summary>
        /// <param name="power">A number specifying a power.</param>
        /// <returns>he number e raised to the <paramref name="power"/>. If <paramref name="power"/>
        /// equals <see cref="float.NaN"/> or <see cref="float.PositiveInfinity"/>, that value is returned.
        /// If <paramref name="power"/> equals <see cref="float.NegativeInfinity"/>, 0 is returned.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp(float power) => MathF.Exp(power);

        /// <summary>
        /// Returns the largest integral value less than or equal to the specified number.
        /// </summary>
        /// <param name="value">A single-precision floating-point number.</param>
        /// <returns>The largest integral value less than or equal to <paramref name="value"/>. 
        /// If <paramref name="value"/> is equal to <see cref="float.NaN"/>, <see cref="float.NegativeInfinity"/>, 
        /// or <see cref="float.PositiveInfinity"/>, that value is returned.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Floor(float value) => MathF.Floor(value);

        /// <summary>
        /// Converts the given value from gamma(sRGB) to linear color space.
        /// </summary>
        /// <param name="value">The gamma value.</param>
        /// <returns>The <paramref name="value"/> in linear color space.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GammaToLinearSpace(float value) => MathF.Pow(value, Gamma);

        /// <summary>
        /// Calculates the linear parameter t that produces the interpolant 
        /// <paramref name="value"/> within the range 
        /// [<paramref name="start"/>, <paramref name="end"/>].
        /// </summary>
        /// <param name="start">Start value.</param>
        /// <param name="end">End value.</param>
        /// <param name="value">Value between start and end.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float InverseLerp(float start, float end, float value) => (value - start) / (end - start);

        /// <summary>
        /// Linearly interpolates between <paramref name="start"/> and 
        /// <paramref name="end"/> by <paramref name="t"/>.
        /// </summary>
        /// <param name="start">Start value.</param>
        /// <param name="end">End value.</param>
        /// <param name="t">The interpolation value between the two floats.</param>
        /// <returns>The interpolated float result between the two float values.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Lerp(float start, float end, float t) => start + ((end - start) * Clamp01(t));

        /// <summary>
        /// Linearly interpolates between <paramref name="start"/> and <paramref name="end"/> 
        /// by <paramref name="t"/> with no limit to <paramref name="t"/>.
        /// </summary>
        /// <param name="start">Start value.</param>
        /// <param name="end">End value.</param>
        /// <param name="t">The interpolation between the two floats.</param>
        /// <returns>The float value as a result from the linear interpolation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LerpUnclamped(float start, float end, float t) => start + (end - start) * t;

        /// <summary>
        /// Converts the given <paramref name="value"/> from linear to gamma (sRGB) color space.
        /// </summary>
        /// <param name="value">The linear value.</param>
        /// <returns>The <paramref name="value"/> in gamma (sRGB) color space.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LinearToGammaSpace(float value) => MathF.Pow(value, InvGamma);

        /// <summary>
        /// Returns the natural (base e) logarithm of a specified number.
        /// </summary>
        /// <param name="x">The number whose logarithm is to be found.</param>
        /// <returns>The natural logarithm of <paramref name="x"/>; that is, 
        /// ln <paramref name="x"/>, or log e <paramref name="x"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log(float x) => MathF.Log(x);

        /// <summary>
        /// Returns the logarithm of a specified number in a specified base.
        /// </summary>
        /// <param name="x">The number whose logarithm is to be found.</param>
        /// <param name="y">The base.</param>
        /// <returns>The base <paramref name="y"/> logarithm of <paramref name="x"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log(float x, float y) => MathF.Log(x, y);

        /// <summary>
        /// Returns the base 10 logarithm of a specified number.
        /// </summary>
        /// <param name="x">A number whose logarithm is to be found.</param>
        /// <returns>The base 10 log of <paramref name="x"/>; that is, log 10 <paramref name="x"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log10(float x) => MathF.Log10(x);

        /// <summary>
        /// Calculates the log on base 2.
        /// </summary>
        /// <param name="d">The number whose logarithm is to be found.</param>
        /// <returns>
        /// The natural logarithm of <paramref name="d"/>, if <paramref name="d"/> is positive.<br/>
        /// <see cref="double.NegativeInfinity"/>, if <paramref name="d"/> is zero.<br/>
        /// <see cref="double.NaN"/>, if <paramref name="d"/> is negative or equal to <see cref="double.NaN"/>.<br/>
        /// <see cref="double.PositiveInfinity"/>, if <paramref name="d"/> is <see cref="double.PositiveInfinity"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log2(float d)
        {
            var log = MathF.Log(d);
            return log * InvLogE2;
        }

        /// <summary>
        /// Returns the larger of two single-precision floating-point numbers.
        /// </summary>
        /// <param name="x">The first of two single-precision floating-point numbers to compare.</param>
        /// <param name="y">The second of two single-precision floating-point numbers to compare.</param>
        /// <returns>Parameter <paramref name="x"/> or <paramref name="y"/>, whichever is larger. 
        /// If <paramref name="x"/>, or <paramref name="y"/>, or both <paramref name="x"/> and 
        /// <paramref name="y"/> are equal to <see cref="float.NaN"/>, <see cref="float.NaN"/> is
        /// returned.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float x, float y) => MathF.Max(x, y);

        /// <summary>
        /// Returns the smaller of two single-precision floating-point numbers.
        /// </summary>
        /// <param name="x">The first of two single-precision floating-point numbers to compare.</param>
        /// <param name="y">The second of two single-precision floating-point numbers to compare.</param>
        /// <returns>Parameter <paramref name="x"/> or <paramref name="y"/>, whichever is smaller. 
        /// If <paramref name="x"/>, <paramref name="y"/>, or both <paramref name="x"/> and <paramref name="y"/> 
        /// are equal to NaN, NaN is returned.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float x, float y) => MathF.Min(x, y);

        /// <summary>
        /// Returns a specified number raised to the specified power.
        /// </summary>
        /// <param name="value">A single-precision floating-point number to be raised to a power.</param>
        /// <param name="power">A single-precision floating-point number that specifies a power.</param>
        /// <returns>The <paramref name="value"/> raised to the <paramref name="power"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow(float value, float power) => MathF.Pow(value, power);

        /// <summary>
        /// Rounds a value to the nearest integer or to the specified number of fractional digits.
        /// </summary>
        /// <param name="a">A single-precision floating-point number to be rounded.</param>
        /// <returns>The integer nearest <paramref name="a"/>. If the fractional component of a is halfway between two integers,
        /// one of which is even and the other odd, then the even number is returned.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float a) => MathF.Round(a);

        /// <summary>
        /// Returns an integer that indicates the sign of a single-precision floating-point number.
        /// </summary>
        /// <param name="value">A signed number.</param>
        /// <returns>A number that indicates the sign of <paramref name="value"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(float value) => MathF.Sign(value);

        /// <summary>
        /// Returns the square root of a specified number.
        /// </summary>
        /// <param name="value">The number whose square root is to be found.</param>
        /// <returns>The positive square root of <paramref name="value"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqrt(float value) => MathF.Sqrt(value);

        /// <summary>
        /// Returns the tangent of the specified angle.
        /// </summary>
        /// <param name="value">An angle, measured in radians.</param>
        /// <returns>The tangent of <paramref name="value"/>. If <paramref name="value"/> is equal to
        /// <see cref="float.NaN"/>, <see cref="float.NegativeInfinity"/>, or <see cref="float.PositiveInfinity"/>, 
        /// this method returns <see cref="float.NaN"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tan(float value) => MathF.Tan(value);

        /// <summary>
        /// Returns the euler angle representation of a <see cref="Quaternion"/>.
        /// </summary>
        /// <param name="q">The quaternion to represent in the form of euler angle.</param>
        /// <returns>An euler angle vector that represents the <paramref name="q"/> quaternion.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 ToEulerAngles(this Quaternion q)
        {
            Vector3 euler;

            // if the input quaternion is normalized, this is exactly one. Otherwise, this acts as a correction factor for the quaternion's not-normalizedness
            float unit = (q.X * q.X) + (q.Y * q.Y) + (q.Z * q.Z) + (q.W * q.W);

            // this will have a magnitude of 0.5 or greater if and only if this is a singularity case
            float test = q.X * q.W - q.Y * q.Z;

            if (test > 0.4995f * unit) // singularity at north pole
            {
                euler.X = MathF.PI / 2;
                euler.Y = 2f * MathF.Atan2(q.Y, q.X);
                euler.Z = 0;
            }
            else if (test < -0.4995f * unit) // singularity at south pole
            {
                euler.X = -MathF.PI / 2;
                euler.Y = -2f * MathF.Atan2(q.Y, q.X);
                euler.Z = 0;
            }
            else // no singularity - this is the majority of cases
            {
                euler.X = MathF.Asin(2f * (q.W * q.X - q.Y * q.Z));
                euler.Y = MathF.Atan2(2f * q.W * q.Y + 2f * q.Z * q.X, 1 - 2f * (q.X * q.X + q.Y * q.Y));
                euler.Z = MathF.Atan2(2f * q.W * q.Z + 2f * q.X * q.Y, 1 - 2f * (q.Z * q.Z + q.X * q.X));
            }

            return euler * Rad2Deg;
        }

        /// <summary>
        /// Returns the quaternion representation of a euler angle <see cref="Vector3"/>.
        /// </summary>
        /// <param name="eulerAngles">The euler angle to represents in the form of quaternion.</param>
        /// <returns>An quaternion that represents the <paramref name="eulerAngles"/> vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion ToQuaternion(this Vector3 eulerAngles)
        {
            Vector3 eulerAnglesRadians = eulerAngles * Deg2Rad;
            return Quaternion.CreateFromYawPitchRoll(eulerAnglesRadians.Y, eulerAnglesRadians.X, eulerAnglesRadians.Z);
        }

        /// <summary>
        /// Remaps a value from a range to another range.
        /// </summary>
        /// <param name="value">The value to remap.</param>
        /// <param name="fromMin">The minimum value of the source range.</param>
        /// <param name="fromMax">The maximum value of the source range.</param>
        /// <param name="toMin">The minimum value of the target range.</param>
        /// <param name="toMax">The maximum value of the target range.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Remap(in float value, in float fromMin, in float fromMax, in float toMin, in float toMax)
        {
            var toDelta = toMax - toMin;
            var fromDelta = fromMax - fromMin;
            var result = (toDelta * ((value - fromMin) / fromDelta)) + toMin;
            return Math.Clamp(result, toMin, toMax);
        }
    }
}
