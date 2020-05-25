using MovieStudio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieStudio.Data
{
    public interface ITheaterData
    {
        IEnumerable<Theaters> GetTheaterByName(string name);
        Theaters GetById(int id);
        Theaters Update(Theaters updatedTheater);
        Theaters Add(Theaters newTheater);
        Theaters Delete(int id);
        int Commint();
    }

    public class InMemoryTheaterData : ITheaterData
    {
        readonly List<Theaters> theaters;

        public InMemoryTheaterData()
        {
            theaters = new List<Theaters>()
            {
                new Theaters {Id = 1, Name = "Cinemax", Adress = "Vodovodska 25", Performance = PerformanceType.cinema},
                new Theaters {Id = 2, Name = "National Theater", Adress = "Trgovacka 8", Performance = PerformanceType.theater},
                new Theaters {Id = 3, Name = "Movie House", Adress = "Pozeska 5", Performance = PerformanceType.cinema3D},
            };
        }

        public Theaters GetById(int id)
        {
            return theaters.SingleOrDefault(t => t.Id == id);
        }

        public Theaters Add(Theaters newTheater)
        {
            theaters.Add(newTheater);
            newTheater.Id = theaters.Max(t => t.Id) + 1;
            return newTheater;
        }

        public Theaters Update(Theaters updatedTheater)
        {
            var theater = theaters.SingleOrDefault(t => t.Id == updatedTheater.Id);
            if(theater != null)
            {
                theater.Name = updatedTheater.Name;
                theater.Adress = updatedTheater.Adress;
                theater.Performance = updatedTheater.Performance;
            }
            return theater;
        }

        public int Commint()
        {
            return 0;
        }

        public IEnumerable<Theaters> GetTheaterByName(string name = null) 
        {
            return from t in theaters
                   where string.IsNullOrEmpty(name) || t.Name.StartsWith(name)
                   orderby t.Name
                   select t;
        }

        public Theaters Delete(int id)
        {
            var theater = theaters.FirstOrDefault(t => t.Id == id);
            if (theater != null)
                theaters.Remove(theater);
            return theater;
        }
    }
}
