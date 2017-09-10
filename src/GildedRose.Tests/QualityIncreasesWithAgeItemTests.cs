using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class QualityIncreasesWithAgeItemTests : CommonBehavior
    {
        [Fact]
        public void QualityIncreasesWithAgeItemShouldIncreaseInQuality()
        {
            SetUp(Samples.QualityIncreasesWithAgeItem);
            Assert.Equal(2, _item.Quality);
        }

        [Fact]
        public void QualityIncreasesWithAgeItemShouldIncreaseInQualityBeyondTheMaxAtMaxSellInValue()
        {
            var item = Samples.QualityIncreasesWithAgeItem;
            item.Quality = RetailItem.MaxQuality;
            SetUp(item);
            Assert.Equal(RetailItem.MaxQuality, _item.Quality);
        }

        [Fact]
        public void QualityIncreasesWithAgeItemShouldIncreaseInQualityBeyondTheMax()
        {
            var item = Samples.QualityIncreasesWithAgeItem;
            item.Quality = RetailItem.MaxQuality - 1;
            SetUp(item);
            Assert.Equal(RetailItem.MaxQuality, _item.Quality);
        }

        [Fact]
        public void QualityIncreasesWithAgeItemDecreaseSellInValue()
        {
            SetUp(Samples.QualityIncreasesWithAgeItem);
            Assert.Equal(0, _item.SellIn);
        }

        [Fact]
        public void QualityIncreasesWithAgeItemShouldNotIncreaseInQualityBeyondTheMaxWhenSellInIsLess0AndQualityMax()
        {
            var item = Samples.QualityIncreasesWithAgeItem;
            item.SellIn = -1;
            item.Quality = RetailItem.MaxQuality;
            SetUp(item);
            Assert.Equal(RetailItem.MaxQuality, _item.Quality);
        }

        [Fact]
        public void QualityIncreasesWithAgeItemShouldNotIncreaseInQualityBeyondTheMaxWhenSellInIsLess0()
        {
            var item = Samples.QualityIncreasesWithAgeItem;
            item.SellIn = -1;
            item.Quality = RetailItem.MaxQuality - 1;
            SetUp(item);
            Assert.Equal(RetailItem.MaxQuality, _item.Quality);
        }

        [Fact]
        public void QualityIncreasesWithAgeItemShouldIncreaseInQualityWhenSellInIsLess0()
        {
            var item = Samples.QualityIncreasesWithAgeItem;
            item.SellIn = -1;
            SetUp(item);
            Assert.Equal(3, _item.Quality);
        }
    }
}