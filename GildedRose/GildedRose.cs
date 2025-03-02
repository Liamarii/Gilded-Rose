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


    public interface IStrategy
    {
        public void Process(Item item);
    }

    public class AgedStrategy : IStrategy
    {
        public void Process(Item item)
        {
            item.IncreaseTheQualityIfConditionMet(item.Quality < 50);
            item.IncreaseTheQualityIfConditionMet(item.SellIn < 1 && item.Quality < 50);
            item.SellIn--;
        }
    }

    public class BackStageStrategy : IStrategy
    {
        public void Process(Item item)
        {
            item.IncreaseTheQualityIfConditionMet(item.Quality < 50);
            item.IncreaseTheQualityIfConditionMet(item.SellIn < 11 && item.Quality < 50);
            item.IncreaseTheQualityIfConditionMet(item.SellIn < 6 && item.Quality < 50);
            item.DecreaseQualityIfConditionsMet(--item.SellIn < 0);
        }
    }

    public class DefaultStrategy : IStrategy
    {
        public void Process(Item item)
        {
            item.LowerItemQualityIfConditionMet(item.Quality > 0);
            item.SellIn--;
            item.LowerItemQualityIfConditionMet(item.Quality > 0 && item.SellIn < 0);
        }
    }

    public class SulfurasStrategy : IStrategy
    {
        public void Process(Item item)
        {
        }
    }

    public Dictionary<string, IStrategy> Strategies = new()
    {
        { "Aged Brie", new AgedStrategy() },
        { "Backstage passes to a TAFKAL80ETC concert", new BackStageStrategy() },
        { "Default", new DefaultStrategy() },
        { "Sulfuras, Hand of Ragnaros", new SulfurasStrategy()}
    };



    public void UpdateQuality()
    {
        foreach (Item item in Items)
        {
            IStrategy chosenStrategy = Strategies.TryGetValue(item.Name, out IStrategy strategy) ? (strategy) : Strategies["Default"];
            chosenStrategy.Process(item);
        }
    }
}

public static class HelperMethods
{
    public static void IncreaseTheQualityIfConditionMet(this Item item, bool conditionMet)
    {
        if (!conditionMet)
        {
            return;
        }
        item.Quality++;
    }

    public static void LowerItemQualityIfConditionMet(this Item item, bool conditionMet)
    {
        if (!conditionMet)
        {
            return;
        }
        item.Quality--;
    }

    public static void DecreaseQualityIfConditionsMet(this Item item, bool conditionMet)
    {
        if (!conditionMet)
        {
            return;
        }
        item.Quality = 0;
    }
}