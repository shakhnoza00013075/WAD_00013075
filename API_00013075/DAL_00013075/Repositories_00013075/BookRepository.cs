using DAL_00013075.Models_00013075;
using Microsoft.EntityFrameworkCore;

namespace DAL_00013075.Repositories_00013075
{
    public class BookRepository : IRepository<Book>
    {
        private readonly BookDbContext context;

        public BookRepository(BookDbContext context)
        {
            this.context = context;
        }

        public async Task Create(Book entity)
        {
            if(entity.Author != null)
            {
                var author = (await context.Authors.FirstAsync(a => a.Id == entity.Author.Id));
                entity.Author = author;
            }
            context.Books.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var book = await context.Books.FirstAsync(b => b.Id == id);
            context.Books.Remove(book);

            await context.SaveChangesAsync();
        }

        public async Task Edit(int id, Book entity)
        {
            if (entity.Author != null)
            {
                var author = (await context.Authors.FirstAsync(a => a.Id == entity.Author.Id));
                entity.Author = author;
            }

            var book = (await Get(id))!;
            book.Title = entity.Title;
            book.Author = entity.Author;
            book.Description = entity.Description;
            book.Price = entity.Price;
            book.PublishedDate = entity.PublishedDate;
            book.Publisher = entity.Publisher;

            await context.SaveChangesAsync();
        }

        public async Task<Book?> Get(int id)
        {
            return await context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<ICollection<Book>> GetAll()
        {
            return await context.Books.Include(b => b.Author).ToListAsync();
        }
    }
}
