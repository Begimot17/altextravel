using AltexTravel.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models.Flights.Booking
{
    public class Passenger
    {
        public DateTime DateOfBirth { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string TravelDocumentNumber { get; set; }
        public Gender Gender { get; set; }
        public PassengerType PassengerType { get; set; }
        public Title Title { get; set; }
    }
}
