using System.Numerics;

namespace Ez.Numerics.Bounding
{
    /// <summary>
    /// Represents a bounding sphere.
    /// </summary>
    public struct BoundingSphere : IBoundingVolume
    {   
        /// <summary>
        /// Creates a new <see cref="BoundingSphere"/> with the center point and radius size.
        /// </summary>
        /// <param name="center">The sphere center.</param>
        /// <param name="radius">The sphere radius.</param>
        public BoundingSphere(Vector3 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        /// <summary>
        /// The sphere center.
        /// </summary>
        public Vector3 Center { get; set; }

        /// <summary>
        /// The sphere radius.
        /// </summary>
        public float Radius { get; set; }

        /// <summary>
        /// Returns the <see cref="ContainmentType"/> between this and another <see cref="BoundingSphere"/>.
        /// </summary>
        /// <param name="sphere">The other <see cref="BoundingSphere"/> to compare.</param>
        /// <returns>
        /// <see cref="ContainmentType.Disjoint"/>, if there is no overlap between the bounding volumes.<br/>
        /// <see cref="ContainmentType.Contains"/>, if the instance fully contains the volume of <see cref="IBoundingVolume"/>.<br/>
        /// <see cref="ContainmentType.Intersects"/>, if only part of the instance contains at least part of
        /// <paramref name="sphere"/> volume.</returns>
        public ContainmentType Contains(in BoundingSphere sphere)
        {
            var sqDistance = Vector3.DistanceSquared(Center, sphere.Center);
            var radius = Radius;
            var otherRadius = sphere.Radius;

            var summedRadius = radius + otherRadius;
            if (sqDistance > summedRadius * summedRadius)
                return ContainmentType.Disjoint;

            var subtractedRadius = radius - otherRadius;
            if (sqDistance <= subtractedRadius * subtractedRadius)
                return ContainmentType.Contains;

            return ContainmentType.Intersects;
        }

        /// <inheritdoc/>
        public ContainmentType Contains(Vector3 point)
        {
            var radius = Radius;
            var sqRadius = radius * radius;
            var sqDistance = Vector3.DistanceSquared(point, Center);

            if (sqDistance > sqRadius)
                return ContainmentType.Disjoint;
            else if (sqDistance < sqRadius)
                return ContainmentType.Contains;
            return ContainmentType.Intersects;
        }

        /// <summary>
        /// Returns the <see cref="ContainmentType"/> between this and a <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">The other <see cref="BoundingBox"/> to compare.</param>
        /// <returns>
        /// <see cref="ContainmentType.Disjoint"/>, if there is no overlap between the bounding volumes.<br/>
        /// <see cref="ContainmentType.Contains"/>, if the instance fully contains the volume of <see cref="BoundingBox"/>.<br/>
        /// <see cref="ContainmentType.Intersects"/>, if only part of the instance contains at least part of
        /// <paramref name="box"/> volume.</returns>
        public ContainmentType Contains(BoundingBox box)
        {
            // check inside
            {
                Vector3 c0 = box.Min;
                Vector3 c1 = box.Max;
                Vector3 c2 = new(c0.X, c0.Y, c1.Z);
                Vector3 c3 = new(c0.X, c1.Y, c0.Z);
                Vector3 c4 = new(c0.X, c1.Y, c1.Z);
                Vector3 c5 = new(c1.X, c0.Y, c0.Z);
                Vector3 c6 = new(c1.X, c0.Y, c1.Z);
                Vector3 c7 = new(c1.X, c1.Y, c0.Z);

                if (Contains(c0) != ContainmentType.Disjoint &&
                    Contains(c1) != ContainmentType.Disjoint &&
                    Contains(c2) != ContainmentType.Disjoint &&
                    Contains(c3) != ContainmentType.Disjoint &&
                    Contains(c4) != ContainmentType.Disjoint &&
                    Contains(c5) != ContainmentType.Disjoint &&
                    Contains(c6) != ContainmentType.Disjoint &&
                    Contains(c7) != ContainmentType.Disjoint)
                    return ContainmentType.Contains;
            }

            return InternalBounding.Intersects(box, this)
                ? ContainmentType.Intersects 
                : ContainmentType.Disjoint;
        }

        /// <inheritdoc/>
        public ContainmentType Contains(IBoundingVolume bounding)
        {
            switch (bounding)
            {
                case BoundingSphere sphere:
                    return Contains(sphere);
                case BoundingBox box:
                    return Contains(box);
                default:
                    var method = bounding.GetType()
                                            .GetMethod("Contains", new[] { typeof(BoundingSphere) });
                    if(method is not null)
                    {
                        return (ContainmentType)method.Invoke(bounding, new object[] { this });
                    }
                    return ContainmentType.Disjoint;
            }
        }
    }
}
