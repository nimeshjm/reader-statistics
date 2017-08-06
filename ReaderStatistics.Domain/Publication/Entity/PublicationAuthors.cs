using System.Collections.Generic;

namespace ReaderStatistics.Domain.Publication.Entity
{
    public class PublicationAuthors
    {
        public Publication Publication { get; set; }

        public int NumberOfViews { get; set; }

        public IEnumerable<Author> Authors { get; set; }
    }
}