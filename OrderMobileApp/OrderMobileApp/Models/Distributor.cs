using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderMobileApp.Models
{
    public class Distributor
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public int DistributorId { get; set; }
    }
}
