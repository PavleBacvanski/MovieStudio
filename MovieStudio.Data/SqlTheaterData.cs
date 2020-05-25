using System.Collections.Generic;
using MovieStudio.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieStudio.Data
{
    public class SqlTheaterData : ITheaterData
    {
        private readonly MovieStudioDBContext db;

        public SqlTheaterData(MovieStudioDBContext db)
        {
            this.db = db;
        }

        public Theaters Add(Theaters newTheater)
        {
            db.Add(newTheater);
            return newTheater;
        }

        public int Commint()
        {
            return db.SaveChanges();
        }

        public Theaters Delete(int id)
        {
            var theater = GetById(id);
            if (theater != null)
                db.Theaters.Remove(theater);

            return theater;
        }

        public Theaters GetById(int id)
        {
            return db.Theaters.Find(id);
        }

        public IEnumerable<Theaters> GetTheaterByName(string name)
        {
            var query = from t in db.Theaters
                        where t.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby t.Name
                        select t;

            return query;
        }

        public Theaters Update(Theaters updatedTheater)
        {
            var entity = db.Theaters.Attach(updatedTheater);
            entity.State = EntityState.Modified;
            return updatedTheater;
        }
    }
}
