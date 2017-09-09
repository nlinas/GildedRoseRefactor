using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        private const int maxQuality = 50;
        public IList<Item> Items;

        private static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }
            };

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (ItemIncreasesQualityWithAge(item) || item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality < maxQuality)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < maxQuality)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < maxQuality)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (item.Quality > 0)
                    {
                        if (ItemNotSoldNQualityNotDecreased(item))
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }

                if (ItemNotSoldNQualityNotDecreased(item))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn >= 0)
                {
                    continue;
                }

                if (ItemIncreasesQualityWithAge(item))
                {
                    if (item.Quality < maxQuality)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
                else
                {
                    if (ItemIncreasesValueSellInApproaches(item))
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                    else
                    {
                        if (item.Quality > 0)
                        {
                            if (ItemNotSoldNQualityNotDecreased(item))
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                }
            }
        }

        private static bool ItemIncreasesValueSellInApproaches(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool ItemNotSoldNQualityNotDecreased(Item item)
        {
            return item.Name != "Sulfuras, Hand of Ragnaros";
        }

        private static bool ItemIncreasesQualityWithAge(Item item)
        {
            return item.Name == "Aged Brie";
        }
    }
}