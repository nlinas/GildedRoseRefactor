using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        public const int MaxQuality = 50;

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = -1, Quality = 20}
                                              //new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              //new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              //new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              //new Item
                                              //    {
                                              //        Name = "Backstage passes to a TAFKAL80ETC concert",
                                              //        SellIn = 15,
                                              //        Quality = 20
                                              //    },
                                              //new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItemQuality(item);

                UpdateItemSellInValue(item);

                if (item.SellIn >= 0)
                {
                    continue;
                }

                UpdateExpiredItemQuality(item);
            }
        }

        public void UpdateItemSellInValue(Item item)
        {
            if (ItemDegradesQuality(item))
            {
                item.SellIn = item.SellIn - 1;
            }
        }

        public void UpdateItemQuality(Item item)
        {
            if (ItemQualityIncreasesWithAge(item) || ItemQualityIncreasesBeforeSellIn(item))
            {
                if (item.Quality < MaxQuality)
                {
                    item.Quality = item.Quality + 1;

                    if (ItemQualityIncreasesBeforeSellIn(item))
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < MaxQuality)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < MaxQuality)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (item.Quality > 0 && ItemDegradesQuality(item))
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }

        public void UpdateExpiredItemQuality(Item item)
        {
            if (ItemQualityIncreasesWithAge(item))
            {
                if (item.Quality < MaxQuality)
                {
                    item.Quality = item.Quality + 1;
                }
            }
            else
            {
                if (ItemQualityIncreasesBeforeSellIn(item))
                {
                    item.Quality = item.Quality - item.Quality;
                }
                else
                {
                    if (item.Quality > 0 && ItemDegradesQuality(item))
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
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
    }
}