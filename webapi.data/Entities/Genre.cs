﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.data.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<Entities.Book> Books { get; set; }
    }
}
