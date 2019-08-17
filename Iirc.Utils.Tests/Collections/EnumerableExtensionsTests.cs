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
        [InlineData(new [] {0}, 10, new [] {0})]
        [InlineData(new [] {1}, 20, new [] {1})]
        [InlineData(new [] {1,2}, 20, new [] {1,2})]
        [InlineData(new [] {1,2}, 21, new [] {2,1})]
        [InlineData(new [] {0,1,2,3,4,5,6,7,8,9}, 32, new [] {4,2,3,5,7,0,6,8,9,1})]
        public void ShuffleTheory(int[] list, int seed, int[] expected)
        {
            Assert.Equal(expected, list.Shuffle(new Random(seed)));
        }
        
        [Theory]
        [MemberData(nameof(ProductTheoryData))]
        public void ProductTheory(int[] values, int repeat, int[][] expected)
        {
            var result = values.Product(repeat).ToList();
            for (var resultIndex = 0; resultIndex < expected.Length; resultIndex++)
            {
                Assert.Equal(expected[resultIndex], result[resultIndex]);
            }
        }
        
        public static IEnumerable<object[]> ProductTheoryData =>
            new List<object[]>
            {
                new object[]
                {
                    new int[] { },
                    10,
                    new [] {new int[] {}}
                },
                new object[]
                {
                    new [] { 1 },
                    0,
                    new [] {new int[] {}}
                },
                new object[]
                {
                    new [] { 5},
                    1,
                    new [] {new [] {5}}
                },
                new object[]
                {
                    new [] { 1 },
                    3,
                    new [] {new [] {1, 1, 1}}
                },
                new object[]
                {
                    new [] { 1, 4, 5 },
                    2,
                    new [] {new [] {1, 1}, new [] {4, 1}, new [] {5, 1}, new[] {1, 4}, new [] {4, 4}, new [] {5, 4}, new [] {1, 5}, new [] {4, 5}, new[] {5, 5}}
                },
                new object[]
                {
                    new [] { 8, 5 },
                    3,
                    new [] { new [] {8, 8, 8}, new [] {5, 8, 8}, new [] {8, 5, 8}, new [] {5, 5, 8}, new [] {8, 8, 5}, new [] {5, 8, 5}, new [] {8, 5, 5}, new [] {5, 5, 5}}
                },
            };
    }
}
