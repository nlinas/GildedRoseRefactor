using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class LegendaryItemTests : CommonBehavior
    {
        [Fact]
        public void LegendaryItemShouldNotDegradeInQuality()
        {
            SetUp(Samples.LegendaryItem);
            Assert.Equal(1, _item.Quality);
        }

        [Fact]
        public void LegendaryItemWithQuality0ShouldNotDegradeInQuality()
        {
            var item = Samples.LegendaryItem;
            item.Quality = 0;
            SetUp(item);
            Assert.Equal(0, _item.Quality);
        }

        [Fact]
        public void LegendaryItemDoNotDecreaseSellInValue()
        {
            SetUp(Samples.LegendaryItem);
            Assert.Equal(1, _item.SellIn);
        }

        [Fact]
        public void LegendaryItemShouldNotIncreaseQualitySellInIsLessThan0AntQualityIsMax()
        {
            var item = Samples.LegendaryItem;
            item.SellIn = -1;
            item.Quality = RetailItem.MaxQuality;
            SetUp(item);
            Assert.Equal(RetailItem.MaxQuality, _item.Quality);
        }

        [Fact]
        public void LegendaryItemShouldNotDegradeQualityWhenSellInValueIsLess0()
        {
            var item = Samples.LegendaryItem;
            item.SellIn = -1;
            SetUp(item);
            Assert.Equal(1, _item.Quality);
        }
    }
}