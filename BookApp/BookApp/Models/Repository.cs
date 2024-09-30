namespace BookApp.Models
{
    public class Repository
    {
        private static readonly List<ProductBook> _productBooks = new();
        private static readonly List<Category> _categories = new();

        static Repository()
        {
            _categories.Add(new Category { CategoryId = 1, Name = "Roman" });
            _categories.Add(new Category { CategoryId = 2, Name = "Kişisel Gelişim" });

            _productBooks.Add(new ProductBook { BookId = 1, BookName = "Son Ayı", Description = "Güzel Kitap", PageCount = 375, IsActive = true, Image = "1.png", CategoryId = 1 });
            _productBooks.Add(new ProductBook { BookId = 2, BookName = "Tarık Buğra'nın Roman Dünyası", Description = "Güzel Kitap", PageCount = 540, IsActive = true, Image = "2.png", CategoryId = 1 });
            _productBooks.Add(new ProductBook { BookId = 3, BookName = "Cadı", Description = "Güzel Kitap", PageCount = 235, IsActive = true, Image = "3.png", CategoryId = 1 });
        }

        public static List<ProductBook> Products
        {
            get
            {
                return _productBooks;
            }
        }

        public static void CreateBook(ProductBook entity)
        {
            _productBooks.Add(entity);
        }

        public static void EditBook(ProductBook updateBook)
        {
            var entity = _productBooks.FirstOrDefault(b => b.BookId == updateBook.BookId);
            if (entity != null)
            {
                entity.BookName = updateBook.BookName;
                entity.Description = updateBook.Description;
                entity.PageCount = updateBook.PageCount;
                entity.Image = updateBook.Image;
                entity.CategoryId = updateBook.CategoryId;
                entity.IsActive = updateBook.IsActive;
            }
        }

        public static void DeleteBook(ProductBook deletedBook)
        {
            var entity = _productBooks.FirstOrDefault(b => b.BookId == deletedBook.BookId);
            if (entity != null)
            {
                _productBooks.Remove(entity);
            }
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
    }
}