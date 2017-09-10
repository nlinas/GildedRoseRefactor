using Xunit;

namespace GildedRose.Tests
{
    public class SimpleItemsTests : CommonBehavior
    {
        [Fact]
        public void SimpleItemShouldDegradeInQuality()
        {
            SetUp(Samples.SimpleItem);
            Assert.Equal(0, _item.Quality);
        }

        [Fact]
        public void SimpleItemWithQuality0ShouldNotDegradeInQuality()
        {
            var item = Samples.SimpleItem;
            item.Quality = 0;
            SetUp(item);
            Assert.Equal(0, _item.Quality);
        }

        [Fact]
        public void SimpleItemDecreaseSellInValue()
        {
            SetUp(Samples.SimpleItem);
            Assert.Equal(0, _item.SellIn);
        }

        [Fact]
        public void SimpleItemShouldDegradeDoubleQualityWhenSellInValueIsLess0()
        {
            var item = Samples.SimpleItem;
            item.SellIn = -1;
            item.Quality = 5;
            SetUp(item);
            Assert.Equal(3, _item.Quality);
        }

        [Fact]
        public void SimpleItemWithQuality0ShouldNotDegradeInQualityWhenSellInValueIsLess0()
        {
            var item = Samples.SimpleItem;
            item.Quality = 0;
            item.SellIn = -1;
            SetUp(item);
            Assert.Equal(0, _item.Quality);
        }

    }
}