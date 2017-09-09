using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.InteropServices;
using GildedRose.Console;
using Xunit;


namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        private Program _program;
        private Item _item;

        public void SetUp(Item item)
        {
            _item = item;
            _program = new Program {Items = new List<Item> {_item}};
            _program.UpdateQuality();
        }

        [Fact]
        public void SimpleItemShouldDegradeInQuality()
        {
            SetUp(Samples.SimpleItem);
            Assert.Equal( 0, _item.Quality );
        }

        [Fact]
        public void LegendaryItemShouldNotDegradeInQuality()
        {
            SetUp(Samples.LegendaryItem);
            Assert.Equal(1, _item.Quality);
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
        public void LegendaryItemWithQuality0ShouldNotDegradeInQuality()
        {
            var item = Samples.LegendaryItem;
            item.Quality = 0;
            SetUp(item);
            Assert.Equal(0, _item.Quality);
        }

        [Fact]
        public void ValueIncreasesItemShouldIncreaseInQuality()
        {
            SetUp(Samples.ValueIncreasesItem);
            Assert.Equal(2, _item.Quality);
        }

        [Fact]
        public void ValueIncreasesItemShouldIncreaseInQualityBeyondTheMaxAtMaxSellInValue()
        {
            var item = Samples.ValueIncreasesItem;
            item.Quality = Program.MaxQuality;
            SetUp(item);
            Assert.Equal(Program.MaxQuality, _item.Quality);
        }

        [Fact]
        public void ValueIncreasesItemShouldIncreaseInQualityBeyondTheMax()
        {
            var item = Samples.ValueIncreasesItem;
            item.Quality = Program.MaxQuality - 1;
            SetUp(item);
            Assert.Equal(Program.MaxQuality, _item.Quality);
        }

        [Fact]
        public void ValueIncreasesBeforeSellInItemShouldIncreaseInQualityBeyondTheMaxAtMaxSellInValue()
        {
            var item = Samples.ValueIncreasesBeforeSellInItem;
            item.Quality = Program.MaxQuality;
            SetUp(item);
            Assert.Equal(Program.MaxQuality, _item.Quality);
        }

        [Fact]
        public void ValueIncreasesBeforeSellInItemShouldIncreaseInQualityBeyondTheMax()
        {
            var item = Samples.ValueIncreasesBeforeSellInItem;
            item.Quality = Program.MaxQuality - 1;
            SetUp(item);
            Assert.Equal(Program.MaxQuality, _item.Quality);
        }

        [Fact]
        public void ValueIncreasesBeforeSellInItemShouldIncreaseInQuality()
        {
            var item = Samples.ValueIncreasesBeforeSellInItem;
            item.SellIn = 11;
            SetUp(item);
            Assert.Equal(2, _item.Quality);
        }

        [Fact]
        public void ValueIncreasesBeforeSellInItemShouldIncreaseDoubleInQualityWhenSellInIsLessThan11()
        {
            var item = Samples.ValueIncreasesBeforeSellInItem;
            item.SellIn = 6;
            SetUp(item);
            Assert.Equal(3, _item.Quality);
        }

        [Fact]
        public void ValueIncreasesBeforeSellInItemShouldIncreaseTripleInQualityWhenSellInIsLessThan6()
        {
            var item = Samples.ValueIncreasesBeforeSellInItem;
            item.SellIn = 2;
            SetUp(item);
            Assert.Equal(4, _item.Quality);
        }

        [Fact]
        public void LegendaryItemDoNotDecreaseSellInValue()
        {
            SetUp(Samples.LegendaryItem);
            Assert.Equal(1, _item.SellIn);
        }

        [Fact]
        public void SimpleItemDecreaseSellInValue()
        {
            SetUp(Samples.SimpleItem);
            Assert.Equal(0, _item.SellIn);
        }

        [Fact]
        public void ValueIncreasesItemDecreaseSellInValue()
        {
            SetUp(Samples.ValueIncreasesItem);
            Assert.Equal(0, _item.SellIn);
        }

        [Fact]
        public void ValueIncreasesBeforeSellInItemDecreaseSellInValue()
        {
            SetUp(Samples.ValueIncreasesBeforeSellInItem);
            Assert.Equal(0, _item.SellIn);
        }


        //Expired
        [Fact]
        public void ValueIncreasesBeforeSellInItemShouldHaveQuality0ThenSellInIsLessThan0()
        {
            var item = Samples.ValueIncreasesBeforeSellInItem;
            item.SellIn = -1;
            item.Quality = 5;
            SetUp(item);
            Assert.Equal(0, _item.Quality);
        }

        //[Fact]
        //public void LegendaryItemShouldIncreaseQualitySellInIsLessThan0()
        //{
        //    var item = Samples.LegendaryItem;
        //    item.SellIn = -1;
        //    SetUp(item);
        //    Assert.Equal(2, _item.Quality);
        //}

        [Fact]
        public void ValueIncreasesItemShouldNotIncreaseInQualityBeyondTheMaxWhenSellInIsLess0AndQualityMax()
        {
            var item = Samples.ValueIncreasesItem;
            item.SellIn = -1;
            item.Quality = Program.MaxQuality;
            SetUp(item);
            Assert.Equal(Program.MaxQuality, _item.Quality);
        }

        [Fact]
        public void ValueIncreasesItemShouldNotIncreaseInQualityBeyondTheMaxWhenSellInIsLess0()
        {
            var item = Samples.ValueIncreasesItem;
            item.SellIn = -1;
            item.Quality = Program.MaxQuality - 1;
            SetUp(item);
            Assert.Equal(Program.MaxQuality, _item.Quality);
        }

        [Fact]
        public void LegendaryItemShouldNotIncreaseQualitySellInIsLessThan0AntQualityIsMax()
        {
            var item = Samples.LegendaryItem;
            item.SellIn = -1;
            item.Quality = Program.MaxQuality;
            SetUp(item);
            Assert.Equal(Program.MaxQuality, _item.Quality);
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
        public void LegendaryItemShouldNotDegradeQualityWhenSellInValueIsLess0()
        {
            var item = Samples.LegendaryItem;
            item.SellIn = -1;
            SetUp(item);
            Assert.Equal(1, _item.Quality);
        }
    }
}