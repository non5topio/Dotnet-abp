using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;
using Volo.Abp;
using Xunit;
using Shouldly;

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
/*
FAILED TEST: The test run failed due to a **missing Shouldly extension method** `ShouldContainAll` referenced in `RandomHelper_Tests.cs` at line 41. This is likely due to a missing or incorrect using directive or a missing reference to the Shouldly library.

**Recommended Fix:**
- Ensure the `using Shouldly;` directive is present at the top of the file.
- Confirm that the Shouldly NuGet package is installed and referenced in the project.

    [Fact]
    public void GenerateRandomizedList_WithMultipleItems_ReturnsRandomizedListWithAllItems()
    {
        // Arrange
        IEnumerable<string> items = new List<string> { "A", "B", "C", "D" };
        var originalList = items.ToList();
    
        // Act
        List<string> result = RandomHelper.GenerateRandomizedList(items);
    
        // Assert
        result.ShouldNotBeNull();
        result.Count.ShouldBe(originalList.Count);
        result.ShouldContainAll(originalList);
    }

*/
/*
FAILED TEST: **Analysis:**

The test `GetRandomOf_WithNullArray_ThrowsArgumentNullException` is failing because the `RandomHelper.GetRandomOf<T>(T[] objs)` method throws a `System.ArgumentException` with the message *"objs can not be null or empty!"* instead of the expected `System.ArgumentNullException`.

This discrepancy is due to the usage of the `Check.NotNullOrEmpty` method in `RandomHelper.GetRandomOf`, which throws `ArgumentException` for null or empty arrays, not `ArgumentNullException`.

**Recommended Fix:**

Update the test to expect `ArgumentException` instead of `ArgumentNullException`:

```csharp
[Fact]
public void GetRandomOf_WithNullArray_ThrowsArgumentException()
{
    // Arrange
    string[] items = null;

    // Act & Assert
    Should.Throw<ArgumentException>(() => RandomHelper.GetRandomOf(items));
}
```

    [Fact]
    public void GetRandomOf_WithNullArray_ThrowsArgumentNullException()
    {
        // Arrange
        string[] items = null;
    
        // Act & Assert
        Should.Throw<ArgumentNullException>(() => RandomHelper.GetRandomOf(items));
    }

*/

    [Fact]
    public void GetRandom_WithMaxValueLessThanMinValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        int minValue = 10;
        int maxValue = 5;
        
        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => RandomHelper.GetRandom(minValue, maxValue));
        Assert.NotNull(exception);
    }


    [Fact]
    public void GetRandomOf_WithSingleItemInArray_ReturnsThatItem()
    {
        // Arrange
        string[] items = { "OnlyItem" };
    
        // Act
        string result = RandomHelper.GetRandomOf(items);
    
        // Assert
        result.ShouldBe("OnlyItem");
    }


    [Fact]
    public void GetRandom_WithMaxValueOfZero_ReturnsZero()
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
        int minValue = 5;
        int maxValue = 5;
    
        // Act
        int result = RandomHelper.GetRandom(minValue, maxValue);
    
        // Assert
        result.ShouldBe(minValue);
    }

}
