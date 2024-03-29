﻿using System.Collections.Generic;
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

            DecreaseSellIn(item);

            if (item.Name == "Aged Brie")
            {
                IncreaseQuality(item);

                if (ItemIsPastSellByDate(item)) IncreaseQuality(item);

                continue;
            }

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                IncreaseQuality(item);

                if (item.SellIn < 10)
                {
                    IncreaseQuality(item);
                }

                if (item.SellIn < 5)
                {
                    IncreaseQuality(item);
                }

                if (ItemIsPastSellByDate(item)) item.Quality = MinQuality;

                continue;
            }
            
            DecreaseQuality(item);

            if (item.Name == "Conjured Mana Cake") DecreaseQuality(item);

            if (ItemIsPastSellByDate(item)) DecreaseQuality(item);
        }
    }

    private static bool ItemIsPastSellByDate(Item item)
    {
        return item.SellIn < 0;
    }

    private static void DecreaseSellIn(Item item)
    {
        item.SellIn -= 1;
    }

    private static void DecreaseQuality(Item item)
    {
        if (item.Quality > MinQuality) item.Quality -= 1;
    }

    private static void IncreaseQuality(Item item)
    {
        if (item.Quality < MaxQuality) item.Quality += 1;
    }
}