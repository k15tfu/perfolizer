namespace Perfolizer.Tests.Common;

public static class TheoryDataHelper
{
    public static TheoryData<T> Create<T>(IEnumerable<T> values)
    {
        var data = new TheoryData<T>();
        foreach (var value in values)
            data.Add(value);
        return data;
    }
}