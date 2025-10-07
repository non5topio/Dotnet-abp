using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;
using System;
using System.Collections.Generic;
using Xunit;
using Volo.Abp;
using System;
using Xunit;
using Volo.Abp;
using System;
using System.Collections.Generic;
using Shouldly;
using Volo.Abp;
using Xunit;
using Xunit;
using Volo.Abp;
using Xunit;
using Shouldly;
using Volo.Abp;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp;
using Xunit;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp;
using Shouldly;
using Xunit;

namespace Volo.Abp;

public class RandomHelper_Tests
{
    [Fact]
    public void GenerateRandomizedList_WithSingleItem_ReturnsListWithThatItem()
    {
        // Arrange
        IEnumerable<string> items = new List<string> { "OnlyItem" };
    
        // Act
        List<string> result = RandomHelper.GenerateRandomizedList(items);
    
        // Assert
        result.ShouldHaveSingleItem();
        result.First().ShouldBe("OnlyItem");
    }

    [Fact]
    public void GenerateRandomizedList_WithNullEnumerable_ThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<int> items = null;
    
        // Act & Assert
        var exception = Should.Throw<ArgumentNullException>(() => RandomHelper.GenerateRandomizedList(items));
        exception.ParamName.ShouldBe("items");
    }


    [Fact]
    public void GetRandom_WithLargeRangeNearMaxValue_ReturnsValueInRange()
    {
        // Arrange
        int minValue = int.MaxValue - 100;
        int maxValue = int.MaxValue;
    
        // Act & Assert
        for (int i = 0; i < 50; i++)
        {
            int result = RandomHelper.GetRandom(minValue, maxValue);
            result.ShouldBeGreaterThanOrEqualTo(minValue);
            result.ShouldBeLessThan(maxValue);
        }
    }


    [Fact]
    public void GetRandomOfList_WithEmptyList_ThrowsArgumentException()
    {
        // Arrange
        IList<int> list = new List<int>();
    
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => RandomHelper.GetRandomOfList(list));
        Assert.Equal("list", exception.ParamName);
    }


    [Fact]
    public void GetRandomOfList_WithNullList_ThrowsArgumentException()
    {
        // Arrange
        IList<int> list = null;
    
        // Act & Assert
        var exception = Should.Throw<ArgumentException>(() => RandomHelper.GetRandomOfList(list));
        exception.ParamName.ShouldBe("list");
    }


    [Fact]
    public void GetRandomOf_WithEmptyArray_ThrowsArgumentException()
    {
        // Arrange
        string[] objs = new string[0];
    
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => RandomHelper.GetRandomOf(objs));
        Assert.Equal("objs", exception.ParamName);
    }


    [Fact]
    public void GenerateRandomizedList_WithEmptyEnumerable_ReturnsEmptyList()
    {
        // Arrange
        IEnumerable<int> items = new List<int>();
    
        // Act
        List<int> result = RandomHelper.GenerateRandomizedList(items);
    
        // Assert
        result.ShouldBeEmpty();
    }


    [Fact]
    public void GetRandomOfList_WithSingleItem_ReturnsThatItem()
    {
        // Arrange
        IList<string> list = new List<string> { "SingleItem" };
    
        // Act & Assert
        for (int i = 0; i < 10; i++)
        {
            string result = RandomHelper.GetRandomOfList(list);
            result.ShouldBe("SingleItem");
        }
    }


    [Fact]
    public void GetRandomOf_WithSingleObject_ReturnsThatObject()
    {
        // Arrange
        string[] objs = new[] { "OnlyItem" };
    
        // Act & Assert
        for (int i = 0; i < 10; i++)
        {
            string result = RandomHelper.GetRandomOf(objs);
            result.ShouldBe("OnlyItem");
        }
    }


    [Fact]
    public void GetRandom_WithMaxValueOne_ReturnsOnlyZero()
    {
        // Act & Assert
        for (int i = 0; i < 50; i++)
        {
            int result = RandomHelper.GetRandom(1);
            result.ShouldBe(0);
        }
    }


    [Fact]
    public void GetRandom_WithMaxValueZero_ReturnsZero()
    {
        // Act
        int result = RandomHelper.GetRandom(0);
    
        // Assert
        result.ShouldBe(0);
    }


    [Fact]
    public void GetRandomOf_WithNullArray_ThrowsArgumentException()
    {
        // Arrange
        string[] objs = null;
    
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => RandomHelper.GetRandomOf(objs));
        Assert.Equal("objs", exception.ParamName);
    }


    [Fact]
    public void GetRandom_WithEqualMinAndMaxValue_ReturnsMinValue()
    {
        // Arrange
        int minValue = 42;
        int maxValue = 42;
    
        // Act
        int result = RandomHelper.GetRandom(minValue, maxValue);
    
        // Assert
        result.ShouldBe(42);
    }


    [Fact]
    public void GenerateRandomizedList_WithMultipleItems_ReturnsAllItemsInRandomOrder()
    {
        // Arrange
        IEnumerable<int> items = new List<int> { 1, 2, 3, 4, 5 };
    
        // Act
        List<int> result = RandomHelper.GenerateRandomizedList(items);
    
        // Assert
        result.Count.ShouldBe(5);
        result.ShouldContain(1);
        result.ShouldContain(2);
        result.ShouldContain(3);
        result.ShouldContain(4);
        result.ShouldContain(5);
        result.Distinct().Count().ShouldBe(5); // No duplicates
    }


    [Fact]
    public void GetRandomOfList_WithMultipleItems_ReturnsOneOfThem()
    {
        // Arrange
        IList<int> list = new List<int> { 1, 2, 3, 4, 5 };
        var results = new List<int>();
    
        // Act
        for (int i = 0; i < 100; i++)
        {
            results.Add(RandomHelper.GetRandomOfList(list));
        }
    
        // Assert
        results.ShouldAllBe(x => list.Contains(x));
        results.Distinct().Count().ShouldBeGreaterThan(1); // Different values should be returned
    }


    [Fact]
    public void GetRandomOf_WithMultipleObjects_ReturnsOneOfThem()
    {
        // Arrange
        var objs = new[] { "apple", "banana", "cherry", "date" };
        var results = new List<string>();
    
        // Act
        for (int i = 0; i < 100; i++)
        {
            results.Add(RandomHelper.GetRandomOf(objs));
        }
    
        // Assert
        results.ShouldAllBe(x => objs.Contains(x));
        results.Distinct().Count().ShouldBeGreaterThan(1); // Different values should be returned
    }


    [Fact]
    public void GetRandom_WithNoParameters_ReturnsNonNegativeValue()
    {
        // Arrange
        var results = new List<int>();
    
        // Act
        for (int i = 0; i < 100; i++)
        {
            results.Add(RandomHelper.GetRandom());
        }
    
        // Assert
        results.ShouldAllBe(x => x >= 0 && x < int.MaxValue);
        results.Distinct().Count().ShouldBeGreaterThan(1); // Values should vary
    }


    [Fact]
    public void GetRandom_WithMaxValueOnly_ReturnsValueInRange()
    {
        // Arrange
        int maxValue = 50;
        var results = new List<int>();
    
        // Act
        for (int i = 0; i < 100; i++)
        {
            results.Add(RandomHelper.GetRandom(maxValue));
        }
    
        // Assert
        results.ShouldAllBe(x => x >= 0 && x < maxValue);
        results.Distinct().Count().ShouldBeGreaterThan(1); // Values should vary
    }


    [Fact]
    public void GetRandom_WithMinAndMaxValue_ReturnsValueInRange()
    {
        // Arrange
        int minValue = 10;
        int maxValue = 20;
        var results = new List<int>();
    
        // Act
        for (int i = 0; i < 100; i++)
        {
            results.Add(RandomHelper.GetRandom(minValue, maxValue));
        }
    
        // Assert
        results.ShouldAllBe(x => x >= minValue && x < maxValue);
        results.Distinct().Count().ShouldBeGreaterThan(1); // Values should vary
    }

}
