using EntityFrameworkDemo.Data;

namespace EntityFrameworkDemo.Models
{
    public class ProductDAL
    {
        private ApplicationDbContext db;
        public ProductDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            var model = db.Products.Where(p => p.Id == id).SingleOrDefault();

            return model;
        }

        public int AddProduct(Product pro)
        {
            int result = 0;
            db.Products.Add(pro);
            result = db.SaveChanges();
            return result;
        }

        public int EditProduct(Product pro)
        {
            int result = 0;
            var model = db.Products.Where(p => p.Id == pro.Id).SingleOrDefault();
            if(model != null)
            {
                model.Name = pro.Name;
                model.Description = pro.Description;
                model.Price = pro.Price;
                model.Stock = pro.Stock;

                result = db.SaveChanges();
            }
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;

            var model = db.Products.Where(p=>p.Id == id).SingleOrDefault();

            if(model != null)
            {
                db.Products.Remove(model);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
