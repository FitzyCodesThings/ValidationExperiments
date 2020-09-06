using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValidationExperiments.Core.Entities;

namespace ValidationExperiments.Core.Interfaces
{
    public partial interface IAppDbContext
    {
        public Task<Author> CreateAuthorAsync(Author author);
        public Task<Author> SelectAuthorByIdAsync(int id);
        public Task<List<Author>> SelectAuthorsAsync();
        public Task<Author> UpdateAuthorAsync(Author author);
        public Task<Author> DeleteAuthorAsync(Author author);
    }
}
