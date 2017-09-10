namespace GildedRose.Console
{
    public class ValueIncreasesItem : RetailItem
    {
        public ValueIncreasesItem(Item item) : base(item)
        {
        }

        protected override void UpdateItemQuality()
        {
            if (Quality < MaxQuality)
            {
                Quality++;
            }
        }

        protected override void UpdateExpiredItemQuality()
        {
            if (Quality < MaxQuality)
            {
                Quality++;
            }
        }
    }
}