using System;

namespace DAL.Models
{
    public class ClientInformation
    {
        public Guid ClientInformationID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IDNumber { get; set; }
        public string Cell { get; set; }
        public string TelHome { get; set; }
        public string TelWork { get; set; }
        public string Email { get; set; }
        public string StreetNameAndNumber { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
