// ADD THIS DIRECTIVES
using System;
using System.ComponentModel.DataAnnotations;

namespace API_Assignment.Models
{
  
        public class Company
        {
            [Key]
            public string symbol { get; set; }
            public string name { get; set; }
            public string date { get; set; }
            public bool isEnabled { get; set; }
            public string type { get; set; }
            public string iexId { get; set; }
        }

    public class Dividends
    {
        [Key]
        public DateTime Exe_date { get; set; }
        public DateTime Pay_date { get; set; }
        public DateTime Rec_date { get; set; }
        public float Amount { get; set; }
        public string Dividends_type { get; set; }
    }

    public class Previous
    {
        [Key]
        public string symbol { get; set; }
        public DateTime datetime { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }

    }

    public class Market
    {
        [Key]
        public string mic { get; set; }
        public string venue_name { get; set; }
        public double volume { get; set; }
        public double tapeA { get; set; }
        public double tapeB { get; set; }
        public double tapeC { get; set; }
        public double market_percent { get; set; }

    }

}
