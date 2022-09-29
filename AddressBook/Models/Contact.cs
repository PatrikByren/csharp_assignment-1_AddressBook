using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    internal class Contact //Här skapar jag det jag anser en kontakt är
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public string SteetAddress { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string City { get; set; } = "";
        public string FullName => $"{FirstName} {LastName}"; //Slår ihop 2 properties för att underlätta hämtningen
        public string PostAddress => $"{SteetAddress}\n{PostalCode}\n{City}"; //Slår ihop 3 properties för att underlätta hämtningen



    }
}
