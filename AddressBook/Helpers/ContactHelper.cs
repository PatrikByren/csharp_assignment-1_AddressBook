using AddressBook.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Helpers
{
    internal interface IContactHelper
    {
        public void Create(Contact contact); //Jag vill ta emot en Kontakt av typen kontakt
        public void Remove(int id); //För att ta bort en kontakt så måste ett int ID anges
        public IEnumerable<Contact> GetAll();
        public Contact GetDetails(int id);
        public void Update(int id, string optionsNumber, string newValue);
    }
    internal class ContactHelper : IContactHelper
    {
        private List<Contact> _contacts = new List<Contact>();
        public void Create(Contact contact)
        {
            _contacts.Add(contact);
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact GetDetails(int id)
        {
            return _contacts.FirstOrDefault(x => x.Id == id);
        }
        public void Remove(int id)
        {
            foreach (var item in _contacts)
            {
                if (item.Id == id)
                {
                    _contacts = _contacts.Where(x => x.Id != id).ToList();
                    Console.Write("Contact Removed");
                    Console.ReadKey();
                    break;
                }
            }
        }

        public void Update(int id, string optionsNumber, string newValue)
        {

            switch (optionsNumber)
            {
                case "1":
                    foreach (var item in _contacts)
                    {
                        if (id == item.Id)
                        {
                            item.FirstName = newValue;
                        }
                    }
                    break;
                case "2":
                    foreach (var item in _contacts)
                    {
                        if (id == item.Id)
                        {
                            item.LastName = newValue;
                        }
                    }
                    break;
                case "3":
                    foreach (var item in _contacts)
                    {
                        if (id == item.Id)
                        {
                            item.PhoneNumber = newValue;
                        }
                    }
                    break; 
                case "4":
                    foreach (var item in _contacts)
                    {
                        if (id == item.Id)
                        {
                            item.Email = newValue;
                        }
                    }
                    break;
                case "5":
                    foreach (var item in _contacts)
                    {
                        if (id == item.Id)
                        {
                            item.SteetAddress = newValue;
                        }
                    }
                    break;
                case "6":
                    foreach (var item in _contacts)
                    {
                        if (id == item.Id)
                        {
                            item.PostalCode = newValue;
                        }
                    }
                    break;
                case "7":
                    foreach (var item in _contacts)
                    {
                        if (id == item.Id)
                        {
                            item.City = newValue;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
