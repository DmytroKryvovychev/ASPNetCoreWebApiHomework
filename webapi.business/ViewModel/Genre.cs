using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.business.ViewModel
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<ViewModel.Book> Books { get; set; }
    }
}
