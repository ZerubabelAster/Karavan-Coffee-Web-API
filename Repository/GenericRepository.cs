using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace KaravanCoffeeWebAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _db;
        //private readonly IWebHostEnvironment _environment;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public GenericRepository(DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _db = _context.Set<T>();
            _hostingEnvironment = webHostEnvironment;
        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db;
            if (include != null)
            {
                query = include(query);
            }
            //return _context.Categories.Where(c => c.CategoryId == 1).Include(c => c.subCategories).f;
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        /*public async IList<Category> GetCategoriesWithDetails()
        {
            IQueryable<T> query = _db;
            return await query.AsNoTracking().
        }*/
        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, /*Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,*/ List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            /*if (orderBy != null)
            {
                query = orderBy(query);
            }*/

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }
        public async Task SaveImage(IFormFile image, string path)
        {
            //var upload = Path.Combine(_environment.WebRootPath, path, "posts", imageName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
                stream.Close();
            }
        }
        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public string UploadImage(IFormFile image, string path)
        {
            string fileName = Path.GetFileName(image.FileName);
            string uniqueFileName = UniqueFileName(fileName);
            string pathAndFileName = _hostingEnvironment.WebRootPath + path + uniqueFileName;
            string dir = _hostingEnvironment.WebRootPath + path;
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            using (FileStream stream = new FileStream(pathAndFileName, FileMode.Create))
            {
                image.CopyToAsync(stream);
                stream.Close();
            }

            return uniqueFileName;
        }

        private string UniqueFileName(string fileName)
        {
            return string.Concat(Path.GetFileNameWithoutExtension(fileName)
, "_", Guid.NewGuid().ToString().AsSpan(0, 4)
, Path.GetExtension(fileName));
        }
    }
}
