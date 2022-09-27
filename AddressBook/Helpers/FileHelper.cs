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
        private string _filePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\AddressBook.json";
        public void NewFilePath(string NewFilePath)
        {
            if (NewFilePath == null!) { }
            else { _filePath = NewFilePath; }
        }
        public void Save(List<Contact> list)
        {
            try
            {
                using var sw = new StreamWriter(_filePath);
                sw.WriteLine(JsonConvert.SerializeObject(list));
            }
            catch { Console.WriteLine("Unable to save! Check File Path!"); Console.ReadKey(); }
        }
        public List<Contact> Read()
        {
            Console.WriteLine($"Looking for addressbook in {_filePath} ... ");
            try
            {

                using var sr = new StreamReader(_filePath);
                Console.Write("Addressbook found... Press a Key!");
                Console.ReadKey();
                return JsonConvert.DeserializeObject<List<Contact>>(sr.ReadToEnd());

            }
            catch { Console.Write("No adressbook to found, Create a new addressbook... Press a Key!"); Console.ReadKey(); }
            return null!;
        }

        
    }
}