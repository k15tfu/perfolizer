using JetBrains.Annotations;
using Perfolizer.Mathematics.Distributions.DiscreteDistributions;
using Perfolizer.Tests.Common;

namespace Perfolizer.Tests.Mathematics.Distributions.DiscreteDistributions;

public class SignedRankDistributionTests
{
    private readonly ITestOutputHelper output;

    public SignedRankDistributionTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    private class TestData
    {
        public int N { get; }
        public double[] ExpectedPmf { get; }

        public TestData(int n, double[] expectedPmf)
        {
            N = n;
            ExpectedPmf = expectedPmf;
        }
    }

    private static readonly List<TestData> TestDataList = new()
    {
        new TestData(1, new[] { 0.5, 0.5 }),
        new TestData(2, new[] { 0.25, 0.25, 0.25, 0.25 }),
        new TestData(3, new[] { 0.125, 0.125, 0.125, 0.25, 0.125, 0.125, 0.125 }),
        new TestData(4, new[] { 0.0625, 0.0625, 0.0625, 0.125, 0.125, 0.125, 0.125, 0.125, 0.0625, 0.0625, 0.0625 }),
        new TestData(5, new[]
        {
            0.03125, 0.03125, 0.03125, 0.0625, 0.0625, 0.09375, 0.09375, 0.09375, 0.09375, 0.09375, 0.09375, 0.0625, 0.0625, 0.03125,
            0.03125, 0.03125
        }),
        new TestData(6, new[]
        {
            0.015625, 0.015625, 0.015625, 0.03125, 0.03125, 0.046875, 0.0625, 0.0625, 0.0625, 0.078125, 0.078125, 0.078125, 0.078125,
            0.0625, 0.0625, 0.0625, 0.046875, 0.03125, 0.03125, 0.015625, 0.015625, 0.015625
        }),
        new TestData(7, new[]
        {
            0.0078125, 0.0078125, 0.0078125, 0.015625, 0.015625, 0.0234375, 0.03125, 0.0390625, 0.0390625, 0.046875, 0.0546875, 0.0546875,
            0.0625, 0.0625, 0.0625, 0.0625, 0.0625, 0.0546875, 0.0546875, 0.046875, 0.0390625, 0.0390625, 0.03125, 0.0234375, 0.015625,
            0.015625, 0.0078125, 0.0078125, 0.0078125
        }),
        new TestData(8, new[]
        {
            0.00390625, 0.00390625, 0.00390625, 0.0078125, 0.0078125, 0.01171875, 0.015625, 0.01953125, 0.0234375, 0.02734375, 0.03125,
            0.03515625, 0.0390625, 0.04296875, 0.046875, 0.05078125, 0.05078125, 0.05078125, 0.0546875, 0.05078125, 0.05078125, 0.05078125,
            0.046875, 0.04296875, 0.0390625, 0.03515625, 0.03125, 0.02734375, 0.0234375, 0.01953125, 0.015625, 0.01171875, 0.0078125,
            0.0078125, 0.00390625, 0.00390625, 0.00390625
        }),
        new TestData(9, new[]
        {
            0.001953125, 0.001953125, 0.001953125, 0.00390625, 0.00390625, 0.005859375, 0.0078125, 0.009765625, 0.01171875, 0.015625,
            0.017578125, 0.01953125, 0.0234375, 0.025390625, 0.029296875, 0.033203125, 0.03515625, 0.037109375, 0.041015625, 0.041015625,
            0.04296875, 0.044921875, 0.044921875, 0.044921875, 0.044921875, 0.04296875, 0.041015625, 0.041015625, 0.037109375, 0.03515625,
            0.033203125, 0.029296875, 0.025390625, 0.0234375, 0.01953125, 0.017578125, 0.015625, 0.01171875, 0.009765625, 0.0078125,
            0.005859375, 0.00390625, 0.00390625, 0.001953125, 0.001953125, 0.001953125
        })
    };

    [UsedImplicitly] public static TheoryData<int> TestDataKeys = TheoryDataHelper.Create(TestDataList.Select(it => it.N));

    [Theory]
    [MemberData(nameof(TestDataKeys))]
    public void TestSpecific(int n)
    {
        var testData = TestDataList.First(it => it.N == n);
        var distribution = new SignedRankDistribution(n);
        var comparer = AbsoluteEqualityComparer.E9;
        for (int k = 0; k < testData.ExpectedPmf.Length; k++)
        {
            double actualPmf = distribution.Pmf(k);
            double expectedPmf = testData.ExpectedPmf[k];
            output.WriteLine($"PMF({k}) = {actualPmf} (Expected: {expectedPmf})");

            double actualCdf = distribution.Cdf(k);
            double expectedCdf = testData.ExpectedPmf.Take(k + 1).Sum();
            output.WriteLine($"CDF({k}) = {actualCdf} (Expected: {expectedCdf})");

            int actualQuantile = distribution.Quantile(expectedCdf);
            int expectedQuantile = k;
            output.WriteLine($"Quantile({expectedCdf}) = {actualQuantile} (Expected: {expectedQuantile})");

            Assert.Equal(expectedPmf, actualPmf, comparer);
            Assert.Equal(expectedCdf, actualCdf, comparer);
            Assert.Equal(expectedQuantile, actualQuantile, comparer);
        }
    }

    [Theory]
    [InlineData(10)]
    [InlineData(13)]
    [InlineData(14)]
    [InlineData(17)]
    [InlineData(18)]
    [InlineData(50)]
    [InlineData(501)]
    [InlineData(1034)]
    [InlineData(1001)]
    public void TestMedian(int n)
    {
        var distribution = new SignedRankDistribution(n);
        int k = n * (n + 1) / 2 / 2;
        Assert.Equal(0.5, distribution.Cdf(k), AbsoluteEqualityComparer.E9);
    }
}