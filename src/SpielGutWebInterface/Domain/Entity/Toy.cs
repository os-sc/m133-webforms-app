using System;
using SpielGutWebInterface.Domain.Interface;
using WebGrease;

namespace SpielGutWebInterface.Domain.Entity
{
    public class Toy : IManagable
    {
        public Toy()
        {
            if (string.IsNullOrWhiteSpace(Id))
                Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }

    }
}