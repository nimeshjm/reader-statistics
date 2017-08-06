using System;
using System.Collections.Generic;
using System.Linq;

namespace ReaderStatistics.Domain.Publication.Entity
{
    public class Publication : Shared.Entity
    {
        public static Publication Null => new Publication { Id = Guid.Empty, Name = string.Empty, AuthorIds = Enumerable.Empty<Guid>() };
        
        public string Name { get; set; }

        public IEnumerable<Guid> AuthorIds { get; set; }
    }
}