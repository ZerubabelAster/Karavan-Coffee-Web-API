using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.IO;
using System.Linq.Expressions;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace KaravanCoffeeWebAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _db;
<<<<<<< Updated upstream
=======
        //private readonly IWebHostEnvironment _environment;
        private readonly IWebHostEnvironment _hostingEnvironment;
>>>>>>> Stashed changes

        public GenericRepository(DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _db = _context.Set<T>();
            _hostingEnvironment= webHostEnvironment;
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
            if(include != null)
            {
                query = include(query);
            }
            
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            
            if(expression != null)
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

            if(orderBy != null)
            {
                query = orderBy(query);
            }        

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

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public string UploadImage(IFormFile image)
        {

            string fileName = Path.GetFileName(image.FileName);
            string pathAndFileName = GetPathAndFileName(fileName);

            using (FileStream stream = new FileStream(pathAndFileName, FileMode.Create))
            {
                image.CopyToAsync(stream);
                stream.Close();
            }
            return pathAndFileName;
        }

        private string GetPathAndFileName(string fileName)
        {
            string path = _hostingEnvironment.ContentRootPath + Constant.DefaultProductImagePath;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path + Path.GetFileNameWithoutExtension(fileName) 
                + "_" + Guid.NewGuid().ToString().Substring(0, 4) 
                + Path.GetExtension(fileName);
        }
    }
}
