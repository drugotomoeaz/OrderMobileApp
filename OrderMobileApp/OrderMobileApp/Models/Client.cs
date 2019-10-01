using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderMobileApp.Models
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        //public string ClientId { get; set; }
        public int Bulstat { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Town { get; set; }
        public string PhoneNumber { get; set; }
    }
}
