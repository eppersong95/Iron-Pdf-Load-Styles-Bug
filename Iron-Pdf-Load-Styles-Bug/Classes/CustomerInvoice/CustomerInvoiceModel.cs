using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronPdfConsoleApp.Classes.CustomerInvoice
{
    public class CustomerInvoiceModel
    {
        public IEnumerable<ShipmentItemModel> Items { get; set; }
        public IEnumerable<ShipmentIdentifierModel> Identifiers { get; set; }
        public IEnumerable<ShipmentChargeModel> Charges { get; set; }
        public AddressModel BillToAddress { get; set; }
        public AddressModel OriginAddress { get; set; }
        public AddressModel DestinationAddress { get; set; }
        public decimal InvoiceTotal { get; set; }
        public string InvoiceTotalFormatted => InvoiceTotal.ToString("C");
        public DateTime InvoiceDate { get; set; }
        public string InvoiceDateFormatted => InvoiceDate.ToString("M/d/yyyy");
        public string InvoiceNumber { get; set; }
        public DateTime PickupDate { get; set; }
        public string PickupDateFormatted => PickupDate.ToString("M/d/yyyy");
        public DateTime DeliveryDate { get; set; }
        public string DeliveryDateFormatted => DeliveryDate.ToString("M/d/yyyy");
        public string CarrierCode { get; set; }
        public string CarrierName { get; set; }
        public string CarrierFormatted => $"{CarrierName} ({CarrierCode})";
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public string SalesGroupLogoUrl { get; set; }
        public string SalesGroupName { get; set; }

        public string CustomerFormatted => $"{CustomerName} ({CustomerNumber})";
        public DateTime DueDate { get; set; }
        public string DueDateFormatted => DueDate.ToString("M/d/yyyy");
        public bool ShowCharges { get; set; }
        public string PaymentTermsFormatted { get; set; }
        public bool IsPrepay => false;

        public decimal AgingCurrent { get; set; }
        public string AgingCurrentFormatted => AgingCurrent.ToString("C2");

        public decimal Aging1To30 { get; set; }
        public string Aging1To30Formatted => Aging1To30.ToString("C2");

        public decimal Aging31To60 { get; set; }
        public string Aging31To60Formatted => Aging31To60.ToString("C2");

        public decimal Aging61To90 { get; set; }
        public string Aging61To90Formatted => Aging61To90.ToString("C2");

        public decimal Aging90Plus { get; set; }
        public string Aging90PlusFormatted => Aging90Plus.ToString("C2");

        public decimal CustomerBalance { get; set; }
        public string CustomerBalanceFormatted => CustomerBalance.ToString("C2");
        public string DefaultSpecialInstructions { get; set; }
        public string OriginNote { get; set; }
        public string DestinationNote { get; set; }
        public string ShipmentAccessorialsFormatted { get; set; }
        public bool IsStackable { get; set; }

        public string SpecialInstructions { get; set; }

        public string Memo { get; set; }
    }
}
