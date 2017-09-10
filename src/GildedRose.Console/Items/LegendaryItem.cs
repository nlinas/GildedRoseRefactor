namespace GildedRose.Console
{
    public class LegendaryItem : RetailItem
    {
        public LegendaryItem(Item item) : base(item)
        {
        }

        protected override void UpdateItemSellInValue()
        {
            //Do Not Update Sell In Value
        }

        protected override void UpdateExpiredItemQuality()
        {
            //Do Not Update Quality Value
        }

        protected override void UpdateItemQuality()
        {
            //Do Not Update Quality Value
        }
    }
}