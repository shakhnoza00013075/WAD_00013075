using DAL_00013075.Models_00013075;
using Microsoft.EntityFrameworkCore;

namespace DAL_00013075.Repositories_00013075
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly BookDbContext context;

        public AuthorRepository(BookDbContext context)
        {
            this.context = context;
        }

        public async Task Create(Author entity)
        {
            await context.Authors.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var author = this.context.Authors.First(a => a.Id == id);
            this.context.Authors.Remove(author);
            await context.SaveChangesAsync();
        }

        public async Task Edit(int id, Author entity)
        {
            var author = (await Get(id))!;
            
            author.FirstName = entity.FirstName;
            author.LastName = entity.LastName;
            author.Birthday = entity.Birthday;

            await context.SaveChangesAsync();
        }

        public async Task<Author?> Get(int id)
        {
            return await context.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<ICollection<Author>> GetAll()
        {
            return await context.Authors.ToListAsync();
        }
    }
}
