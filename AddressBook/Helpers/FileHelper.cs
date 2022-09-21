using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Helpers
{
    internal interface IFileHelper
    {
        public void Read();
        public void Save();
    }
    internal class FileHelper : IFileHelper
    {
        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}