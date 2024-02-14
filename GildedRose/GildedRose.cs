using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRose;

public class GildedRose
{
    private readonly IList<Item> _items;

    private const int MaxQuality = 50;
    private const int MinQuality = 0;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros") continue;

            if (item.Name == "Aged Brie")
            {
                IncreaseQuality(item);
                DecreaseSellIn(item);

                if (item.SellIn < 0) IncreaseQuality(item);

                continue;
            }

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                DecreaseSellIn(item);
                
                IncreaseQuality(item);

                if (item.SellIn < 10)
                {
                    IncreaseQuality(item);
                }

                if (item.SellIn < 5)
                {
                    IncreaseQuality(item);
                }

                if (item.SellIn < 0) item.Quality = 0;

                continue;
            }
            
            DecreaseQuality(item);
            DecreaseSellIn(item);

            if (item.SellIn < 0) DecreaseQuality(item);
        }
    }

    private static void DecreaseSellIn(Item item)
    {
        item.SellIn -= 1;
    }

    private static void DecreaseQuality(Item item)
    {
        if (item.Quality > MinQuality) item.Quality -= 1;
    }

    private static void IncreaseQuality(Item item, int value = 1)
    {
        if (item.Quality < MaxQuality) item.Quality += value;
    }
}