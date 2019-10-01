using SQLite;
using System;

namespace OrderMobileApp.Models
{
    //[Table("Item")]
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ItemId { get; set; }
        public int Quantity { get; set; }
        public string Measure { get; set; }
    }
}