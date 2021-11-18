// Copyright (c) 2021 ezequias2d <ezequiasmoises@gmail.com> and the Ez.Numerics contributors
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.
using System.Runtime.CompilerServices;

using static Ez.Numerics.EzMath;
namespace Ez.Numerics
{
    /// <summary>
    /// Class that provider functions to compute Perlin noise
    /// </summary>
    public static class Perlin
    {
        /// <summary>
        /// Computes one-dimensional perlin noise.
        /// </summary>
        /// <param name="x">The x-coordinate of sample point.</param>
        /// <returns>A value between 0.0 and 1.0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Noise(float x)
        {
            var x0 = (int)x;
            x -= x0;
            var u = Fade(x);
            return Lerp(Gradient(Hash(x0), x), Gradient(Hash(x0 + 1), x - 1), u) * 2;
        }

        /// <summary>
        /// Computes two-dimensional perlin noise.
        /// </summary>
        /// <param name="x">The x-coordinate of sample point.</param>
        /// <param name="y">The y-coordinate of sample point.</param>
        /// <returns>A value between 0.0 and 1.0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Noise(float x, float y)
        {
            var x0 = (int)x;
            x -= x0;
            var u = Fade(x);

            var y0 = (int)y;
            y -= y0;
            var v = Fade(y);

            var A = Hash(x0) + y0;
            var B = Hash(x0 + 1) + y0;
            return Lerp(Lerp(Gradient(Hash(A), x, y), Gradient(Hash(B), x - 1, y), u),
                           Lerp(Gradient(Hash(A + 1), x, y - 1), Gradient(Hash(B + 1), x - 1, y - 1), u), v);
        }

        /// <summary>
        /// Computes three-dimensional perlin noise.
        /// </summary>
        /// <param name="x">The x-coordinate of sample point.</param>
        /// <param name="y">The y-coordinate of sample point.</param>
        /// <param name="z">The z-coordinate of sample point.</param>
        /// <returns>A value between 0.0 and 1.0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Noise(float x, float y, float z)
        {
            var x0 = (int)x;
            x -= x0;
            var u = Fade(x);

            var y0 = (int)y;
            y -= y0;
            var v = Fade(y);

            var z0 = (int)z;
            z -= z0;
            var w = Fade(z);

            var A = Hash(x0) + y0;
            var B = Hash(x0 + 1) + y0;
            var AA = Hash(A) + z0;
            var BA = Hash(B) + z0;
            var AB = Hash(A + 1) + z0;
            var BB = Hash(B + 1) + z0;
            return Lerp(Lerp(Lerp(Gradient(Hash(AA), x, y, z), Gradient(Hash(BA), x - 1, y, z), u),
                                   Lerp(Gradient(Hash(AB), x, y - 1, z), Gradient(Hash(BB), x - 1, y - 1, z), u), v),
                           Lerp(Lerp(Gradient(Hash(AA + 1), x, y, z - 1), Gradient(Hash(BA + 1), x - 1, y, z - 1), u),
                                   Lerp(Gradient(Hash(AB + 1), x, y - 1, z - 1), Gradient(Hash(BB + 1), x - 1, y - 1, z - 1), u), v), w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float Fade(float t)
        {
            const float c = -PI;
            const float d = 1.6180339887498948482045868343656f; // gold ratio
            const float a = (3 * d + c);
            const float b = 2 * d;

            const float min = 0;
            const float max = a / (b + c + d);

            var sq = t * t;
            var value = a * sq / (b * sq + c * t + d);
            return Remap(value, min, max, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float Gradient(int hash, float x)
        {
            return (hash & 1) == 0 ? x : -x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float Gradient(int hash, float x, float y)
        {
            return Gradient(hash, x) + Gradient(hash >> 1, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float Gradient(int hash, float x, float y, float z)
        {
            var h = hash & 15;
            var u = h < 8 ? x : y;
            var v = h < 4 ? y : (h == 12 || h == 14 ? x : z);
            return Gradient(hash, u, v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int Hash(int value)
        {
            return perm[value & 0xFF];
        }

        static readonly int[] perm = {
            151,160,137,91,90,15,
            131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,
            190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
            88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
            77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
            102,143,54, 65,25,63,161, 1,216,80,73,209,76,132,187,208, 89,18,169,200,196,
            135,130,116,188,159,86,164,100,109,198,173,186, 3,64,52,217,226,250,124,123,
            5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
            223,183,170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,172,9,
            129,22,39,253, 19,98,108,110,79,113,224,232,178,185, 112,104,218,246,97,228,
            251,34,242,193,238,210,144,12,191,179,162,241, 81,51,145,235,249,14,239,107,
            49,192,214, 31,181,199,106,157,184, 84,204,176,115,121,50,45,127, 4,150,254,
            138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180,
        };
    }
}