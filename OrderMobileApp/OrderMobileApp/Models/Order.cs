using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace OrderMobileApp.Models
{
    public class Order
    {
        [AutoIncrement,PrimaryKey]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int ItemId { get; set; }
        public int DistributorId { get; set; }
        public DateTime Date { get; set; }
    }
}
