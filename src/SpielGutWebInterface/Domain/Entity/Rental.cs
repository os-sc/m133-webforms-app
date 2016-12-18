using System;
using SpielGutWebInterface.Domain.Interface;

namespace SpielGutWebInterface.Domain.Entity
{
    public class Rental : IManagable
    {
        public string Id { get; set; }
        public string User { get; set; }
        public string Toy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueReturnDate { get; set; }

        public Rental()
        {
            if (string.IsNullOrWhiteSpace(Id))
                Id = Guid.NewGuid().ToString();
        }

        public static bool IsActive(Rental r)
        {
            return (DateTime.Now < r.DueReturnDate);
        }
    }
}