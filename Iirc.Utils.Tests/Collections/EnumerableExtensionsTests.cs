// ---------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableExtensionsTests.cs" company="Czech Technical University in Prague">
//   Copyright (c) 2018 Czech Technical University in Prague
// </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Iirc.Utils.Tests.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using Iirc.Utils.Collections;

    public class EnumerableExtensionsTests
    {
        [Theory]
        [InlineData(new int[] {0}, 10, new int[] {0})]
        [InlineData(new int[] {1}, 20, new int[] {1})]
        [InlineData(new int[] {1,2}, 20, new int[] {1,2})]
        [InlineData(new int[] {1,2}, 21, new int[] {2,1})]
        [InlineData(new int[] {0,1,2,3,4,5,6,7,8,9}, 32, new int[] {4,2,3,5,7,0,6,8,9,1})]
        public void ShuffleTheory(int[] list, int seed, int[] expected)
        {
            Assert.Equal(expected, list.Shuffle(new Random(seed)));
        }
    }
}
