// Copyright (c) 2021 ezequias2d <ezequiasmoises@gmail.com> and the Ez.Numerics contributors
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.
using System.Numerics;

namespace Ez.Numerics.Bounding
{
    /// <summary>
    /// Represents a bounding box aligned to the X and Y axes .
    /// </summary>
    public struct BoundingBox : IBoundingVolume
    {

        /// <summary>
        /// The maximum point the <see cref="BoundingBox"/> contains.
        /// </summary>
        public Vector3 Max { get; set; }

        /// <summary>
        /// The minimum point the <see cref="BoundingBox"/> contains.
        /// </summary>
        public Vector3 Min { get; set; }

        /// <summary>
        /// Creates a new <see cref="BoundingBox"/> with the minimum point and maximum point.
        /// </summary>
        /// <param name="min">The minimum point.</param>
        /// <param name="max">The maximum point.</param>
        public BoundingBox(Vector3 min, Vector3 max)
        {
            Min = min;
            Max = max;
        }
        
        /// <inheritdoc/>
        public ContainmentType Contains(IBoundingVolume bounding)
        {
            if (bounding is BoundingBox boundingBox)
                Contains(boundingBox);
            return ContainmentType.Disjoint;
        }

        /// <summary>
        /// Returns the <see cref="ContainmentType"/> between this and another <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="bounding">The other <see cref="BoundingBox"/> to compare.</param>
        /// <returns>
        /// <see cref="ContainmentType.Disjoint"/>, if there is no overlap between the bounding volumes.<br/>
        /// <see cref="ContainmentType.Contains"/>, if the instance fully contains the volume of <see cref="BoundingBox"/>.<br/>
        /// <see cref="ContainmentType.Intersects"/>, if only part of the instance contains at least part of
        /// <paramref name="bounding"/> volume.</returns>
        public ContainmentType Contains(in BoundingBox bounding)
        {
            if ((Max.X >= bounding.Min.X) && (Min.X <= bounding.Max.X) &&
                (Max.Y >= bounding.Min.Y) && (Min.Y <= bounding.Max.Y) &&
                (Max.Z >= bounding.Min.Z) && (Min.Z <= bounding.Max.Z))
            {
                return ((Min.X <= bounding.Min.X) && (Max.X >= bounding.Max.X) &&
                    (Min.Y <= bounding.Min.Y) && (Max.Y >= bounding.Max.Y) &&
                    (Min.Z <= bounding.Min.Z) && (Max.Z >= bounding.Max.Z))
                    ? ContainmentType.Contains : ContainmentType.Intersects;
            }
            return ContainmentType.Disjoint;
        }

        /// <summary>
        /// Returns the <see cref="ContainmentType"/> between this and a <see cref="BoundingSphere"/>.
        /// </summary>
        /// <param name="sphere">The other <see cref="BoundingSphere"/> to compare.</param>
        /// <returns>
        /// <see cref="ContainmentType.Disjoint"/>, if there is no overlap between the bounding volumes.<br/>
        /// <see cref="ContainmentType.Contains"/>, if the instance fully contains the volume of <see cref="BoundingSphere"/>.<br/>
        /// <see cref="ContainmentType.Intersects"/>, if only part of the instance contains at least part of
        /// <paramref name="sphere"/> volume.</returns>
        public ContainmentType Contains(in BoundingSphere sphere)
        {
            var bmin = Min;
            var bmax = Max;
            var center = sphere.Center;
            var radius = sphere.Radius;

            if (center.X - bmin.X > radius
                && center.Y - bmin.Y > radius
                && center.Z - bmin.Z > radius
                && bmax.X - center.X > radius
                && bmax.Y - center.Y > radius
                && bmax.Z - center.Z > radius)
                return ContainmentType.Contains;

            return InternalBounding.Intersects(this, sphere)
                ? ContainmentType.Intersects
                : ContainmentType.Disjoint;
        }

        /// <inheritdoc/>
        public ContainmentType Contains(Vector3 point)
        {
            return ((Max.X >= point.X) && (Min.X <= point.X) &&
                (Max.Y >= point.Y) && (Min.Y <= point.Y) &&
                (Max.Z >= point.Z) && (Min.Z <= point.Z)) 
                ? ContainmentType.Contains 
                : ContainmentType.Disjoint;
        }
    }
}
