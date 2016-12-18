using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.Serialization;
using SpielGutWebInterface.Domain.Entity;
using SpielGutWebInterface.Domain.Interface;

namespace SpielGutWebInterface.Domain.Manager
{
    [DataContract]
    public class ToyManager : Manager<Toy>
    {
        [DataMember]
        protected sealed override List<Toy> Data { get; set; }
        protected sealed override XmlDatabase<Toy> Db { get; set; }

        public ToyManager(string dbpath)
        {
            Data = new List<Toy>();
            Db = new XmlDatabase<Toy>(dbpath);
            Data = Db.LoadData();

            if (!IsEmpty()) return;
            InitializeDefaultData();
            Db.SaveData(Data);
        }

        public override Toy GetById(string id)
        {
            return Data.FirstOrDefault(toy => toy.Id == id);
        }

        public Toy FindByNamePart(string np)
        {
            return Data.FirstOrDefault(toy => toy.Name.Contains(np));
        }

        public sealed override void InitializeDefaultData()
        {
            Data.Add(new Toy { Id = "1", Manufacturer = "Playmobil", Name = "Hazmat disposal crew" });
            Data.Add(new Toy { Id = "2", Manufacturer = "Yahoo!", Name = "MD5 Hashed Password Guessing Game" });
            Data.Add(new Toy { Id = "3", Manufacturer = "Hasbro", Name = "Monopoly (2008 Financial Crisis Edition)" });
            Data.Add(new Toy { Id = "4", Manufacturer = "IBM", Name = "704 Fortran Manual" });
            Data.Add(new Toy { Id = "5", Manufacturer = "Chamber of Malice", Name = "Crime City Slam" });
            Data.Add(new Toy { Id = "6", Manufacturer = "Tumblr", Name = "Gender/Pronouns Matching Game (Special Snowflake Edition)" });
            Data.Add(new Toy { Id = "7", Manufacturer = "Gentoo", Name = "Kernel Compilation Game (Extended Compilerflag Edition)" });
            Data.Add(new Toy { Id = "8", Manufacturer = "Dice", Name = "Bielefeld 1" });
        }

        public List<Toy> GetAll()
        {
            return Data;
        }

        public Toy GetByName(string name)
        {
            return Data.FirstOrDefault(t => t.Name == name);
        }
    }
}
