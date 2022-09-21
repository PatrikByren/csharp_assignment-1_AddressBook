using AddressBook.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Helpers
{
    internal interface IMenuHelper
    {
        public void MainMenu();
        public void AllContactMenu();
        public void AddContactMenu();
        public void UpdateContactMenu(int id);
    }
    internal class MenuHelper : IMenuHelper
    {
        IContactHelper contactHelper = new ContactHelper();
        public void MainMenu()
        { do
            {
                Console.Clear();
                Console.WriteLine("----- MAIN MENU -----");
                Console.WriteLine("#1. Show all Contacts");
                Console.WriteLine("#2. Add a Contact");
                Console.WriteLine("#3. Remove a Contact");
                Console.WriteLine("#4. Find a Contact");
                Console.WriteLine("#Q. Close Address Book");
                Console.Write("\nChoose an Option: ");
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        AllContactMenu();
                        break;
                    case "2":
                        AddContactMenu();
                        break;
                    case "3":
                        try
                        {
                            Console.Write("ID: ");
                            contactHelper.Remove(int.Parse(Console.ReadLine()));
                        }
                        catch 
                        {
                            Console.Write("Wrong Key!");
                            Console.ReadKey();
                        }
                        break;
                    case "4":
                        break;
                    case "q":
                        Environment.Exit(0);
                        break;
                    default: 
                        break;
                }
            }while(true);
        }
        public void AllContactMenu()
        {
            Console.Clear();
            Console.WriteLine("----- ALL CONTACT MENU -----");
            Console.WriteLine("Name:\t\t\t\t\tID:");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (var item in contactHelper.GetAll())
            {
                Console.WriteLine($"{item.FullName}\t\t\t\t{item.Id}");
            }
            Console.WriteLine("\n--------------------------------------------------------------------");
            Console.Write("\nEnter a contact ID to see details: ");
            try
            {
                int idOption = int.Parse(Console.ReadLine());
                Console.Clear();
                Contact contact = contactHelper.GetDetails(idOption);
                Console.WriteLine($"{contact.FullName}\t\nPhone number: {contact.PhoneNumber}\nEmail: {contact.Email}\n\nAdress: \n{contact.PostAddress}");
                Console.WriteLine("\n--------------------------------------------------------------------");
                Console.Write("\nMain menu: \"E\"\nChange details: \"C\"\nDelete Contact: \"D\"\n\nChoose an option: ");
                switch (Console.ReadLine().ToLower())
                {
                    case "e":
                        MainMenu();
                        break;
                    case "c":
                        UpdateContactMenu(idOption);
                        break;
                    case "d":
                        contactHelper.Remove(idOption);
                        break;
                    default:
                        Console.WriteLine("Wrong option!");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Wrong option!");
            }

 
        }
        public void AddContactMenu()
        {
            Contact contact = new Contact();
            int id = 0;
            int contactId=0;
                foreach (var item in contactHelper.GetAll())
            {
                contactId=item.Id;
                id++;
            if (contactId != id) { break; }
            }
            if ( contactId == id)
                {
                    id++;
                }
            
            contact.Id = id;
            contact.FirstName = "Patrik";
            contact.LastName = "Byren";
            contact.PhoneNumber = "0739448454";
            contact.Email = "patrik.byren@hotmail.com";
            contact.SteetAddress = "Päronvägen 9";
            contact.PostalCode = "74633";
            contact.City = "Håbo";
            //Console.Write("First name: ");
            //Console.Write("Last name: ");
            //Console.Write("Phone Number: ");
            //Console.Write("Email: ");
            //Console.Write("Street name: ");
            //Console.Write("Postal Code: ");
            //Console.WriteLine("City: ");
            Console.Write("Contact Added, press ANY key to return");
            Console.ReadKey();
            contactHelper.Create(contact);
        }

        public void UpdateContactMenu(int id)
        {
            string newValue=null!;
            string optionsNumber;
            Console.Write("What do you want to change? \n#1. First name\n#2. Last name\n#3. Phone number\n#4. Email\n#5. Street name\n#6. Postal code\n#7. City");
            optionsNumber = Console.ReadLine();
            Console.Write("Update to: ");
            newValue = Console.ReadLine();
            contactHelper.Update(id, optionsNumber, newValue);
        }

    }

}
