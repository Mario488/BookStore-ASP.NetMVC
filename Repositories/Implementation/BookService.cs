using BookeStore_application.Models.Domain;
using BookeStore_application.Repositories.Abstract;

namespace BookeStore_application.Repositories.Implementation
{
    public class BookService : IBookService
    {
        private readonly DbContext1 context;
        public BookService(DbContext1 context)
        {
            this.context = context;
        }
        public bool Add(Book model)
        {
            try
            {
                context.Book.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = FindById(id);
                if (data == null) return false;
                context.Book.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Book FindById(int id)
        {
            return context.Book.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            var data = (from book in context.Book
                        join author in context.Author on book.AuthorId equals author.Id
                        join publisher in context.Publisher on book.PublisherId equals publisher.Id
                        join genre in context.Genre on book.GenreId equals genre.Id
                        select new Book { Id = book.Id, AuthorId = book.AuthorId, GenreId = book.GenreId, ISBN = book.ISBN, PublisherId = book.PublisherId, Title = book.Title, TotalPages = book.TotalPages, GenreName = genre.Name, AuthorName = author.AuthorName, PublisherName = publisher.PublisherName }).ToList();
            return data;
        }

        public bool Update(Book model)
        {
            try
            {
                context.Book.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
