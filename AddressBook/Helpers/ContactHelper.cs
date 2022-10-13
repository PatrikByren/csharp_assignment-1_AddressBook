using AddressBook.Models;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Helpers
{
    internal interface IContactHelper // Ett interface är skapas, dvs ett "kontrakt" av vad denna class måste innehålla.
    {
        public void Create(Contact contact); //Jag vill ta emot en Kontakt av typen kontakt
        public void Remove(int id); //För att ta bort en kontakt så måste ett int ID anges
        public IEnumerable<Contact> GetAll(); //Skickar ut en lista av IEunerble typ, dvs endast läsbar lista
        public Contact GetDetails(int id); //För att se detaljerad vy av en kontakt måste ett ID anges, sedan skickar jag tillbaka en kontakt.
        public void Update(int id, string optionsNumber); //För att uppdatera en kontakt anges Id, optionsNumber(vad som ska ändras)
        public void ReadFile(); //Vid programm start vill jag se om det finns en kontaktbok att hämta.
    }
    internal class ContactHelper : IContactHelper //Jag kodar upp mitt interface
    {
        IFileHelper fileHelper = new FileHelper(); //Instancerar min FileHelper.
        private List<Contact>? _contacts; //Min lista
        public void Create(Contact contact)
        {

            _contacts!.Add(contact); //Kontakten jag tar emot Adderar jag till listan
            _contacts = _contacts.OrderBy(x => x.Id).ToList(); //Jag sorterar listan på ID nummer, för att när jag sätter ID numret så är min kod byggd att den måste sorteras för att inte riskera att få samma ID nummer som en tidigare kontakt.
            fileHelper.Save(_contacts); //Jag sparar min kontakt till fil
            Console.Write("\nContact Succesfully created! :) :)"); //Har systemet inte kraschat så har kontakten sparas
            Console.ReadKey();// jag saktar ner och låter användaren se det
        }
        
        public IEnumerable<Contact> GetAll()
        {
            return _contacts; //Kallar man på denna metod så får man tillbaka en Läsbar lista! 
        }

        public Contact GetDetails(int id)
        {
            return _contacts.FirstOrDefault(x => x.Id == id); //Använder mig av lamba uttryck för att skicka tillbaka en detaljerad kontakt.
        }
        public void Remove(int id)
        {
            Console.Write("Wrong ID"); //Denna har jag "fuskat" in, kommer endast att hinna visas om det inte finns en kontakt med korrekt ID-nummer.
            foreach (var item in _contacts) //Letar i min lista 
            {
                if (item.Id == id)//Tittar om det finns ett matchande ID nummer i min lista
                {
                    Console.Clear();//Rensar bort tidigare text för att få bort "Wrong ID"
                    _contacts = _contacts.Where(x => x.Id != id).ToList(); //Med ett lamba uttryck tar jag bort kontakten från min lista 
                    Console.Write($"Contact \"{item.FullName}\" Removed"); //Meddelar vilken kontakt som har tagits bort
                    fileHelper.Save(_contacts); //Listan sparas
                    Console.WriteLine("\nContact Succesfully Removed! :) :)"); //Meddelar ovan
                    break;
            }
        }
            Console.ReadKey(); //Saktar ner för att visa ovan meddelande
        }

        public void Update(int id, string optionsNumber) 
        {
            switch (optionsNumber) //Switchsats för att se vad användaren vill uppdatera
            {
                case "1":
                    foreach (var item in _contacts) 
                    {
                        if (id == item.Id) // Hittar korrekt kontakt
                        {
                            Console.Write("First name: ");
                            item.FirstName = Console.ReadLine() ?? null!; //uppdaterar efter användarens val
                            fileHelper.Save(_contacts); //Sparar uppdateringen
                            Console.Write("\nContact succesfully Uppdated! :) :)"); //Meddelar användaren
                            Console.ReadKey();//Saktar ner
                        }
                    }
                    break;
                case "2":
                    foreach (var item in _contacts)
                    {
                        if (id == item.Id)
                        {
                            Console.Write("Last name: ");
                            item.LastName = Console.ReadLine() ?? null!;
                            fileHelper.Save(_contacts);
                            Console.Write("\nContact succesfully Uppdated! :) :)");
                            Console.ReadKey();
                        }
                    }
                    break;
                case "3":
                    foreach (var item in _contacts)
                    {
                        if (id == item.Id)
                        {
                            Console.Write("Phone number: ");
                            item.PhoneNumber = Console.ReadLine() ?? null!;
                            fileHelper.Save(_contacts);
                            Console.Write("\nContact succesfully Uppdated! :) :)");
                            Console.ReadKey();
                        }
                    }
                    break;
                case "4":
                    foreach (var item in _contacts)
                    {
                        if (id == item.Id)
                        {
                            Console.Write("Email: ");
                            item.Email = Console.ReadLine() ?? null!;
                            fileHelper.Save(_contacts);
                            Console.Write("\nContact succesfully Uppdated! :) :)");
                            Console.ReadKey();
                        }
                    }
                    break;
                case "5":
                    foreach (var item in _contacts)
                    {
                        if (id == item.Id)
                        {
                            Console.Write("Street address: ");
                            item.SteetAddress = Console.ReadLine() ?? null!;
                            fileHelper.Save(_contacts);
                            Console.Write("\nContact succesfully Uppdated! :) :)");
                            Console.ReadKey();
                        }
                    }
                    break;
                case "6":
                    foreach (var item in _contacts)
                    {
                        if (id == item.Id)
                        {
                            Console.Write("PostalCode: ");
                            item.PostalCode = Console.ReadLine() ?? null!;
                            fileHelper.Save(_contacts);
                            Console.Write("\nContact succesfully Uppdated! :) :)");
                            Console.ReadKey();
                        }
                    }
                    break;
                case "7":
                    foreach (var item in _contacts)
                    {
                        if (id == item.Id)
                        {
                            Console.Write("City: ");
                            item.City = Console.ReadLine() ?? null!;
                            fileHelper.Save(_contacts);
                            Console.Write("\nContact succesfully Uppdated! :) :)");
                            Console.ReadKey();
                        }
                    }
                    break;
                default:
                    Console.Write("Wrong option, going back to main menu");
                    Console.ReadKey();
                    break;
            }
        }
        public void ReadFile()
        {
           _contacts = fileHelper.Read(); //Hämtar listan från fil och lägger in listan i applikationen
            if (_contacts == null)
            {
                _contacts = new List<Contact>(); //Gör en ny tom lista om det inte finns en lista sparad
            }
        }

    }
}
