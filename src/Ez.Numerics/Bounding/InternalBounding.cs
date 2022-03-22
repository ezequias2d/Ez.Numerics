using System.Runtime.CompilerServices;

namespace Ez.Numerics.Bounding
{
    internal static class InternalBounding
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Intersects(in BoundingBox box, in BoundingSphere sphere)
        {
            var bmin = box.Min;
            var bmax = box.Max;
            var radius = sphere.Radius;
            var center = sphere.Center;

            var dmin = 0f;
            dmin += GetDmin(center.X, bmin.X, bmax.X);
            dmin += GetDmin(center.Y, bmin.Y, bmax.Y);
            dmin += GetDmin(center.Z, bmin.Z, bmax.Z);

            return dmin <= radius * radius;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float GetDmin(in float center, in float min, in float max)
        {
            float tmp;
            if (center < min)
                tmp = center - min;
            else if (center > max)
                tmp = center - max;
            else
                return 0;
            return tmp * tmp;
        }
    }
}
