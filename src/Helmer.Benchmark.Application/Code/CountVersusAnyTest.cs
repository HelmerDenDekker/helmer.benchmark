using System.Collections.ObjectModel;

namespace Helmer.Benchmark.Application.Code;

public class CountVersusAnyTest
{
	private static readonly IEnumerable<int> NumbersEnumerable = Enumerable.Range(1, 1000);
	private static readonly ReadOnlyCollection<int> NumbersCollection = NumbersEnumerable.ToList().AsReadOnly();
	private static readonly ReadOnlyCollection<int>? NullableNumbersCollection = NumbersEnumerable.ToList().AsReadOnly();
	
	public static bool TestIEnumerableWithCountParenthesis()
	{
		return NumbersEnumerable.Count() > 0;
	}
	
	public static bool TestIEnumerableWithToListAndCount()
	{
		return NumbersEnumerable.ToList().Count > 0;
	}
	
	public static bool TestIEnumerableWithAny()
	{
		return NumbersEnumerable.Any();
	}
	
	public static bool TestReadOnlyCollectionWithCountParenthesis()
	{
		return NumbersCollection.Count() > 0;
	}
	
	public static bool TestReadOnlyCollectionWithCount()
	{
		return NumbersCollection.Count > 0;
	}
	
	public static bool TestReadOnlyCollectionWithAny()
	{
		return NumbersCollection.Any();
	}
	
	public static bool TestNullableReadOnlyCollectionWithCount()
	{
		return NullableNumbersCollection?.Count > 0;
	}
	
	public static bool TestNullReadOnlyCollectionWithCount()
	{
		ReadOnlyCollection<int>? nullableNumbersCollection = null;
		return nullableNumbersCollection?.Count > 0;
	}
}
