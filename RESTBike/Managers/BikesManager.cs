using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTBike.Managers
{
    public class BikesManager
    {
        /// <summary>
        /// static declarer at, metoden kun tilhører classen, den kan derfor ikke instansieres
        ///dvs man kan ikke oprette et objekt af en static class
        ///her: listen er static og tilhører kun denne class
        ///readonly indicates that assignment to the field can only occur as part of the
        ///declaration/ or in a constructor in the same class
        /// </summary>
        
        private static int _nextID = 1;
      
        private static readonly List<Bike.Bike> _bikes = new List<Bike.Bike>()
        {
            new Bike.Bike { Id = _nextID++, Name = "Sweet", Brand = "Kildemoes", Price = 3500},
            new Bike.Bike { Id = _nextID++, Name = "Darkness", Brand = "Greenmos", Price = 3500},
            new Bike.Bike { Id = _nextID++, Name = "Lightness", Brand = "Mountain", Price = 3500}
        };

        public List<Bike.Bike> GetAll()
        {
            List<Bike.Bike> result = new List<Bike.Bike>(_bikes);
            return result;
        }

        public Bike.Bike GetByID(int id)
        {
            return _bikes.Find(b=>b.Id==id);
        }
        //Post / Add tilføjer en ny cykel, til listen _bikes
        //assigner et nyt id, der er autogenereret
        public Bike.Bike AddBike(Bike.Bike addbike)
        {
            if (addbike == null)
            {
                return null;
            }
            addbike.Id = _nextID++;
            _bikes.Add(addbike);
            return addbike;
        }

        //Update - redigere en cykels informationer
        public Bike.Bike UpdateBike(int id, Bike.Bike updateBike)
        {
            Bike.Bike bike = _bikes.Find(b => b.Id == id);
            if (bike == null)
            {
                return null;
            }
            //ellers
            bike.Name = updateBike.Name;
            bike.Brand = updateBike.Brand;
            bike.Price = updateBike.Price;
            return bike;
        }

        //Delete sletter en cykel, fra listen _bikes
        //sletter på den tilhørende id
        public Bike.Bike DeleteBike(int id)
        {
            Bike.Bike deleteBike = _bikes.Find(b => b.Id==id);
            if (deleteBike == null)
            {
                return null;
            }
            //ellers
            _bikes.Remove(deleteBike);
            return deleteBike;
        }
    
    }
}
