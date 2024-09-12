using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace chart.Models
{
    public class Posts
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }
        public bool isAvailable { get; set; }
    }
}
