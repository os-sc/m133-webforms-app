using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SpielGutWebInterface.Domain.Entity;
using SpielGutWebInterface.Domain.Interface;

namespace SpielGutWebInterface.Domain.Manager
{
    public class RentalManager : Manager<Rental>
    {
        protected sealed override List<Rental> Data { get; set; }
        protected sealed override XmlDatabase<Rental> Db { get; set; }

        public RentalManager(string dbpath)
        {
            Data = new List<Rental>();
            Db = new XmlDatabase<Rental>(dbpath);
            Data = Db.LoadData();

            if (!IsEmpty()) return;
            InitializeDefaultData();
            Db.SaveData(Data);
        }

        public void Extend(string rid, int weeks)
        {
            var rental = GetById(rid);
            rental.DueReturnDate = rental.DueReturnDate.AddDays(weeks*7);
            Db.SaveData(Data);
        }

        public override Rental GetById(string id)
        {
            return Data.FirstOrDefault(rental => rental.Id == id);
        }

        public static List<Rental> OrderByDueDate(List<Rental> l)
        {
            return l.OrderBy(r => r.DueReturnDate).Reverse().ToList();
        }

        public sealed override void InitializeDefaultData()
        {
            Data.Add(new Rental { User = "srgv61@gmail.com", Toy = "1", StartDate = new DateTime(1970, 01, 01), DueReturnDate = new DateTime(1970, 01, 15) });
            Data.Add(new Rental { User = "srgv61@gmail.com", Toy = "2", StartDate = new DateTime(2001, 09, 11), DueReturnDate = new DateTime(2001, 09, 25) });
            Data.Add(new Rental { User = "srgv61@gmail.com", Toy = "3", StartDate = new DateTime(2015, 11, 11), DueReturnDate = new DateTime(2015, 11, 27) });
            Data.Add(new Rental { User = "srgv61@gmail.com", Toy = "5", StartDate = new DateTime(2016, 12, 01), DueReturnDate = new DateTime(2016, 02, 02) });
            Data.Add(new Rental { User = "srgv61@gmail.com", Toy = "6", StartDate = new DateTime(2016, 10, 12), DueReturnDate = new DateTime(2017, 01, 01) });
            Data.Add(new Rental { User = "srgv61@gmail.com", Toy = "8", StartDate = new DateTime(2016, 10, 12), DueReturnDate = new DateTime(2017, 01, 01) });
        }
        

        public List<Rental> GetRentalsByUser(string uid)
        {
            return Data.FindAll(r => r.User == uid);
        }

        public List<Rental> GetAllActive()
        {
            return Data.FindAll(Rental.IsActive);
        }

        public void AddNewRental(string userId, Toy toy, int weeks)
        {
            Data.Add(new Rental() { User = userId, Toy = toy.Id, StartDate = DateTime.Now, DueReturnDate = DateTime.Now.AddDays(weeks*7)});
            Db.SaveData(Data);
        }
    }
}