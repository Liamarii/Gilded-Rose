using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (Item item in Items)
        {
            if (item.Name == "Aged Brie")
            {
                IncreaseTheQualityIfLessThan(item, 50);
                IncreaseTheQualityIfSellInLessThan(item, 1);
                DecreaseSellIn(item, x => true);
            }

            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {

                    IncreaseTheQualityIfLessThan(item, 50);
                    IncreaseTheQualityIfSellInLessThan(item, 11);
                    IncreaseTheQualityIfSellInLessThan(item, 6);

                if (--item.SellIn < 0)
                    {
                        item.Quality = 0;
                    }
            }
            
            else if (item.Name == "Sulfuras, Hand of Ragnaros")
            {

            }

            else
            {
                LowerItemQualityWhenGreaterThanZero(item);
                DecreaseSellIn(item, x => true);
                LowerItemQualityWhenSellInLessThanZero(item);
            }
            
        }
    }

    void DecreaseSellIn(Item item, Func<Item, bool> func)
    {
        if (func(item))
        {
            item.SellIn--;
        }
    }

    void IncreaseTheQualityIfSellInLessThan(Item item, int sellInMin)
    {
        if (item.SellIn < sellInMin)
        {
            IncreaseTheQualityIfLessThan(item, 50);
        }
    }

    void IncreaseTheQualityIfLessThan(Item item, int qualityLimit)
    {
        if (item.Quality < qualityLimit)
        {
            item.Quality = item.Quality + 1;
        }
    }

    void LowerItemQualityWhenGreaterThanZero(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality = item.Quality - 1;
        }
    }

    void LowerItemQualityWhenSellInLessThanZero(Item item)
    {
        if (item.SellIn < 0)
        {
            LowerItemQualityWhenGreaterThanZero(item);
        }
    }









}