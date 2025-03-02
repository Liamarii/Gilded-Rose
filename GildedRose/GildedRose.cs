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
        public virtual void Process(Item item)
        {
        }
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
            item.ZeroQualityIfConditionMet(--item.SellIn < 0);
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

    public class EmptyStrategy : IStrategy
    {
    }

    public Dictionary<string, IStrategy> Strategies = new()
    {
        { "Aged Brie", new AgedStrategy() },
        { "Backstage passes to a TAFKAL80ETC concert", new BackStageStrategy() },
        { "Default", new DefaultStrategy() },
        { "Sulfuras, Hand of Ragnaros", new EmptyStrategy()}
    };

    public void UpdateQuality()
    {
        foreach (Item item in Items)
        {
            IStrategy chosenStrategy = Strategies.TryGetValue(item.Name, out IStrategy strategy) ? strategy : Strategies["Default"];
            chosenStrategy.Process(item);
        }
    }
}

public static class QualityMethods
{
    public static void IncreaseTheQualityIfConditionMet(this Item item, bool conditionMet) => item.Quality += conditionMet ? 1 : 0;

    public static void LowerItemQualityIfConditionMet(this Item item, bool conditionMet) => item.Quality -= conditionMet ? 1 : 0;

    public static void ZeroQualityIfConditionMet(this Item item, bool conditionMet) => item.Quality = conditionMet ? 0 : item.Quality;
}