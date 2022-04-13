using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronPdfConsoleApp.Classes.CustomerInvoice
{
    public class AddressModel
    {
        public string Name { get; set; }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public string PhoneNumberFormatted { get; set; }
    }
}
