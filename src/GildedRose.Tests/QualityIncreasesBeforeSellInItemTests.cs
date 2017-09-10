using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class QualityIncreasesBeforeSellInItemTests : CommonBehavior
    {
        [Fact]
        public void ValueIncreasesBeforeSellInItemShouldIncreaseInQualityBeyondTheMaxAtMaxSellInValue()
        {
            var item = Samples.QualityIncreasesBeforeSellInItem;
            item.Quality = RetailItem.MaxQuality;
            SetUp(item);
            Assert.Equal(RetailItem.MaxQuality, _item.Quality);
        }

        [Fact]
        public void ValueIncreasesBeforeSellInItemShouldIncreaseInQualityBeyondTheMax()
        {
            var item = Samples.QualityIncreasesBeforeSellInItem;
            item.Quality = RetailItem.MaxQuality - 1;
            SetUp(item);
            Assert.Equal(RetailItem.MaxQuality, _item.Quality);
        }

        [Fact]
        public void ValueIncreasesBeforeSellInItemShouldIncreaseInQuality()
        {
            var item = Samples.QualityIncreasesBeforeSellInItem;
            item.SellIn = 11;
            SetUp(item);
            Assert.Equal(2, _item.Quality);
        }

        [Fact]
        public void ValueIncreasesBeforeSellInItemShouldIncreaseDoubleInQualityWhenSellInIsLessThan11()
        {
            var item = Samples.QualityIncreasesBeforeSellInItem;
            item.SellIn = 6;
            SetUp(item);
            Assert.Equal(3, _item.Quality);
        }

        [Fact]
        public void ValueIncreasesBeforeSellInItemShouldIncreaseTripleInQualityWhenSellInIsLessThan6()
        {
            var item = Samples.QualityIncreasesBeforeSellInItem;
            item.SellIn = 2;
            SetUp(item);
            Assert.Equal(4, _item.Quality);
        }

        [Fact]
        public void ValueIncreasesBeforeSellInItemDecreaseSellInValue()
        {
            SetUp(Samples.QualityIncreasesBeforeSellInItem);
            Assert.Equal(0, _item.SellIn);
        }

        [Fact]
        public void ValueIncreasesBeforeSellInItemShouldHaveQuality0ThenSellInIsLessThan0()
        {
            var item = Samples.QualityIncreasesBeforeSellInItem;
            item.SellIn = -1;
            item.Quality = 5;
            SetUp(item);
            Assert.Equal(0, _item.Quality);
        }
    }
}