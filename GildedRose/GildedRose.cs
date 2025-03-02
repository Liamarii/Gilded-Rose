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

                item.SellIn = item.SellIn - 1;
                
                if (item.SellIn < 0)
                {
                    IncreaseTheQualityIfLessThanFifty(item);
                }
            }


            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality < 50)
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
                }
                item.SellIn = item.SellIn - 1;
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
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 1;
                }
                item.SellIn = item.SellIn - 1;
                if (item.SellIn < 0)
                {                    
                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }     
                }
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

    void 











}