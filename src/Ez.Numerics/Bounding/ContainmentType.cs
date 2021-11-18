﻿// Copyright (c) 2021 ezequias2d <ezequiasmoises@gmail.com> and the Ez.Numerics contributors
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace Ez.Numerics.Bounding
{
    /// <summary>
    /// Indicates the extent to which bounding volumes intersect or contain one another.
    /// </summary>
    public enum ContainmentType
    {
        /// <summary>
        /// Indicates there is no overlap between the bounding volumes.
        /// </summary>
        Disjoint,
        /// <summary>
        /// Indicates that one bounding volume completely contains the other.
        /// </summary>
        Contains,
        /// <summary>
        /// Indicates that the bounding volumes partially overlap.
        /// </summary>
        Intersects
    }
}
