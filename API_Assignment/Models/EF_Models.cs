// ADD THIS DIRECTIVES
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace API_Assignment.Models
{
  
        public class Company
        {
            [Key]
            public string symbol { get; set; }

             [Column(TypeName ="nvarchar(max)")]
            public string name { get; set; }

            [Column(TypeName = "nvarchar(max)")]
            public string date { get; set;  }

            [Column(TypeName = "nvarchar(max)")]
            public string isEnabled { get; set; }

            [Column(TypeName = "nvarchar(max)")]
            public string type { get; set; }

            [Column(TypeName = "nvarchar(max)")]
            public string iexId { get; set; }
        }

    public class Dividends
    {
        [Key]
        public DateTime Exe_date { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public DateTime Pay_date { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public DateTime Rec_date { get; set; }
        [Column(TypeName = "float")]
        public float Amount { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Dividends_type { get; set; }
    }

    public class Previous
    {
        [Key]
        public string symbol { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public DateTime datetime { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public float open { get; set; }
        [Column(TypeName = "float")]
        public float high { get; set; }
        [Column(TypeName = "float")]
        public float low { get; set; }
        [Column(TypeName = "float")]
        public float close { get; set; }

    }

    public class Market
    {
        [Key]
        public string mic { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string venue_name { get; set; }
        [Column(TypeName = "float")]
        public float volume { get; set; }
        [Column(TypeName = "float")]
        public float tapeA { get; set; }
        [Column(TypeName = "float")]
        public float tapeB { get; set; }
        [Column(TypeName = "float")]
        public float tapeC { get; set; }
        [Column(TypeName = "float")]
        public float market_percent { get; set; }

    }

}
