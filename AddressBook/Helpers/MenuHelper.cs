﻿using AddressBook.Models;
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
        public void ShowAllContactMenu();
        public void CreateContactMenu();
        public void UpdateContactMenu(int id);
        public void ErrorText();
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
                switch (Console.ReadLine()?.ToLower())
                {
                    case "1":
                        ShowAllContactMenu();
                        break;
                    case "2":
                        CreateContactMenu();
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
                    default: ErrorText();
                        break;
                }
            }while(true);
        }
        public void ShowAllContactMenu()
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
                Contact contact = contactHelper.GetDetails(idOption);
                Console.Clear();
                Console.WriteLine($"{contact.FullName}\t\nPhone number: {contact.PhoneNumber}\nEmail: {contact.Email}\n\nAdress: \n{contact.PostAddress}");
                Console.WriteLine("\n--------------------------------------------------------------------");
                Console.Write("\nEXIT  to  menu: \"E\"\nCHANGE details: \"C\"\nDELETE contact: \"D\"\n\nChoose an option: ");
                switch (Console.ReadLine()?.ToLower())
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
                        ErrorText();
                        break;
                }
            }
            catch
            {
            ErrorText();
            }

 
        }
        public void CreateContactMenu()
        {
            Contact contact = new Contact();
            int id = 0;
            int contactId=0;
                foreach (var item in contactHelper.GetAll())
            {
                contactId=item.Id;
                id++;
            if (contactId != id) { }
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
            Console.Write("Contact Added...");
            Console.ReadKey();
            contactHelper.Create(contact);
        }

        public void UpdateContactMenu(int id)
        {
            Console.WriteLine("What do you want to change? \n#1. First name\n#2. Last name\n#3. Phone number\n#4. Email\n#5. Street address\n#6. Postal code\n#7. City");
            string optionsNumber = Console.ReadLine();
            string? newValue;
            switch (optionsNumber)
            {
                case "1":
                    Console.Write("First name: ");
                    newValue = Console.ReadLine();
                    contactHelper.Update(id, optionsNumber, newValue);
                    break;
                case "2":
                    Console.Write("Last name: ");
                    newValue = Console.ReadLine();
                    contactHelper.Update(id, optionsNumber, newValue);
                    break;
                case "3":
                    Console.Write("Phone number: ");
                    newValue = Console.ReadLine();
                    contactHelper.Update(id, optionsNumber, newValue);
                    break;
                case "4":
                    Console.Write("Email: ");
                    newValue = Console.ReadLine();
                    contactHelper.Update(id, optionsNumber, newValue);
                    break;
                case "5":
                    Console.Write("Street address: ");
                    newValue = Console.ReadLine();
                    contactHelper.Update(id, optionsNumber, newValue);
                    break;
                case "6":
                    Console.Write("Postal Code: ");
                    newValue = Console.ReadLine();
                    contactHelper.Update(id, optionsNumber, newValue);
                    break;
                case "7":
                    Console.Write("City: ");
                    newValue = Console.ReadLine();
                    contactHelper.Update(id, optionsNumber, newValue);
                    break;
                default:
                    ErrorText();
                    break;
            }    
        }
        public void ErrorText()
        {
            Console.Write("\nInvalid option!\nGoing back to main menu...");
            Console.ReadKey();
        }

    }

}
