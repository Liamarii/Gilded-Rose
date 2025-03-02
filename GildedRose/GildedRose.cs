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
                IncreaseTheQualityIfLessThanFifty(item);
                
                if (item.SellIn-- < 1)
                {
                    IncreaseTheQualityIfLessThanFifty(item);
                }
            }


            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {

                    IncreaseTheQualityIfLessThanFifty(item);

                    if (item.SellIn < 11)
                    {
                        IncreaseTheQualityIfLessThanFifty(item);
                    }
                    if (item.SellIn < 6)
                    {
                        IncreaseTheQualityIfLessThanFifty(item);
                    }
                    
                 
                    item.SellIn--;
                
                if (item.SellIn < 0)
                {
                    item.Quality = item.Quality - item.Quality;
                }
            }
            
            else if (item.Name == "Sulfuras, Hand of Ragnaros")
            {

            }

            else
            {
                LowerItemQualityWhenGreaterThanZero(item);


                item.SellIn--;



                LowerItemQualityWhenSellInLessThanZero(item);
            }
            
        }
    }





    void IncreaseTheQualityIfLessThanFifty(Item item)
    {
        if (item.Quality < 50)
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