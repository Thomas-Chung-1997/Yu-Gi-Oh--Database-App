using System;
using System.Collections.Generic;
using System.Text;

namespace YuGiOhDatabase
{
    // UNUSED
    // Could be used in the future for saving a specific version of a card.
    public class CardSet
    {
        public string set_name { get; set; }
        public string set_code { get; set; }
        public string set_rarity { get; set; }
        public string set_rarity_code { get; set; }
        public string set_price { get; set; }
    }

    // UNUSED
    // Could be used in the future for displaying an image of a card.
    public class CardImage
    {
        public int id { get; set; }
        public string image_url { get; set; }
        public string image_url_small { get; set; }
    }

    // UNUSED
    public class CardPrice
    {
        public string cardmarket_price { get; set; }
        public string tcgplayer_price { get; set; }
        public string ebay_price { get; set; }
        public string amazon_price { get; set; }
        public string coolstuffinc_price { get; set; }
    }

    // Json structure of a card.
    public class CardModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public string race { get; set; }
        public string archetype { get; set; }
        public List<CardSet> card_sets { get; set; }
        public List<CardImage> card_images { get; set; }
        public List<CardPrice> card_prices { get; set; }
        public int? atk { get; set; }
        public int? def { get; set; }
        public int? level { get; set; }
        public string attribute { get; set; }
    }

    // Json structure of the database api caller.
    public class CardCollection
    {
        public List<CardModel> data { get; set; }
    }

    // Card Model for datagrid to properly add and pull selected row data from datagrid. no functionality will be given to this class.
    public class DataGridCardModel
    {
        public int id { get; set; }
        public int count { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public string race { get; set; }
    }
}
