using Perfolizer.Common;
using Perfolizer.Mathematics.Common;

namespace Perfolizer.Mathematics.Distributions.DiscreteDistributions;

/*
 * The Wilcoxon Signed Rank distribution
 */
public class SignedRankDistribution : IDiscreteDistribution
{
    public int N { get; }

    private readonly int m, m2;
    private readonly double[] w;

    public SignedRankDistribution(int n)
    {
        Assertion.Positive(nameof(n), n);

        N = n;
        m = n * (n + 1) / 2;
        m2 = m / 2;

        w = new double[m2 + 1];
        w[0] = 1.0;
        if (n > 1)
        {
            w[1] = 1;
            for (int j = 2; j < n + 1; j++)
            for (int i = Min(j * (j + 1) / 2, m2); i >= j; i--)
                w[i] += w[i - j];
        }
    }

    private double W(int k)
    {
        if (k < 0 || k > m)
            return 0;
        return k > m2 ? w[m - k] : w[k];
    }


    public double Pmf(int k)
    {
        if (k < 0 || k > m)
            return 0;
        return Exp(Log(W(k)) - N * Constants.Log2);
    }

    public double Cdf(int k)
    {
        if (k < 0)
            return 0;
        if (k >= m)
            return 1;

        double sum = 0;
        for (int i = 0; i <= k; i++)
            sum += Pmf(i);
        return sum;
    }

    public int Quantile(Probability p)
    {
        double sum = 0;
        for (int i = 0; i <= m; i++)
        {
            sum += Pmf(i);
            if (sum >= p - 10 * double.Epsilon)
                return i;
        }
        return m2;
    }
}