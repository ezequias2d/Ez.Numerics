using System;
using System.Drawing;
using System.Numerics;

namespace Ez.Numerics
{
    /// <summary>
    /// Some extensions for convert colors and vectors.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Convert a <see cref="Vector3"/> into a <see cref="Color"/>;
        /// </summary>
        /// <param name="value">The <see cref="Vector3"/> to convert to <see cref="Color"/>.</param>
        /// <returns>The converted <see cref="Color"/>.</returns>
        public static Color ToColor(this in Vector3 value)
        {
            return ToColor(new Vector4(value, 1f));
        }

        /// <summary>
        /// Convert a <see cref="Vector4"/> into a <see cref="Color"/>;
        /// </summary>
        /// <param name="value">The <see cref="Vector4"/> to convert to <see cref="Color"/>.</param>
        /// <returns>The converted <see cref="Color"/>.</returns>
        public static Color ToColor(this in Vector4 value)
        {
            var r = (int)Math.Clamp(value.X * 255f, byte.MinValue, byte.MaxValue);
            var g = (int)Math.Clamp(value.Y * 255f, byte.MinValue, byte.MaxValue);
            var b = (int)Math.Clamp(value.Z * 255f, byte.MinValue, byte.MaxValue);
            var a = (int)Math.Clamp(value.W * 255f, byte.MinValue, byte.MaxValue);

            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// Convert a <see cref="Color"/> into a <see cref="Vector3"/>;
        /// </summary>
        /// <param name="color">The <see cref="Color"/> to convert to <see cref="Vector3"/>.</param>
        /// <returns>The converted <see cref="Vector3"/>.</returns>
        public static Vector3 ToVector3(this in Color color)
        {
            const float inv = 1f / 255f;
            return new Vector3(color.R, color.G, color.B) * inv;
        }

        /// <summary>
        /// Convert a <see cref="Color"/> into a <see cref="Vector4"/>;
        /// </summary>
        /// <param name="color">The <see cref="Color"/> to convert to <see cref="Vector4"/>.</param>
        /// <returns>The converted <see cref="Vector4"/>.</returns>
        public static Vector4 ToVector4(this in Color color)
        {
            const float inv = 1f / 255f;
            return new Vector4(color.R, color.G, color.B, color.A) * inv;
        }
    }
}
