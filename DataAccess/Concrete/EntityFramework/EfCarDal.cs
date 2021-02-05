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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RecapDbContext context = new RecapDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapDbContext context = new RecapDbContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList(); //select * from products : filtrelenmiş select
            }
        }

        public void Update(Car entity)
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
