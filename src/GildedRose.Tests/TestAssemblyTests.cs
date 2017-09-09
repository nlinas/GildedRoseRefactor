using System.Collections.Generic;
using GildedRose.Console;
using Xunit;


namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void ASimpleItemShoudntDegradeInQuality()
        {
            var item = new Item {Name = "Sample", Quality = 1, SellIn = 1};
            var program = new Program {Items = new List<Item> {item}};
            program.UpdateQuality();
            Assert.Equal( 0, item.Quality );
        }
    }
}