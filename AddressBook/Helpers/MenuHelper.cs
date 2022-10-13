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
    internal interface IMenuHelper //Med ett interface tar jag hjälp av vad som ska göras i Menyn som ska instansieras från andra classer
    {
        public void RunProgram(); //Behöver endast 1 metod i Interfacet, då resten är 'privata'
    }
    internal class MenuHelper : IMenuHelper
    {
        IContactHelper contactHelper = new ContactHelper(); //Instansierar klassen icontacthelper
        IFileHelper fileHelper = new FileHelper(); //Samt ifilehelper
        private void MainMenu() //Main menu där du har val, samt kallar på andra metoder efter val
        {
            do //Loopar här ifrån
            {
                Console.Clear();
                Console.WriteLine("----- MAIN MENU -----");
                Console.WriteLine("#1. Show all Contacts");
                Console.WriteLine("#2. Add a Contact");
                Console.WriteLine("#3. Remove a Contact");
                Console.WriteLine("#4. Settings");
                Console.WriteLine("#Q. Close Address Book");
                Console.Write("\nChoose an Option: ");
                switch (Console.ReadLine()?.ToLower()) //Läser in valet till gemen
                {
                    case "1":
                        ShowAllContactMenu(); //kör metoder
                        break;
                    case "2":
                        CreateContactMenu(); //kör metoden
                        break;
                    case "3":
                        try
                        {
                            Console.Write("Enter ID to remove contact: ");
                            contactHelper.Remove(int.Parse(Console.ReadLine() ?? "")); //kör metoden om ett nummer har lagts in
                        }
                        catch
                        {
                            Console.Write("Wrong Key!"); // annars meddelar jag att det är fel kanpptryck
                            Console.ReadKey();
                        }
                        break;
                    case "4":
                        Console.Write("Enter the new file path and Enter OR just press Enter to exit to main menu...\nNew file path and/or Enter:");
                        fileHelper.NewFilePath(Console.ReadLine() ?? null!); //Kallar på metoden och skickar med det som har skrivits, Null värde är OK.
                        
                        break;
                    case "q":
                        Environment.Exit(0); //Avslutar programmet
                        break;
                    default:
                        ErrorText(); //Kallar på metoden
                        break;
                }
            } while (true); //Sant som gör det till en evighetsloop
        }
        private void ShowAllContactMenu()
        {
            Console.Clear();
            Console.WriteLine("----- CONTACT MENU -----");
            Console.WriteLine("ID:\tName:");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (var item in contactHelper.GetAll()) //Kallar på metoden för att hämta lista
            {
                Console.WriteLine($"{item.Id}\t{item.FullName}"); //Visar alla ID och hela namn i listan.
            }
            Console.WriteLine("\n--------------------------------------------------------------------");
            Console.Write("\nEnter a contact ID to see details: ");
            try
            {
                int idOption = int.Parse(Console.ReadLine() ?? "");
                Contact contact = contactHelper.GetDetails(idOption); //Hämtar en kontakt med hjälp av metoden.
                Console.Clear();
                Console.WriteLine("----- CONTACT MENU -----\n");
                Console.WriteLine($"{contact.FullName}\t\nPhone number: {contact.PhoneNumber}\nEmail: " +
                    $"{contact.Email}\n\nAdress: \n{contact.PostAddress}"); //Visar hela den kontakten
                Console.WriteLine("\n--------------------------------------------------------------------");
                Console.Write("\n#1. Exit to menu\n#2. Change details\n#D. Delete contact\n\nOption: ");
                switch (Console.ReadLine()?.ToLower()) 
                {
                    case "1":
                        MainMenu();//kör metoden
                        break;
                    case "2":
                        UpdateContactMenu(idOption); //kör metoden och tar med idOption(alltså id'et på kontakten)
                        break;
                    case "d":
                        contactHelper.Remove(idOption); //kör metoden och tar med idOption(alltså id'et på kontakten)
                        break;
                    default:
                        ErrorText(); //kör metoden
                        break;
                }
            }
            catch
            {
                ErrorText();
            }


        }
        private void CreateContactMenu() //Skapar ny kontakt i menyn(ej till lista)
        {
            Contact contact = new Contact(); //Gör en tom kontakt
            int id = 0;
            int contactId=0;
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
            contact.Id = id; //Sätter ID'et med koden ovan, kommer bli 1, 2, 3, 4 osv tar man bort kontakt kommer nästa kontakt få ärva dens nummer
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
            contactHelper.Create(contact);//skickar kontakten jag har skapat med infon ovan till metoden.
        }

        private void UpdateContactMenu(int id)
        {
            Console.Write("What do you want to change? \n#1. First name\n#2. Last name\n#3. Phone number\n#4. Email\n#5. Street address\n#6. Postal code\n#7. City\nOption: ");

            contactHelper.Update(id, Console.ReadLine() ?? null!); 
           
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
