using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMonkey.Model
{
    [Table("Player")]
    public class Player
    {
        [PrimaryKey,AutoIncrement,Column("_id")]
        public int Id { get; set; }
        [Unique,MaxLength(250)]
        public string PlayerName { get; set; }
        public long Score { get; set; }
    }
}
