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
                IncreaseTheQualityIfConditionMet(item, x => item.Quality < 50);
                IncreaseTheQualityIfConditionMet(item, x => item.SellIn < 1 && item.Quality < 50);
                DecreaseSellInIfConditionMet(item, x => true);
            }

            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {

                IncreaseTheQualityIfConditionMet(item, x => item.Quality < 50);
                IncreaseTheQualityIfConditionMet(item, x => item.SellIn < 11 && item.Quality < 50);
                IncreaseTheQualityIfConditionMet(item, x => item.SellIn < 6 && item.Quality < 50);
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
                LowerItemQualityIfConditionMet(item, x => item.Quality > 0);
                DecreaseSellInIfConditionMet(item, x => true);
                LowerItemQualityIfConditionMet(item, x => item.Quality > 0 && item.SellIn < 0);
            }
            
        }
    }

    void DecreaseSellInIfConditionMet(Item item, Func<Item, bool> func)
    {
        if (!func(item))
        {
            return;
        }
        item.SellIn--;
    }

    void IncreaseTheQualityIfConditionMet(Item item, Func<Item, bool> func)
    {
        if (!func(item))
        {
            return;
        }
        item.Quality++;
    }


    void LowerItemQualityIfConditionMet(Item item, Func<Item, bool> func)
    {
        if (!func(item))
        {
            return;
        }
        item.Quality--;
    }







}