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
                item.IncreaseTheQualityIfConditionMet(x => item.Quality < 50);
                item.IncreaseTheQualityIfConditionMet(x => item.SellIn < 1 && item.Quality < 50);
                item.DecreaseSellInValue();
            }

            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {

                item.IncreaseTheQualityIfConditionMet(x => item.Quality < 50);
                item.IncreaseTheQualityIfConditionMet(x => item.SellIn < 11 && item.Quality < 50);
                item.IncreaseTheQualityIfConditionMet(x => item.SellIn < 6 && item.Quality < 50);
                item.DecreaseQualityIfConditionsMet(x => --item.SellIn < 0);                
            }

            else if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.LowerItemQualityIfConditionMet(x => item.Quality > 0);
                item.DecreaseSellInValue();
                item.LowerItemQualityIfConditionMet(x => item.Quality > 0 && item.SellIn < 0);
            }
            
            else
            {

            } 
        }
    }
}

public static class HelperMethods
{

    public static void DecreaseSellInValue(this Item item) => item.SellIn--;

    public static void IncreaseTheQualityIfConditionMet(this Item item, Func<Item, bool> conditionMet)
    {
        if (!conditionMet(item))
        {
            return;
        }
        item.Quality++;
    }

    public static void LowerItemQualityIfConditionMet(this Item item, Func<Item, bool> conditionMet)
    {
        if (!conditionMet(item))
        {
            return;
        }
        item.Quality--;
    }

    public static void DecreaseQualityIfConditionsMet(this Item item, Func<Item, bool> conditionMet)
    {
        if (!conditionMet(item))
        {
            return;
        }
        item.Quality = 0;
    }
}