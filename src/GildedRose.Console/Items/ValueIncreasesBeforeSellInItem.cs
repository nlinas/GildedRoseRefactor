namespace GildedRose.Console
{
    public class ValueIncreasesBeforeSellInItem : ValueIncreasesItem
    {
        public ValueIncreasesBeforeSellInItem(Item item) : base(item)
        {
        }

        protected override void UpdateItemQuality()
        {
            base.UpdateItemQuality();

            if (SellIn < 11)
            {
                if (Quality < MaxQuality)
                {
                    Quality++;
                }
            }

            if (SellIn < 6)
            {
                if (Quality < MaxQuality)
                {
                    Quality++;
                }
            }
        }

        protected override void UpdateExpiredItemQuality()
        {
            Quality = 0;
        }
    }
}