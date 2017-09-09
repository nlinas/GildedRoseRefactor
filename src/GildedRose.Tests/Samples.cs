using GildedRose.Console;

namespace GildedRose.Tests
{
    public static class Samples
    {
        public static Item SimpleItem
        {
            get
            {
                return new Item { Name = "Simple", Quality = 1, SellIn = 1 };
            }
        }

        public static Item LegendaryItem
        {
            get
            {
                return new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 1, SellIn = 1 };
            }
        }

        public static Item ValueIncreasesBeforeSellInItem
        {
            get
            {
                return new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = 1 };
            }
        }

        public static Item ValueIncreasesItem
        {
            get
            {
                return new Item { Name = "Aged Brie", Quality = 1, SellIn = 1 };
            }
        }

    }
}