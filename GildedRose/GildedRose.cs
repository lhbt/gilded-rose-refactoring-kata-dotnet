using System;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRose;


public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros") continue;

            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality > 0)
                {
                    DecreaseQuality(item);
                }
            }
            else
            {
                IncreaseQuality(item);

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 11)
                    {
                        IncreaseQuality(item);
                     
                    }

                    if (item.SellIn < 6)
                    {
                        IncreaseQuality(item);
                    }
                }
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                DecreaseQuality(item);
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    IncreaseQuality(item);
                }
            }
        }
    }

    private static void DecreaseQuality(Item item)
    {
        item.Quality -= 1;
    }

    private static void IncreaseQuality(Item item)
    {
        if (item.Quality < 50) item.Quality += 1;
    }
}