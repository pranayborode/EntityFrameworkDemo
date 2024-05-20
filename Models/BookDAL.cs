using EntityFrameworkDemo.Data;

namespace EntityFrameworkDemo.Models
{
    public class BookDAL
    {
        private ApplicationDbContext db;
        public BookDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Book> GetBooks()
        {
            return db.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            var model = db.Books.Where(p => p.Id == id).SingleOrDefault();

            return model;
        }

        public int AddBook(Book bk)
        {
            int result = 0;
            db.Books.Add(bk);
            result = db.SaveChanges();
            return result;
        }

        public int EditBook(Book bk)
        {
            int result = 0;
            var model = db.Books.Where(p => p.Id == bk.Id).SingleOrDefault();
            if (model != null)
            {
                model.Name = bk.Name;
                model.Author = bk.Author;
                model.Description = bk.Description;
                model.Price = bk.Price;
                model.Stock = bk.Stock;

                result = db.SaveChanges();
            }
            return result;
        }

        public int DeleteBook(int id)
        {
            int result = 0;

            var model = db.Books.Where(p => p.Id == id).SingleOrDefault();

            if (model != null)
            {
                db.Books.Remove(model);
                result = db.SaveChanges();
            }
            return result;
        }

    }
}
