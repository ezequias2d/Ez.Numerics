// Copyright (c) 2021 ezequias2d <ezequiasmoises@gmail.com> and the Ez.Numerics contributors
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Numerics;

namespace Ez.Numerics.Bounding
{
    /// <summary>
    /// Provides a generic interface for bounding volume
    /// </summary>
    public interface IBoundingVolume
    {
        /// <summary>
        /// Returns the <see cref="ContainmentType"/> between this and another <see cref="IBoundingVolume"/>.
        /// </summary>
        /// <param name="bounding">The other <see cref="IBoundingVolume"/> to compare.</param>
        /// <returns>
        /// <see cref="ContainmentType.Disjoint"/>, if there is no overlap between the bounding volumes.<br/>
        /// <see cref="ContainmentType.Contains"/>, if the instance fully contains the volume of <see cref="IBoundingVolume"/>.<br/>
        /// <see cref="ContainmentType.Intersects"/>, if only part of the instance contains at least part of
        /// <paramref name="bounding"/> volume.</returns>
        public ContainmentType Contains(IBoundingVolume bounding);

        /// <summary>
        /// Returns a value indicating whether the point is within the bounding.
        /// </summary>
        /// <param name="point">The pointer to evaluate.</param>
        /// <returns><see langword="true"/> if the point is inside the bounding box; otherwise, <see langword="false"/>.</returns>
        public ContainmentType Contains(Vector3 point);

    }
}
