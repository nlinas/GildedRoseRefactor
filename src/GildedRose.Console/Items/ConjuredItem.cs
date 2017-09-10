using System;

namespace GildedRose.Console
{
    public class ConjuredItem : RetailItem
    {
        public ConjuredItem(Item item) : base(item)
        {
        }

        protected override void UpdateItemQuality()
        {
            if (Quality > 0)
            {
                Quality = Math.Max(Quality - 2, 0);
            }
        }

        protected override void UpdateExpiredItemQuality()
        {
            if (Quality > 0)
            {
                Quality = Math.Max(Quality - 2, 0);
            }
        }
    }
}