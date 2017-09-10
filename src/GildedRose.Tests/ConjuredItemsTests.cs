using Xunit;

namespace GildedRose.Tests
{
    public class ConjuredItemsTests : CommonBehavior
    {
        [Fact]
        public void ConjuredItemsDegradeQualityTwiceAsNormalItems()
        {
            var item = Samples.ConjuredItem;
            item.Quality = 10;
            item.SellIn = -1;
            SetUp(item);
            Assert.Equal(6, _item.Quality);
        }

        [Fact]
        public void ConjuredItemsShouldNotDegradeQualityBelowZero()
        {
            var item = Samples.ConjuredItem;
            item.Quality = 1;
            item.SellIn = -1;
            SetUp(item);
            Assert.Equal(0, _item.Quality);
        }

        [Fact]
        public void ConjuredItemsWith0QualityShouldNotDegradeQuality()
        {
            var item = Samples.ConjuredItem;
            item.Quality = 0;
            SetUp(item);
            Assert.Equal(0, _item.Quality);
        }

        //[Fact]
        //public void ConjuredItemsWith0QualityShouldNotDegradeQuality()
        //{
        //    var item = Samples.ConjuredItem;
        //    item.Quality = 2;
        //    SetUp(item);
        //    Assert.Equal(0, _item.Quality);
        //}
    }
}