using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;
using Volo.Abp;
using Shouldly;
using Xunit;
using Volo.Abp;
using Xunit;
using Shouldly;

namespace Volo.Abp;

public class RandomHelper_Tests
{
    // Test cases will be generated here by the AI agent

    [Fact]
    public void GenerateRandomizedList_WithDuplicateItems_ReturnsShuffledList()
    {
        // Arrange
        var items = new List<string> { "A", "A", "A" };
    
        // Act
        var result = RandomHelper.GenerateRandomizedList(items);
    
        // Assert
        result.ShouldAllBe(item => item == "A");
        result.ShouldBeEquivalentTo(items);
    }


    [Fact]
    public void GenerateRandomizedList_WithSingleItem_ReturnsSameItem()
    {
        // Arrange
        var items = new List<string> { "SingleItem" };
    
        // Act
        var result = RandomHelper.GenerateRandomizedList(items);
    
        // Assert
        result.ShouldBeEquivalentTo(items);
    }


    [Fact]
    public void GetRandomOfList_WithSingleItem_ReturnsSameItem()
    {
        // Arrange
        var list = new List<string> { "SingleItem" };
    
        // Act
        var result = RandomHelper.GetRandomOfList(list);
    
        // Assert
        result.ShouldBe("SingleItem");
    }


    [Fact]
    public void GetRandomOf_WithNullOrEmptyArray_ThrowsException()
    {
        // Arrange
        string[] emptyArray = Array.Empty<string>();
        string[] nullArray = null;
    
        // Act & Assert
        Should.Throw<Exception>(() => RandomHelper.GetRandomOf(emptyArray));
        Should.Throw<Exception>(() => RandomHelper.GetRandomOf(nullArray));
    }


    [Fact]
    public void GetRandom_WithMaxValueZero_ReturnsZero()
    {
        // Arrange
        int maxValue = 0;
    
        // Act
        int result = RandomHelper.GetRandom(maxValue);
    
        // Assert
        result.ShouldBe(0);
    }


    [Fact]
    public void GetRandom_WithMinValueEqualToMaxValue_ReturnsMinValue()
    {
        // Arrange
        int minValue = 10;
        int maxValue = 10;
    
        // Act
        int result = RandomHelper.GetRandom(minValue, maxValue);
    
        // Assert
        result.ShouldBe(minValue);
    }

}
