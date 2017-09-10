namespace GildedRose.Console
{
    public static class RetailItemFactory
    {
        public static RetailItem Create(Item item)
        {
            if (ItemQualityIncreasesWithAge(item))
            {
                return new ValueIncreasesItem(item);
            }

            if (ItemQualityIncreasesBeforeSellIn(item))
            {
                return new ValueIncreasesBeforeSellInItem(item);
            }

            if (ItemConjured(item))
            {
                return new ConjuredItem(item);
            }

            if (ItemDegradesQuality(item))
            {
                return new RetailItem(item);
            }

            return new LegendaryItem(item);
        }

        private static bool ItemDegradesQuality(Item item)
        {
            return item.Name != "Sulfuras, Hand of Ragnaros";
        }

        private static bool ItemQualityIncreasesBeforeSellIn(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool ItemQualityIncreasesWithAge(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private static bool ItemConjured(Item item)
        {
            return item.Name == "Conjured Mana Cake";
        }
    }
}