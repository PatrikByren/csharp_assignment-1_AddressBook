using AddressBook.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Helpers
{
    internal interface IFileHelper
    {
        public List<Contact> Read();
        public void Save(List<Contact> list);
        public void NewFilePath(string NewFilePath);
    }
    internal class FileHelper : IFileHelper
    {
        private string _filePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\AddressBook.json"; //Standard sök och sparväg för filen
        public void NewFilePath(string NewFilePath) //hämtar in en ny sökväg till filen
        {
            if (NewFilePath == null!) { } //Om sökvägen är tom, vill jag inte spara den
            else { _filePath = NewFilePath; } //Finns det text så sparar jag 
        }
        public void Save(List<Contact> list) //Hämtar lista
        {
            try //Försöker att =
            {
                using var sw = new StreamWriter(_filePath); //Spara med sökvägen
                sw.WriteLine(JsonConvert.SerializeObject(list)); //Konverterar och sparar den som ett Json objekt.
            }
            catch { Console.WriteLine("Unable to save! Check File Path!"); Console.ReadKey(); } //Lyckas jag inte spara den meddelar jag användaren det
        }
        public List<Contact> Read()
        {
            Console.WriteLine($"Looking for addressbook in {_filePath} ... ");
            try
            {

                using var sr = new StreamReader(_filePath); // Letar efter en sparad fil
                Console.Write("Addressbook found... Press a Key!"); //meddelar att app hittat filen
                Console.ReadKey();
                return JsonConvert.DeserializeObject<List<Contact>>(sr.ReadToEnd()); //retunerar filen

            }
            catch { Console.Write("No adressbook found, Create a new addressbook... Press a Key!"); Console.ReadKey(); } //Meddelar användaren att app inte kan hitta filen
            return null!;
        }

        
    }
}