using Perfolizer.Collections;
using Perfolizer.Mathematics.GenericEstimators;
using Perfolizer.Tests.Common;

namespace Perfolizer.Tests.Mathematics.GenericEstimators;

public class HodgesLehmannEstimatorTests
{
    private static readonly IEqualityComparer<double> EqualityComparer = AbsoluteEqualityComparer.E9;

    private readonly ITestOutputHelper output;

    public HodgesLehmannEstimatorTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void HodgesLehmannLocationShiftTest01()
    {
        CheckShift(
            new[] { 0.298366502872861, 2.30272056972301, -1.07018041144338, 0.967248885283515, -0.849008187096325 },
            new[] { 9.98634587887872, 8.78621971483415, 9.35864761227285, 9.80372149505987, 10.2586337161638 },
            -9.50535499218701
        );
    }

    [Fact]
    public void HodgesLehmannMedianTest01()
    {
        CheckMedian(new double[] { 1, 2, 3, 4, 5 }, 3);
    }

    [Fact]
    public void HodgesLehmannMedianTest02()
    {
        CheckMedian(new[]
        {
            -0.616152614118394, -1.16812505107469, 0.328640358591086, 1.46651062744016, -0.356009545088913
        }, -0.143756127763654);
    }

    [Fact]
    public void HodgesLehmannMedianCiTest01() => CheckMedianCi(new[] { 1.0, 2.0, 4.0, 8.0, 16.0 }, 1, 16);

    [Fact]
    public void HodgesLehmannMedianCiTest02() => CheckMedianCi(new[]
    {
        -0.74315183848227, 0.506516386132896, 0.446721697848128, 0.370860468029778,
        0.13178222166903, 0.520402049232006, -1.11138116594466, -1.28087562153579,
        -0.789553914786685, 1.13584635187956
    }, -0.766352876634477, 0.506516386132896);
    
    [Fact]
    public void HodgesLehmannMedianCiTest03() => CheckMedianCi(Enumerable.Range(0, 10).ToDoubleArray(), 2.5, 7.5);

    private static void CheckShift(double[] x, double[] y, double expected)
    {
        double actual = HodgesLehmannEstimator.Instance.LocationShift(x.ToSample(), y.ToSample());
        Assert.Equal(expected, actual, EqualityComparer);
    }

    private static void CheckMedian(double[] x, double expected)
    {
        double actual = HodgesLehmannEstimator.Instance.Median(x.ToSample());
        Assert.Equal(expected, actual, EqualityComparer);
    }

    private void CheckMedianCi(double[] x, double expectedL, double expectedR, double level = 0.95)
    {
        var ci = HodgesLehmannEstimator.Instance.MedianConfidenceInterval(x.ToSample(), level);
        output.WriteLine(ci.ToString());
        Assert.Equal(expectedL, ci.Lower, EqualityComparer);
        Assert.Equal(expectedR, ci.Upper, EqualityComparer);
    }
}