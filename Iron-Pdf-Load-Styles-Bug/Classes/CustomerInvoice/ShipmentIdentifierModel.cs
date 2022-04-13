using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronPdfConsoleApp.Classes.CustomerInvoice
{
    public class ShipmentIdentifierModel
    {
        public string Value { get; set; }
        public string CustomTypeName { get; set; }
        public string TypeHumanized => CustomTypeName;
    }
}
