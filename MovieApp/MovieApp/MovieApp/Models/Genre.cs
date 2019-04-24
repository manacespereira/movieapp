using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MovieApp.Models
{
    public class Genre
    {
        // PrimaryKey is used because the SQLite needs
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
