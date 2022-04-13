using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronPdfConsoleApp.Classes.CustomerInvoice
{
    public class ShipmentChargeModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }

        public string RateFormatted => Rate.ToString("C");
        public string TotalFormatted => Total.ToString("C");
    }
}
