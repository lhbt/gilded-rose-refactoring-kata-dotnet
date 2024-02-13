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
}