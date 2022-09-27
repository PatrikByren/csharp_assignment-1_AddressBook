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
            using var sw = new StreamWriter(_filePath);
            sw.WriteLine(JsonConvert.SerializeObject(list));
        }
        public List<Contact> Read()
        {
            try
            {

                using var sr = new StreamReader(_filePath);
                Console.Write("Addressbook uploading...");
                Console.ReadKey();
                return JsonConvert.DeserializeObject<List<Contact>>(sr.ReadToEnd());

            }
            catch { Console.Write("No adressbook to upload, Create a new addressbook"); Console.ReadKey(); }
            return null!;
        }

        
    }
}