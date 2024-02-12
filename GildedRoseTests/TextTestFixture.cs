using System;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public static class TextTestFixture
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        var items = new List<Item>{
            new Item(name: "+5 Dexterity Vest", sellIn: 10, quality: 20),
            new Item(name: "Aged Brie", sellIn: 2, quality: 0),
            new Item(name: "Elixir of the Mongoose", sellIn: 5, quality: 7),
            new Item(name: "Sulfuras, Hand of Ragnaros", sellIn: 0, quality: 80),
            new Item(name: "Sulfuras, Hand of Ragnaros", sellIn: -1, quality: 80),
            new Item(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 15, quality: 20),
            new Item(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 10, quality: 49),
            new Item(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 5, quality: 49),
            // this conjured item does not work properly yet
            new Item(name: "Conjured Mana Cake", sellIn: 3, quality: 6)
        };

        var app = new GildedRose(items);

        int days = 2;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }
    }
}