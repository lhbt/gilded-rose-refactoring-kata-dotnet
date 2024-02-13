using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void Foo()
    {
        var items = new List<Item> {new Item(name: "foo", sellIn: 0, quality: 0)};
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Name, Is.EqualTo("foo"));
    }

    [Test]
    public void quality_and_sell_in_of_a_normal_item_decrease_when_a_day_passes()
    {
        var item = new Item("random item", 1, 1);
        var inventory = new GildedRose(new List<Item> { item });

        inventory.UpdateQuality();

        Assert.That(item.SellIn, Is.EqualTo(0));
        Assert.That(item.Quality, Is.EqualTo(0));
    }

    [Test]
    public void quality_decreases_twice_as_fast_once_sell_by_date_has_passed()
    {
        var item = new Item("another random item", 0, 2);
        var inventory = new GildedRose(new List<Item> { item });

        inventory.UpdateQuality();

        Assert.That(item.SellIn, Is.EqualTo(-1));
        Assert.That(item.Quality, Is.EqualTo(0));
    }

    [Test]
    public void quality_can_never_be_negative()
    {
        var item = new Item("quality 0, danger incoming!", 1, 0);
        var inventory = new GildedRose(new List<Item> { item });

        inventory.UpdateQuality();

        Assert.That(item.SellIn, Is.EqualTo(0));
        Assert.That(item.Quality, Is.EqualTo(0));
    }

    [Test]
    public void aged_brie_increases_in_quality_as_it_gets_older()
    {
        var item = new Item("Aged Brie", 1, 0);
        var inventory = new GildedRose(new List<Item> { item });

        inventory.UpdateQuality();

        Assert.That(item.SellIn, Is.EqualTo(0));
        Assert.That(item.Quality, Is.EqualTo(1));
    }

    [Test]
    public void sulfuras_never_decreases_sell_in_or_quality()
    {
        var item = new Item("Sulfuras, Hand of Ragnaros", 1, 1);
        var inventory = new GildedRose(new List<Item> { item });

        inventory.UpdateQuality();

        Assert.That(item.SellIn, Is.EqualTo(1));
        Assert.That(item.Quality, Is.EqualTo(1));
    }

    [Test]
    public void backstage_passes_increase_in_quality_by_1_as_sell_in_value_is_above_10()
    {
        var item = new Item("Backstage passes to a TAFKAL80ETC concert", 15, 1);
        var inventory = new GildedRose(new List<Item> { item });

        inventory.UpdateQuality();

        Assert.That(item.SellIn, Is.EqualTo(14));
        Assert.That(item.Quality, Is.EqualTo(2));
    }

    [Test]
    public void backstage_passes_increase_in_quality_by_2_as_sell_in_value_is_10_or_less()
    {
        var item = new Item("Backstage passes to a TAFKAL80ETC concert", 10, 1);
        var inventory = new GildedRose(new List<Item> { item });

        inventory.UpdateQuality();

        Assert.That(item.SellIn, Is.EqualTo(9));
        Assert.That(item.Quality, Is.EqualTo(3));
    }

    [Test]
    public void backstage_passes_increase_in_quality_by_3_as_sell_in_value_is_5_or_less()
    {
        var item = new Item("Backstage passes to a TAFKAL80ETC concert", 5, 1);
        var inventory = new GildedRose(new List<Item> { item });

        inventory.UpdateQuality();

        Assert.That(item.SellIn, Is.EqualTo(4));
        Assert.That(item.Quality, Is.EqualTo(4));
    }
}