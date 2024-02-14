using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void Foo()
    {
        var items = new List<Item> {new Item( "foo",  0, 0)};
        var app = new GildedRose.GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Name, Is.EqualTo("foo"));
    }

    private Item SetupInventoryAndUpdateItemQuality(string itemName, int startingSellIn, int startingQuality)
    {
        var item = new Item(itemName, startingSellIn, startingQuality);
        var inventory = new GildedRose.GildedRose(new List<Item> { item });

        inventory.UpdateQuality();

        return item;
    }

    [Test]
    public void quality_and_sell_in_of_a_normal_item_decrease_when_a_day_passes()
    {
        var updatedItem = SetupInventoryAndUpdateItemQuality("random item", 1, 1);

        Assert.That(updatedItem.SellIn, Is.EqualTo(0));
        Assert.That(updatedItem.Quality, Is.EqualTo(0));
    }

    [Test]
    public void quality_decreases_twice_as_fast_once_sell_by_date_has_passed()
    {
        var updatedItem = SetupInventoryAndUpdateItemQuality("another random item", 0, 2);
        
        Assert.That(updatedItem.SellIn, Is.EqualTo(-1));
        Assert.That(updatedItem.Quality, Is.EqualTo(0));
    }

    [TestCase("Aged Brie")]
    [TestCase("Backstage passes to a TAFKAL80ETC concert")]
    public void quality_of_aged_brie_and_backstage_passes_can_never_be_over_50(string itemName)
    {
        var updatedItem = SetupInventoryAndUpdateItemQuality(itemName, 4, 50);
        
        Assert.That(updatedItem.SellIn, Is.EqualTo(3));
        Assert.That(updatedItem.Quality, Is.EqualTo(50));
    }

    [Test]
    public void quality_can_never_be_negative()
    {
        var updatedItem = SetupInventoryAndUpdateItemQuality("quality 0, danger incoming!", 1, 0);
        
        Assert.That(updatedItem.SellIn, Is.EqualTo(0));
        Assert.That(updatedItem.Quality, Is.EqualTo(0));
    }

    [Test]
    public void aged_brie_increases_in_quality_as_it_gets_older()
    {
        var updatedItem = SetupInventoryAndUpdateItemQuality("Aged Brie", 1, 0);
        
        Assert.That(updatedItem.SellIn, Is.EqualTo(0));
        Assert.That(updatedItem.Quality, Is.EqualTo(1));
    }

    [Test]
    public void sulfuras_never_decreases_sell_in_or_quality()
    {
        var updatedItem = SetupInventoryAndUpdateItemQuality("Sulfuras, Hand of Ragnaros", 1, 1);
        
        Assert.That(updatedItem.SellIn, Is.EqualTo(1));
        Assert.That(updatedItem.Quality, Is.EqualTo(1));
    }

    [TestCase(15, 1, 14, 2)]
    [TestCase(10, 1, 9, 3)]
    [TestCase(5, 1, 4, 4)]
    [TestCase(0, 49, -1, 0)]
    public void backstage_passes_quality_varies_as_days_pass_based_on_sell_in_value
        (int startingSellIn, int startingQuality, int expectedUpdatedSellIn, int expectedUpdatedQuality)
    {
        var updatedItem = SetupInventoryAndUpdateItemQuality("Backstage passes to a TAFKAL80ETC concert", startingSellIn, startingQuality);
        
        Assert.That(updatedItem.SellIn, Is.EqualTo(expectedUpdatedSellIn));
        Assert.That(updatedItem.Quality, Is.EqualTo(expectedUpdatedQuality));
    }

    [Test]
    public void conjured_items_decrease_twice_as_fast_in_quality()
    {
        var updatedItem = SetupInventoryAndUpdateItemQuality("Conjured Mana Cake", 3, 6);

        Assert.That(updatedItem.SellIn, Is.EqualTo(2));
        Assert.That(updatedItem.Quality, Is.EqualTo(4));
    }
}