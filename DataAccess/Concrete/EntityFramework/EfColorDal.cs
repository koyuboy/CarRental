using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal:IColorDal
    {
        public void Add(Color entity)
        {
            using (RecapDbContext context = new RecapDbContext()) // bu yapı blok bitince oluşturulan objeyi hafızadan siler
            {
                var addedEntity = context.Entry(entity); //referansı yakalar
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (RecapDbContext context = new RecapDbContext()) // bu yapı blok bitince oluşturulan objeyi hafızadan siler
            {
                var deletedEntity = context.Entry(id); //referansı yakalar
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (RecapDbContext context = new RecapDbContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RecapDbContext context = new RecapDbContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList(); //select * from products : filtrelenmiş select
            }
        }

        public void Update(Color entity)
        {
            using (RecapDbContext context = new RecapDbContext()) // bu yapı blok bitince oluşturulan objeyi hafızadan siler
            {
                var updatedEntity = context.Entry(entity); //referansı yakalar
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
