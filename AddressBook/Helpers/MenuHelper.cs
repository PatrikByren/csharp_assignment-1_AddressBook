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

        public void RunProgram();
    }
    internal class MenuHelper : IMenuHelper
    {
        IContactHelper contactHelper = new ContactHelper();
        IFileHelper fileHelper = new FileHelper();
        private void MainMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("----- MAIN MENU -----");
                Console.WriteLine("#1. Show all Contacts");
                Console.WriteLine("#2. Add a Contact");
                Console.WriteLine("#3. Remove a Contact");
                Console.WriteLine("#4. Settings");
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
                            Console.Write("Enter ID to remove contact: ");
                            contactHelper.Remove(int.Parse(Console.ReadLine() ?? ""));
                        }
                        catch
                        {
                            Console.Write("Wrong Key!");
                            Console.ReadKey();
                        }
                        break;
                    case "4":
                        Console.Write("Enter the new file path and OR just press Enter to exit to main menu...\nNew file path / Enter:");
                        fileHelper.NewFilePath(Console.ReadLine() ?? null!);
                        
                        break;
                    case "q":
                        Environment.Exit(0);
                        break;
                    default:
                        ErrorText();
                        break;
                }
            } while (true);
        }
        private void ShowAllContactMenu()
        {
            Console.Clear();
            Console.WriteLine("----- CONTACT MENU -----");
            Console.WriteLine("ID:\tName:");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (var item in contactHelper.GetAll())
            {
                Console.WriteLine($"{item.Id}\t{item.FullName}");
            }
            Console.WriteLine("\n--------------------------------------------------------------------");
            Console.Write("\nEnter a contact ID to see details: ");
            try
            {
                int idOption = int.Parse(Console.ReadLine() ?? "");
                Contact contact = contactHelper.GetDetails(idOption);
                Console.Clear();
                Console.WriteLine("----- CONTACT MENU -----\n");
                Console.WriteLine($"{contact.FullName}\t\nPhone number: {contact.PhoneNumber}\nEmail: {contact.Email}\n\nAdress: \n{contact.PostAddress}");
                Console.WriteLine("\n--------------------------------------------------------------------");
                Console.Write("\nExit  to  MENU: \"M\"\nDetails CHANGE: \"C\"\nContact DELETE: \"D\"\n\nChoose an option: ");
                switch (Console.ReadLine()?.ToLower())
                {
                    case "m":
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
        private void CreateContactMenu()
        {
            Contact contact = new Contact();
            int id = 0;
            int contactId = 0;
            foreach (var item in contactHelper.GetAll())
            {
                contactId = item.Id;
                id++;
                if (contactId != id) { break; }
            }
            if (contactId == id)
            {
                id++;
            }

            contact.Id = id;
            Console.Write("First name: ");
            contact.FirstName = Console.ReadLine() ?? "";
            Console.Write("Last name: ");
            contact.LastName = Console.ReadLine() ?? "";
            Console.Write("Phone Number: ");
            contact.PhoneNumber = Console.ReadLine() ?? "";
            Console.Write("Email: ");
            contact.Email = Console.ReadLine() ?? "";
            Console.Write("Street name: ");
            contact.SteetAddress = Console.ReadLine() ?? "";
            Console.Write("Postal Code: ");
            contact.PostalCode = Console.ReadLine() ?? "";
            Console.Write("City: ");
            contact.City = Console.ReadLine() ?? "";
            contactHelper.Create(contact);
        }

        private void UpdateContactMenu(int id)
        {
            Console.Write("What do you want to change? \n#1. First name\n#2. Last name\n#3. Phone number\n#4. Email\n#5. Street address\n#6. Postal code\n#7. City\nOption?");
            string optionsNumber = Console.ReadLine() ??"";
            string? newValue;
            switch (optionsNumber)
            {
                case "1":
                    Console.Write("First name: ");
                    newValue = Console.ReadLine();
                    contactHelper.Update(id, optionsNumber, newValue ??"");
                    break;
                case "2":
                    Console.Write("Last name: ");
                    newValue = Console.ReadLine();
                    contactHelper.Update(id, optionsNumber, newValue??"");
                    break;
                case "3":
                    Console.Write("Phone number: ");
                    newValue = Console.ReadLine();
                    contactHelper.Update(id, optionsNumber, newValue??"");
                    break;
                case "4":
                    Console.Write("Email: ");
                    newValue = Console.ReadLine();
                    contactHelper.Update(id, optionsNumber, newValue??"");
                    break;
                case "5":
                    Console.Write("Street address: ");
                    newValue = Console.ReadLine();
                    contactHelper.Update(id, optionsNumber, newValue??"");
                    break;
                case "6":
                    Console.Write("Postal Code: ");
                    newValue = Console.ReadLine();
                    contactHelper.Update(id, optionsNumber, newValue??"");
                    break;
                case "7":
                    Console.Write("City: ");
                    newValue = Console.ReadLine();
                    contactHelper.Update(id, optionsNumber, newValue??"");
                    break;
                default:
                    ErrorText();
                    break;
            }
        }
        private void ErrorText()
        {
            Console.Write("\nInvalid option!\nGoing back to main menu...");
            Console.ReadKey();
        }
        public void RunProgram()
        {
            contactHelper.ReadFile();
            MainMenu();
        }
    }
}
