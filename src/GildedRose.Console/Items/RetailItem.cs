namespace GildedRose.Console
{
    public class RetailItem
    {
        public const int MaxQuality = 50;

        public RetailItem(Item item)
        {
            Item = item;
        }

        private Item Item { get; set; }

        public string Name
        {
            get { return Item.Name; }
            set { Item.Name = value; }
        }

        public int SellIn
        {
            get { return Item.SellIn; }
            set { Item.SellIn = value; }
        }

        public int Quality
        {
            get { return Item.Quality; }
            set { Item.Quality = value; }
        }

        public void Update()
        {
            UpdateItemQuality();

            UpdateItemSellInValue();

            if (SellIn >= 0)
            {
                return;
            }

            UpdateExpiredItemQuality();
        }

        protected virtual void UpdateItemSellInValue()
        {
            SellIn--;
        }

        protected virtual void UpdateItemQuality()
        {
            if (Quality > 0)
            {
                Quality--;
            }
        }

        protected virtual void UpdateExpiredItemQuality()
        {
            if (Quality > 0)
            {
                Quality--;
            }
        }
    }
}