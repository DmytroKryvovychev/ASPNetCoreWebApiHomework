using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public int PublicationYear { get; set; }

        public string PublisherName { get; set; }
        [NotMapped]
        public int GenreId { get; set; }
        [NotMapped]
        public Genre Genre { get; set; }
    }
}
